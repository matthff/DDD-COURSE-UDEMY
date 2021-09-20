using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DDD_Domain.DTOs.Uf;
using Newtonsoft.Json;
using Xunit;


namespace DDD_Integration_Test.UfEndpoint
{
    public class TestUfRead : BaseIntegration
    {
        [Fact(DisplayName = "Is Possible to Read from Uf Endpoint")]
        public async Task IsPossibleGetUf()
        {
            await this.AddToken();

            //GetAll
            var responseGetAll = await Client.GetAsync($"{HostApi}uf");
            Assert.Equal(HttpStatusCode.OK, responseGetAll.StatusCode);
            var getAllResult = await responseGetAll.Content.ReadAsStringAsync();
            var getAllResponseObject = JsonConvert.DeserializeObject<IEnumerable<UfDTO>>(getAllResult);
            Assert.NotNull(getAllResponseObject);
            Assert.True(getAllResponseObject.Count() == 27);
            Assert.True(getAllResponseObject.Where(p => p.FederatedUnit.Equals("PB")).Count() == 1);

            //GetById
            var uf = getAllResponseObject.First(p => p.FederatedUnit.Equals("PB"));
            var responseGet = await Client.GetAsync($"{HostApi}uf/{uf.Id}");
            Assert.Equal(HttpStatusCode.OK, responseGet.StatusCode);
            var getResult = await responseGet.Content.ReadAsStringAsync();
            var getResultObject = JsonConvert.DeserializeObject<UfDTO>(getResult);
            Assert.NotNull(getResultObject);
            Assert.Equal(getResultObject.Id, uf.Id);
            Assert.Equal(getResultObject.FederatedUnit, uf.FederatedUnit);
            Assert.Equal(getResultObject.Name, uf.Name);
        }
    }
}
