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
    public class Result_GET_UF
    {
        private UfsController _controller;

        [Fact(DisplayName = "É possivel realizar GET.")]
        public async Task E_Possivel_Realizar_GET()
        {
            var serviceMok = new Mock<IUfService>();

            serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UfDto
                {
                    Id = Guid.NewGuid(),
                    NameUf = "São Paulo",
                    Sigla = "SP"
                }
            );

            _controller = new UfsController(serviceMok.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            serviceMok.Setup(m => m.Get("SP")).ReturnsAsync(
                new UfDto
                {
                    Id = Guid.NewGuid(),
                    NameUf = "São Paulo",
                    Sigla = "SP"
                }
            );

            _controller = new UfsController(serviceMok.Object);

            result = await _controller.Get("SP");
            Assert.True(result is OkObjectResult);
        }
    }
}
