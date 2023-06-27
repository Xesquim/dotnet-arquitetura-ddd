using Api.Domain.Dtos.City;
using Api.Domain.Dtos.Si;
using Api.Domain.Dtos.User;
using Api.Domain.Dtos.ZipCode;
using Api.Domain.Models.City;
using Api.Domain.Models.Si;
using Api.Domain.Models.User;
using Api.Domain.Models.ZipCode;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region User    
            CreateMap<UserModel, UserDto>()
                .ReverseMap();
            CreateMap<UserModel, UserDtoCreate>()
                .ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>()
                .ReverseMap();
            #endregion

            #region Si
            CreateMap<SiModel, SiDto>()
                .ReverseMap();
            #endregion

            #region City
            CreateMap<CityModel, CityDto>()
                .ReverseMap();
            CreateMap<CityModel, CityDtoCreate>()
                .ReverseMap();
            CreateMap<CityModel, CityDtoUpdate>()
                .ReverseMap();
            #endregion

            #region ZipCode
            CreateMap<ZipCodeModel, ZipCodeDto>()
                .ReverseMap();
            CreateMap<ZipCodeModel, ZipCodeDtoCreate>()
                .ReverseMap();
            CreateMap<ZipCodeModel, ZipCodeDtoUpdate>()
                .ReverseMap();
            #endregion
        }
    }
}