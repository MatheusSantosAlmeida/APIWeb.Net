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
    public class Result_GET_Municipio_BadRequest
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possivel realizar GETALL BadRequest.")]
        public async Task E_Possivel_Realizar_GETALL_BadRequest()
        {
            var serviceMok = new Mock<IMunicipioService>();
            var nome = Faker.Address.City();
            var codIBGE = Faker.RandomNumber.Next(1, 10000);

            serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new MunicipioDto
                {
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    CodIBGE = codIBGE,
                    UfId = Guid.NewGuid()
                }
            );

            _controller = new MunicipiosController(serviceMok.Object);

            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            var result = await _controller.Get(default(Guid));
            Assert.True(result is BadRequestObjectResult);

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
            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            result = await _controller.GetCompleteById(default(Guid));
            Assert.True(result is BadRequestObjectResult);

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
            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            result = await _controller.GetCompleteByIBGE(codIBGE);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
