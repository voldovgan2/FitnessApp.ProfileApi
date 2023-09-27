using FitnessApp.Common.Abstractions.Services.Generic;
using FitnessApp.ProfileApi.Data.Entities;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Services.UserProfileGeneric
{
    public interface IUserProfileGenericService
        : IGenericService<UserProfileGenericEntity, UserProfileGenericModel, CreateUserProfileGenericModel, UpdateUserProfileGenericModel>
    {
    }
}