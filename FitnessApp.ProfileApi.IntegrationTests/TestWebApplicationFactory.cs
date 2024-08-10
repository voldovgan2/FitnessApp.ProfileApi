using FitnessApp.Common.IntegrationTests;
using FitnessApp.ProfileApi.Data.Entities;

namespace FitnessApp.ProfileApi.IntegrationTests;
public class TestWebApplicationFactory(MongoDbFixture fixture) :
    TestGenericFileAggregatorWebApplicationFactoryBase<
        Program,
        MockAuthenticationHandler,
        UserProfileGenericEntity>(fixture);
