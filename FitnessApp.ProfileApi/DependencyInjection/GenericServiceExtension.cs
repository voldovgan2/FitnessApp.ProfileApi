using System;
using FitnessApp.Common.Abstractions.Services.Configuration;
using FitnessApp.ProfileApi.Services.UserProfileAggregator;
using FitnessApp.ProfileApi.Services.UserProfileGeneric;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.ProfileApi.DependencyInjection;

public static class GenericServiceExtension
{
    public static IServiceCollection ConfigureGenericServices(this IServiceCollection services, IConfiguration configuration)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.Configure<GenericFileAggregatorSettings>(configuration.GetSection("GenericFileAggregatorSettings"));
        services.AddTransient<IUserProfileGenericService, UserProfileGenericService>();
        services.AddTransient<IUserProfileAggregatorService, UserProfileAggregatorService>();

        return services;
    }
}
