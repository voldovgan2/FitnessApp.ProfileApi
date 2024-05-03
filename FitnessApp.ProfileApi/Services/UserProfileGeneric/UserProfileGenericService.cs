using AutoMapper;
using FitnessApp.Common.Abstractions.Services.Generic;
using FitnessApp.ProfileApi.Data;
using FitnessApp.ProfileApi.Data.Entities;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Services.UserProfileGeneric
{
    public class UserProfileGenericService(IUserProfileRepository repository, IMapper mapper) : GenericService<
        UserProfileGenericEntity,
        UserProfileGenericModel,
        CreateUserProfileGenericModel,
        UpdateUserProfileGenericModel>(repository, mapper),
        IUserProfileGenericService;
}