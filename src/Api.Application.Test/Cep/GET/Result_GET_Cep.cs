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
    public class Result_GET_Cep
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar GET.")]
        public async Task E_Possivel_Realizar_GET()
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

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as CepDto;
            Assert.NotNull(resultValue);
            Assert.Equal(CepC, resultValue.Cep);
            Assert.Equal(LogradouroC, resultValue.Logradouro);
            Assert.Equal(NumeroCep, resultValue.Numero);
            Assert.NotNull(resultValue.Municipio);
            Assert.NotNull(resultValue.Municipio.Uf);

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

            result = await _controller.Get(CepC);
            Assert.True(result is OkObjectResult);

            resultValue = ((OkObjectResult)result).Value as CepDto;
            Assert.NotNull(resultValue);
            Assert.Equal(CepC, resultValue.Cep);
            Assert.Equal(LogradouroC, resultValue.Logradouro);
            Assert.Equal(NumeroCep, resultValue.Numero);
            Assert.NotNull(resultValue.Municipio);
            Assert.NotNull(resultValue.Municipio.Uf);
        }
    }
}
