using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;
using Api.Domain.Interfaces.Services.UF;
using Moq;

namespace Api.Service.Test.Uf
{
    public class GetAllUfTeste : UfTeste
    {
        private IUfService _ufservice;
        private Mock<IUfService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo GETALL.")]
        public async Task E_Possivel_Executar_GETALL()
        {
            _serviceMok = new Mock<IUfService>();
            _serviceMok.Setup(m => m.GetAll()).ReturnsAsync(listaUfDto);
            _ufservice = _serviceMok.Object;

            var result = await _ufservice.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listresult = new List<UfDto>();
            _serviceMok = new Mock<IUfService>();
            _serviceMok.Setup(m => m.GetAll()).ReturnsAsync(_listresult.AsEnumerable);
            _ufservice = _serviceMok.Object;

            var _record = await _ufservice.GetAll();
            Assert.Empty(_record);
            Assert.True(_record.Count() == 0);
        }
    }
}
