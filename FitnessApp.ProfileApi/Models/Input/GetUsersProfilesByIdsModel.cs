using FitnessApp.Common.Paged.Models.Input;

namespace FitnessApp.ProfileApi.Models.Input;

public class GetUsersProfilesByIdsModel : GetPagedDataModel
{
    public string[] UsersIds { get; set; }
}
