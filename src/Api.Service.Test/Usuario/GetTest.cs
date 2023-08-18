using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Interfaces.Services.User;
using Moq;

namespace Api.Service.Test.Usuario
{
    public class GetTest : UsuarioTeste
    {
        private IUserService _userservice;
        private Mock<IUserService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo GET.")]
        public async Task E_Possivel_Executar_GET()
        {
            _serviceMok = new Mock<IUserService>();
            _serviceMok.Setup(m => m.Get(IdUsuario)).ReturnsAsync(userDto);
            _userservice = _serviceMok.Object;

            var result = await _userservice.Get(IdUsuario);
            Assert.NotNull(result);
            Assert.True(result.Id == IdUsuario);
            Assert.Equal(NomeUsuario, result.Name);

            _serviceMok = new Mock<IUserService>();
            _serviceMok.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((UserDto)null));
            _userservice = _serviceMok.Object;

            var _record = await _userservice.Get(IdUsuario);
            Assert.Null(_record);
        }
    }
}
