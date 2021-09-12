using System;
using AutoMapper;
using DDD_CrossCutting.Mapping;
using Xunit;

namespace DDD_Service_Test
{
    public abstract class BaseTestService
    {
        public IMapper Mapper { get; set; }
        public BaseTestService()
        {
            Mapper = new AutoMapperFixture().GetMapper();
        }

        public class AutoMapperFixture : IDisposable
        {
            public IMapper GetMapper()
            {
                var configMapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new DtoToModelProfile());
                    cfg.AddProfile(new EntityToDtoProfile());
                    cfg.AddProfile(new ModelToEntityProfile());
                });

                return configMapper.CreateMapper();
            }
            
            public void Dispose()
            {
                throw new NotImplementedException();
            }
        }
    }
}
