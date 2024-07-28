using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Abstractions.Db.DbContext;
using FitnessApp.Common.Abstractions.Db.Repository.Generic;
using FitnessApp.ProfileApi.Data.Entities;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Data;

public class UserProfileRepository :
    GenericRepository<
        UserProfileGenericEntity,
        UserProfileGenericModel,
        CreateUserProfileGenericModel,
        UpdateUserProfileGenericModel>,
    IUserProfileRepository
{
    private readonly IDbContext<UserProfileGenericEntity> _dbContext;
    public UserProfileRepository(IDbContext<UserProfileGenericEntity> dbContext, IMapper mapper)
        : base(dbContext, mapper)
    {
        _dbContext = dbContext;
    }

    public async Task<IEnumerable<UserProfileGenericModel>> FilterUserProfiles(GetUserProfilesModel model)
    {
        var items = await _dbContext.FilterItems(up =>
            up.FirstName.Contains(model.Search)
            || up.LastName.Contains(model.Search)
            || up.About.Contains(model.Search));
        return Map(items);
    }
}
