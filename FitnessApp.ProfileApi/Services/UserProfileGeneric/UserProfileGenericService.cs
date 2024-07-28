using System.Threading.Tasks;
using FitnessApp.Common.Abstractions.Services.Generic;
using FitnessApp.Common.Paged.Models.Output;
using FitnessApp.ProfileApi.Data;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Services.UserProfileGeneric;

public class UserProfileGenericService(IUserProfileRepository repository) :
    GenericService<
        UserProfileGenericModel,
        CreateUserProfileGenericModel,
        UpdateUserProfileGenericModel>(repository),
    IUserProfileGenericService
{
    public Task<PagedDataModel<UserProfileGenericModel>> FilterUserProfiles(GetUserProfilesModel model)
    {
        return repository.FilterUserProfiles(model);
    }
}
