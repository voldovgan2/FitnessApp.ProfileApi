using FitnessApp.Common.Abstractions.Db.Repository.Generic;
using FitnessApp.ProfileApi.Data.Entities;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi.Data
{
    public interface IUserProfileRepository :
        IGenericRepository<
            UserProfileGenericEntity,
            UserProfileGenericModel,
            CreateUserProfileGenericModel,
            UpdateUserProfileGenericModel>;
}
