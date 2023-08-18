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
    public class Result_PUT_Cep_BadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar PUT BadRequest.")]
        public async Task E_Possivel_Realizar_PUT_BadRequest()
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
            _controller.ModelState.AddModelError("Name", "É um campo obrigatorio");

            var cepDtoUpdate = new CepDtoUpdate
            {
                Id = IdCep,
                Cep = CepC,
                Logradouro = LogradouroC,
                Numero = NumeroCep,
                MunicipioId = Guid.NewGuid()
            };

            var resultPUT = await _controller.Put(cepDtoUpdate);
            Assert.True(resultPUT is BadRequestObjectResult);
        }

    }
}
