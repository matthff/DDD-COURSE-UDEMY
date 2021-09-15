using System.Threading.Tasks;
using DDD_Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace DDD_Service_Test.TestPostalCode
{
    public class TestPutMethod : PostalCodeMock
    {
        private IPostalCodeService _service;
        private Mock<IPostalCodeService> _serviceMock;

        [Fact(DisplayName = "Put Request executed successfully")]
        public async Task MustExecutePutMethod()
        {
            _serviceMock = new Mock<IPostalCodeService>();
            _serviceMock.Setup(m => m.Put(postalCodeUpdateDTO)).ReturnsAsync(postalCodeUpdateResultDTO);
            _service = _serviceMock.Object;

            var result = await _service.Put(postalCodeUpdateDTO);
            Assert.NotNull(result);
            Assert.Equal(result.Id, PostalCodeId);
            Assert.Equal(result.PostalCode, PostalCodeZip);
            Assert.Equal(result.Address, PostalCodeAddressUpdated);
            Assert.Equal(result.StreetNumber, PostalCodeStreetNumberUpdated);
            Assert.Equal(result.CityId, PostalCodeCityId);
        }
    }
}
