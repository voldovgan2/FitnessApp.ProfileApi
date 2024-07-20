using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.FileImage;
using FitnessApp.Common.Abstractions.Models.GenericFileAggregator;

namespace FitnessApp.ProfileApi.Models.Output;

public class UserProfileGenericFileAggregatorModel : IGenericFileAggregatorModel<UserProfileGenericModel>
{
    public UserProfileGenericModel Model { get; set; }
    public List<FileImageModel> Images { get; set; }
}
