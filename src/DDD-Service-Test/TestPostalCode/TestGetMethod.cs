using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD_Domain.DTOs.PostalCode;
using DDD_Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace DDD_Service_Test.TestPostalCode
{
    public class TestGetMethod : PostalCodeMock
    {
        private IPostalCodeService _service;
        private Mock<IPostalCodeService> _serviceMock;

        [Fact(DisplayName = "GET By Id Request executed successfully")]
        public async Task MustExecuteGETByIdMethod()
        {
            _serviceMock = new Mock<IPostalCodeService>();
            _serviceMock.Setup(m => m.Get(PostalCodeId)).ReturnsAsync(postalCodeDTO);
            _service = _serviceMock.Object;

            var result = await _service.Get(PostalCodeId);
            Assert.NotNull(result);
            Assert.Equal(result.Id, PostalCodeId);
            Assert.Equal(result.PostalCode, PostalCodeZip);
            Assert.Equal(result.Address, PostalCodeAddress);
            Assert.Equal(result.StreetNumber, PostalCodeStreetNumber);
            Assert.Equal(result.CityId, PostalCodeCityId);
            Assert.NotNull(result.City);


            _serviceMock = new Mock<IPostalCodeService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((PostalCodeDTO)null));
            _service = _serviceMock.Object;

            var record = await _service.Get(PostalCodeId);
            Assert.Null(record);
        }

        [Fact(DisplayName = "GET By PostalCode Request executed successfully")]
        public async Task MustExecuteGETByPostalCodeMethod()
        {
            _serviceMock = new Mock<IPostalCodeService>();
            _serviceMock.Setup(m => m.Get(PostalCodeZip)).ReturnsAsync(postalCodeDTO);
            _service = _serviceMock.Object;

            var result = await _service.Get(PostalCodeZip);
            Assert.NotNull(result);
            Assert.Equal(result.Id, PostalCodeId);
            Assert.Equal(result.PostalCode, PostalCodeZip);
            Assert.Equal(result.Address, PostalCodeAddress);
            Assert.Equal(result.StreetNumber, PostalCodeStreetNumber);
            Assert.Equal(result.CityId, PostalCodeCityId);
            Assert.NotNull(result.City);


            _serviceMock = new Mock<IPostalCodeService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<string>())).Returns(Task.FromResult((PostalCodeDTO)null));
            _service = _serviceMock.Object;

            var record = await _service.Get(PostalCodeId);
            Assert.Null(record);
        }
    }
}
