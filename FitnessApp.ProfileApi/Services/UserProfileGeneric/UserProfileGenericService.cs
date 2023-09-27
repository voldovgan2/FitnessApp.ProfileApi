using AutoMapper;
using FitnessApp.Common.Abstractions.Services.Generic;
using FitnessApp.Common.Abstractions.Services.Search;
using FitnessApp.ProfileApi.Data;
using FitnessApp.ProfileApi.Data.Entities;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Services.UserProfileGeneric
{
    public class UserProfileGenericService
        : GenericService<UserProfileGenericEntity, UserProfileGenericModel, CreateUserProfileGenericModel, UpdateUserProfileGenericModel>,
        IUserProfileGenericService
    {
        public UserProfileGenericService(
            IUserProfileRepository repository,
            ISearchService searchService,
            IMapper mapper)
            : base(repository, searchService, mapper)
        {
        }
    }
}