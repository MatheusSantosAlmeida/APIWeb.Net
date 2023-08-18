using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Cep.DELETE
{
    public class Result_DELETE_Cep_BadRequest
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar DELETE BadRequest.")]
        public async Task E_Possivel_Realizar_DELETE_BadRequest()
        {
            var serviceMok = new Mock<ICepService>();
            serviceMok.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new CepsController(serviceMok.Object);

            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);
        }
    }
}
