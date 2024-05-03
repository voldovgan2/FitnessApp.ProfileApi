using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Abstractions.Services.Configuration;
using FitnessApp.Common.Abstractions.Services.GenericFileAggregator;
using FitnessApp.Common.Files;
using FitnessApp.ProfileApi.Data.Entities;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;
using FitnessApp.ProfileApi.Services.UserProfileGeneric;
using Microsoft.Extensions.Options;

namespace FitnessApp.ProfileApi.Services.UserProfileAggregator
{
    public class UserProfileAggregatorService(
        IUserProfileGenericService userProfileService,
        IFilesService filesService,
        IMapper mapper,
        IOptions<GenericFileAggregatorSettings> genericFileAggregatorSettings) : GenericFileAggregatorService<
            UserProfileGenericEntity,
            UserProfileGenericFileAggregatorModel,
            UserProfileGenericModel,
            CreateUserProfileGenericFileAggregatorModel,
            CreateUserProfileGenericModel,
            UpdateUserProfileGenericFileAggregatorModel,
            UpdateUserProfileGenericModel>(userProfileService, filesService, mapper, genericFileAggregatorSettings.Value),
            IUserProfileAggregatorService
    {
        public Task<UserProfileGenericFileAggregatorModel> GetUserProfile(string userId)
        {
            return GetItem(userId);
        }

        public async Task<IEnumerable<UserProfileGenericFileAggregatorModel>> GetUsersProfiles(string[] ids)
        {
            return ids.Length == 0 ?
                Enumerable.Empty<UserProfileGenericFileAggregatorModel>()
                : await GetItems(ids);
        }

        public Task<IEnumerable<UserProfileGenericFileAggregatorModel>> GetUsersProfiles(
            string search,
            Expression<System.Func<UserProfileGenericEntity, bool>> predicate)
        {
            return GetItems(search, predicate);
        }

        public Task<UserProfileGenericFileAggregatorModel> CreateUserProfile(CreateUserProfileGenericFileAggregatorModel model)
        {
            return CreateItem(model);
        }

        public Task<UserProfileGenericFileAggregatorModel> UpdateUserProfile(UpdateUserProfileGenericFileAggregatorModel model)
        {
            return UpdateItem(model);
        }

        public Task<string> DeleteUserProfile(string userId)
        {
            return DeleteItem(userId);
        }
    }
}