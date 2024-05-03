using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FitnessApp.ProfileApi.Contracts.Input;
using FitnessApp.ProfileApi.Contracts.Output;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Services.UserProfileAggregator;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessApp.ProfileApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]

    [Authorize]
    public class UserProfileController(IUserProfileAggregatorService userProfileAggregatorService, IMapper mapper) : Controller
    {
        [HttpPost("GetUserProfiles")]
        public async Task<IEnumerable<UserProfileContract>> GetUserProfiles([FromBody]GetUserProfilesContract contract)
        {
            var response = await userProfileAggregatorService.GetUsersProfiles(
                contract.Search,
                entity => true);
            return mapper.Map<IEnumerable<UserProfileContract>>(response);
        }

        [HttpPost("GetUsersProfiles")]
        public async Task<IEnumerable<UserProfileContract>> GetUsersProfiles([FromBody]GetUsersProfilesContract contract)
        {
            var response = await userProfileAggregatorService.GetUsersProfiles(contract.UsersIds);
            return mapper.Map<IEnumerable<UserProfileContract>>(response);
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
}