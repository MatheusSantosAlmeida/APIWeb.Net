using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Moq;

namespace Api.Service.Test.Usuario
{
    public class PutTest : UsuarioTeste
    {
        private IUserService _userservice;
        private Mock<IUserService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo PUT.")]
        public async Task E_Possivel_Executar_PUT()
        {
            _serviceMok = new Mock<IUserService>();
            _serviceMok.Setup(m => m.Post(userDtoCreate)).ReturnsAsync(userDtoCreateResult);
            _userservice = _serviceMok.Object;

            var result = await _userservice.Post(userDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(NomeUsuario, result.Name);
            Assert.Equal(EmailUsuario, result.Email);

            _serviceMok = new Mock<IUserService>();
            _serviceMok.Setup(m => m.Put(userDtoUpdate)).ReturnsAsync(userDtoUpdateResult);
            _userservice = _serviceMok.Object;

            var resultUpdate = await _userservice.Put(userDtoUpdate);
            Assert.NotNull(resultUpdate);
            Assert.Equal(NomeUsuarioAlterado, resultUpdate.Name);
            Assert.Equal(EmailAlterado, resultUpdate.Email);
        }
    }
}
