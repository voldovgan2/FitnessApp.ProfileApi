using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Abstractions.Services.Generic;
using FitnessApp.ProfileApi.Data;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Services.UserProfileGeneric;

public class UserProfileGenericService(IUserProfileRepository repository, IMapper mapper) :
    GenericService<
        UserProfileGenericModel,
        CreateUserProfileGenericModel,
        UpdateUserProfileGenericModel>(repository, mapper),
    IUserProfileGenericService
{
    public Task<IEnumerable<UserProfileGenericModel>> FilterUserProfiles(GetUserProfilesModel model)
    {
        return repository.FilterUserProfiles(model);
    }
}
