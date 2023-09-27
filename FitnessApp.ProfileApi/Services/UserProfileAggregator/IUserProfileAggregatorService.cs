using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FitnessApp.ProfileApi.Data.Entities;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Services.UserProfileAggregator
{
    public interface IUserProfileAggregatorService
    {
        Task<UserProfileGenericBlobAggregatorModel> GetUserProfile(string userId);
        Task<IEnumerable<UserProfileGenericBlobAggregatorModel>> GetUsersProfiles(string[] ids);
        Task<IEnumerable<UserProfileGenericBlobAggregatorModel>> GetUsersProfiles(string search, Expression<Func<UserProfileGenericEntity, bool>> predicate);
        Task<UserProfileGenericBlobAggregatorModel> CreateUserProfile(CreateUserProfileGenericBlobAggregatorModel model);
        Task<UserProfileGenericBlobAggregatorModel> UpdateUserProfile(UpdateUserProfileGenericBlobAggregatorModel model);
        Task<string> DeleteUserProfile(string userId);
    }
}