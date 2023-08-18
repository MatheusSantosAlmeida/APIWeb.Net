using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Interfaces.Services.User;
using Moq;

namespace Api.Service.Test.Login
{
    public class FindByLoginTest
    {
        private ILoginService _service;
        private Mock<ILoginService> _serviceMok;

        [Fact(DisplayName = "É possivel executar o metodo de LOGIN.")]
        public async Task E_Possivel_Executar_LOGIN()
        {
            var email = Faker.Internet.Email();

            var objetoRetorno = new
            {
                authenticated = true,
                created = DateTime.UtcNow,
                expiration = DateTime.UtcNow.AddHours(8),
                acessToken = Guid.NewGuid(),
                userName = email,
                message = "Usuario Logado"
            };

            var loginDto = new LoginDto
            {
                Email = email
            };

            _serviceMok = new Mock<ILoginService>();
            _serviceMok.Setup(m => m.FindByLogin(loginDto)).ReturnsAsync(objetoRetorno);
            _service = _serviceMok.Object;

            var result = await _service.FindByLogin(loginDto);
            Assert.NotNull(result);
        }

    }
}
