using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Abstractions.Db.DbContext;
using FitnessApp.Common.Abstractions.Db.Repository.Generic;
using FitnessApp.Common.Paged.Extensions;
using FitnessApp.Common.Paged.Models.Output;
using FitnessApp.ProfileApi.Data.Entities;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Data;

public class UserProfileRepository(IDbContext<UserProfileGenericEntity> dbContext, IMapper mapper) :
    GenericRepository<
        UserProfileGenericEntity,
        UserProfileGenericModel,
        CreateUserProfileGenericModel,
        UpdateUserProfileGenericModel>(dbContext, mapper),
    IUserProfileRepository
{
    public async Task<PagedDataModel<UserProfileGenericModel>> FilterUserProfiles(GetUserProfilesModel model)
    {
        var items = await DbContext.FilterItems(up =>
            up.FirstName.Contains(model.Search)
            || up.LastName.Contains(model.Search)
            || up.About.Contains(model.Search));
        return Mapper.Map<IEnumerable<UserProfileGenericModel>>(items).ToPaged(model);
    }
}
