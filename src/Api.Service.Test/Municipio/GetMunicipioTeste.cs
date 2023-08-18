using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;

namespace Api.Service.Test.Municipio
{
    public class GetMunicipioTeste : MunicipioTeste
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo GET.")]
        public async Task E_Possivel_Executar_GET()
        {
            _serviceMok = new Mock<IMunicipioService>();
            _serviceMok.Setup(m => m.Get(IdMunicipio)).ReturnsAsync(municipioDto);
            _service = _serviceMok.Object;

            var result = await _service.Get(IdMunicipio);
            Assert.NotNull(result);
            Assert.True(result.Id == IdMunicipio);
            Assert.Equal(NomeMunicipio, result.Nome);
            Assert.Equal(CodIBGEMunicipio, result.CodIBGE);

            _serviceMok = new Mock<IMunicipioService>();
            _serviceMok.Setup(m => m.GetCompleteById(IdMunicipio)).ReturnsAsync(municipioDtoCompleto);
            _service = _serviceMok.Object;

            var resultCompleto = await _service.GetCompleteById(IdMunicipio);
            Assert.NotNull(resultCompleto);
            Assert.True(resultCompleto.Id == IdMunicipio);
            Assert.Equal(NomeMunicipio, resultCompleto.Nome);
            Assert.Equal(CodIBGEMunicipio, resultCompleto.CodIBGE);
            Assert.NotNull(resultCompleto.Uf);

            _serviceMok = new Mock<IMunicipioService>();
            _serviceMok.Setup(m => m.GetCompleteByIBGE(CodIBGEMunicipio)).ReturnsAsync(municipioDtoCompleto);
            _service = _serviceMok.Object;

            resultCompleto = await _service.GetCompleteByIBGE(CodIBGEMunicipio);
            Assert.NotNull(resultCompleto);
            Assert.True(resultCompleto.Id == IdMunicipio);
            Assert.Equal(NomeMunicipio, resultCompleto.Nome);
            Assert.Equal(CodIBGEMunicipio, resultCompleto.CodIBGE);
            Assert.NotNull(resultCompleto.Uf);

            _serviceMok = new Mock<IMunicipioService>();
            _serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((MunicipioDto)null));
            _service = _serviceMok.Object;

            var _record = await _service.Get(IdMunicipio);
            Assert.Null(_record);
        }
    }
}
