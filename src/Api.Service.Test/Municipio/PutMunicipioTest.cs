using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;

namespace Api.Service.Test.Municipio
{
    public class PutMunicipioTest : MunicipioTeste
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo PUT.")]
        public async Task E_Possivel_Executar_PUT()
        {
            _serviceMok = new Mock<IMunicipioService>();
            _serviceMok.Setup(m => m.Post(municipioDtoCreat)).ReturnsAsync(municipioCreatDtoResult);
            _service = _serviceMok.Object;

            var result = await _service.Post(municipioDtoCreat);
            Assert.NotNull(result);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodIBGEMunicipio, result.CodIBGE);
            Assert.Equal(IdUf, result.UfId);

            _serviceMok = new Mock<IMunicipioService>();
            _serviceMok.Setup(m => m.Put(municipioDtoUpdate)).ReturnsAsync(municipioDtoUpdateResult);
            _service = _serviceMok.Object;

            var resultUpdate = await _service.Put(municipioDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeMunicipioAlterado, resultUpdate.Nome);
            Assert.Equal(CodIBGEMunicipioAlterado, resultUpdate.CodIBGE);
            Assert.Equal(IdUf, resultUpdate.UfId);
        }
    }
}
