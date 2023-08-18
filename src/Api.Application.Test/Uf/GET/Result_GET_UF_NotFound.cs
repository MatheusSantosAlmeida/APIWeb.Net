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
    public class Result_GET_UF_NotFound
    {
        private UfsController _controller;

        [Fact(DisplayName = "É possivel realizar GET NotFound.")]
        public async Task E_Possivel_Realizar_GET_NotFound()
        {
            var serviceMok = new Mock<IUfService>();
            var sigla = Faker.Address.UsState().Substring(1, 3);

            serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UfDto)null));

            _controller = new UfsController(serviceMok.Object);

            var result = await _controller.Get(default(Guid));
            Assert.True(result is NotFoundResult);

            serviceMok.Setup(m => m.Get(sigla)).Returns(Task.FromResult((UfDto)null));

            _controller = new UfsController(serviceMok.Object);

            result = await _controller.Get(sigla);
            Assert.True(result is NotFoundResult);
        }
    }
}
