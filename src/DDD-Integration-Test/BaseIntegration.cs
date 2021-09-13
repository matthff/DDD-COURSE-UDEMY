using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using DDD_Api;
using DDD_CrossCutting.Mapping;
using DDD_Data.Context;
using DDD_Domain.DTOs.Login;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace DDD_Integration_Test
{
    public class BaseIntegration : IDisposable
    {
        public MySQLContext Context { get; private set; }
        public HttpClient Client { get; private set; }
        public IMapper Mapper { get; set; }
        public string HostApi { get; set; }
        public HttpResponseMessage Response { get; set; }

        public BaseIntegration()
        {
            HostApi = "http://localhost:5000/api/";
            var builder = new WebHostBuilder().UseEnvironment("Testing").UseStartup<Startup>();
            var server = new TestServer(builder);

            Context = server.Host.Services.GetService(typeof(MySQLContext)) as MySQLContext;
            Context.Database.Migrate();

            Mapper = new AutoMapperFixture().GetMapper();

            Client = server.CreateClient();
        }

        public async Task AddToken()
        {
            var loginDTO = new LoginDTO
            {
                Email = "admin@mail.com"
            };

            var resultLogin = await PostJsonAsync(loginDTO, $"{HostApi}login", Client);
            var jsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var loginObject = JsonConvert.DeserializeObject<LoginResultDTO>(jsonLogin);

            Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginObject.AccessToken);
        }

        public static async Task<HttpResponseMessage> PostJsonAsync(object dataClass, string url, HttpClient client)
        {
            return await client.PostAsync(
                url,
                new StringContent(
                    JsonConvert.SerializeObject(dataClass),
                    System.Text.Encoding.UTF8, "application/json"
                )
            );
        }

        public void Dispose()
        {
            Context.Dispose();
            Client.Dispose();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var configMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            return configMapper.CreateMapper();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}