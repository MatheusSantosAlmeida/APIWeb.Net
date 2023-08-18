using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Newtonsoft.Json;

namespace Api.Integration.Test.Usuario
{
    public class CrudUsuario : BaseIntegration
    {
        private string _name { get; set; }

        private string _email { get; set; }

        [Fact]
        public async Task E_Possivel_Realizar_Crud_Usuario()
        {
            _name = Faker.Name.First();
            _email = Faker.Internet.Email();

            var userDto = new UserDtoCreate()
            {
                Name = _name,
                Email = _email
            };

            //POST
            var response = await PostJsonAsync(userDto, $"{hostApi}users", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var resgistroPost = JsonConvert.DeserializeObject<UserDtoCreateResult>(postResult);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_email, resgistroPost.Email);
            Assert.Equal(_name, resgistroPost.Name);
            Assert.True(resgistroPost.Id != default(Guid));

            await AdicionarToken();

            //GET ALL
            response = await client.GetAsync($"{hostApi}users");
            var jsonResult = await response.Content.ReadAsStringAsync();
            var resgistroGetAll = JsonConvert.DeserializeObject<IEnumerable<UserDto>>(jsonResult);
            Assert.NotNull(resgistroGetAll);
            Assert.True(resgistroGetAll.Count() > 0);
            Assert.True(resgistroGetAll.Where(r => r.Id == resgistroPost.Id).Count() == 1);

            var userDtoUp = new UserDtoUpdate()
            {
                Id = resgistroPost.Id,
                Name = Faker.Name.First(),
                Email = Faker.Internet.Email()
            };

            //PUT
            var stringContent = new StringContent(JsonConvert.SerializeObject(userDtoUp), Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}users", stringContent);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<UserDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(resgistroPost.Name, registroAtualizado.Name);
            Assert.NotEqual(resgistroPost.Email, registroAtualizado.Email);

            //GET ID
            response = await client.GetAsync($"{hostApi}users/{registroAtualizado.Id}");
            jsonResult = await response.Content.ReadAsStringAsync();
            var objetoSelecionado = JsonConvert.DeserializeObject<UserDto>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(objetoSelecionado);
            Assert.Equal(registroAtualizado.Name, objetoSelecionado.Name);
            Assert.Equal(registroAtualizado.Email, objetoSelecionado.Email);

            //DELETE
            response = await client.DeleteAsync($"{hostApi}users/{objetoSelecionado.Id}");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //GET DEPOIS DO DELETE
            response = await client.GetAsync($"{hostApi}users/{objetoSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
