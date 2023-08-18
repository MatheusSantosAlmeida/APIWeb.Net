using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Municipio.DELETE
{
    public class Result_DELETE_Municipio
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possivel realizar DELETE.")]
        public async Task E_Possivel_Realizar_DELETE()
        {
            var serviceMok = new Mock<IMunicipioService>();
            serviceMok.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

            _controller = new MunicipiosController(serviceMok.Object);

            var result = await _controller.Delete(Guid.NewGuid());
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value;
            Assert.NotNull(resultValue);
            Assert.True((Boolean)resultValue);
        }
    }
}
