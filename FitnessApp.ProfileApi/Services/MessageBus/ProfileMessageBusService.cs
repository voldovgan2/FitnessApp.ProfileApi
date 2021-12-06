using FitnessApp.IntegrationEvents;
using FitnessApp.NatsServiceBus;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;
using FitnessApp.ProfileApi.Services.UserProfile;
using FitnessApp.Serializer.JsonSerializer;

namespace FitnessApp.ProfileApi.Services.MessageBus
{
    public class ProfileMessageBusService : MessageBusService
    {
        private readonly IUserProfileService<Data.Entities.UserProfile, UserProfileModel, GetUsersProfilesModel, CreateUserProfileModel, UpdateUserProfileModel> _service;
        
        public ProfileMessageBusService
        (
            IServiceBus serviceBus, 
            IUserProfileService<Data.Entities.UserProfile, UserProfileModel, GetUsersProfilesModel, CreateUserProfileModel, UpdateUserProfileModel> userProfileService, 
            IJsonSerializer serializer
        )
            : base(serviceBus, serializer)
        {
            _service = userProfileService;
        }

        protected override void HandleNewUserRegisteredEvent(NewUserRegisteredEvent integrationEvent)
        {
            _service.CreateItemAsync(CreateUserProfileModel.Default(integrationEvent.UserId, integrationEvent.Email));
        }
    }
}