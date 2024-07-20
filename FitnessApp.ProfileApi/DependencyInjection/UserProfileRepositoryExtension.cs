using System;
using AutoMapper;
using FitnessApp.Common.Abstractions.Db.DbContext;
using FitnessApp.ProfileApi.Data;
using FitnessApp.ProfileApi.Data.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace FitnessApp.ProfileApi.DependencyInjection;

public static class UserProfileRepositoryExtension
{
    public static IServiceCollection ConfigureUserProfileRepository(this IServiceCollection services)
    {
        ArgumentNullException.ThrowIfNull(services);

        services.AddTransient<IDbContext<UserProfileGenericEntity>, DbContext<UserProfileGenericEntity>>();
        services.AddTransient<IUserProfileRepository, UserProfileRepository>(
            sp =>
            {
                return new UserProfileRepository(
                    sp.GetRequiredService<IDbContext<UserProfileGenericEntity>>(),
                    sp.GetRequiredService<IMapper>()
                );
            }
        );

        return services;
    }
}
