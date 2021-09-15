using System;
using System.Collections.Generic;
using System.Linq;
using DDD_Domain.DTOs.City;
using DDD_Domain.Entities;
using DDD_Domain.Models;
using Xunit;

namespace DDD_Service_Test.TestMapper
{
    public class TestCityMapper : BaseTestService
    {
        [Fact(DisplayName = "Is possible to map all models profiles")]
        public void TestName()
        {
            var model = new CityModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Address.City(),
                IbgeCode = Faker.RandomNumber.Next(1000000, 9999999),
                UfId = new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var entityList = new List<CityEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new CityEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Address.UsState(),
                    IbgeCode = Faker.RandomNumber.Next(1000000, 9999999),
                    UfId = Guid.NewGuid(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Uf = new UfEntity
                    {
                        Id = Guid.NewGuid(),
                        FederatedUnit = Faker.Address.UsState().Substring(1, 3),
                        Name = Faker.Address.UsState()
                    }
                };
                entityList.Add(item);
            }

            //Model -> Entity
            var entity = Mapper.Map<CityEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.IbgeCode, model.IbgeCode);
            Assert.Equal(entity.UfId, model.UfId);
            Assert.Equal(entity.CreatedAt, model.CreatedAt);
            Assert.Equal(entity.UpdatedAt, model.UpdatedAt);

            //Entity -> DTO

            var cityDTO = Mapper.Map<CityDTO>(entity);
            Assert.Equal(cityDTO.Id, entity.Id);
            Assert.Equal(cityDTO.Name, entity.Name);
            Assert.Equal(cityDTO.IbgeCode, entity.IbgeCode);
            Assert.Equal(cityDTO.UfId, entity.UfId);

            var cityCompleteDTO = Mapper.Map<CityCompleteDTO>(entityList.FirstOrDefault());
            Assert.Equal(cityCompleteDTO.Id, entityList.FirstOrDefault().Id);
            Assert.Equal(cityCompleteDTO.Name, entityList.FirstOrDefault().Name);
            Assert.Equal(cityCompleteDTO.IbgeCode, entityList.FirstOrDefault().IbgeCode);
            Assert.Equal(cityCompleteDTO.UfId, entityList.FirstOrDefault().UfId);
            Assert.NotNull(cityCompleteDTO.Uf);

            var listDTO = Mapper.Map<List<CityDTO>>(entityList);
            Assert.True(listDTO.Count() == entityList.Count());
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(listDTO[i].Id, entityList[i].Id);
                Assert.Equal(listDTO[i].Name, entityList[i].Name);
                Assert.Equal(listDTO[i].IbgeCode, entityList[i].IbgeCode);
                Assert.Equal(listDTO[i].UfId, entityList[i].UfId);
            }

            var cityCreatedDTO = Mapper.Map<CityCreateResultDTO>(entity);
            Assert.Equal(cityCreatedDTO.Id, entity.Id);
            Assert.Equal(cityCreatedDTO.Name, entity.Name);
            Assert.Equal(cityCreatedDTO.IbgeCode, entity.IbgeCode);
            Assert.Equal(cityCreatedDTO.UfId, entity.UfId);
            Assert.Equal(cityCreatedDTO.CreatedAt, entity.CreatedAt);

            var cityUpdatedDTO = Mapper.Map<CityUpdateResultDTO>(entity);
            Assert.Equal(cityUpdatedDTO.Id, entity.Id);
            Assert.Equal(cityUpdatedDTO.Name, entity.Name);
            Assert.Equal(cityUpdatedDTO.IbgeCode, entity.IbgeCode);
            Assert.Equal(cityUpdatedDTO.UfId, entity.UfId);
            Assert.Equal(cityUpdatedDTO.UpdatedAt, entity.UpdatedAt);

            //DTO -> Model

            var cityModel = Mapper.Map<CityModel>(cityDTO);
            Assert.Equal(cityModel.Id, cityDTO.Id);
            Assert.Equal(cityModel.Name, cityDTO.Name);
            Assert.Equal(cityModel.IbgeCode, cityDTO.IbgeCode);
            Assert.Equal(cityModel.UfId, cityDTO.UfId);

            var cityCreateDTO = Mapper.Map<CityCreateDTO>(cityModel);
            Assert.Equal(cityCreateDTO.Name, cityModel.Name);
            Assert.Equal(cityCreateDTO.IbgeCode, cityModel.IbgeCode);
            Assert.Equal(cityCreateDTO.UfId, cityModel.UfId);

            var cityUpdateDTO = Mapper.Map<CityUpdateDTO>(cityModel);
            Assert.Equal(cityUpdateDTO.Id, cityModel.Id);
            Assert.Equal(cityUpdateDTO.Name, cityModel.Name);
            Assert.Equal(cityUpdateDTO.IbgeCode, cityModel.IbgeCode);
            Assert.Equal(cityUpdateDTO.UfId, cityModel.UfId);
        }
    }
}
