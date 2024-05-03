using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FitnessApp.Common.Abstractions.Models.FileImage;
using FitnessApp.ProfileApi.Contracts.Input;
using FitnessApp.ProfileApi.Contracts.Output;
using FitnessApp.ProfileApi.Data.Entities;
using FitnessApp.ProfileApi.Models.Input;
using FitnessApp.ProfileApi.Models.Output;

namespace FitnessApp.ProfileApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Contract 2 GenericFileAggregatorModel
            CreateMap<CreateUserProfileContract, CreateUserProfileGenericFileAggregatorModel>()
                .ForMember(m => m.Images, c => c.MapFrom(c => new List<FileImageModel>
                {
                    new()
                    {
                        FieldName = "BackgroundPhoto",
                        Value = c.BackgroundPhoto
                    },
                    new()
                    {
                        FieldName = "CroppedProfilePhoto",
                        Value = c.CroppedProfilePhoto
                    },
                    new()
                    {
                        FieldName = "OriginalProfilePhoto",
                        Value = c.OriginalProfilePhoto
                    }
                }));
            CreateMap<UpdateUserProfileContract, UpdateUserProfileGenericFileAggregatorModel>()
                .ForMember(m => m.Images, c => c.MapFrom(c => new List<FileImageModel>
                {
                    new()
                    {
                        FieldName = "BackgroundPhoto",
                        Value = c.BackgroundPhoto
                    },
                    new()
                    {
                        FieldName = "CroppedProfilePhoto",
                        Value = c.CroppedProfilePhoto
                    },
                    new()
                    {
                        FieldName = "OriginalProfilePhoto",
                        Value = c.OriginalProfilePhoto
                    }
                }));
            #endregion

            #region GenericFileAggregatorModel 2 GenericModel
            CreateMap<CreateUserProfileGenericFileAggregatorModel, CreateUserProfileGenericModel>();
            CreateMap<UpdateUserProfileGenericFileAggregatorModel, UpdateUserProfileGenericModel>();
            #endregion

            #region GenericModel 2 GenericEntity
            CreateMap<CreateUserProfileGenericModel, UserProfileGenericEntity>();
            CreateMap<UpdateUserProfileGenericModel, UserProfileGenericEntity>();
            CreateMap<UserProfileGenericModel, UserProfileGenericEntity>();
            #endregion

            #region GenericEntity 2 GenericModel
            CreateMap<UserProfileGenericEntity, UserProfileGenericModel>();
            #endregion

            #region GenericFileAggregatorModel 2 Contract
            CreateMap<UserProfileGenericFileAggregatorModel, UserProfileContract>()
                .ForMember(c => c.UserId, m => m.MapFrom(m => m.Model.UserId))
                .ForMember(c => c.Email, m => m.MapFrom(m => m.Model.Email))
                .ForMember(c => c.FirstName, m => m.MapFrom(m => m.Model.FirstName))
                .ForMember(c => c.LastName, m => m.MapFrom(m => m.Model.LastName))
                .ForMember(c => c.BirthDate, m => m.MapFrom(m => m.Model.BirthDate))
                .ForMember(c => c.Height, m => m.MapFrom(m => m.Model.Height))
                .ForMember(c => c.Weight, m => m.MapFrom(m => m.Model.Weight))
                .ForMember(c => c.Gender, m => m.MapFrom(m => m.Model.Gender))
                .ForMember(c => c.About, m => m.MapFrom(m => m.Model.About))
                .ForMember(c => c.Language, m => m.MapFrom(m => m.Model.Language))
                .ForMember(c => c.BackgroundPhoto, m => m.MapFrom(m => MapFileField(nameof(UserProfileContract.BackgroundPhoto), m)))
                .ForMember(c => c.CroppedProfilePhoto, m => m.MapFrom(m => MapFileField(nameof(UserProfileContract.CroppedProfilePhoto), m)))
                .ForMember(c => c.OriginalProfilePhoto, m => m.MapFrom(m => MapFileField(nameof(UserProfileContract.OriginalProfilePhoto), m)));
            #endregion
        }

        private static string MapFileField(string fieldName, UserProfileGenericFileAggregatorModel model)
        {
            var result = model.Images.SingleOrDefault(i => i.FieldName == fieldName)?.Value;
            return result;
        }
    }
}