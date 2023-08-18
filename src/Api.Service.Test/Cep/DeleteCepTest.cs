using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Cep;
using Moq;

namespace Api.Service.Test.Cep
{
    public class DeleteCepTest : CepBaseTest
    {
        private ICepService _service;
        private Mock<ICepService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo DELETE.")]
        public async Task E_Possivel_Executar_DELETE()
        {
            _serviceMok = new Mock<ICepService>();
            _serviceMok.Setup(m => m.Delete(IdCep)).ReturnsAsync(true);
            _service = _serviceMok.Object;

            var result = await _service.Delete(IdCep);
            Assert.True(result);

            _serviceMok = new Mock<ICepService>();
            _serviceMok.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMok.Object;

            result = await _service.Delete(Guid.NewGuid());
            Assert.False(result);
        }
    }
}
