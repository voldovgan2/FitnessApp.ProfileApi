using System.Reflection;
using FitnessApp.Common.Configuration;
using FitnessApp.ProfileApi;
using FitnessApp.ProfileApi.DependencyInjection;
using FitnessApp.ProfileApi.Extensions;
using FitnessApp.ProfileApi.Services.MessageBus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureMapper(new MappingProfile());
builder.Services.ConfigureMongo(builder.Configuration);
builder.Services.ConfigureVault(builder.Configuration);
builder.Services.ConfigureUserProfileRepository();
builder.Services.ConfigureFilesService(builder.Configuration);
builder.Services.ConfigureNats(builder.Configuration);
builder.Services.AddUserProfileMessageTopicSubscribersService();
builder.Services.ConfigureAuthentication(builder.Configuration);
builder.Services.ConfigureSwagger(Assembly.GetExecutingAssembly().GetName().Name);
builder.Services.ConfigureGenericServices(builder.Configuration);
if ("false".Contains("true"))
    builder.Services.AddHostedService<UserProfileMessageTopicSubscribersService>();

builder.Host.ConfigureAppConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerAndUi();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
public partial class Program { }