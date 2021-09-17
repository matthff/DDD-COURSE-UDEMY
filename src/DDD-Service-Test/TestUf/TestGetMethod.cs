using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD_Domain.DTOs.Uf;
using DDD_Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace DDD_Service_Test.TestUf
{
    public class TestGetMethod : UfMock
    {
        private IUfService _service;
        private Mock<IUfService> _serviceMock;

        [Fact(DisplayName = "GET By Id Request executed successfully")]
        public async Task MustExecuteGETMethod()
        {
            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetById(UfId)).ReturnsAsync(ufDTO);
            _service = _serviceMock.Object;

            var result = await _service.GetById(UfId);
            Assert.NotNull(result);
            Assert.Equal(result.Id, UfId);
            Assert.Equal(result.FederatedUnit, UfFederatedUnit);
            Assert.Equal(result.Name, UfName);

            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((UfDTO)null));
            _service = _serviceMock.Object;

            var record = await _service.GetById(UfId);
            Assert.Null(record);
        }

        [Fact(DisplayName = "GET All Records Request executed successfully")]
        public async Task MustExecuteGETAllMethod()
        {
            var userList = new List<UfDTO>();

            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listUfDTO);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.Contains(result, uf => uf.FederatedUnit == "PB");
            Assert.True(result.Count() == 27);

            _serviceMock = new Mock<IUfService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(userList.AsEnumerable);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}
