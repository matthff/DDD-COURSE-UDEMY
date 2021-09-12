using System;
using System.Collections.Generic;
using System.Linq;
using DDD_Domain.DTOs.User;
using DDD_Domain.Entities;
using DDD_Domain.Models;
using DDD_Service_Test.TestUser;
using Xunit;

namespace DDD_Service_Test.TestMapper
{
    public class TestUserMappers : BaseTestService
    {
        [Fact(DisplayName = "Is possible to map all models profiles")]
        public void MustMapAllModels()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var entityList = new List<UserEntity>();
            for (int i = 0; i < 5; i++)
            {
                var item = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                entityList.Add(item);
            }

            //Model -> Entity
            var entity = Mapper.Map<UserEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Email, model.Email);
            Assert.Equal(entity.CreatedAt, model.CreatedAt);
            Assert.Equal(entity.UpdatedAt, model.UpdatedAt);

            //Entity -> DTO
            var userDTO = Mapper.Map<UserDTO>(entity);
            Assert.Equal(userDTO.Id, entity.Id);
            Assert.Equal(userDTO.Name, entity.Name);
            Assert.Equal(userDTO.Email, entity.Email);
            Assert.Equal(userDTO.CreatedAt, entity.CreatedAt);

            var listDTO = Mapper.Map<List<UserDTO>>(entityList);
            Assert.True(listDTO.Count() == entityList.Count());
            for (int i = 0; i < listDTO.Count(); i++)
            {
                Assert.Equal(listDTO[i].Id, entityList[i].Id);
                Assert.Equal(listDTO[i].Name, entityList[i].Name);
                Assert.Equal(listDTO[i].Email, entityList[i].Email);
                Assert.Equal(listDTO[i].CreatedAt, entityList[i].CreatedAt);
            }

            var userCreateDTO = Mapper.Map<UserCreateResultDTO>(entity);
            Assert.Equal(userCreateDTO.Id, entity.Id);
            Assert.Equal(userCreateDTO.Name, entity.Name);
            Assert.Equal(userCreateDTO.Email, entity.Email);
            Assert.Equal(userCreateDTO.CreatedAt, entity.CreatedAt);

            var userUpdateDTO = Mapper.Map<UserUpdateResultDTO>(entity);
            Assert.Equal(userUpdateDTO.Id, entity.Id);
            Assert.Equal(userUpdateDTO.Name, entity.Name);
            Assert.Equal(userUpdateDTO.Email, entity.Email);
            Assert.Equal(userUpdateDTO.UpdatedAt, entity.UpdatedAt);

            //DTO -> Model

            var userModel = Mapper.Map<UserModel>(userDTO);
            Assert.Equal(userModel.Id, userDTO.Id);
            Assert.Equal(userModel.Name, userDTO.Name);
            Assert.Equal(userModel.Email, userDTO.Email);
            Assert.Equal(userModel.CreatedAt, userDTO.CreatedAt);

            var userDtoCreate = Mapper.Map<UserCreateDTO>(userModel);
            Assert.Equal(userDtoCreate.Name, userModel.Name);
            Assert.Equal(userDtoCreate.Email, userModel.Email);

            var userDtoUpdate = Mapper.Map<UserUpdateDTO>(userModel);
            Assert.Equal(userUpdateDTO.Id, userModel.Id);
            Assert.Equal(userUpdateDTO.Name, userModel.Name);
            Assert.Equal(userUpdateDTO.Email, userModel.Email);
        }
    }
}