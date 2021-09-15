using System.Threading.Tasks;
using DDD_Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace DDD_Service_Test.TestUser
{
    public class TestPutMethod : UserMock
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Put Request executed successfully")]
        public async Task MustExecutePutMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Post(userCreateDTO)).ReturnsAsync(userCreateResultDTO);
            _service = _serviceMock.Object;

            var createResult = await _service.Post(userCreateDTO);
            Assert.NotNull(createResult);
            Assert.Equal(UserName, createResult.Name);
            Assert.Equal(UserEmail, createResult.Email);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Put(userUpdateDTO)).ReturnsAsync(userUpdateResultDTO);
            _service = _serviceMock.Object;

            var updateResult = await _service.Put(userUpdateDTO);
            Assert.NotNull(updateResult);
            Assert.Equal(UserNameUpdated, updateResult.Name);
            Assert.Equal(UserEmailUpdated, updateResult.Email);
        }
    }
}
