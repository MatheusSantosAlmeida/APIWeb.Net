using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Moq;

namespace Api.Service.Test.Cep
{
    public class PutCepTest : CepBaseTest
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo PUT.")]
        public async Task E_Possivel_Executar_PUT()
        {
            _serviceMok = new Mock<ICepService>();
            _serviceMok.Setup(m => m.Post(cepDtoCreat)).ReturnsAsync(cepDtoCreatResult);
            _service = _serviceMok.Object;

            var result = await _service.Post(cepDtoCreat);
            Assert.NotNull(result);
            Assert.Equal(CepC, result.Cep);
            Assert.Equal(LogradouroC, result.Logradouro);
            Assert.Equal(NumeroCep, result.Numero);
            Assert.Equal(MunicipioId, result.MunicipioId);
            Assert.NotNull(result.CreatAt);

            _serviceMok = new Mock<ICepService>();
            _serviceMok.Setup(m => m.Put(cepDtoUpdate)).ReturnsAsync(cepDtoUpdateResult);
            _service = _serviceMok.Object;

            var resultUpdate = await _service.Put(cepDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(IdCep, resultUpdate.Id);
            Assert.Equal(CepC, resultUpdate.Cep);
            Assert.Equal(LogradouroC, resultUpdate.Logradouro);
            Assert.Equal(NumeroCepAlterado, resultUpdate.Numero);
            Assert.Equal(MunicipioId, resultUpdate.MunicipioId);
            Assert.NotNull(resultUpdate.UpdateAt);
        }
    }
}
