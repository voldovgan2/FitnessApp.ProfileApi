using AutoMapper;
using FitnessApp.Common.Abstractions.Db.DbContext;
using FitnessApp.Common.Abstractions.Db.Repository.Generic;
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
    IUserProfileRepository;