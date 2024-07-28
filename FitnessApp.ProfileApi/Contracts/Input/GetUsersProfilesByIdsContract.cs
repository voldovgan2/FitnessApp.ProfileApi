using FitnessApp.Common.Paged.Contracts.Input;

namespace FitnessApp.ProfileApi.Contracts.Input;

public class GetUsersProfilesByIdsContract : GetPagedDataContract
{
    public string[] UsersIds { get; set; }
}
