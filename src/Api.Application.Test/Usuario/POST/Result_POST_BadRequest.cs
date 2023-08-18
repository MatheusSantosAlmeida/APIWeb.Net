using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Usuario.POST
{
    public class Result_POST_BadRequest
    {
        private UsersController _controller;

        [Fact(DisplayName = "Resultado BadRequest do POST BadRequest.")]
        public async Task Result_BadRequest_POST_BadRequest()
        {
            var serviceMok = new Mock<IUserService>();
            var nome = Faker.Name.FullName();
            var emai = Faker.Internet.Email();
            serviceMok.Setup(m => m.Post(It.IsAny<UserDtoCreate>())).ReturnsAsync(
                new UserDtoCreateResult
                {
                    Id = Guid.NewGuid(),
                    Name = nome,
                    Email = emai,
                    CreatAt = DateTime.UtcNow
                }
            );

            _controller = new UsersController(serviceMok.Object);
            _controller.ModelState.AddModelError("Name", "É um campo obrigatorio");

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var userDtoCreate = new UserDtoCreate
            {
                Name = nome,
                Email = emai
            };

            var result = await _controller.Post(userDtoCreate);
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
