using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Municipio.DELETE
{
    public class Result_DELETE_Municipio_BadResquest
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possivel realizar DELETE BadResquest.")]
        public async Task E_Possivel_Realizar_DELETE_BadResquest()
        {
            var serviceMok = new Mock<IMunicipioService>();
            serviceMok.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new MunicipiosController(serviceMok.Object);
            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
