using System.Threading.Tasks;
using DDD_Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace DDD_Service_Test.TestCity
{
    public class TestPostMethod : CityMock
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Post Request executed successfully")]
        public async Task MustExecutePostMethod()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Post(cityCreateDTO)).ReturnsAsync(cityCreateResultDTO);
            _service = _serviceMock.Object;

            var result = await _service.Post(cityCreateDTO);
            Assert.NotNull(result);
            Assert.Equal(result.Name, CityName);
            Assert.Equal(result.IbgeCode, CityIbgeCode);
            Assert.Equal(result.UfId, CityUfId);
        }
    }
}
