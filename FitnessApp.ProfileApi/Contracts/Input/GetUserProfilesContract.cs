using System.Collections.Generic;

namespace FitnessApp.ProfileApi.Contracts.Input
{
    public class GetUserProfilesContract
    {
        public IEnumerable<string> UsersIds { get; set; }
        public string Search { get; set; }
    }
}