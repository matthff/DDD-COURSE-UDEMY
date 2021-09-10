using AutoMapper;
using DDD_Domain.DTOs.User;
using DDD_Domain.Models;

namespace DDD_CrossCutting.Mapping
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            CreateMap<UserModel, UserDTO>().ReverseMap();
            CreateMap<UserModel, UserCreateDTO>().ReverseMap();
            CreateMap<UserModel, UserUpdateDTO>().ReverseMap();
        }
    }
}
