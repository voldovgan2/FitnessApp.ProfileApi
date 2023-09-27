using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Abstractions.Services.Configuration;
using FitnessApp.Common.Abstractions.Services.GenericBlobAggregator;
using FitnessApp.Common.Blob;
using FitnessApp.ProfileApi.Data.Entities;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;
using FitnessApp.ProfileApi.Services.UserProfileGeneric;
using Microsoft.Extensions.Options;

namespace FitnessApp.ProfileApi.Services.UserProfileAggregator
{
    public class UserProfileAggregatorService
        : GenericBlobAggregatorService<UserProfileGenericEntity, UserProfileGenericBlobAggregatorModel, UserProfileGenericModel, CreateUserProfileGenericBlobAggregatorModel, CreateUserProfileGenericModel, UpdateUserProfileGenericBlobAggregatorModel, UpdateUserProfileGenericModel>,
        IUserProfileAggregatorService
    {
        public UserProfileAggregatorService(
            IUserProfileGenericService userProfileService,
            IBlobService blobService,
            IMapper mapper,
            IOptions<GenericBlobAggregatorSettings> genericBlobAggregatorSettings)
            : base(userProfileService, blobService, mapper, genericBlobAggregatorSettings.Value)
        { }

        public Task<UserProfileGenericBlobAggregatorModel> GetUserProfile(string userId)
        {
            return GetItem(userId);
        }

        public async Task<IEnumerable<UserProfileGenericBlobAggregatorModel>> GetUsersProfiles(string[] ids)
        {
            return !ids.Any() ?
                Enumerable.Empty<UserProfileGenericBlobAggregatorModel>()
                : await GetItems(ids);
        }

        public Task<IEnumerable<UserProfileGenericBlobAggregatorModel>> GetUsersProfiles(
            string search,
            Expression<System.Func<UserProfileGenericEntity, bool>> predicate)
        {
            return GetItems(search, predicate);
        }

        public Task<UserProfileGenericBlobAggregatorModel> CreateUserProfile(CreateUserProfileGenericBlobAggregatorModel model)
        {
            return CreateItem(model);
        }

        public Task<UserProfileGenericBlobAggregatorModel> UpdateUserProfile(UpdateUserProfileGenericBlobAggregatorModel model)
        {
            return UpdateItem(model);
        }

        public Task<string> DeleteUserProfile(string userId)
        {
            return DeleteItem(userId);
        }
    }
}