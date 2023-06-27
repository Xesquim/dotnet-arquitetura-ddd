using Api.Domain.Entities;
using Api.Domain.Models.City;
using Api.Domain.Models.Si;
using Api.Domain.Models.User;
using Api.Domain.Models.ZipCode;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            #region User
            CreateMap<UserEntity, UserModel>()
                .ReverseMap();
            #endregion

            #region Si
            CreateMap<SiEntity, SiModel>()
                .ReverseMap();
            #endregion

            #region City
            CreateMap<CityEntity, CityModel>()
                .ReverseMap();
            #endregion

            #region ZipCode
            CreateMap<ZipCodeEntity, ZipCodeModel>()
                .ReverseMap();
            #endregion
        }
    }
}