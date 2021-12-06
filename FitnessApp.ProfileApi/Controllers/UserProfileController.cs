using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using System.Net;
using FitnessApp.ProfileApi.Services.UserProfile;
using FitnessApp.ProfileApi.Contracts.Output;
using FitnessApp.ProfileApi.Contracts.Input;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Data.Entities;
using FitnessApp.ProfileApi.Models.Output;
using System.Collections.Generic;
using FitnessApp.Serializer.JsonMapper;

namespace FitnessApp.ProfileApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    [Authorize]
    public class UserProfileController : Controller
    {
        private readonly IUserProfileService<UserProfile, UserProfileModel, GetUsersProfilesModel, CreateUserProfileModel, UpdateUserProfileModel> _userProfileService;
        private readonly IJsonMapper _mapper;

        public UserProfileController
        (
            IUserProfileService<UserProfile, UserProfileModel, GetUsersProfilesModel, CreateUserProfileModel, UpdateUserProfileModel> userProfileService, 
            IJsonMapper mapper
        )
        {
            _userProfileService = userProfileService;
            _mapper = mapper;
        }

        [HttpGet("GetUserProfiles")]
        public async Task<IActionResult> GetUserProfilesAsync([FromBody]GetUserProfilesContract contract)
        {
            var model = _mapper.Convert<GetUsersProfilesModel>(contract);
            var response = await _userProfileService.GetItemsAsync(model);
            if (response != null)
            {
                var result = _mapper.Convert<IEnumerable<UserProfileContract>>(response);
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("GetUsersProfiles")]
        public async Task<IActionResult> GetUsersProfilesAsync([FromBody]GetUsersProfilesContract contract)
        {
            var model = _mapper.Convert<GetUsersProfilesModel>(contract);
            var response = await _userProfileService.GetUsersProfilesAsync(model);
            if (response != null)
            {
                var result = _mapper.Convert<IEnumerable<UserProfileContract>>(response);
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("GetUserProfile/{userId}")]
        public async Task<IActionResult> GetUserProfileAsync([FromRoute] string userId)
        {
            var response = await _userProfileService.GetItemByUserIdAsync(userId);
            if (response != null)
            {
                var result = _mapper.Convert<UserProfileContract>(response);
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        [HttpPost("CreateUserProfile")]
        public async Task<IActionResult> CreateUserProfileAsync([FromBody]CreateUserProfileContract contract)
        {
            var model = _mapper.Convert<CreateUserProfileModel>(contract);
            var created = await _userProfileService.CreateItemAsync(model);
            if (created != null)
            {
                var result = _mapper.Convert<UserProfileContract>(created);
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
            var model = _mapper.Convert<UpdateUserProfileModel>(contract);
            var updated = await _userProfileService.UpdateItemAsync(model);
            if (updated != null)
            {
                var result = _mapper.Convert<UserProfileContract>(updated);
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
            var deleted = await _userProfileService.DeleteItemAsync(userId);
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