using System;
using System.Threading.Tasks;
using DDD_Api.Controllers;
using DDD_Domain.DTOs.City;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DDD_Api_Test.CityControllerTest.DELETE
{
    public class TestOkResult
    {
        private CityController _controller;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Controller response is Ok Code - 200")]
        public async Task MustReturnOkResult()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new CityController(_serviceMock.Object);
            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((Boolean)resultValue);
        }
    }
}