using System;
using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.Extensions.Logging;
using FitnessApp.NatsServiceBus;
using FitnessApp.Serializer.JsonSerializer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using FitnessApp.ProfileApi.Services.MessageBus;
using FitnessApp.Serializer.JsonMapper;
using FitnessApp.Abstractions.Db.Configuration;
using FitnessApp.Abstractions.Services.Configuration;
using FitnessApp.ProfileApi.Models.Output;
using FitnessApp.ProfileApi.Data.Entities;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Data;
using FitnessApp.ProfileApi.Services.UserProfile;
using FitnessApp.Abstractions.Services.Cache;

namespace FitnessApp.ProfileApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options =>
            {
                options.EnableEndpointRouting = false;
            });

            services.AddTransient<IJsonSerializer, JsonSerializer>();

            services.AddTransient<IJsonMapper, JsonMapper>();

            services.Configure<MongoDbSettings>(Configuration.GetSection("MongoConnection"));

            services.Configure<NatsBusSettings>(Configuration.GetSection("Nats"));

            services.Configure<CacheSettings>(Configuration.GetSection("Cache"));

            services.AddTransient<ICacheService<UserProfileModel>, CacheService<UserProfileModel>>();

            services.AddTransient<IUserProfileRepository<UserProfile, UserProfileModel, CreateUserProfileModel, UpdateUserProfileModel>, UserProfileRepository<UserProfile, UserProfileModel, CreateUserProfileModel, UpdateUserProfileModel>>();

            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = Configuration["Redis:Configuration"];
                option.InstanceName = Configuration["Redis:InstanceName"];
            });

            services.AddTransient<IUserProfileService<UserProfile, UserProfileModel, GetUsersProfilesModel, CreateUserProfileModel, UpdateUserProfileModel>, UserProfileService<UserProfile, UserProfileModel, GetUsersProfilesModel, CreateUserProfileModel, UpdateUserProfileModel>>();

            services.AddSingleton<IServiceBus, ServiceBus>();

            services.AddHostedService<ProfileMessageBusService>();
                        
            services.AddAuthentication(opts =>
            {
                opts.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opts.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.Authority = Configuration["JWT:Issuer"];
                cfg.Audience = Configuration["JWT:Audience"];
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FitnessApp.ProfileApi",
                    Version = "v1",
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.XML";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });
                c.OperationFilter<SecurityRequirementsOperationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            loggerFactory.AddFile("Logs/ProfileApi-{Date}.txt");

            app.UseHttpsRedirection();

            app.UseAuthentication();

            app.UseMvc();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger XML Api Demo v1");
            });    
        }
    }
}