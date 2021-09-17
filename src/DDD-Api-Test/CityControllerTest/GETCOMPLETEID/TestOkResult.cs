using System;
using System.Threading.Tasks;
using DDD_Api.Controllers;
using DDD_Domain.DTOs.City;
using DDD_Domain.DTOs.Uf;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DDD_Api_Test.CityControllerTest.GETCOMPLETEID
{
    public class TestOkResult
    {
        private CityController _controller;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Controller response is Ok Code - 200")]
        public async Task MustReturnOkResult()
        {
            var name = Faker.Address.City();
            var ibgeCode = Faker.RandomNumber.Next(1000000, 9999999);
            var ufId = Guid.NewGuid();
            var uf = new UfDTO
            {
                Id = Guid.NewGuid(),
                FederatedUnit = Faker.Address.UsState().Substring(1, 3),
                Name = Faker.Address.UsState()
            };

            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.GetCompleteById(It.IsAny<Guid>())).ReturnsAsync(
                new CityCompleteDTO
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    IbgeCode = ibgeCode,
                    UfId = ufId,
                    Uf = uf
                }
            );

            _controller = new CityController(_serviceMock.Object);
            var result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as CityCompleteDTO;
            Assert.NotNull(resultValue);
            Assert.Equal(name, resultValue.Name);
            Assert.Equal(ibgeCode, resultValue.IbgeCode);
            Assert.Equal(ufId, resultValue.UfId);
            Assert.NotNull(resultValue.Uf);
        }
    }
}