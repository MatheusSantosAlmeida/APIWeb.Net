using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Usuario.GET
{
    public class Result_GET_NotFound
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar GET NotFound.")]
        public async Task E_Possivel_Realizar_GET_NotFound()
        {
            var serviceMok = new Mock<IUserService>();

            serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));

            _controller = new UsersController(serviceMok.Object);

            var result = await _controller.Get(Guid.NewGuid());
            Assert.True(result is NotFoundResult);
        }
    }
}
