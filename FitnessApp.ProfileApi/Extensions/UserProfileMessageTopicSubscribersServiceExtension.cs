using System;
using FitnessApp.Common.ServiceBus.Nats.Services;
using FitnessApp.ProfileApi.Services.MessageBus;
using FitnessApp.ProfileApi.Services.UserProfileAggregator;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.ProfileApi.Extensions
{
    public static class UserProfileMessageTopicSubscribersServiceExtension
    {
        public static IServiceCollection AddUserProfileMessageTopicSubscribersService(this IServiceCollection services)
        {
            ArgumentNullException.ThrowIfNull(services);

            services.AddTransient(
                sp =>
                {
                    return new UserProfileMessageTopicSubscribersService(
                        sp.GetRequiredService<IServiceBus>(),
                        sp.GetRequiredService<IUserProfileAggregatorService>().CreateUserProfile);
                }
            );

            return services;
        }
    }
}
