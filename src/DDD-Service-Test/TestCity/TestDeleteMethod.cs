using System;
using System.Threading.Tasks;
using DDD_Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace DDD_Service_Test.TestCity
{
    public class TestDeleteMethod : CityMock
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Delete Request executed successfully")]
        public async Task MustExecuteDeleteMethod()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Delete(CityId)).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.Delete(CityId);
            Assert.True(result);

            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            var record = await _service.Delete(Guid.NewGuid());
            Assert.False(record);
        }
    }
}
