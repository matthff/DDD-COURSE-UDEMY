using AutoMapper;
using DDD_Domain.DTOs.City;
using DDD_Domain.DTOs.PostalCode;
using DDD_Domain.DTOs.Uf;
using DDD_Domain.DTOs.User;
using DDD_Domain.Entities;

namespace DDD_CrossCutting.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            //User
            CreateMap<UserDTO, UserEntity>().ReverseMap();
            CreateMap<UserCreateResultDTO, UserEntity>().ReverseMap();
            CreateMap<UserUpdateResultDTO, UserEntity>().ReverseMap();

            //Uf
            CreateMap<UfDTO, UfEntity>().ReverseMap();

            //City
            CreateMap<CityDTO, CityEntity>().ReverseMap();
            CreateMap<CityCompleteDTO, CityEntity>().ReverseMap();
            CreateMap<CityCreateResultDTO, CityEntity>().ReverseMap();
            CreateMap<CityUpdateResultDTO, CityEntity>().ReverseMap();

            //PostalCode
            CreateMap<PostalCodeDTO, PostalCodeEntity>().ReverseMap();
            CreateMap<PostalCodeCreateResultDTO, PostalCodeEntity>().ReverseMap();
            CreateMap<PostalCodeUpdateResultDTO, PostalCodeEntity>().ReverseMap();
        }
    }
}
