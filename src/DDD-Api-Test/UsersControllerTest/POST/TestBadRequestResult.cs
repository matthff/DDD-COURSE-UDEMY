using System;
using System.Threading.Tasks;
using DDD_Api.Controllers;
using DDD_Domain.DTOs.User;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DDD_Api_Test.UsersControllerTest.POST
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
            _serviceMock.Setup(m => m.Post(It.IsAny<UserCreateDTO>())).ReturnsAsync(
                new UserCreateResultDTO
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    Email = email,
                    CreatedAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Name", "Field is not nullable");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userCreateDTO = new UserCreateDTO
            {
                Name = name,
                Email = email
            };

            var result = await _controller.Post(userCreateDTO);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}