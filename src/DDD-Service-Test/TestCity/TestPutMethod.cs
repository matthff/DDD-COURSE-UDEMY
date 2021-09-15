using System.Threading.Tasks;
using DDD_Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace DDD_Service_Test.TestCity
{
    public class TestPutMethod : CityMock
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Put Request executed successfully")]
        public async Task MustExecutePutMethod()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Put(cityUpdateDTO)).ReturnsAsync(cityUpdateResultDTO);
            _service = _serviceMock.Object;

            var result = await _service.Put(cityUpdateDTO);
            Assert.NotNull(result);
            Assert.Equal(result.Name, CityNameUpdated);
            Assert.Equal(result.IbgeCode, CityIbgeCodeUpdated);
            Assert.Equal(result.UfId, CityUfId);
        }
    }
}
