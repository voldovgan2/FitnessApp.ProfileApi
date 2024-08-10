using System.Net.Http.Json;
using FitnessApp.Common.IntegrationTests;
using FitnessApp.ProfileApi.Contracts.Input;

namespace FitnessApp.ProfileApi.IntegrationTests;
public class UserProfileControllerTests : IClassFixture<MongoDbFixture>
{
    private readonly HttpClient _httpClient;

    public UserProfileControllerTests(MongoDbFixture fixture)
    {
        var appFactory = new TestWebApplicationFactory(fixture);
        _httpClient = appFactory.CreateHttpClient();
    }

    [Fact]
    public async Task FilterUserProfiles_ReturnsOk()
    {
        var contract = new GetUserProfilesContract
        {
            Page = 0,
            PageSize = 10,
            Search = MockConstants.SvTest,
        };

        // Act
        var response = await _httpClient.PostAsJsonAsync("api/UserProfile/FilterUserProfiles", contract);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetUsersProfilesByIds_ReturnsOk()
    {
        var contract = new GetUsersProfilesByIdsContract
        {
            Page = 0,
            PageSize = 10,
            UsersIds = new string[] { MockConstants.SvTest },
        };

        // Act
        var response = await _httpClient.PostAsJsonAsync("api/UserProfile/GetUsersProfilesByIds", contract);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task GetUserProfile_ReturnsOk()
    {
        // Act
        var response = await _httpClient.GetAsync($"api/UserProfile/GetUserProfile/{IdsConstants.IdToGet}");

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task CreateUserProfile_ReturnsOk()
    {
        // Arrange
        var createSettingsContract = new CreateUserProfileContract
        {
            UserId = IdsConstants.IdToCreate,
            FirstName = "FirstName",
            LastName = "LastName",
            About = "About",
            Language = "Language",
            BirthDate = DateTime.Now,
            Email = "Email",
            Height = 180,
            Weight = 75,
            Gender = Enums.Gender.Male,
            BackgroundPhoto = "BackgroundPhoto",
            CroppedProfilePhoto = "CroppedProfilePhoto",
            OriginalProfilePhoto = "OriginalProfilePhoto",
        };

        // Act
        var response = await _httpClient.PostAsJsonAsync("api/UserProfile/CreateUserProfile", createSettingsContract);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task UpdateUserProfile_ReturnsOk()
    {
        // Arrange
        var updateSettingsContract = new UpdateUserProfileContract
        {
            UserId = IdsConstants.IdToUpdate,
            FirstName = "FirstName",
            LastName = "LastName",
            About = "About",
            Language = "Language",
            BirthDate = DateTime.Now,
            Email = "Email",
            Height = 180,
            Weight = 75,
            Gender = Enums.Gender.Male,
            BackgroundPhoto = "BackgroundPhoto",
            CroppedProfilePhoto = "CroppedProfilePhoto",
            OriginalProfilePhoto = "OriginalProfilePhoto",
        };

        // Act
        var response = await _httpClient.PutAsJsonAsync("api/UserProfile/UpdateUserProfile", updateSettingsContract);

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }

    [Fact]
    public async Task DeleteUserProfile_ReturnsOk()
    {
        // Act
        var response = await _httpClient.DeleteAsync($"api/UserProfile/DeleteUserProfile/{IdsConstants.IdToDelete}");

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }
}
