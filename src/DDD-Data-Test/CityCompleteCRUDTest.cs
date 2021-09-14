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
    public class CityCompleteCRUDTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public CityCompleteCRUDTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }


        [Fact(DisplayName = "City CRUD operations")]
        [Trait("CRUD", "CityEntity")]
        public async Task IsPossibleCRUDInCityDatabase()
        {
            using (var context = _serviceProvider.GetService<MySQLContext>())
            {
                CityRepository repository = new CityRepository(context);
                CityEntity entity = new CityEntity
                {
                    Name = Faker.Address.City(),
                    IbgeCode = Faker.RandomNumber.Next(1000000, 9999999),
                    UfId = new Guid("ad5969bd-82dc-4e23-ace2-d8495935dd2e"),
                };

                var createdRecord = await repository.CreateAsync(entity);
                Assert.NotNull(createdRecord);
                Assert.Equal(entity.Name, createdRecord.Name);
                Assert.Equal(entity.IbgeCode, createdRecord.IbgeCode);
                Assert.Equal(entity.UfId, createdRecord.UfId);
                Assert.False(createdRecord.Id == Guid.Empty);

                entity.Name = Faker.Address.City();
                entity.Id = createdRecord.Id;
                var updatedRecord = await repository.UpdateAsync(entity);
                Assert.NotNull(updatedRecord);
                Assert.Equal(entity.Name, updatedRecord.Name);
                Assert.Equal(entity.IbgeCode, updatedRecord.IbgeCode);
                Assert.Equal(entity.UfId, updatedRecord.UfId);

                var recordExists = await repository.ExistsAsync(updatedRecord.Id);
                Assert.True(recordExists);

                var selectedRecord = await repository.FindByIdAsync(updatedRecord.Id);
                Assert.NotNull(selectedRecord);
                Assert.Equal(entity.Name, selectedRecord.Name);
                Assert.Equal(entity.IbgeCode, selectedRecord.IbgeCode);
                Assert.Equal(entity.UfId, selectedRecord.UfId);
                Assert.Null(selectedRecord.Uf);

                selectedRecord = await repository.FindCompleteByIBGECode(updatedRecord.IbgeCode);
                Assert.NotNull(selectedRecord);
                Assert.Equal(entity.Name, selectedRecord.Name);
                Assert.Equal(entity.IbgeCode, selectedRecord.IbgeCode);
                Assert.Equal(entity.UfId, selectedRecord.UfId);
                Assert.NotNull(selectedRecord.Uf);

                selectedRecord = await repository.FindCompleteByIdAsync(updatedRecord.Id);
                Assert.NotNull(selectedRecord);
                Assert.Equal(entity.Name, selectedRecord.Name);
                Assert.Equal(entity.IbgeCode, selectedRecord.IbgeCode);
                Assert.Equal(entity.UfId, selectedRecord.UfId);
                Assert.NotNull(selectedRecord.Uf);

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
