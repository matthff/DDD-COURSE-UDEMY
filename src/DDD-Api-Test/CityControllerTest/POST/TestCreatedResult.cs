using System;
using System.Threading.Tasks;
using DDD_Api.Controllers;
using DDD_Domain.DTOs.City;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DDD_Api_Test.CityControllerTest.POST
{
    public class TestCreatedResult
    {
        private CityController _controller;
        private Mock<ICityService> _serviceMock;

        [Fact(DisplayName = "Controller response is Created Code - 201")]
        public async Task MustReturnCreateResult()
        {
            var name = Faker.Address.City();
            var ibgeCode = Faker.RandomNumber.Next(1000000, 9999999);
            var ufId = Guid.NewGuid();

            _serviceMock = new Mock<ICityService>();
            _serviceMock.Setup(m => m.Post(It.IsAny<CityCreateDTO>())).ReturnsAsync(
                new CityCreateResultDTO
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    IbgeCode = ibgeCode,
                    UfId = ufId,
                    CreatedAt = DateTime.UtcNow
                }
            );

            _controller = new CityController(_serviceMock.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var cityCreateDTO = new CityCreateDTO
            {
                Name = name,
                IbgeCode = ibgeCode,
                UfId = ufId
            };

            var result = await _controller.Post(cityCreateDTO);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as CityCreateResultDTO;
            Assert.NotNull(resultValue);
            Assert.Equal(cityCreateDTO.Name, resultValue.Name);
            Assert.Equal(cityCreateDTO.IbgeCode, resultValue.IbgeCode);
            Assert.Equal(cityCreateDTO.UfId, resultValue.UfId);
        }
    }
}