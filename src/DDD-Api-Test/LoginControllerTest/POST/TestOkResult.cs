using System;
using System.Threading.Tasks;
using DDD_Api.Controllers;
using DDD_Domain.DTOs;
using DDD_Domain.DTOs.User;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DDD_Api_Test.LoginControllerTest.POST
{
    public class TestOkResult
    {
        private LoginController _controller;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "Must return a Ok Status for Login Request")]
        public async Task MustReturnOkLoginResult()
        {
            var validEmail = Faker.Internet.Email();

            var validLoginDTO = new LoginDTO{
                Email = validEmail
            };

            var returnResult = new
            {
                authenticated = true,
                create = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                accessToken = Guid.NewGuid(),
                userName = validEmail,
                name = Faker.Name.FullName(),
                message = "User successfully logged"
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(validLoginDTO)).ReturnsAsync(returnResult);

            _controller = new LoginController();

            var result = await _controller.Login(validLoginDTO, _serviceMock.Object);
            Assert.NotNull(result);
            Assert.Equal(result, returnResult);
        }
    }
}