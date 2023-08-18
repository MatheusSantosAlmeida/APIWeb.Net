using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;

namespace Api.Service.Test.Usuario
{
    public class DeleteTest : UsuarioTeste
    {
        private IUserService _userservice;
        private Mock<IUserService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo DELETE.")]
        public async Task E_Possivel_Executar_DELETE()
        {
            _serviceMok = new Mock<IUserService>();
            _serviceMok.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _userservice = _serviceMok.Object;

            var result = await _userservice.Delete(IdUsuario);
            Assert.True(result);

            _serviceMok = new Mock<IUserService>();
            _serviceMok.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _userservice = _serviceMok.Object;

            result = await _userservice.Delete(Guid.NewGuid());
            Assert.False(result);
        }
    }
}
