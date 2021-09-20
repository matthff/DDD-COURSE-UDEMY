using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DDD_Domain.DTOs.City;
using DDD_Domain.DTOs.Uf;
using Newtonsoft.Json;
using Xunit;

namespace DDD_Integration_Test.CityEndpoint
{
    public class TestCityCRUD : BaseIntegration
    {
        [Fact(DisplayName = "Is Possible to realize all CRUD operations from City Endpoint")]
        public async Task IsPossibleCityCRUD()
        {
            await this.AddToken();
            
            //GetAUf
            var responseGetAllUf = await Client.GetAsync($"{HostApi}uf");
            Assert.Equal(HttpStatusCode.OK, responseGetAllUf.StatusCode);
            var getAllUfResult = await responseGetAllUf.Content.ReadAsStringAsync();
            var getAllUfResultObject = JsonConvert.DeserializeObject<IEnumerable<UfDTO>>(getAllUfResult);
            var uf = getAllUfResultObject.First(p => p.FederatedUnit.Equals("PB"));
            
            //Post
            var cityDTO = new CityCreateDTO{
                Name = "João Pessoa",
                IbgeCode = 705115,
                UfId = uf.Id
            };

            var response = await PostJsonAsync(cityDTO, $"{HostApi}city", Client);
            var postResult = await response.Content.ReadAsStringAsync();
            var postResponseObject = JsonConvert.DeserializeObject<CityCreateResultDTO>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(cityDTO.Name, postResponseObject.Name);
            Assert.Equal(cityDTO.IbgeCode, postResponseObject.IbgeCode);
            Assert.Equal(cityDTO.UfId, postResponseObject.UfId);
            Assert.True(postResponseObject.Id != default(Guid));

            //GetAll
            response = await Client.GetAsync($"{HostApi}city");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var getAllResult = await response.Content.ReadAsStringAsync();
            var getAllResponseObject = JsonConvert.DeserializeObject<IEnumerable<CityDTO>>(getAllResult);
            Assert.NotNull(getAllResponseObject);
            Assert.True(getAllResponseObject.Count() > 0);
            Assert.True(getAllResponseObject.Where(p => p.Id == postResponseObject.Id).Count() == 1);

            //Update
            var cityUpdateDTO = new CityUpdateDTO{
                Id = postResponseObject.Id,
                Name = "Guarabira",
                IbgeCode = 989115,
                UfId = uf.Id
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(cityUpdateDTO), Encoding.UTF8, "application/json");
            response = await Client.PutAsync($"{HostApi}city", stringContent);
            var putResult = await response.Content.ReadAsStringAsync();
            var putResponseObject = JsonConvert.DeserializeObject<CityUpdateResultDTO>(putResult);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(postResponseObject.Name, putResponseObject.Name);
            Assert.NotEqual(postResponseObject.IbgeCode, putResponseObject.IbgeCode);
            Assert.Equal(postResponseObject.UfId, putResponseObject.UfId);

            //GetById
            response = await Client.GetAsync($"{HostApi}city/{putResponseObject.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var getByIdResult = await response.Content.ReadAsStringAsync();
            var getByIdResponseObject = JsonConvert.DeserializeObject<CityDTO>(getByIdResult);
            Assert.NotNull(getByIdResponseObject);
            Assert.Equal(getByIdResponseObject.Name, putResponseObject.Name);
            Assert.Equal(getByIdResponseObject.IbgeCode, putResponseObject.IbgeCode);
            Assert.Equal(getByIdResponseObject.UfId, putResponseObject.UfId);

            //GetCompleteByIBGECode
            response = await Client.GetAsync($"{HostApi}city/byIBGE/{putResponseObject.IbgeCode}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var getCompleteByIbgeCodeResult = await response.Content.ReadAsStringAsync();
            var getCompleteByIbgeCodeResponseObject = JsonConvert.DeserializeObject<CityCompleteDTO>(getCompleteByIbgeCodeResult);
            Assert.NotNull(getCompleteByIbgeCodeResponseObject);
            Assert.Equal(getCompleteByIbgeCodeResponseObject.Name, putResponseObject.Name);
            Assert.Equal(getCompleteByIbgeCodeResponseObject.IbgeCode, putResponseObject.IbgeCode);
            Assert.Equal(getCompleteByIbgeCodeResponseObject.UfId, putResponseObject.UfId);
            Assert.NotNull(getCompleteByIbgeCodeResponseObject.Uf);

            //GetCompleteById
            response = await Client.GetAsync($"{HostApi}city/complete/{putResponseObject.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var getCompleteByIdResult = await response.Content.ReadAsStringAsync();
            var getCompleteByIdResponseObject = JsonConvert.DeserializeObject<CityCompleteDTO>(getCompleteByIdResult);
            Assert.NotNull(getCompleteByIdResponseObject);
            Assert.Equal(getCompleteByIdResponseObject.Name, putResponseObject.Name);
            Assert.Equal(getCompleteByIdResponseObject.IbgeCode, putResponseObject.IbgeCode);
            Assert.Equal(getCompleteByIdResponseObject.UfId, putResponseObject.UfId);

            //Delete
            response = await Client.DeleteAsync($"{HostApi}city/{getByIdResponseObject.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //GetById after Delete
            response = await Client.GetAsync($"{HostApi}city/{getByIdResponseObject.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}