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
    public class TestBadRequestResult
    {
        private CityController _controller;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Controller response is BadRequest Code - 400")]
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
            _controller.ModelState.AddModelError("Id", "Invalid Format");
            var result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}