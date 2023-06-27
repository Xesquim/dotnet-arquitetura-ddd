using Api.Domain.Dtos.City;
using Api.Domain.Dtos.Si;
using Api.Domain.Dtos.User;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            #region User
            CreateMap<UserDto, UserEntity>()
                .ReverseMap();
            CreateMap<UserDtoCreateResult, UserEntity>()
                .ReverseMap();
            CreateMap<UserDtoUpdateResult, UserEntity>()
                .ReverseMap();
            #endregion

            #region Si
            CreateMap<SiDto, SiEntity>()
                .ReverseMap();
            #endregion

            #region City
            CreateMap<CityDto, CityEntity>()
                .ReverseMap();
            CreateMap<CityDtoComplete, CityEntity>()
                .ReverseMap();
            CreateMap<CityDtoCreateResult, CityEntity>()
                .ReverseMap();
            CreateMap<CityDtoUpdateResult, CityEntity>()
                .ReverseMap();
            #endregion

            #region ZipCode
            CreateMap<ZipCodeDto, ZipCodeEntity>()
                .ReverseMap();
            CreateMap<ZipCodeDtoCreateResult, ZipCodeEntity>()
                .ReverseMap();
            CreateMap<ZipCodeDtoUpdateResult, ZipCodeEntity>()
                .ReverseMap();
            #endregion
        }
    }
}