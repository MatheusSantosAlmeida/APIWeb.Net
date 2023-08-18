using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Usuario.DELETE
{
    public class Result_DELETE_BadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar DELETE BadRequest.")]
        public async Task E_Possivel_Realizar_DELETE_BadRequest()
        {
            var serviceMok = new Mock<IUserService>();
            serviceMok.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

            _controller = new UsersController(serviceMok.Object);
            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            var result = await _controller.Delete(default(Guid));
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
