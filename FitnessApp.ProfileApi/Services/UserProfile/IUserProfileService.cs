using FitnessApp.Abstractions.Db.Entities.Base;
using FitnessApp.Abstractions.Models.Base;
using FitnessApp.Abstractions.Services.Base;
using FitnessApp.ProfileApi.Models.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessApp.ProfileApi.Services.UserProfile
{
    public interface IUserProfileService<Entity, Model, GetItemsModel, CreateModel, UpdateModel>
        : IGenericService<Entity, Model, GetItemsModel, CreateModel, UpdateModel>
        where Entity : IEntity
        where Model : ISearchableModel
        where GetItemsModel : IGetItemsModel
        where CreateModel : ICreateModel
        where UpdateModel : IUpdateModel
    {
        Task<IEnumerable<Model>> GetUsersProfilesAsync(GetUsersProfilesModel model);
    }
}