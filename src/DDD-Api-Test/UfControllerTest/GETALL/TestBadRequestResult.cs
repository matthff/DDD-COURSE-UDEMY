using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD_Api.Controllers;
using DDD_Domain.DTOs.Uf;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DDD_Api_Test.UfControllerTest.GETALL
{
    public class TestBadRequestResult
    {
        private UfController _controller;
        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName = "Controller response is BadRequest Code - 400")]
        public async Task MustReturnBadRequestResult()
        {
            var federatedUnit = Faker.Address.UsState().Substring(1, 3);
            var name = Faker.Address.UsState();

            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UfDTO>
                {
                    new UfDTO{
                        Id = Guid.NewGuid(),
                        FederatedUnit = federatedUnit,
                        Name = name
                    },
                    new UfDTO{
                        Id = Guid.NewGuid(),
                        FederatedUnit = federatedUnit,
                        Name = name
                    }
                }
            );

            _controller = new UfController(_serviceMock.Object);
            _controller.ModelState.AddModelError("FederatedUnit", "Federated Unit Field is obrigatory");
            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}