using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Abstractions.Services.Configuration;
using FitnessApp.Common.Abstractions.Services.GenericFileAggregator;
using FitnessApp.Common.Files;
using FitnessApp.Common.Paged.Extensions;
using FitnessApp.Common.Paged.Models.Output;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;
using FitnessApp.ProfileApi.Services.UserProfileGeneric;
using Microsoft.Extensions.Options;

namespace FitnessApp.ProfileApi.Services.UserProfileAggregator;

public class UserProfileAggregatorService(
    IUserProfileGenericService userProfileService,
    IFilesService filesService,
    IMapper mapper,
    IOptions<GenericFileAggregatorSettings> genericFileAggregatorSettings) :
    GenericFileAggregatorService<
        UserProfileGenericFileAggregatorModel,
        UserProfileGenericModel,
        CreateUserProfileGenericFileAggregatorModel,
        CreateUserProfileGenericModel,
        UpdateUserProfileGenericFileAggregatorModel,
        UpdateUserProfileGenericModel>(
        userProfileService,
        filesService,
        mapper,
        genericFileAggregatorSettings.Value),
        IUserProfileAggregatorService
{
    public Task<UserProfileGenericFileAggregatorModel> GetUserProfile(string userId)
    {
        return GetItemByUserId(userId);
    }

    public async Task<PagedDataModel<UserProfileGenericFileAggregatorModel>> GetUsersProfilesByIds(GetUsersProfilesByIdsModel model)
    {
        return (await GetItemsByIds(model.UsersIds)).ToPaged(model);
    }

    public async Task<PagedDataModel<UserProfileGenericFileAggregatorModel>> FilterUserProfiles(GetUserProfilesModel model)
    {
        var models = await userProfileService.FilterUserProfiles(model);
        return (await LoadAndComposeGenericFileAggregatorModels(models.Items)).ToPaged(model);
    }

    public Task<UserProfileGenericFileAggregatorModel> CreateUserProfile(CreateUserProfileGenericFileAggregatorModel model)
    {
        return CreateItem(model);
    }

    public Task<UserProfileGenericFileAggregatorModel> UpdateUserProfile(UpdateUserProfileGenericFileAggregatorModel model)
    {
        return UpdateItem(model);
    }

    public Task<string> DeleteUserProfile(string userId)
    {
        return DeleteItem(userId);
    }
}