using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using FitnessApp.Common.Abstractions.Models.BlobImage;
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
            #region Contract 2 GenericBlobAggregatorModel
            CreateMap<CreateUserProfileContract, CreateUserProfileGenericBlobAggregatorModel>()
                .ForMember(m => m.Images, c => c.MapFrom(c => new List<BlobImageModel>
                {
                    new BlobImageModel
                    {
                        FieldName = "BackgroundPhoto",
                        Value = c.BackgroundPhoto
                    },
                    new BlobImageModel
                    {
                        FieldName = "CroppedProfilePhoto",
                        Value = c.CroppedProfilePhoto
                    },
                    new BlobImageModel
                    {
                        FieldName = "OriginalProfilePhoto",
                        Value = c.OriginalProfilePhoto
                    }
                }));
            CreateMap<UpdateUserProfileContract, UpdateUserProfileGenericBlobAggregatorModel>()
                .ForMember(m => m.Images, c => c.MapFrom(c => new List<BlobImageModel>
                {
                    new BlobImageModel
                    {
                        FieldName = "BackgroundPhoto",
                        Value = c.BackgroundPhoto
                    },
                    new BlobImageModel
                    {
                        FieldName = "CroppedProfilePhoto",
                        Value = c.CroppedProfilePhoto
                    },
                    new BlobImageModel
                    {
                        FieldName = "OriginalProfilePhoto",
                        Value = c.OriginalProfilePhoto
                    }
                }));
            #endregion

            #region GenericBlobAggregatorModel 2 GenericModel
            CreateMap<CreateUserProfileGenericBlobAggregatorModel, CreateUserProfileGenericModel>();
            CreateMap<UpdateUserProfileGenericBlobAggregatorModel, UpdateUserProfileGenericModel>();
            #endregion

            #region GenericModel 2 GenericEntity
            CreateMap<CreateUserProfileGenericModel, UserProfileGenericEntity>();
            CreateMap<UpdateUserProfileGenericModel, UserProfileGenericEntity>();
            CreateMap<UserProfileGenericModel, UserProfileGenericEntity>();
            #endregion

            #region GenericEntity 2 GenericModel
            CreateMap<UserProfileGenericEntity, UserProfileGenericModel>();
            #endregion

            #region GenericBlobAggregatorModel 2 Contract
            CreateMap<UserProfileGenericBlobAggregatorModel, UserProfileContract>()
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
                .ForMember(c => c.BackgroundPhoto, m => m.MapFrom(m => MapBlobField(nameof(UserProfileContract.BackgroundPhoto), m)))
                .ForMember(c => c.CroppedProfilePhoto, m => m.MapFrom(m => MapBlobField(nameof(UserProfileContract.CroppedProfilePhoto), m)))
                .ForMember(c => c.OriginalProfilePhoto, m => m.MapFrom(m => MapBlobField(nameof(UserProfileContract.OriginalProfilePhoto), m)));
            #endregion
        }

        private static string MapBlobField(string fieldName, UserProfileGenericBlobAggregatorModel model)
        {
            var result = model.Images.SingleOrDefault(i => i.FieldName == fieldName)?.Value;
            return result;
        }
    }
}