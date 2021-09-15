using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD_Domain.DTOs.City;
using DDD_Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace DDD_Service_Test.TestCity
{
    public class TestGetMethod : CityMock
    {
        private ICityService _service;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "GET By Id Request executed successfully")]
        public async Task MustExecuteGETByIdMethod()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Get(CityId)).ReturnsAsync(cityDTO);
            _service = _serviceMock.Object;

            var result = await _service.Get(CityId);
            Assert.NotNull(result);
            Assert.Equal(result.Id, CityId);
            Assert.Equal(result.Name, CityName);
            Assert.Equal(result.IbgeCode, CityIbgeCode);
            Assert.Equal(result.UfId, CityUfId);

            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CityDTO)null));
            _service = _serviceMock.Object;

            var record = await _service.Get(Guid.NewGuid());
            Assert.Null(record);
        }

        [Fact(DisplayName = "GET Complete By IBGE Code Request executed successfully")]
        public async Task MustExecuteGETCompleteByIBGEMethod()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.GetCompleteByIBGE(CityIbgeCode)).ReturnsAsync(cityCompleteDTO);
            _service = _serviceMock.Object;

            var result = await _service.GetCompleteByIBGE(CityIbgeCode);
            Assert.NotNull(result);
            Assert.Equal(result.Id, CityId);
            Assert.Equal(result.Name, CityName);
            Assert.Equal(result.IbgeCode, CityIbgeCode);
            Assert.Equal(result.UfId, CityUfId);
            Assert.NotNull(result.Uf);
            Assert.Equal(result.Uf, CityUf);
        }

        [Fact(DisplayName = "GET Complete By Id Request executed successfully")]
        public async Task MustExecuteGETCompleteByIdMethod()
        {
            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.GetCompleteById(CityId)).ReturnsAsync(cityCompleteDTO);
            _service = _serviceMock.Object;

            var result = await _service.GetCompleteById(CityId);
            Assert.NotNull(result);
            Assert.Equal(result.Id, CityId);
            Assert.Equal(result.Name, CityName);
            Assert.Equal(result.IbgeCode, CityIbgeCode);
            Assert.Equal(result.UfId, CityUfId);
            Assert.NotNull(result.Uf);
            Assert.Equal(result.Uf, CityUf);
        }

        [Fact(DisplayName = "GET All Request executed successfully")]
        public async Task MustExecuteGETAllMethod()
        {
            var cityList = new List<CityDTO>();

            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listCityDTO);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(cityList.AsEnumerable);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}
