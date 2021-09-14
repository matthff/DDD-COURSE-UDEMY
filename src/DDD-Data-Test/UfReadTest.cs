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
    public class UfReadTest : BaseTest, IClassFixture<DbTest>
    {
        private ServiceProvider _serviceProvider;

        public UfReadTest(DbTest dbTest)
        {
            _serviceProvider = dbTest.ServiceProvider;
        }

        [Fact(DisplayName = "Read operations for UF Entity")]
        [Trait("Read", "UfEntity")]
        public async Task IsPossibleToReadFromUfDatabase()
        {
            using (var context = _serviceProvider.GetService<MySQLContext>())
            {
                UfRepository repository = new UfRepository(context);

                UfEntity entity = new UfEntity
                {
                    Id = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                    FederatedUnit = "PB",
                    Name = "Paraíba"
                };

                var recordExists = await repository.ExistsAsync(entity.Id);
                Assert.True(recordExists);

                var selectedRecord = await repository.FindByIdAsync(entity.Id);
                Assert.NotNull(selectedRecord);
                Assert.Equal(entity.FederatedUnit, selectedRecord.FederatedUnit);
                Assert.Equal(entity.Name, selectedRecord.Name);
                Assert.Equal(entity.Id, selectedRecord.Id);

                var selectedRecords = await repository.FindAllAsync();
                Assert.NotNull(selectedRecord);
                Assert.True(selectedRecords.Count() == 27);
            }
        }
    }
}
