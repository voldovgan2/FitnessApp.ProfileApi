using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessApp.Common.Abstractions.Db.Repository.Generic;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Data;

public interface IUserProfileRepository :
    IGenericRepository<
        UserProfileGenericModel,
        CreateUserProfileGenericModel,
        UpdateUserProfileGenericModel>
{
    Task<IEnumerable<UserProfileGenericModel>> FilterUserProfiles(GetUserProfilesModel model);
}
