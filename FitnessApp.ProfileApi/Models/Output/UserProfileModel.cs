using FitnessApp.Abstractions.Models.Base;
using FitnessApp.ProfileApi.Enums;
using System;

namespace FitnessApp.ProfileApi.Models.Output
{
    public class UserProfileModel : ISearchableModel
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CroppedProfilePhoto { get; set; }
        public string OriginalProfilePhoto { get; set; }
        public DateTime BirthDate { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public Gender Gender { get; set; }
        public string About { get; set; }
        public string Language { get; set; }
        public string BackgroundPhoto { get; set; }

        public bool Matches(string search)
        {
            bool result = true;
            if (!string.IsNullOrWhiteSpace(search))
            {
                result = FirstName.IndexOf(search) != -1
                    || LastName.IndexOf(search) != -1
                    || About.IndexOf(search) != -1
                    || Email.IndexOf(search) != -1;
            }
            return result;
        }
    }
}