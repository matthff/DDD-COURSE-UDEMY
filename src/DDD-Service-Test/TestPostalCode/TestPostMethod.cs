using System.Threading.Tasks;
using DDD_Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace DDD_Service_Test.TestPostalCode
{
    public class TestPostMethod : PostalCodeMock
    {
        private IPostalCodeService _service;
        private Mock<IPostalCodeService> _serviceMock;

        [Fact(DisplayName = "Post Request executed successfully")]
        public async Task MustExecutePostMethod()
        {
            _serviceMock = new Mock<IPostalCodeService>();
            _serviceMock.Setup(m => m.Post(postalCodeCreateDTO)).ReturnsAsync(postalCodeCreateResultDTO);
            _service = _serviceMock.Object;

            var result = await _service.Post(postalCodeCreateDTO);
            Assert.NotNull(result);
            Assert.Equal(result.Id, PostalCodeId);
            Assert.Equal(result.PostalCode, PostalCodeZip);
            Assert.Equal(result.Address, PostalCodeAddress);
            Assert.Equal(result.StreetNumber, PostalCodeStreetNumber);
            Assert.Equal(result.CityId, PostalCodeCityId);
            Assert.Equal(result.CreatedAt, postalCodeCreateResultDTO.CreatedAt);
        }
    }
}
