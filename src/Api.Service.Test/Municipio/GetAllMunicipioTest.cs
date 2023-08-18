using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Interfaces.Services.Municipio;
using Moq;

namespace Api.Service.Test.Municipio
{
    public class GetAllMunicipioTest : MunicipioTeste
    {
        private IMunicipioService _service;
        private Mock<IMunicipioService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo GETALL.")]
        public async Task E_Possivel_Executar_GETALL()
        {
            _serviceMok = new Mock<IMunicipioService>();
            _serviceMok.Setup(m => m.GetAll()).ReturnsAsync(listaMunicipioDto);
            _service = _serviceMok.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listresult = new List<MunicipioDto>();
            _serviceMok = new Mock<IMunicipioService>();
            _serviceMok.Setup(m => m.GetAll()).ReturnsAsync(_listresult.AsEnumerable);
            _service = _serviceMok.Object;

            var _record = await _service.GetAll();
            Assert.Empty(_record);
            Assert.True(_record.Count() == 0);
        }
    }
}
