using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Cep.GET
{
    public class Result_GET_Cep_NotFound
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar GET NotFound.")]
        public async Task E_Possivel_Realizar_GET_NotFound()
        {
            var serviceMok = new Mock<ICepService>();
            var CepC = Faker.RandomNumber.Next(1, 10000).ToString();

            serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CepDto)null));

            _controller = new CepsController(serviceMok.Object);

            var result = await _controller.Get(default(Guid));
            Assert.True(result is NotFoundResult);

            serviceMok.Setup(m => m.Get(It.IsAny<string>())).Returns(Task.FromResult((CepDto)null));

            _controller = new CepsController(serviceMok.Object);

            result = await _controller.Get(CepC);
            Assert.True(result is NotFoundResult);
        }
    }
}
