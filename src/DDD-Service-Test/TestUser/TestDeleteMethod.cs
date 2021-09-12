using System;
using System.Threading.Tasks;
using DDD_Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace DDD_Service_Test.TestUser
{
    public class TestDeleteMethod : UserMock
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "Delete Request executed successfully")]
        public async Task MustExecuteDeleteMethod()
        {
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(UserId)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var deletado = await _service.Delete(UserId);
            Assert.True(deletado);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            deletado = await _service.Delete(Guid.NewGuid());
            Assert.False(deletado);
        }
    }
}