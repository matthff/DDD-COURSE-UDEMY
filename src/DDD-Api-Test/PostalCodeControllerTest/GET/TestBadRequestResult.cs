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

namespace DDD_Api_Test.PostalCodeControllerTest.GET
{
    public class TestBadRequestResult
    {
        private PostalCodeController _controller;
        private Mock<IPostalCodeService> _serviceMock;

        [Fact(DisplayName = "Controller response is BadRequest Code - 400")]
        public async Task MustReturnBadRequestResult()
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
            _serviceMock.Setup(m => m.GetById(It.IsAny<Guid>())).ReturnsAsync(
                new PostalCodeDTO
                {
                    Id = Guid.NewGuid(),
                    PostalCode = postalCode,
                    Address = address,
                    StreetNumber = streetNumber,
                    CityId = city.Id,
                    City = city
                }
            );

            _controller = new PostalCodeController(_serviceMock.Object);
            _controller.ModelState.AddModelError("Id", "Invalid Format");
            var result = await _controller.GetById(Guid.NewGuid());
            Assert.True(result is BadRequestObjectResult);
        }
    }
}