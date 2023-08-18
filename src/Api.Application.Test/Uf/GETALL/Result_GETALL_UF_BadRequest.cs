using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.UF;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Api.Application.Test.Uf.GETALL
{
    public class Result_GETALL_UF_BadRequest
    {
        private UfsController _controller;

        [Fact(DisplayName = "É possivel realizar GETALL BadRequest.")]
        public async Task E_Possivel_Realizar_GETALL_BadRequest()
        {
            var serviceMok = new Mock<IUfService>();
            var listaUfDto = new List<UfDto>();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UfDto
                {
                    Id = Guid.NewGuid(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                    NameUf = Faker.Address.UsState()
                };
                listaUfDto.Add(dto);
            }

            serviceMok.Setup(m => m.GetAll()).ReturnsAsync(listaUfDto);

            _controller = new UfsController(serviceMok.Object);
            _controller.ModelState.AddModelError("Id", "Formato Invalido");

            var result = await _controller.GetAll();
            Assert.True(result is BadRequestObjectResult);

        }
    }
}
