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
        Task<UserProfileGenericFileAggregatorModel> GetUserProfile(string userId);
        Task<IEnumerable<UserProfileGenericFileAggregatorModel>> GetUsersProfiles(string[] ids);
        Task<IEnumerable<UserProfileGenericFileAggregatorModel>> GetUsersProfiles(string search, Expression<Func<UserProfileGenericEntity, bool>> predicate);
        Task<UserProfileGenericFileAggregatorModel> CreateUserProfile(CreateUserProfileGenericFileAggregatorModel model);
        Task<UserProfileGenericFileAggregatorModel> UpdateUserProfile(UpdateUserProfileGenericFileAggregatorModel model);
        Task<string> DeleteUserProfile(string userId);
    }
}