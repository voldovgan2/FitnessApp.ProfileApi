using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.Common.Abstractions.Services.Generic;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Services.UserProfileGeneric;

public interface IUserProfileGenericService :
    IGenericService<
        UserProfileGenericModel,
        CreateUserProfileGenericModel,
        UpdateUserProfileGenericModel>
{
    Task<IEnumerable<UserProfileGenericModel>> FilterUserProfiles(GetUserProfilesModel model);
}