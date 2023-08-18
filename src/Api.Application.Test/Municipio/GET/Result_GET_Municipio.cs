using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Municipio.GET
{
    public class Result_GET_Municipio
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possivel realizar GETALL.")]
        public async Task E_Possivel_Realizar_GETALL()
        {
            var serviceMok = new Mock<IMunicipioService>();
            var nome = Faker.Address.City();
            var codIBGE = Faker.RandomNumber.Next(1, 10000);
            var ufId = Guid.NewGuid();

            serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new MunicipioDto
                {
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    CodIBGE = codIBGE,
                    UfId = ufId
                }
            );

            _controller = new MunicipiosController(serviceMok.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as MunicipioDto;
            Assert.NotNull(resultValue);
            Assert.Equal(nome, resultValue.Nome);
            Assert.Equal(codIBGE, resultValue.CodIBGE);

            serviceMok.Setup(m => m.GetCompleteById(It.IsAny<Guid>())).ReturnsAsync(
                new MunicipioDtoCompleto
                {
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    CodIBGE = codIBGE,
                    UfId = Guid.NewGuid(),
                    Uf = new UfDto
                    {
                        Id = Guid.NewGuid(),
                        NameUf = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3)
                    }
                }
            );

            _controller = new MunicipiosController(serviceMok.Object);

            result = await _controller.GetCompleteById(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValueCompleto = ((OkObjectResult)result).Value as MunicipioDtoCompleto;
            Assert.NotNull(resultValueCompleto);
            Assert.Equal(nome, resultValueCompleto.Nome);
            Assert.Equal(codIBGE, resultValueCompleto.CodIBGE);
            Assert.NotNull(resultValueCompleto.Uf);

            serviceMok.Setup(m => m.GetCompleteByIBGE(It.IsAny<int>())).ReturnsAsync(
                new MunicipioDtoCompleto
                {
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    CodIBGE = codIBGE,
                    UfId = Guid.NewGuid(),
                    Uf = new UfDto
                    {
                        Id = Guid.NewGuid(),
                        NameUf = Faker.Address.UsState(),
                        Sigla = Faker.Address.UsState().Substring(1, 3)
                    }
                }
            );

            _controller = new MunicipiosController(serviceMok.Object);

            result = await _controller.GetCompleteByIBGE(codIBGE);
            Assert.True(result is OkObjectResult);

            resultValueCompleto = ((OkObjectResult)result).Value as MunicipioDtoCompleto;
            Assert.NotNull(resultValueCompleto);
            Assert.Equal(nome, resultValueCompleto.Nome);
            Assert.Equal(codIBGE, resultValueCompleto.CodIBGE);
            Assert.NotNull(resultValueCompleto.Uf);
        }
    }
}
