using System.Collections.Generic;

namespace FitnessApp.ProfileApi.Contracts.Input
{
    public class GetUsersProfilesContract
    {
        public IEnumerable<string> UsersIds { get; set; }
    }
}
