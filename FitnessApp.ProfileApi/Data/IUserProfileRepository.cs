using System.Threading.Tasks;
using FitnessApp.Common.Abstractions.Db.Repository.Generic;
using FitnessApp.Common.Paged.Models.Output;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Data;

public interface IUserProfileRepository :
    IGenericRepository<
        UserProfileGenericModel,
        CreateUserProfileGenericModel,
        UpdateUserProfileGenericModel>
{
    Task<PagedDataModel<UserProfileGenericModel>> FilterUserProfiles(GetUserProfilesModel model);
}
