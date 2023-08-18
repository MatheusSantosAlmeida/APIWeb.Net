using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Cep.GET
{
    public class Result_GET_Cep_BadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar GET BadRequest.")]
        public async Task E_Possivel_Realizar_GET_BadRequest()
        {
            var serviceMok = new Mock<ICepService>();
            var IdCep = Guid.NewGuid();
            var CepC = Faker.RandomNumber.Next(1, 10000).ToString();
            var LogradouroC = Faker.Address.StreetName();
            var NumeroCep = Faker.RandomNumber.Next(1, 10000).ToString();

            serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new CepDto
                {
                    Id = IdCep,
                    Cep = CepC,
                    Logradouro = LogradouroC,
                    Numero = NumeroCep,
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioDtoCompleto
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(1, 10000),
                        UfId = Guid.NewGuid(),
                        Uf = new UfDto
                        {
                            Id = Guid.NewGuid(),
                            Sigla = Faker.Address.UsState().Substring(1, 3),
                            NameUf = Faker.Address.UsState()
                        }
                    }
                }
            );

            _controller = new CepsController(serviceMok.Object);

            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            var result = await _controller.Get(default(Guid));
            Assert.True(result is BadRequestObjectResult);

            serviceMok.Setup(m => m.Get(It.IsAny<string>())).ReturnsAsync(
                new CepDto
                {
                    Id = IdCep,
                    Cep = CepC,
                    Logradouro = LogradouroC,
                    Numero = NumeroCep,
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioDtoCompleto
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(1, 10000),
                        UfId = Guid.NewGuid(),
                        Uf = new UfDto
                        {
                            Id = Guid.NewGuid(),
                            Sigla = Faker.Address.UsState().Substring(1, 3),
                            NameUf = Faker.Address.UsState()
                        }
                    }
                }
            );

            _controller = new CepsController(serviceMok.Object);

            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            result = await _controller.Get(CepC);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
