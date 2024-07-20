﻿using System;
using FitnessApp.Common.Abstractions.Db.Entities.Generic;
using FitnessApp.ProfileApi.Enums;
using MongoDB.Bson.Serialization.Attributes;

namespace FitnessApp.ProfileApi.Data.Entities;

public class UserProfileGenericEntity : IGenericEntity
{
    [BsonId]
    public string UserId { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }
    public double Height { get; set; }
    public double Weight { get; set; }
    public Gender Gender { get; set; }
    public string About { get; set; }
    public string Language { get; set; }
    public string Partition { get; set; }
}