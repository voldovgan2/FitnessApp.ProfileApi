using FitnessApp.Common.IntegrationTests;
using FitnessApp.ProfileApi.Data.Entities;

namespace FitnessApp.ProfileApi.IntegrationTests;
public class MongoDbFixture() : MongoDbFixtureBase<UserProfileGenericEntity>("FitnessProfiles", "Profiles");
