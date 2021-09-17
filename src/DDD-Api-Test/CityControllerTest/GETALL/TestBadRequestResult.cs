using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DDD_Api.Controllers;
using DDD_Domain.DTOs.City;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DDD_Api_Test.CityControllerTest.GETALL
{
    public class TestBadRequestResult
    {
        private CityController _controller;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Controller response is BadRequest Code - 400")]
        public async Task MustReturnBadRequestResult()
        {
            var name = Faker.Address.City();
            var ibgeCode = Faker.RandomNumber.Next(1000000, 9999999);
            var ufId = Guid.NewGuid();

            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<CityDTO>
                {
                    new CityDTO{
                        Id = Guid.NewGuid(),
                        Name = name,
                        IbgeCode = ibgeCode,
                        UfId = ufId
                    },
                    new CityDTO{
                        Id = Guid.NewGuid(),
                        Name = name,
                        IbgeCode = ibgeCode,
                        UfId = ufId
                    }
                }
            );

            _controller = new CityController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Invalid Format");
            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}