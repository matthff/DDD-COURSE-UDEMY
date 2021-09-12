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
    public class TestOkResult
    {
        private UsersController _controller;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Controller response is Ok Code - 200")]
        public async Task MustReturnOkResult()
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

            var userUpdateDTO = new UserUpdateDTO
            {
                Id = Guid.NewGuid(),
                Name = name,
                Email = email
            };

            var result = await _controller.Put(userUpdateDTO);
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as UserUpdateResultDTO;
            Assert.NotNull(resultValue);
            Assert.Equal(userUpdateDTO.Name, resultValue.Name);
            Assert.Equal(userUpdateDTO.Email, resultValue.Email);
        }
    }
}