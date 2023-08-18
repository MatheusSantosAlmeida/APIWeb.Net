using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Usuario.GETALL
{
    public class Result_GETALL_BadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar GETALL BadRequest.")]
        public async Task E_Possivel_Realizar_GETALL_BadRequest()
        {
            var serviceMok = new Mock<IUserService>();
            var listaUserDto = new List<UserDto>();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UserDto
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email()
                };
                listaUserDto.Add(dto);
            }

            serviceMok.Setup(m => m.GetAll()).ReturnsAsync(listaUserDto);

            _controller = new UsersController(serviceMok.Object);
            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            var result = await _controller.Getall();
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
