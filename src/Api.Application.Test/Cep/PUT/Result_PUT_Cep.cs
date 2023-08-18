using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Cep.PUT
{
    public class Result_PUT_Cep
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar PUT.")]
        public async Task E_Possivel_Realizar_PUT()
        {
            var serviceMok = new Mock<ICepService>();
            var IdCep = Guid.NewGuid();
            var CepC = Faker.RandomNumber.Next(1, 10000).ToString();
            var LogradouroC = Faker.Address.StreetName();
            var NumeroCep = Faker.RandomNumber.Next(1, 10000).ToString();

            serviceMok.Setup(m => m.Put(It.IsAny<CepDtoUpdate>())).ReturnsAsync(
                new CepDtoUpdateResult
                {
                    Id = IdCep,
                    Cep = CepC,
                    Logradouro = LogradouroC,
                    Numero = NumeroCep,
                    MunicipioId = Guid.NewGuid(),
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new CepsController(serviceMok.Object);

            var cepDtoUpdate = new CepDtoUpdate
            {
                Id = IdCep,
                Cep = CepC,
                Logradouro = LogradouroC,
                Numero = NumeroCep,
                MunicipioId = Guid.NewGuid()
            };

            var resultPUT = await _controller.Put(cepDtoUpdate);
            Assert.True(resultPUT is OkObjectResult);

            var resultValuePUT = ((OkObjectResult)resultPUT).Value as CepDtoUpdateResult;
            Assert.NotNull(resultValuePUT);
            Assert.Equal(cepDtoUpdate.Cep, resultValuePUT.Cep);
            Assert.Equal(cepDtoUpdate.Logradouro, resultValuePUT.Logradouro);
            Assert.Equal(cepDtoUpdate.Numero, resultValuePUT.Numero);
        }

    }
}
