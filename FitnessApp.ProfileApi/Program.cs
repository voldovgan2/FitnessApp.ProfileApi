using System.Reflection;
using AutoMapper;
using FitnessApp.AzureServiceBus;
using FitnessApp.Common.Abstractions.Db.Configuration;
using FitnessApp.Common.Abstractions.Db.DbContext;
using FitnessApp.Common.Abstractions.Services.Configuration;
using FitnessApp.Common.Configuration.Blob;
using FitnessApp.Common.Configuration.Identity;
using FitnessApp.Common.Configuration.Swagger;
using FitnessApp.Common.Serializer.JsonSerializer;
using FitnessApp.ProfileApi;
using FitnessApp.ProfileApi.Data;
using FitnessApp.ProfileApi.Data.Entities;
using FitnessApp.ProfileApi.Extensions;
using FitnessApp.ProfileApi.Services.UserProfileAggregator;
using FitnessApp.ProfileApi.Services.UserProfileGeneric;
using FitnessApp.ServiceBus.AzureServiceBus.Configuration;
using FitnessApp.ServiceBus.AzureServiceBus.Consumer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddBlobService(builder.Configuration);

builder.Services.AddTransient<IJsonSerializer, JsonSerializer>();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoConnection"));

builder.Services.Configure<AzureServiceBusSettings>(builder.Configuration.GetSection("AzureServiceBusSettings"));

builder.Services.Configure<GenericBlobAggregatorSettings>(builder.Configuration.GetSection("GenericBlobAggregatorSettings"));

builder.Services.AddTransient<IDbContext<UserProfileGenericEntity>, DbContext<UserProfileGenericEntity>>();

builder.Services.AddTransient<IUserProfileRepository, UserProfileRepository>();

builder.Services.AddTransient<IUserProfileGenericService, UserProfileGenericService>();

builder.Services.AddTransient<IUserProfileAggregatorService, UserProfileAggregatorService>();

builder.Services.AddUserProfileMessageTopicSubscribersService();

builder.Services.AddSingleton<IMessageConsumer, MessageConsumer>();

builder.Services.AddHostedService<MessageListenerService>();

builder.Services.ConfigureAzureAdAuthentication(builder.Configuration);

builder.Services.ConfigureSwaggerConfiguration(Assembly.GetExecutingAssembly().GetName().Name);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger XML Api Demo v1");
});

app.Run();

#pragma warning disable S1118 // Utility classes should not have public constructor
public partial class Program { }
#pragma warning restore S1118 // Utility classes should not have public constructor