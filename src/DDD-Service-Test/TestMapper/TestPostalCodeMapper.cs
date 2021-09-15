using System;
using System.Collections.Generic;
using System.Linq;
using DDD_Domain.DTOs.PostalCode;
using DDD_Domain.Entities;
using DDD_Domain.Models;
using Xunit;

namespace DDD_Service_Test.TestMapper
{
    public class TestPostalCodeMapper : BaseTestService
    {
        [Fact(DisplayName = "Is possible to map all models profiles")]
        public void TestName()
        {
            var model = new PostalCodeModel
            {
                Id = Guid.NewGuid(),
                PostalCode = Faker.RandomNumber.Next(1, 10000).ToString(),
                Address = Faker.Address.StreetName(),
                StreetNumber = Faker.RandomNumber.Next(1, 2000).ToString(),
                CityId = Guid.NewGuid(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var entityList = new List<PostalCodeEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new PostalCodeEntity
                {
                    Id = Guid.NewGuid(),
                    PostalCode = Faker.RandomNumber.Next(1, 10000).ToString(),
                    Address = Faker.Address.StreetName(),
                    StreetNumber = Faker.RandomNumber.Next(1, 10000).ToString(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    CityId = Guid.NewGuid(),
                    City = new CityEntity
                    {
                        Id = Guid.NewGuid(),
                        Name = Faker.Address.UsState(),
                        IbgeCode = Faker.RandomNumber.Next(1000000, 9999999),
                        UfId = Guid.NewGuid(),
                        Uf = new UfEntity
                        {
                            Id = Guid.NewGuid(),
                            FederatedUnit = Faker.Address.UsState().Substring(1, 3),
                            Name = Faker.Address.UsState()
                        }
                    }
                };
                entityList.Add(item);
            }

            //Model -> Entity
            var entity = Mapper.Map<PostalCodeEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.PostalCode, model.PostalCode);
            Assert.Equal(entity.Address, model.Address);
            Assert.Equal(entity.StreetNumber, model.StreetNumber);
            Assert.Equal(entity.CreatedAt, model.CreatedAt);
            Assert.Equal(entity.UpdatedAt, model.UpdatedAt);

            //Entity -> DTO

            var postalCodeDTO = Mapper.Map<PostalCodeDTO>(entity);
            Assert.Equal(postalCodeDTO.Id, entity.Id);
            Assert.Equal(postalCodeDTO.PostalCode, entity.PostalCode);
            Assert.Equal(postalCodeDTO.Address, entity.Address);
            Assert.Equal(postalCodeDTO.StreetNumber, entity.StreetNumber);

            var postalCodeCompleteDTO = Mapper.Map<PostalCodeDTO>(entityList.FirstOrDefault());
            Assert.Equal(postalCodeCompleteDTO.Id, entityList.FirstOrDefault().Id);
            Assert.Equal(postalCodeCompleteDTO.PostalCode, entityList.FirstOrDefault().PostalCode);
            Assert.Equal(postalCodeCompleteDTO.Address, entityList.FirstOrDefault().Address);
            Assert.Equal(postalCodeCompleteDTO.StreetNumber, entityList.FirstOrDefault().StreetNumber);
            Assert.NotNull(postalCodeCompleteDTO.City);
            Assert.NotNull(postalCodeCompleteDTO.City.Uf);

            var listDTO = Mapper.Map<List<PostalCodeDTO>>(entityList);
            Assert.True(listDTO.Count() == entityList.Count());
            for (int i = 0; i < 5; i++)
            {
                Assert.Equal(listDTO[i].Id, entityList[i].Id);
                Assert.Equal(listDTO[i].PostalCode, entityList[i].PostalCode);
                Assert.Equal(listDTO[i].Address, entityList[i].Address);
                Assert.Equal(listDTO[i].StreetNumber, entityList[i].StreetNumber);
            }

            var postalCodeCreatedDTO = Mapper.Map<PostalCodeCreateResultDTO>(entity);
            Assert.Equal(postalCodeCreatedDTO.Id, entity.Id);
            Assert.Equal(postalCodeCreatedDTO.PostalCode, entity.PostalCode);
            Assert.Equal(postalCodeCreatedDTO.Address, entity.Address);
            Assert.Equal(postalCodeCreatedDTO.StreetNumber, entity.StreetNumber);
            Assert.Equal(postalCodeCreatedDTO.CreatedAt, entity.CreatedAt);

            var postalCodeUpdatedDTO = Mapper.Map<PostalCodeUpdateResultDTO>(entity);
            Assert.Equal(postalCodeUpdatedDTO.Id, entity.Id);
            Assert.Equal(postalCodeUpdatedDTO.PostalCode, entity.PostalCode);
            Assert.Equal(postalCodeUpdatedDTO.Address, entity.Address);
            Assert.Equal(postalCodeUpdatedDTO.StreetNumber, entity.StreetNumber);
            Assert.Equal(postalCodeUpdatedDTO.UpdatedAt, entity.UpdatedAt);

            //DTO -> Model

            var postalCodeModel = Mapper.Map<PostalCodeModel>(postalCodeDTO);
            Assert.Equal(postalCodeModel.Id, postalCodeDTO.Id);
            Assert.Equal(postalCodeModel.PostalCode, postalCodeDTO.PostalCode);
            Assert.Equal(postalCodeModel.Address, postalCodeDTO.Address);
            Assert.Equal(postalCodeModel.StreetNumber, postalCodeDTO.StreetNumber);

            var postalCodeCreateDTO = Mapper.Map<PostalCodeCreateDTO>(postalCodeModel);
            Assert.Equal(postalCodeCreateDTO.PostalCode, postalCodeModel.PostalCode);
            Assert.Equal(postalCodeCreateDTO.Address, postalCodeModel.Address);
            Assert.Equal(postalCodeCreateDTO.StreetNumber, postalCodeModel.StreetNumber);

            var postalCodeUpdateDTO = Mapper.Map<PostalCodeUpdateDTO>(postalCodeModel);
            Assert.Equal(postalCodeUpdateDTO.Id, postalCodeModel.Id);
            Assert.Equal(postalCodeUpdateDTO.PostalCode, postalCodeModel.PostalCode);
            Assert.Equal(postalCodeUpdateDTO.Address, postalCodeModel.Address);
            Assert.Equal(postalCodeUpdateDTO.StreetNumber, postalCodeModel.StreetNumber);
        }
    }
}
