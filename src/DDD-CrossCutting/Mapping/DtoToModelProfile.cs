using AutoMapper;
using DDD_Domain.DTOs.City;
using DDD_Domain.DTOs.PostalCode;
using DDD_Domain.DTOs.Uf;
using DDD_Domain.DTOs.User;
using DDD_Domain.Models;

namespace DDD_CrossCutting.Mapping
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            //User
            CreateMap<UserModel, UserDTO>().ReverseMap();
            CreateMap<UserModel, UserCreateDTO>().ReverseMap();
            CreateMap<UserModel, UserUpdateDTO>().ReverseMap();

            //Uf
            CreateMap<UfModel, UfDTO>().ReverseMap();

            //City
            CreateMap<CityModel, CityDTO>().ReverseMap();
            CreateMap<CityModel, CityCompleteDTO>().ReverseMap();
            CreateMap<CityModel, CityCreateDTO>().ReverseMap();
            CreateMap<CityModel, CityUpdateDTO>().ReverseMap();

            //PostalCode
            CreateMap<PostalCodeModel, PostalCodeDTO>().ReverseMap();
            CreateMap<PostalCodeModel, PostalCodeCreateDTO>().ReverseMap();
            CreateMap<PostalCodeModel, PostalCodeUpdateDTO>().ReverseMap();
        }
    }
}
