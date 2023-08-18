using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Date.Context;
using System.Net.Http;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Api.Application;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Api.CrossCuting.Mappings;
using Api.Domain.Dtos;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Api.Integration.Test
{
    public abstract class BaseIntegration : IDisposable
    {
        public MyContext myContext { get; private set; }

        public HttpClient client { get; private set; }

        public IMapper mapper { get; set; }

        public string hostApi { get; set; }

        public HttpResponseMessage response { get; set; }

        public BaseIntegration()
        {

            hostApi = "http://localhost:5000/api/";
            var builder = new WebHostBuilder().UseEnvironment("Testing").UseStartup<Startup>();
            var server = new TestServer(builder);

            myContext = server.Host.Services.GetService(typeof(MyContext)) as MyContext;
            myContext.Database.Migrate();

            mapper = new AutoMapperFixture().GetMapper();

            client = server.CreateClient();

        }
        public async Task AdicionarToken()
        {
            var loginDto = new LoginDto
            {
                Email = "adm@mail.com"
            };

            var resultLogin = await PostJsonAsync(loginDto, $"{hostApi}login", client);
            var jsonLogin = await resultLogin.Content.ReadAsStringAsync();
            var loginObject = JsonConvert.DeserializeObject<LoginResponseDto>(jsonLogin);

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", loginObject.acessToken);
        }
        public static async Task<HttpResponseMessage> PostJsonAsync(object dataclass, string url, HttpClient client)
        {
            return await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(dataclass), System.Text.Encoding.UTF8, "application/json"));
        }
        public void Dispose()
        {
            myContext.Dispose();
            client.Dispose();
        }
    }

    public class AutoMapperFixture : IDisposable
    {
        public IMapper GetMapper()
        {
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtoToModelProfile());
                cfg.AddProfile(new EntityToDtoProfile());
                cfg.AddProfile(new ModelToEntityProfile());
            });

            return config.CreateMapper();
        }

        public void Dispose() { }
    }
}
