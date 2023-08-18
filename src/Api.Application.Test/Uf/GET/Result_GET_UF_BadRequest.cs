using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.UF;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Uf.GET
{
    public class Result_GET_UF_BadRequest
    {
        private UfsController _controller;

        [Fact(DisplayName = "É possivel realizar GET BadRequest.")]
        public async Task E_Possivel_Realizar_GET_BadRequest()
        {
            var serviceMok = new Mock<IUfService>();
            var sigla = Faker.Address.UsState().Substring(1, 3);
            var nameUf = Faker.Address.UsState();

            serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UfDto
                {
                    Id = Guid.NewGuid(),
                    Sigla = sigla,
                    NameUf = nameUf
                }
            );

            _controller = new UfsController(serviceMok.Object);

            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            var result = await _controller.Get(default(Guid));
            Assert.True(result is BadRequestObjectResult);

            serviceMok.Setup(m => m.Get(sigla)).ReturnsAsync(
                new UfDto
                {
                    Id = Guid.NewGuid(),
                    Sigla = sigla,
                    NameUf = nameUf
                }
            );

            _controller = new UfsController(serviceMok.Object);
            _controller.ModelState.AddModelError("Sigla", "Formato Invalido");

            result = await _controller.Get(sigla);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
