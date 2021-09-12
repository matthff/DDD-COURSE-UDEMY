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
    public class TestCreatedResult
    {
        private UsersController _controller;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Controller response is Created Code - 201")]
        public async Task MustReturnCreateResult()
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

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userCreateDTO = new UserCreateDTO
            {
                Name = name,
                Email = email
            };

            var result = await _controller.Post(userCreateDTO);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as UserCreateResultDTO;
            Assert.NotNull(resultValue);
            Assert.Equal(userCreateDTO.Name, resultValue.Name);
            Assert.Equal(userCreateDTO.Email, resultValue.Email);
        }
    }
}