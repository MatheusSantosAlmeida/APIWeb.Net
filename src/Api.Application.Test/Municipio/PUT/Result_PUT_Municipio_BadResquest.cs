using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Municipio.PUT
{
    public class Result_PUT_Municipio_BadRequest
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possivel realizar PUT BadRequest.")]
        public async Task E_Possivel_Realizar_PUT_BadRequest()
        {
            var serviceMok = new Mock<IMunicipioService>();
            var id = Guid.NewGuid();
            var nome = Faker.Address.City();
            var codIBGE = Faker.RandomNumber.Next(1, 10000);
            var ufId = Guid.NewGuid();

            serviceMok.Setup(m => m.Put(It.IsAny<MunicipioDtoUpdate>())).ReturnsAsync(
                new MunicipioDtoUpdateResult
                {
                    Id = id,
                    Nome = nome,
                    CodIBGE = codIBGE,
                    UfId = ufId,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new MunicipiosController(serviceMok.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatorio");

            var municipioDtoUpdate = new MunicipioDtoUpdate
            {
                Id = id,
                Nome = nome,
                CodIBGE = codIBGE,
                UfId = ufId
            };

            var resultPUT = await _controller.Put(municipioDtoUpdate);
            Assert.True(resultPUT is BadRequestObjectResult);
        }
    }
}
