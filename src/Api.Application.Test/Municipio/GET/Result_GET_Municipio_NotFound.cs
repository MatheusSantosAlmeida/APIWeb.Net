using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Municipio.GET
{
    public class Result_GET_Municipio_NotFound
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possivel realizar GETALL NotFound.")]
        public async Task E_Possivel_Realizar_GETALL_NotFound()
        {
            var serviceMok = new Mock<IMunicipioService>();
            var codIBGE = Faker.RandomNumber.Next(1, 10000);

            serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDto)null));

            _controller = new MunicipiosController(serviceMok.Object);

            var result = await _controller.Get(default(Guid));
            Assert.True(result is NotFoundResult);

            serviceMok.Setup(m => m.GetCompleteById(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDtoCompleto)null));

            _controller = new MunicipiosController(serviceMok.Object);

            result = await _controller.Get(default(Guid));
            Assert.True(result is NotFoundResult);

            serviceMok.Setup(m => m.GetCompleteByIBGE(It.IsAny<int>())).Returns(Task.FromResult((MunicipioDtoCompleto)null));

            _controller = new MunicipiosController(serviceMok.Object);

            result = await _controller.Get(default(Guid));
            Assert.True(result is NotFoundResult);
        }
    }
}
