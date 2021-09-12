using System;
using System.Threading.Tasks;
using DDD_Api.Controllers;
using DDD_Domain.DTOs.User;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DDD_Api_Test.UsersControllerTest.PUT
{
    public class TestBadRequest
    {
        private UsersController _controller;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Controller response is BadRequest Code - 400")]
        public async Task MustReturnBadRequestResult()
        {
            var name = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(It.IsAny<UserUpdateDTO>())).ReturnsAsync(
                new UserUpdateResultDTO
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    UpdatedAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "Field is not nullable");

            var userUpdateDTO = new UserUpdateDTO
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            };

            var result = await _controller.Put(userUpdateDTO);
            Assert.True(result is BadRequestObjectResult);
            Assert.False(_controller.ModelState.IsValid);
        }
    }
}