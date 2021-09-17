using System;
using System.Threading.Tasks;
using DDD_Api.Controllers;
using DDD_Domain.DTOs.City;
using DDD_Domain.DTOs.PostalCode;
using DDD_Domain.DTOs.Uf;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DDD_Api_Test.PostalCodeControllerTest.DELETE
{
    public class TestBadRequest
    {
        private PostalCodeController _controller;
        private Mock<IPostalCodeService> _serviceMock;

        [Fact(DisplayName = "Controller response is BadRequest Code - 400")]
        public async Task MustReturnBadRequestResult()
        {
            _serviceMock = new Mock<IPostalCodeService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new PostalCodeController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Invalid Format");

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}