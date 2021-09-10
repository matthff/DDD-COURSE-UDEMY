using AutoMapper;
using DDD_Domain.DTOs.User;
using DDD_Domain.Entities;

namespace DDD_CrossCutting.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDTO, UserEntity>().ReverseMap();
            CreateMap<UserCreateResultDTO, UserEntity>().ReverseMap();
            CreateMap<UserUpdateResultDTO, UserEntity>().ReverseMap();
        }
    }
}
