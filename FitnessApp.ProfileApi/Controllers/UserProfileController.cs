using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.Common.Abstractions.Controllers;
using FitnessApp.Common.Paged.Contracts.Output;
using FitnessApp.ProfileApi.Contracts.Input;
using FitnessApp.ProfileApi.Contracts.Output;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Services.UserProfileAggregator;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.ProfileApi.Controllers;

public class UserProfileController(IUserProfileAggregatorService userProfileAggregatorService, IMapper mapper) : FitnessAppBaseController
{
    [HttpPost("FilterUserProfiles")]
    public async Task<PagedDataContract<UserProfileContract>> FilterUserProfiles([FromBody]GetUserProfilesContract contract)
    {
        var model = mapper.Map<GetUserProfilesModel>(contract);
        var response = await userProfileAggregatorService.FilterUserProfiles(model);
        return mapper.Map<PagedDataContract<UserProfileContract>>(response);
    }

    [HttpPost("GetUsersProfilesByIds")]
    public async Task<PagedDataContract<UserProfileContract>> GetUsersProfilesByIds([FromBody]GetUsersProfilesByIdsContract contract)
    {
        var model = mapper.Map<GetUsersProfilesByIdsModel>(contract);
        var response = await userProfileAggregatorService.GetUsersProfilesByIds(model);
        return mapper.Map<PagedDataContract<UserProfileContract>>(response);
    }

    [HttpGet("GetUserProfile/{userId}")]
    public async Task<UserProfileContract> GetUserProfile([FromRoute] string userId)
    {
        var response = await userProfileAggregatorService.GetUserProfile(userId);
        return mapper.Map<UserProfileContract>(response);
    }

    [HttpPost("CreateUserProfile")]
    public async Task<UserProfileContract> CreateUserProfile([FromBody]CreateUserProfileContract contract)
    {
        var model = mapper.Map<CreateUserProfileGenericFileAggregatorModel>(contract);
        var response = await userProfileAggregatorService.CreateUserProfile(model);
        return mapper.Map<UserProfileContract>(response);
    }

    [HttpPut("UpdateUserProfile")]
    public async Task<UserProfileContract> UpdateUserProfileAsync([FromBody]UpdateUserProfileContract contract)
    {
        var model = mapper.Map<UpdateUserProfileGenericFileAggregatorModel>(contract);
        var response = await userProfileAggregatorService.UpdateUserProfile(model);
        return mapper.Map<UserProfileContract>(response);
    }

    [HttpDelete("DeleteUserProfile/{userId}")]
    public async Task<string> DeleteUserProfileAsync([FromRoute] string userId)
    {
        var response = await userProfileAggregatorService.DeleteUserProfile(userId);
        return response;
    }
}