using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessApp.Abstractions.Services.Cache;
using FitnessApp.Logger;
using FitnessApp.ProfileApi.Data.Entities;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FitnessApp.ProfileApi.Data
{
    public class DataInitializer
    {
        public static async Task EnsureProfilesAreCreatedAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var repository = services.GetRequiredService<IUserProfileRepository<UserProfile, UserProfileModel, CreateUserProfileModel, UpdateUserProfileModel>>();
                var logger = services.GetRequiredService<ILogger<DataInitializer>>();
                for (int k = 0; k < 200; k++)
                {
                    var userEmail = $"user{k}@hotmail.com";
                    var userId = $"ApplicationUser_{userEmail}";
                    var userProfile = await repository.GetItemByUserIdAsync(userId);
                    if (userProfile == null)
                    {
                        var user = CreateUserProfileModel.Default(userId, userEmail);
                        if(user.IsMops())
                        {
                            logger.WriteInformation($"Mops found: First name: {user.FirstName} Last name: {user.LastName} About: {user.About}");
                        }
                        await repository.CreateItemAsync(user);
                    }
                }
                var adminEmail = "admin@hotmail.com";
                var adminId = $"ApplicationUser_{adminEmail}";
                var adminProfile = await repository.GetItemByUserIdAsync(adminId);
                if (adminProfile == null)
                {
                    await repository.CreateItemAsync(CreateUserProfileModel.Default(adminId, adminEmail, true));
                }
            }
        }

        public static async Task FillCacheWithSettingsAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var profilesRepository = services.GetRequiredService<IUserProfileRepository<UserProfile, UserProfileModel, CreateUserProfileModel, UpdateUserProfileModel>>();
                var cacheService = services.GetRequiredService<ICacheService<UserProfileModel>>();
                var keysCacheService = services.GetRequiredService< ICacheService<IEnumerable<string>>>();
                var allProfiles = (await profilesRepository.GetAllItemsAsync()).ToList();
                foreach (var profile in allProfiles)
                {                   
                    await cacheService.SaveItem(profile.UserId, profile);
                }
            }
        }
    }
}