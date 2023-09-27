using System;
using FitnessApp.Common.Serializer.JsonSerializer;
using FitnessApp.ProfileApi.Services.MessageBus;
using FitnessApp.ProfileApi.Services.UserProfileAggregator;
using FitnessApp.ServiceBus.AzureServiceBus.TopicSubscribers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.ProfileApi.Extensions
{
    public static class UserProfileMessageTopicSubscribersServiceExtension
    {
        public static IServiceCollection AddUserProfileMessageTopicSubscribersService(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddTransient<ITopicSubscribers, UserProfileMessageTopicSubscribersService>(
                sp =>
                {
                    var configuration = sp.GetRequiredService<IConfiguration>();
                    var subscription = configuration.GetValue<string>("ServiceBusSubscriptionName");
                    return new UserProfileMessageTopicSubscribersService(
                        sp.GetRequiredService<IUserProfileAggregatorService>().CreateUserProfile,
                        subscription,
                        sp.GetRequiredService<IJsonSerializer>()
                    );
                }
            );

            return services;
        }
    }
}
