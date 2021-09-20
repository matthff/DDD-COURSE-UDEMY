using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DDD_Domain.DTOs.Uf;
using DDD_Domain.DTOs.City;
using DDD_Domain.DTOs.PostalCode;
using Newtonsoft.Json;
using Xunit;

namespace DDD_Integration_Test.PostalCodeEndpoint
{
    public class TestPostalCodeCRUD : BaseIntegration
    {
        [Fact(DisplayName = "Is Possible to realize all CRUD operations from PostalCode Endpoint")]
        public async Task IsPossiblePostalCodeCRUD()
        {
            await this.AddToken();
            
            //GetAUf
            var responseGetAllUf = await Client.GetAsync($"{HostApi}uf");
            Assert.Equal(HttpStatusCode.OK, responseGetAllUf.StatusCode);
            var getAllUfResult = await responseGetAllUf.Content.ReadAsStringAsync();
            var getAllUfResultObject = JsonConvert.DeserializeObject<IEnumerable<UfDTO>>(getAllUfResult);
            var uf = getAllUfResultObject.First(p => p.FederatedUnit.Equals("PB"));
            
            //PostACity
            var cityDTO = new CityCreateDTO{
                Name = "João Pessoa",
                IbgeCode = 705115,
                UfId = uf.Id
            };

            var responsePostCity = await PostJsonAsync(cityDTO, $"{HostApi}city", Client);
            var postCityResult = await responsePostCity.Content.ReadAsStringAsync();
            var postCityResponseObject = JsonConvert.DeserializeObject<CityCreateResultDTO>(postCityResult);
            Assert.Equal(HttpStatusCode.Created, responsePostCity.StatusCode);

            //GetACityCompleteById
            var responseCityComplete = await Client.GetAsync($"{HostApi}city/complete/{postCityResponseObject.Id}");
            Assert.Equal(HttpStatusCode.OK, responseCityComplete.StatusCode);
            var getCityCompleteByIdResult = await responseCityComplete.Content.ReadAsStringAsync();
            var getCityCompleteByIdResponseObject = JsonConvert.DeserializeObject<CityCompleteDTO>(getCityCompleteByIdResult);

            var postalCodeDTO = new PostalCodeCreateDTO{
                PostalCode = Faker.Address.ZipCode(),
                Address = Faker.Address.StreetAddress(),
                StreetNumber = Faker.RandomNumber.Next(1, 2000).ToString(),
                CityId = getCityCompleteByIdResponseObject.Id
            };

            //Post
            var response = await PostJsonAsync(postalCodeDTO, $"{HostApi}postalcode", Client);
            var postResult = await response.Content.ReadAsStringAsync();
            var postResponseObject = JsonConvert.DeserializeObject<PostalCodeCreateResultDTO>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(postalCodeDTO.PostalCode, postResponseObject.PostalCode);
            Assert.Equal(postalCodeDTO.Address, postResponseObject.Address);
            Assert.Equal(postalCodeDTO.StreetNumber, postResponseObject.StreetNumber);
            Assert.Equal(postalCodeDTO.CityId, postResponseObject.CityId);
            Assert.True(postResponseObject.Id != default(Guid));

            //Update
            var postalCodeUpdateDTO = new PostalCodeUpdateDTO{
                Id = postResponseObject.Id,
                PostalCode = Faker.Address.ZipCode(),
                Address = Faker.Address.StreetAddress(),
                StreetNumber = Faker.RandomNumber.Next(1, 2000).ToString(),
                CityId = getCityCompleteByIdResponseObject.Id
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(postalCodeUpdateDTO), Encoding.UTF8, "application/json");
            response = await Client.PutAsync($"{HostApi}postalcode", stringContent);
            var putResult = await response.Content.ReadAsStringAsync();
            var putResponseObject = JsonConvert.DeserializeObject<PostalCodeUpdateResultDTO>(putResult);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(postResponseObject.PostalCode, putResponseObject.PostalCode);
            Assert.NotEqual(postResponseObject.Address, putResponseObject.Address);
            Assert.NotEqual(postResponseObject.StreetNumber, putResponseObject.StreetNumber);
            Assert.Equal(postResponseObject.CityId, putResponseObject.CityId);

            //GetById
            response = await Client.GetAsync($"{HostApi}postalcode/{putResponseObject.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var getByIdResult = await response.Content.ReadAsStringAsync();
            var getByIdResponseObject = JsonConvert.DeserializeObject<PostalCodeDTO>(getByIdResult);
            Assert.NotNull(getByIdResponseObject);
            Assert.Equal(getByIdResponseObject.Id, putResponseObject.Id);
            Assert.Equal(getByIdResponseObject.PostalCode, putResponseObject.PostalCode);
            Assert.Equal(getByIdResponseObject.Address, putResponseObject.Address);
            Assert.Equal(getByIdResponseObject.StreetNumber, putResponseObject.StreetNumber);
            Assert.Equal(getByIdResponseObject.CityId, putResponseObject.CityId);
            Assert.NotNull(getByIdResponseObject.City);
            Assert.NotNull(getByIdResponseObject.City.Uf);

            //GetByPostalCode
            response = await Client.GetAsync($"{HostApi}postalcode/zip/{putResponseObject.PostalCode}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var getByPostalCodeResult = await response.Content.ReadAsStringAsync();
            var getByPostalCodeResponseObject = JsonConvert.DeserializeObject<PostalCodeDTO>(getByPostalCodeResult);
            Assert.NotNull(getByPostalCodeResponseObject);
            Assert.Equal(getByPostalCodeResponseObject.Id, putResponseObject.Id);
            Assert.Equal(getByPostalCodeResponseObject.PostalCode, putResponseObject.PostalCode);
            Assert.Equal(getByPostalCodeResponseObject.Address, putResponseObject.Address);
            Assert.Equal(getByPostalCodeResponseObject.StreetNumber, putResponseObject.StreetNumber);
            Assert.Equal(getByPostalCodeResponseObject.CityId, putResponseObject.CityId);
            Assert.NotNull(getByPostalCodeResponseObject.City);
            Assert.NotNull(getByPostalCodeResponseObject.City.Uf);

            //Delete
            response = await Client.DeleteAsync($"{HostApi}postalcode/{getByIdResponseObject.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //GetById after Delete
            var getResponse = await Client.GetAsync($"{HostApi}postalcode/{getByIdResponseObject.Id}");
            Assert.Equal(HttpStatusCode.NoContent, getResponse.StatusCode);

            //DeleteCity
            response = await Client.DeleteAsync($"{HostApi}city/{postCityResponseObject.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}