using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Usuario.PUT
{
    public class Result_PUT
    {
        private UsersController _controller;

        [Fact(DisplayName = "É possivel realizar PUT.")]
        public async Task E_Possivel_Realizar_PUT()
        {
            var serviceMok = new Mock<IUserService>();
            var id = Guid.NewGuid();
            var nome = Faker.Name.FullName();
            var emai = Faker.Internet.Email();

            serviceMok.Setup(m => m.Put(It.IsAny<UserDtoUpdate>())).ReturnsAsync(
                new UserDtoUpdateResult
                {
                    Id = id,
                    Name = nome,
                    Email = emai,
                    UpdateAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMok.Object);



            var userDtoUpdate = new UserDtoUpdate
            {
                Id = id,
                Name = nome,
                Email = emai
            };

            var resultPUT = await _controller.Put(userDtoUpdate);
            Assert.True(resultPUT is OkObjectResult);

            var resultValuePUT = ((OkObjectResult)resultPUT).Value as UserDtoUpdateResult;
            Assert.NotNull(resultValuePUT);
            Assert.Equal(userDtoUpdate.Email, resultValuePUT.Email);
            Assert.Equal(userDtoUpdate.Name, resultValuePUT.Name);
            Assert.Equal(userDtoUpdate.Id, resultValuePUT.Id);
        }

    }
}
