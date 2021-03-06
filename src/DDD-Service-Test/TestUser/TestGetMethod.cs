using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDD_Domain.DTOs.User;
using DDD_Domain.Interfaces.Services;
using Moq;
using Xunit;

namespace DDD_Service_Test.TestUser
{
    public class TestGetMethod : UserMock
    {
        private IUserService _service;
        private Mock<IUserService> _serviceMock;

        [Fact(DisplayName = "GET By Id Request executed successfully")]
        public async Task MustExecuteGETMethod(){
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetById(UserId)).ReturnsAsync(userDTO);
            _service = _serviceMock.Object;

            var result = await _service.GetById(UserId);
            Assert.NotNull(result);
            Assert.True(result.Id == UserId);
            Assert.Equal(UserName, result.Name);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetById(It.IsAny<Guid>())).Returns(Task.FromResult((UserDTO)null));
            _service = _serviceMock.Object;

            var record = await _service.GetById(UserId);
            Assert.Null(record);
        }

        [Fact(DisplayName = "GET All Records Request executed successfully")]
        public async Task MustExecuteGETAllMethod(){
            var userList = new List<UserDTO>();
            
            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listUserDTO);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            _serviceMock = new Mock<IUserService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(userList.AsEnumerable);
            _service = _serviceMock.Object;

            var resultEmpty = await _service.GetAll();
            Assert.Empty(resultEmpty);
            Assert.True(resultEmpty.Count() == 0);
        }
    }
}