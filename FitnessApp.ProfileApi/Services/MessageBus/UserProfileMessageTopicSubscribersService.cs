using System;
using System.Threading.Tasks;
using FitnessApp.Common.Serializer.JsonSerializer;
using FitnessApp.Common.ServiceBus;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Services.MessageBus
{
    public class UserProfileMessageTopicSubscribersService : GenericBlobAggregatorServiceNewUserRegisteredSubscriberService<UserProfileGenericBlobAggregatorModel, UserProfileGenericModel, CreateUserProfileGenericBlobAggregatorModel>
    {
        public UserProfileMessageTopicSubscribersService(
            Func<CreateUserProfileGenericBlobAggregatorModel, Task<UserProfileGenericBlobAggregatorModel>> createItemMethod,
            string subscription,
            IJsonSerializer serializer
        )
            : base(createItemMethod, subscription, serializer)
        { }
    }
}