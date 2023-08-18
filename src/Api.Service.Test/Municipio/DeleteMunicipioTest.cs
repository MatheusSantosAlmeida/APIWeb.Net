using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;

namespace Api.Service.Test.Municipio
{
    public class DeleteMunicipioTest : MunicipioTeste
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo DELETE.")]
        public async Task E_Possivel_Executar_DELETE()
        {
            _serviceMok = new Mock<IMunicipioService>();
            _serviceMok.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMok.Object;

            var result = await _service.Delete(IdMunicipio);
            Assert.True(result);

            _serviceMok = new Mock<IMunicipioService>();
            _serviceMok.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMok.Object;

            result = await _service.Delete(Guid.NewGuid());
            Assert.False(result);
        }
    }
}
