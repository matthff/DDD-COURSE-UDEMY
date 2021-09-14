using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DDD_Domain.DTOs.User;
using Newtonsoft.Json;
using Xunit;

namespace DDD_Integration_Test.UserEndpoint
{
    public class TestUserCRUD : BaseIntegration
    {
        [Fact]
        public async Task IsPossibleUserCRUD()
        {
            await this.AddToken();

            var userDTO = new UserCreateDTO()
            {
                Name = Faker.Name.First(),
                Email = Faker.Internet.Email()
            };

            //Post
            var response = await PostJsonAsync(userDTO, $"{HostApi}users", Client);
            var postResult = await response.Content.ReadAsStringAsync();
            var postResponseObject = JsonConvert.DeserializeObject<UserCreateResultDTO>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(userDTO.Name, postResponseObject.Name);
            Assert.Equal(userDTO.Email, postResponseObject.Email);
            Assert.True(postResponseObject.Id != default(Guid));

            //GetAll
            response = await Client.GetAsync($"{HostApi}users");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var getAllResult = await response.Content.ReadAsStringAsync();
            var getAllResponseObject = JsonConvert.DeserializeObject<IEnumerable<UserDTO>>(getAllResult);
            Assert.NotNull(getAllResponseObject);
            Assert.True(getAllResponseObject.Count() > 0);
            Assert.True(getAllResponseObject.Where(p => p.Id == postResponseObject.Id).Count() == 1);

            //Update
            var updateUserDTO = new UserUpdateDTO
            {
                Id = postResponseObject.Id,
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email()
            };

            var stringContent = new StringContent(JsonConvert.SerializeObject(updateUserDTO), Encoding.UTF8, "application/json");
            response = await Client.PutAsync($"{HostApi}users", stringContent);
            var putResult = await response.Content.ReadAsStringAsync();
            var putResponseObject = JsonConvert.DeserializeObject<UserUpdateResultDTO>(putResult);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(postResponseObject.Name, putResponseObject.Name);
            Assert.NotEqual(postResponseObject.Email, putResponseObject.Email);

            //GetById
            response = await Client.GetAsync($"{HostApi}users/{putResponseObject.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var getByIdResult = await response.Content.ReadAsStringAsync();
            var getByIdResponseObject = JsonConvert.DeserializeObject<UserDTO>(getByIdResult);
            Assert.NotNull(getByIdResponseObject);
            Assert.Equal(getByIdResponseObject.Name, putResponseObject.Name);
            Assert.Equal(getByIdResponseObject.Email, putResponseObject.Email);

            //Delete
            response = await Client.DeleteAsync($"{HostApi}users/{getByIdResponseObject.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //GetById after Delete
            response = await Client.GetAsync($"{HostApi}users/{getByIdResponseObject.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
