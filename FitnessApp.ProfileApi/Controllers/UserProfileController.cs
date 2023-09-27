using System.Collections.Generic;
using System.Net;
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

    // [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IUserProfileAggregatorService _userProfileAggregatorService;
        private readonly IMapper _mapper;

        public UserProfileController(
            IUserProfileAggregatorService userProfileAggregatorService,
            IMapper mapper)
        {
            _userProfileAggregatorService = userProfileAggregatorService;
            _mapper = mapper;
        }

        [HttpPost("GetUserProfiles")]
        public async Task<IActionResult> GetUserProfiles([FromBody]GetUserProfilesContract contract)
        {
            var response = await _userProfileAggregatorService.GetUsersProfiles(
                contract.Search,
                entity => true);
            if (response != null)
            {
                var result = _mapper.Map<IEnumerable<UserProfileContract>>(response);
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("GetUsersProfiles")]
        public async Task<IActionResult> GetUsersProfiles([FromBody]GetUsersProfilesContract contract)
        {
            var response = await _userProfileAggregatorService.GetUsersProfiles(contract.UsersIds);
            if (response != null)
            {
                var result = _mapper.Map<IEnumerable<UserProfileContract>>(response);
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("GetUserProfile/{userId}")]
        public async Task<IActionResult> GetUserProfile([FromRoute] string userId)
        {
            var response = await _userProfileAggregatorService.GetUserProfile(userId);
            if (response != null)
            {
                var result = _mapper.Map<UserProfileContract>(response);
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("CreateUserProfile")]
        public async Task<IActionResult> CreateUserProfile([FromBody]CreateUserProfileContract contract)
        {
            var model = _mapper.Map<CreateUserProfileGenericBlobAggregatorModel>(contract);
            var created = await _userProfileAggregatorService.CreateUserProfile(model);
            if (created != null)
            {
                var result = _mapper.Map<UserProfileContract>(created);
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut("UpdateUserProfile")]
        public async Task<IActionResult> UpdateUserProfileAsync([FromBody]UpdateUserProfileContract contract)
        {
            var model = _mapper.Map<UpdateUserProfileGenericBlobAggregatorModel>(contract);
            var updated = await _userProfileAggregatorService.UpdateUserProfile(model);
            if (updated != null)
            {
                var result = _mapper.Map<UserProfileContract>(updated);
                return Ok(result);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete("DeleteUserProfile/{userId}")]
        public async Task<IActionResult> DeleteUserProfileAsync([FromRoute] string userId)
        {
            var deleted = await _userProfileAggregatorService.DeleteUserProfile(userId);
            if (deleted != null)
            {
                return Ok(deleted);
            }
            else
            {
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}