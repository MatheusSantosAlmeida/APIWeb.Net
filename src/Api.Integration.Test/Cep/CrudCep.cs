using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Newtonsoft.Json;

namespace Api.Integration.Test.Cep
{
    public class CrudCep : BaseIntegration
    {
        [Fact]
        public async Task E_Possivel_Realizar_Crud_Cep()
        {
            await AdicionarToken();

            var municipioDto = new MunicipioDtoCreat()
            {
                Nome = "São Paulo",
                CodIBGE = 35598,
                UfId = new Guid("e7e416de-477c-4fa3-a541-b5af5f35ccf6")
            };


            //POST Municipio
            var response = await PostJsonAsync(municipioDto, $"{hostApi}municipios", client);
            var postResult = await response.Content.ReadAsStringAsync();
            var registroPostMunicipio = JsonConvert.DeserializeObject<MunicipioCreatDtoResult>(postResult);

            var _cep = "58714-000";
            var _logradouro = "Rua do Prado";
            var _numero = "125";

            var cepdto = new CepDtoCreat()
            {
                Cep = _cep,
                Logradouro = _logradouro,
                Numero = _numero,
                MunicipioId = registroPostMunicipio.Id
            };

            //POST
            response = await PostJsonAsync(cepdto, $"{hostApi}ceps", client);
            postResult = await response.Content.ReadAsStringAsync();
            var registroPost = JsonConvert.DeserializeObject<CepDtoCreatResult>(postResult);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.Equal(_cep, registroPost.Cep);
            Assert.Equal(_logradouro, registroPost.Logradouro);
            Assert.Equal(_numero, registroPost.Numero);
            Assert.True(registroPost.Id != default(Guid));


            _cep = "58456-000";
            _logradouro = "Rua da Pampa";
            _numero = string.Empty;

            var cepUpdate = new CepDtoUpdate()
            {
                Id = registroPost.Id,
                Cep = _cep,
                Logradouro = _logradouro,
                Numero = _numero,
                MunicipioId = registroPost.MunicipioId
            };

            //PUT
            var stringContent = new StringContent(JsonConvert.SerializeObject(cepUpdate), Encoding.UTF8, "application/json");
            response = await client.PutAsync($"{hostApi}ceps", stringContent);
            var jsonResult = await response.Content.ReadAsStringAsync();
            var registroAtualizado = JsonConvert.DeserializeObject<CepDtoUpdateResult>(jsonResult);

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(_cep, registroAtualizado.Cep);
            Assert.Equal(_logradouro, registroAtualizado.Logradouro);
            Assert.Equal("S/N", registroAtualizado.Numero);

            //GET ID
            response = await client.GetAsync($"{hostApi}ceps/{registroAtualizado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionado = JsonConvert.DeserializeObject<CepDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Logradouro, registroAtualizado.Logradouro);

            //GET CEP
            response = await client.GetAsync($"{hostApi}ceps/byCep/{registroAtualizado.Cep}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            jsonResult = await response.Content.ReadAsStringAsync();
            var registroSelecionadoCep = JsonConvert.DeserializeObject<CepDto>(jsonResult);
            Assert.NotNull(registroSelecionado);
            Assert.Equal(registroSelecionado.Logradouro, registroAtualizado.Logradouro);

            //DELETE
            response = await client.DeleteAsync($"{hostApi}ceps/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //DELETE Municipio
            response = await client.DeleteAsync($"{hostApi}municipios/{registroPostMunicipio.Id}");
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);

            //GET ID depois do DELETE
            response = await client.GetAsync($"{hostApi}ceps/{registroSelecionado.Id}");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
