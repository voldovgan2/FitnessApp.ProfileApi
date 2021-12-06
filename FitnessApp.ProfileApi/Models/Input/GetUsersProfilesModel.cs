using FitnessApp.Abstractions.Models.Base;
using System.Collections.Generic;

namespace FitnessApp.ProfileApi.Models.Input
{
    public class GetUsersProfilesModel : IGetItemsModel
    {
        public IEnumerable<string> UsersIds { get; set; }
        public string Search { get; set; }
        public bool EnsureAllIds { get; set; }
    }
}