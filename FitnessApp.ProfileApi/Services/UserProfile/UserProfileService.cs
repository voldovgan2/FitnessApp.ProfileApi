using FitnessApp.Abstractions.Db.Entities.Base;
using FitnessApp.Abstractions.Models.Base;
using FitnessApp.Abstractions.Services.Base;
using FitnessApp.Abstractions.Services.Cache;
using FitnessApp.Logger;
using FitnessApp.ProfileApi.Data;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.Serializer.JsonMapper;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.ProfileApi.Services.UserProfile
{
    public class UserProfileService<Entity, Model, GetItemsModel, CreateModel, UpdateModel>
        : GenericService<Entity, Model, GetItemsModel, CreateModel, UpdateModel>
        , IUserProfileService<Entity, Model, GetItemsModel, CreateModel, UpdateModel>
        where Entity : IEntity
        where Model : ISearchableModel
        where GetItemsModel : IGetItemsModel
        where CreateModel : ICreateModel
        where UpdateModel : IUpdateModel
    {  
        private readonly IJsonMapper _mapper;
        private readonly ILogger<UserProfileService<Entity, Model, GetItemsModel, CreateModel, UpdateModel>> _log;

        public UserProfileService
        (
            IUserProfileRepository<Entity, Model, CreateModel, UpdateModel> repository,
            ICacheService<Model> cacheService,
            IJsonMapper mapper,
            ILogger<UserProfileService<Entity, Model, GetItemsModel, CreateModel, UpdateModel>> log
        )
            : base(repository, cacheService, log)
        {
            _mapper = mapper;
            _log = log;
        }
                
        public async Task<IEnumerable<Model>> GetUsersProfilesAsync(GetUsersProfilesModel model)
        {
            IEnumerable<Model> result = null;
            if (!model.UsersIds.Any())
            {
                result = Enumerable.Empty<Model>();
            }
            else
            {
                var geItemsModel = _mapper.Convert<GetItemsModel>(model);
                var items = await base.GetItemsAsync(geItemsModel);
                if (model.EnsureAllIds)
                {
                    if (model.UsersIds.All(i => items?.Any(e => e.UserId == i) == true))
                    {
                        result = items;
                    }
                    else
                    {
                        var unexistingEntity = model.UsersIds.First(i => !items.Any(e => e.UserId == i));
                        _log.WriteWarning($"Item does not exist. UserId: {unexistingEntity}");
                    }
                }
                else
                {
                    result = items;
                }
            }
            return result;
        }
    }
}