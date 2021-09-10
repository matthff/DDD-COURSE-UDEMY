using AutoMapper;
using DDD_Domain.Entities;
using DDD_Domain.Models;

namespace DDD_CrossCutting.Mapping
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserModel, UserEntity>().ReverseMap();
        }
    }
}
