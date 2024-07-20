using System;
using System.Collections.Generic;
using FitnessApp.Common.Abstractions.Models.FileImage;
using FitnessApp.Common.Abstractions.Models.GenericFileAggregator;
using FitnessApp.ProfileApi.Enums;

namespace FitnessApp.ProfileApi.Models.Input;

public class UpdateUserProfileGenericFileAggregatorModel : IUpdateGenericFileAggregatorModel
{
    public string UserId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? BirthDate { get; set; }
    public double? Height { get; set; }
    public double? Weight { get; set; }
    public Gender? Gender { get; set; }
    public string About { get; set; }
    public string Language { get; set; }
    public List<FileImageModel> Images { get; set; }
}