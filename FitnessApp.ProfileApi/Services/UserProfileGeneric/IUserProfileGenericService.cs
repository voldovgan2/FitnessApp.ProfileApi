using System.Threading.Tasks;
using FitnessApp.Common.Abstractions.Services.Generic;
using FitnessApp.Common.Paged.Models.Output;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Services.UserProfileGeneric;

public interface IUserProfileGenericService :
    IGenericService<
        UserProfileGenericModel,
        CreateUserProfileGenericModel,
        UpdateUserProfileGenericModel>
{
    Task<PagedDataModel<UserProfileGenericModel>> FilterUserProfiles(GetUserProfilesModel model);
}