using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.UF;
using Moq;

namespace Api.Service.Test.Uf
{
    public class GetUfTeste : UfTeste
    {
        private IUfService _ufservice;
        private Mock<IUfService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo GET.")]
        public async Task E_Possivel_Executar_GET()
        {
            _serviceMok = new Mock<IUfService>();
            _serviceMok.Setup(m => m.Get(IdUf)).ReturnsAsync(ufDto);
            _ufservice = _serviceMok.Object;

            var result = await _ufservice.Get(IdUf);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUf);
            Assert.Equal(NameUf, result.NameUf);
            Assert.Equal(Sigla, result.Sigla);

            _serviceMok = new Mock<IUfService>();
            _serviceMok.Setup(m => m.Get(Sigla)).ReturnsAsync(ufDto);
            _ufservice = _serviceMok.Object;

            result = await _ufservice.Get(Sigla);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUf);
            Assert.Equal(NameUf, result.NameUf);
            Assert.Equal(Sigla, result.Sigla);

            _serviceMok = new Mock<IUfService>();
            _serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UfDto)null));
            _ufservice = _serviceMok.Object;

            var _record = await _ufservice.Get(IdUf);
            Assert.Null(_record);
        }
    }
}
