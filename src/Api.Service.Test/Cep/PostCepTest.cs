using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Moq;

namespace Api.Service.Test.Cep
{
    public class PostCepTest : CepBaseTest
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo POST.")]
        public async Task E_Possivel_Executar_POST()
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
        }
    }
}
