﻿using FitnessApp.Abstractions.Models.Base;
using FitnessApp.ProfileApi.Enums;
using System;

namespace FitnessApp.ProfileApi.Models.Input
{
    public class CreateUserProfileModel : ICreateModel
    {
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

        public bool IsMops()
        {
            return IsVikaMops() || IsSaniokMopsya();
        }

        public static CreateUserProfileModel Default(string userId, string email, bool isAdmin = false)
        {
            var random = new Random();
            var ageShift = random.Next(-50, -10);
            var dateShift = random.Next(0, 365);
            var gender = random.Next(0, 1);
            var height = random.Next(125, 195);
            var weight = random.Next(45, 95);
            var isVika = ageShift >= 25 && ageShift <= 30
                && gender == 1
                && height >= 150 && height <= 160
                && weight >= 60 && height <= 70;
            var isSaniok = ageShift >= 35 && ageShift <= 40
                && gender == 0
                && height >= 150 && height <= 160
                && weight >= 70 && height <= 85;
            var firstName = email;
            var lastName = email;
            var about = email;
            if (isVika && !isAdmin)
            {
                firstName = _vikaMopsFirstName;
                lastName = _vikaMopsLastName;
                about = _vikaMopsAbout;
            }
            if (isSaniok && !isAdmin)
            {
                firstName = _saniokMopsFirstName;
                lastName = _saniokMopsLastName;
                about = _saniokMopsAbout;
            }
            return new CreateUserProfileModel
            {
                UserId = userId,
                Email = email,
                FirstName = firstName,
                LastName = lastName,
                About = about,
                BirthDate = DateTime.Now.AddYears(ageShift).AddDays(dateShift),
                Gender = gender == 0 ? Gender.Male : Gender.Famele,
                Height = height,
                Weight = weight,
                Language = "EN",
                BackgroundPhoto = "",
                CroppedProfilePhoto = "data:image/png;base64,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",
                OriginalProfilePhoto = ""
            };
        }

        private static string _vikaMopsFirstName = "Vika";
        private static string _vikaMopsLastName = "Modoletska";
        private static string _vikaMopsAbout = "Hello, I'm PihVika Mops";

        private static string _saniokMopsFirstName = "Saniok";
        private static string _saniokMopsLastName = "Dovbash";
        private static string _saniokMopsAbout = "Hello, I'm Sanyok Mopsya";

        private bool IsVikaMops()
        {
            return FirstName == _vikaMopsFirstName && LastName == _vikaMopsLastName && About == _vikaMopsAbout;
        }

        private bool IsSaniokMopsya()
        {
            return FirstName == _saniokMopsFirstName && LastName == _saniokMopsLastName && About == _saniokMopsAbout;
        }
    }
}