using AutoMapper;
using DDD_Domain.Entities;
using DDD_Domain.Models;

namespace DDD_CrossCutting.Mapping
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            //User
            CreateMap<UserModel, UserEntity>().ReverseMap();

            //Uf
            CreateMap<UfModel, UfEntity>().ReverseMap();

            //City
            CreateMap<CityModel, CityEntity>().ReverseMap();

            //PostalCode
            CreateMap<PostalCodeModel, PostalCodeEntity>().ReverseMap();
        }
    }
}
