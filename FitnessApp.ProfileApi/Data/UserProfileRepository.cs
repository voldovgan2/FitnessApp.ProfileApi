using FitnessApp.Serializer.JsonMapper;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using System.Collections.Generic;
using FitnessApp.ProfileApi.Models.Input;
using System.Linq;
using System;
using FitnessApp.Logger;
using FitnessApp.Abstractions.Db.Repository.Base;
using FitnessApp.Abstractions.Db.Entities.Base;
using FitnessApp.Abstractions.Models.Base;
using FitnessApp.Abstractions.Db.Configuration;

namespace FitnessApp.ProfileApi.Data
{
    public class UserProfileRepository<Entity, Model, CreateModel, UpdateModel>
        : GenericRepository<Entity, Model, CreateModel, UpdateModel>
        , IUserProfileRepository<Entity, Model, CreateModel, UpdateModel>
        where Entity : IEntity
        where Model : ISearchableModel
        where CreateModel : ICreateModel
        where UpdateModel : IUpdateModel
    {
        private readonly ILogger<UserProfileRepository<Entity, Model, CreateModel, UpdateModel>> _log;

        public UserProfileRepository
        (
            IOptions<MongoDbSettings> settings, 
            IJsonMapper mapper, 
            ILogger<UserProfileRepository<Entity, Model, CreateModel, UpdateModel>> log
        )
            : base(settings, mapper, log)
        {  

        }
    }
}