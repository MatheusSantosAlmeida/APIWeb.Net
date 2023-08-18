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
    public class Result_GET_BadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar GET BadRequest.")]
        public async Task E_Possivel_Realizar_GET_BadRequest()
        {
            var serviceMok = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var email = Faker.Internet.Email();

            serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
                new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    Email = email,
                    CreatAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMok.Object);
            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            var result = await _controller.Get(default(Guid));
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
