using System;
using System.Linq;
using System.Threading.Tasks;
using DDD_Data.Context;
using DDD_Data.Repository;
using DDD_Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace DDD_Data_Test
{
    public class PostalCodeCompleteCRUDTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public PostalCodeCompleteCRUDTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }


        [Fact(DisplayName = "Postal Code CRUD operations")]
        [Trait("CRUD", "PostalCodeEntity")]
        public async Task IsPossibleCRUDInPostalCodeDatabase()
        {
            using (var context = _serviceProvider.GetService<MySQLContext>())
            {
                PostalCodeRepository repository = new PostalCodeRepository(context);
                CityRepository cityRepository = new CityRepository(context);

                CityEntity cityEntity = new CityEntity
                {
                    Name = Faker.Address.City(),
                    IbgeCode = Faker.RandomNumber.Next(1000000, 9999999),
                    UfId = new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                };

                var cityCreatedRecord = await cityRepository.CreateAsync(cityEntity);
                Assert.NotNull(cityCreatedRecord);
                Assert.Equal(cityEntity.Name, cityCreatedRecord.Name);
                Assert.Equal(cityEntity.IbgeCode, cityCreatedRecord.IbgeCode);
                Assert.Equal(cityEntity.UfId, cityCreatedRecord.UfId);
                Assert.False(cityCreatedRecord.Id == Guid.Empty);

                PostalCodeEntity entity = new PostalCodeEntity
                {
                    PostalCode = Faker.Address.ZipCode(),
                    Address = Faker.Address.StreetAddress(),
                    StreetNumber = Faker.RandomNumber.Next(1, 2000).ToString(),
                    CityId = cityCreatedRecord.Id
                };

                var createdRecord = await repository.CreateAsync(entity);
                Assert.NotNull(createdRecord);
                Assert.Equal(entity.PostalCode, createdRecord.PostalCode);
                Assert.Equal(entity.Address, createdRecord.Address);
                Assert.Equal(entity.StreetNumber, createdRecord.StreetNumber);
                Assert.Equal(entity.CityId, createdRecord.CityId);
                Assert.False(createdRecord.Id == Guid.Empty);

                entity.PostalCode = Faker.Address.ZipCode();
                entity.Id = createdRecord.Id;
                var updatedRecord = await repository.UpdateAsync(entity);
                Assert.NotNull(updatedRecord);
                Assert.Equal(entity.PostalCode, updatedRecord.PostalCode);
                Assert.Equal(entity.Address, updatedRecord.Address);
                Assert.Equal(entity.StreetNumber, updatedRecord.StreetNumber);
                Assert.True(createdRecord.Id == entity.Id);

                var recordExists = await repository.ExistsAsync(updatedRecord.Id);
                Assert.True(recordExists);

                var selectedRecord = await repository.FindByIdAsync(updatedRecord.Id);
                Assert.NotNull(selectedRecord);
                Assert.Equal(entity.PostalCode, selectedRecord.PostalCode);
                Assert.Equal(entity.Address, selectedRecord.Address);
                Assert.Equal(entity.StreetNumber, selectedRecord.StreetNumber);
                Assert.Equal(entity.CityId, selectedRecord.CityId);

                selectedRecord = await repository.FindByPostalCode(updatedRecord.PostalCode);
                Assert.NotNull(selectedRecord);
                Assert.Equal(entity.PostalCode, selectedRecord.PostalCode);
                Assert.Equal(entity.Address, selectedRecord.Address);
                Assert.Equal(entity.StreetNumber, selectedRecord.StreetNumber);
                Assert.Equal(entity.CityId, selectedRecord.CityId);
                Assert.NotNull(selectedRecord.City);
                Assert.Equal(cityEntity.Name, selectedRecord.City.Name);
                Assert.NotNull(selectedRecord.City.Uf);
                Assert.Equal(cityEntity.UfId, selectedRecord.City.Uf.Id);

                var allRecords = await repository.FindAllAsync();
                Assert.NotNull(allRecords);
                Assert.True(allRecords.Count() > 0);

                var recordRemoved = await repository.DeleteAsync(selectedRecord.Id);
                Assert.True(recordRemoved);

                allRecords = await repository.FindAllAsync();
                Assert.NotNull(allRecords);
                Assert.True(allRecords.Count() == 0);
            }
        }
    }
}
