using System;
using System.Threading.Tasks;
using DDD_Domain.DTOs;
using DDD_Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace DDD_Service_Test.TestLogin
{
    public class TestPostMethod
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMock;

        [Fact(DisplayName = "Is possible to login on the application")]
        public async Task MustExecuteLoginPostMethod()
        {
            var email = Faker.Internet.Email();

            var returnObject = new
            {
                authenticated = true,
                create = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                accessToken = Guid.NewGuid(),
                userName = email,
                name = Faker.Name.FullName(),
                message = "User successfully logged"
            };

            var loginDto = new LoginDTO
            {
                Email = email
            };

            _serviceMock = new Mock<ILoginService>();
            _serviceMock.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(returnObject);
            _service = _serviceMock.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
        }
    }
}