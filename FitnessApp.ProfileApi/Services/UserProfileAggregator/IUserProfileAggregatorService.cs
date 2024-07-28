using System.Threading.Tasks;
using FitnessApp.Common.Paged.Models.Output;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Services.UserProfileAggregator;

public interface IUserProfileAggregatorService
{
    Task<UserProfileGenericFileAggregatorModel> GetUserProfile(string userId);
    Task<PagedDataModel<UserProfileGenericFileAggregatorModel>> GetUsersProfilesByIds(GetUsersProfilesByIdsModel model);
    Task<PagedDataModel<UserProfileGenericFileAggregatorModel>> FilterUserProfiles(GetUserProfilesModel model);
    Task<UserProfileGenericFileAggregatorModel> CreateUserProfile(CreateUserProfileGenericFileAggregatorModel model);
    Task<UserProfileGenericFileAggregatorModel> UpdateUserProfile(UpdateUserProfileGenericFileAggregatorModel model);
    Task<string> DeleteUserProfile(string userId);
}