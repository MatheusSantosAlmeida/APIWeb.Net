using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Interfaces.Services.Cep;
using Moq;

namespace Api.Service.Test.Cep
{
    public class GetCepTest : CepBaseTest
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo GET.")]
        public async Task E_Possivel_Executar_GET()
        {
            _serviceMok = new Mock<ICepService>();
            _serviceMok.Setup(m => m.Get(IdCep)).ReturnsAsync(cepDto);
            _service = _serviceMok.Object;

            var result = await _service.Get(IdCep);
            Assert.NotNull(result);
            Assert.True(result.Id == IdCep);
            Assert.Equal(CepC, result.Cep);
            Assert.Equal(LogradouroC, result.Logradouro);
            Assert.Equal(NumeroCep, result.Numero);
            Assert.Equal(MunicipioId, result.MunicipioId);
            Assert.NotNull(result.Municipio);
            Assert.NotNull(result.Municipio.Uf);

            _serviceMok = new Mock<ICepService>();
            _serviceMok.Setup(m => m.Get(CepC)).ReturnsAsync(cepDto);
            _service = _serviceMok.Object;

            result = await _service.Get(CepC);
            Assert.NotNull(result);
            Assert.True(result.Id == IdCep);
            Assert.Equal(CepC, result.Cep);
            Assert.Equal(LogradouroC, result.Logradouro);
            Assert.Equal(NumeroCep, result.Numero);
            Assert.Equal(MunicipioId, result.MunicipioId);
            Assert.NotNull(result.Municipio);
            Assert.NotNull(result.Municipio.Uf);

            _serviceMok = new Mock<ICepService>();
            _serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CepDto)null));
            _service = _serviceMok.Object;

            var _record = await _service.Get(IdCep);
            Assert.Null(_record);
        }
    }
}
