using System.Threading.Tasks;
using DDD_Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace DDD_Service_Test.TestUser
{
    public class TestPostMethod : UserMock
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Post Request executed successfully")]
        public async Task MustExecutePostMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userCreateDTO)).ReturnsAsync(userCreateResultDTO);
            _service = _serviceMock.Object;

            var result = await _service.Post(userCreateDTO);
            Assert.NotNull(result);
            Assert.Equal(UserName, result.Name);
            Assert.Equal(UserEmail, result.Email);
        }
    }
}