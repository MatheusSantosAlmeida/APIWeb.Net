using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;

namespace Api.Service.Test.Usuario
{
    public class GetAllTest : UsuarioTeste
    {
        private IUserService _userservice;
        private Mock<IUserService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo GETALL.")]
        public async Task E_Possivel_Executar_GETALL()
        {
            _serviceMok = new Mock<IUserService>();
            _serviceMok.Setup(m => m.GetAll()).ReturnsAsync(listaUserDto);
            _userservice = _serviceMok.Object;

            var result = await _userservice.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listresult = new List<UserDto>();
            _serviceMok = new Mock<IUserService>();
            _serviceMok.Setup(m => m.GetAll()).ReturnsAsync(_listresult.AsEnumerable);
            _userservice = _serviceMok.Object;

            var _record = await _userservice.GetAll();
            Assert.Empty(_record);
            Assert.True(_record.Count() == 0);
        }
    }
}
