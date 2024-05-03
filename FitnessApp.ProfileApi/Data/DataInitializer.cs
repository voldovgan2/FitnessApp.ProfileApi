using System;
using System.Threading.Tasks;
using FitnessApp.ProfileApi.Models.Input;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FitnessApp.ProfileApi.Data
{
    public static class DataInitializer
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public static async Task EnsureProfilesAreCreated(IServiceProvider serviceProvider)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            /*
            using (var scope = serviceProvider.CreateScope())
            {
                var services = scope.ServiceProvider;
                var repository = services.GetRequiredService<IUserProfileAggregatorService>();
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
                            //logger.WriteInformation($"Mops found: First name: {user.FirstName} Last name: {user.LastName} About: {user.About}");
                        }
                        await repository.CreateItemAsync(user);
                    }
                }
                var adminEmail = "admin@hotmail.com";
                var adminId = $"ApplicationUser_{adminEmail}";
                var adminProfile = await repository.GetUserProfileAsync(adminId);
                if (adminProfile == null)
                {
                    await repository.CreateUserProfileAsync(CreateGenericFileAggregatorUserProfileModel.Default(adminId, adminEmail, true));
                }
            }
            */
        }
    }
}