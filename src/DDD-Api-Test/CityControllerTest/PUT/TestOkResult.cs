using System;
using System.Threading.Tasks;
using DDD_Api.Controllers;
using DDD_Domain.DTOs.City;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DDD_Api_Test.CityControllerTest.PUT
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

            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Put(It.IsAny<CityUpdateDTO>())).ReturnsAsync(
                new CityUpdateResultDTO
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    IbgeCode = ibgeCode,
                    UfId = ufId,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            _controller = new CityController(_serviceMock.Object);

            var userUpdateDTO = new CityUpdateDTO
            {
                Id = Guid.NewGuid(),
                Name = name,
                IbgeCode = ibgeCode,
                UfId = ufId
            };

            var result = await _controller.Put(userUpdateDTO);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as CityUpdateResultDTO;
            Assert.NotNull(resultValue);
            Assert.Equal(userUpdateDTO.Name, resultValue.Name);
            Assert.Equal(userUpdateDTO.IbgeCode, resultValue.IbgeCode);
            Assert.Equal(userUpdateDTO.UfId, resultValue.UfId);
        }
    }
}