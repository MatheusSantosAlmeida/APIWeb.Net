using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Municipio.GETALL
{
    public class Result_GETALL_Municipio
    {
        private MunicipiosController _controller;

        [Fact(DisplayName = "É possivel realizar GETALL.")]
        public async Task E_Possivel_Realizar_GETALL()
        {
            var serviceMok = new Mock<IMunicipioService>();
            var listaMunicipioDto = new List<MunicipioDto>();

            for (int i = 0; i < 10; i++)
            {
                var dto = new MunicipioDto
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid()
                };
                listaMunicipioDto.Add(dto);
            }

            serviceMok.Setup(m => m.GetAll()).ReturnsAsync(listaMunicipioDto);

            _controller = new MunicipiosController(serviceMok.Object);

            var result = await _controller.Getall();
            Assert.True(result is OkObjectResult);

            var resultValue = ((OkObjectResult)result).Value as IEnumerable<MunicipioDto>;
            Assert.NotNull(resultValue);
            Assert.True(resultValue.Count() == 10);
        }
    }
}
