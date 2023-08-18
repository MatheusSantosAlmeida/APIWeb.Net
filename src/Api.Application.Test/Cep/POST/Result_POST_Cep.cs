using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Cep.POST
{
    public class Result_POST_Cep
    {
        private CepsController _controller;

        [Fact(DisplayName = "É possivel realizar POST.")]
        public async Task E_Possivel_Realizar_POST()
        {
            var serviceMok = new Mock<ICepService>();
            var CepC = Faker.RandomNumber.Next(1, 10000).ToString();
            var LogradouroC = Faker.Address.StreetName();
            var NumeroCep = Faker.RandomNumber.Next(1, 10000).ToString();

            serviceMok.Setup(m => m.Post(It.IsAny<CepDtoCreat>())).ReturnsAsync(
                new CepDtoCreatResult
                {
                    Id = Guid.NewGuid(),
                    Cep = CepC,
                    Logradouro = LogradouroC,
                    Numero = NumeroCep,
                    MunicipioId = Guid.NewGuid(),
                    CreatAt = DateTime.UtcNow
                }
            );

            _controller = new CepsController(serviceMok.Object);

            Mock<IUrlHelper> url = new Mock<IUrlHelper>();
            url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000");
            _controller.Url = url.Object;

            var cepDtoCreate = new CepDtoCreat
            {
                Cep = CepC,
                Logradouro = LogradouroC,
                Numero = NumeroCep,
                MunicipioId = Guid.NewGuid(),
            };

            var result = await _controller.Post(cepDtoCreate);
            Assert.True(result is CreatedResult);

            var resultValue = ((CreatedResult)result).Value as CepDtoCreatResult;
            Assert.NotNull(resultValue);
            Assert.Equal(cepDtoCreate.Cep, resultValue.Cep);
            Assert.Equal(cepDtoCreate.Logradouro, resultValue.Logradouro);
            Assert.Equal(cepDtoCreate.Numero, resultValue.Numero);
        }
    }
}
