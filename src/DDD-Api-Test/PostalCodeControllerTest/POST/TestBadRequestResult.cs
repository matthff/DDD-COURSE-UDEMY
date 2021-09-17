using System;
using System.Threading.Tasks;
using DDD_Api.Controllers;
using DDD_Domain.DTOs.City;
using DDD_Domain.DTOs.PostalCode;
using DDD_Domain.DTOs.Uf;
using DDD_Domain.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace DDD_Api_Test.PostalCodeControllerTest.POST
{
    public class TestBadRequestResult
    {
        private PostalCodeController _controller;
        private Mock<IPostalCodeService> _serviceMock;

        [Fact(DisplayName = "Controller response is BadRequest Code - 400")]
        public async Task MustReturnCreateResult()
        {
            var uf = new UfDTO
            {
                Id = Guid.NewGuid(),
                FederatedUnit = Faker.Address.UsState().Substring(1, 3),
                Name = Faker.Address.UsState()
            };
            
            var city = new CityCompleteDTO{
                Id = Guid.NewGuid(),
                Name = Faker.Address.City(),
                IbgeCode = Faker.RandomNumber.Next(1000000, 9999999),
                UfId = uf.Id,
                Uf = uf
            };

            var postalCode = Faker.Address.ZipCode();
            var address = Faker.Address.StreetAddress();
            var streetNumber = Faker.RandomNumber.Next(1, 2000).ToString();
            var cityId = Guid.NewGuid();

            _serviceMock = new Mock<IPostalCodeService>();
            _serviceMock.Setup(m => m.Post(It.IsAny<PostalCodeCreateDTO>())).ReturnsAsync(
                new PostalCodeCreateResultDTO
                {
                    Id = Guid.NewGuid(),
                    PostalCode = postalCode,
                    Address = address,
                    StreetNumber = streetNumber,
                    CityId = city.Id,
                    CreatedAt = DateTime.UtcNow
                }
            );

             _controller = new PostalCodeController(_serviceMock.Object);
             _controller.ModelState.AddModelError("Id", "Invalid Format");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var postalCodeCreateDTO = new PostalCodeCreateDTO
            {
                PostalCode = postalCode,
                Address = address,
                StreetNumber = streetNumber,
                CityId = city.Id
            };

            var result = await _controller.Post(postalCodeCreateDTO);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}