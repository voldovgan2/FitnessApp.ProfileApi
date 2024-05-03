using System;
using System.Threading.Tasks;
using FitnessApp.Common.Serializer.JsonSerializer;
using FitnessApp.Common.ServiceBus;
using FitnessApp.Common.ServiceBus.Nats.Services;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Services.MessageBus
{
    public class UserProfileMessageTopicSubscribersService(
        IServiceBus serviceBus,
        Func<CreateUserProfileGenericFileAggregatorModel, Task<UserProfileGenericFileAggregatorModel>> createItemMethod,
        IJsonSerializer serializer
        ) : GenericFileAggregatorServiceNewUserRegisteredSubscriberService<
            UserProfileGenericFileAggregatorModel,
            UserProfileGenericModel,
            CreateUserProfileGenericFileAggregatorModel>(serviceBus, createItemMethod, serializer);
}