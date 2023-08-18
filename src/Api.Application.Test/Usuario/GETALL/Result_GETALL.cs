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
    public class Result_GETALL
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar GETALL.")]
        public async Task E_Possivel_Realizar_GETALL()
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

            var result = await _controller.Getall();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<UserDto>;
            Assert.NotNull(resultValue);
            Assert.True(resultValue.Count() == 10);

        }
    }
}
