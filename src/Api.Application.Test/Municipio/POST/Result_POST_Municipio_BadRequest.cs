using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Municipio.POST
{
    public class Result_POST_Municipio_BadRequest
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possivel realizar POST BadRequest.")]
        public async Task E_Possivel_Realizar_POST_BadRequest()
        {
            var serviceMok = new Mock<IMunicipioService>();
            var nome = Faker.Address.City();
            var codIBGE = Faker.RandomNumber.Next(1, 10000);
            var ufId = Guid.NewGuid();

            serviceMok.Setup(m => m.Post(It.IsAny<MunicipioDtoCreat>())).ReturnsAsync(
                new MunicipioCreatDtoResult
                {
                    Id = Guid.NewGuid(),
                    Nome = nome,
                    CodIBGE = codIBGE,
                    UfId = ufId,
                    CreatAt = DateTime.UtcNow
                }
            );

            _controller = new MunicipiosController(serviceMok.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatorio");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var municipioDtoCreate = new MunicipioDtoCreat
            {
                Nome = nome,
                CodIBGE = codIBGE,
                UfId = ufId
            };

            var result = await _controller.Post(municipioDtoCreate);
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
