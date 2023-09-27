using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.BlobImage;
using FitnessApp.Common.Abstractions.Models.GenericBlobAggregator;

namespace FitnessApp.ProfileApi.Models.Output
{
    public class UserProfileGenericBlobAggregatorModel : IGenericBlobAggregatorModel<UserProfileGenericModel>
    {
        public UserProfileGenericModel Model { get; set; }
        public List<BlobImageModel> Images { get; set; }
    }
}
