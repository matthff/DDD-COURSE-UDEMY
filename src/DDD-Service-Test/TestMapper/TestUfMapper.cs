using System;
using System.Collections.Generic;
using System.Linq;
using DDD_Domain.DTOs.Uf;
using DDD_Domain.Entities;
using DDD_Domain.Models;
using Xunit;

namespace DDD_Service_Test.TestMapper
{
    public class TestUfMapper : BaseTestService
    {
        [Fact(DisplayName = "Is possible to map all models profiles")]
        public void MustMapAllModels()
        {
            var model = new UfModel
            {
                Id = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                FederatedUnit = "PB",
                Name = "Paraíba",
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            var entityList = new List<UfEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new UfEntity
                {
                    Id = Guid.NewGuid(),
                    FederatedUnit = Faker.Address.UsState().Substring(1, 3),
                    Name = Faker.Address.UsState(),
                    CreatedAt = DateTime.UtcNow,
                    //Need some cities?
                    UpdatedAt = DateTime.UtcNow

                };
                entityList.Add(item);
            }

            //Model -> Entity
            var entity = Mapper.Map<UfEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.FederatedUnit, model.FederatedUnit);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.CreatedAt, model.CreatedAt);
            Assert.Equal(entity.UpdatedAt, model.UpdatedAt);

            //Entity -> DTO
            var ufDTO = Mapper.Map<UfDTO>(entity);
            Assert.Equal(ufDTO.Id, entity.Id);
            Assert.Equal(ufDTO.FederatedUnit, entity.FederatedUnit);
            Assert.Equal(ufDTO.Name, entity.Name);

            var listDTO = Mapper.Map<List<UfDTO>>(entityList);
            Assert.True(listDTO.Count() == entityList.Count());
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(listDTO[i].Id, entityList[i].Id);
                Assert.Equal(listDTO[i].FederatedUnit, entityList[i].FederatedUnit);
                Assert.Equal(listDTO[i].Name, entityList[i].Name);
            }

            //DTO -> Model
            var ufModel = Mapper.Map<UfModel>(ufDTO);
            Assert.Equal(ufModel.Id, ufDTO.Id);
            Assert.Equal(ufModel.FederatedUnit, ufDTO.FederatedUnit);
            Assert.Equal(ufModel.Name, ufDTO.Name);
        }
    }
}
