using System;
using System.Threading.Tasks;
using DDD_Api.Controllers;
using DDD_Domain.DTOs.Uf;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DDD_Api_Test.UfControllerTest.GET
{
    public class TestOkResult
    {
        private UfController _controller;
        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName = "Controller response is Ok Code - 200")]
        public async Task MustReturnOkResult()
        {
            var federatedUnit = Faker.Address.UsState().Substring(1, 3);
            var name = Faker.Address.UsState();

            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetById(It.IsAny<Guid>())).ReturnsAsync(
                new UfDTO
                {
                    Id = Guid.NewGuid(),
                    FederatedUnit = federatedUnit,
                    Name = name
                }
            );

            _controller = new UfController(_serviceMock.Object);
            var result = await _controller.GetById(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UfDTO;
            Assert.NotNull(resultValue);
            Assert.Equal(federatedUnit, resultValue.FederatedUnit);
            Assert.Equal(name, resultValue.Name);
        }
    }
}