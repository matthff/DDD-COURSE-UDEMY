using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD_Api.Controllers;
using DDD_Domain.DTOs.User;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DDD_Api_Test.UsersControllerTest.GETALL
{
    public class TestBadRequestResult
    {
        private UsersController _controller;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Controller response is BadRequest Code - 400")]
        public async Task MustReturnBadRequestResult()
        {
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
                new List<UserDTO>
                {
                    new UserDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = name,
                        Email = email,
                        CreatedAt = DateTime.UtcNow
                    },
                    new UserDTO
                    {
                        Id = Guid.NewGuid(),
                        Name = name,
                        Email = email,
                        CreatedAt = DateTime.UtcNow
                    }
                }
            );

            _controller = new UsersController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Invalid Format");
            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);
        }
    }
}