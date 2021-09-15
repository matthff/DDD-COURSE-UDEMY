using System;
using System.Threading.Tasks;
using DDD_Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace DDD_Service_Test.TestPostalCode
{
    public class TestDeleMethod : PostalCodeMock
    {
        private IPostalCodeService _service;
        private Mock<IPostalCodeService> _serviceMock;

        [Fact(DisplayName = "Delete Request executed successfully")]
        public async Task MustExecuteDeleteMethod()
        {
            _serviceMock = new Mock<IPostalCodeService>();
            _serviceMock.Setup(m => m.Delete(PostalCodeId)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.Delete(PostalCodeId);
            Assert.True(result);

            _serviceMock = new Mock<IPostalCodeService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            var record = await _service.Delete(Guid.NewGuid());
            Assert.False(record);
        }
    }
}
