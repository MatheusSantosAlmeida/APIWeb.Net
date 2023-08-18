using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;

namespace Api.Service.Test.Municipio
{
    public class PostMunicipioTest : MunicipioTeste
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo POST.")]
        public async Task E_Possivel_Executar_POST()
        {
            _serviceMok = new Mock<IMunicipioService>();
            _serviceMok.Setup(m => m.Post(municipioDtoCreat)).ReturnsAsync(municipioCreatDtoResult);
            _service = _serviceMok.Object;

            var result = await _service.Post(municipioDtoCreat);
            Assert.NotNull(result);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodIBGEMunicipio, result.CodIBGE);
            Assert.Equal(IdUf, result.UfId);
        }
    }
}
