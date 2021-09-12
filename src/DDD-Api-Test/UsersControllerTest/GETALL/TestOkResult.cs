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
            _serviceMock.Setup(m => m.Get()).ReturnsAsync(
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
            var result = await _controller.Get();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDTO>;
            Assert.NotNull(resultValue);
            Assert.True(resultValue.Count() == 2);
        }
    }
}