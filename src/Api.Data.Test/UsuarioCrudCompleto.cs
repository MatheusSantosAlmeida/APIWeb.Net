using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Date.Context;
using Api.Date.Implementations;
using Api.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public UsuarioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD de Usuario")]
        [Trait("CRUD", "UserEntity")]
        public async Task E_Possivel_Realizar_CRUD_Usario()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                UserImplementation _repositorio = new UserImplementation(context);
                UserEntity _entity = new UserEntity
                {
                    Email = Faker.Internet.Email(),
                    Name = Faker.Name.FullName()
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Email, _registroCriado.Email);
                Assert.Equal(_entity.Name, _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);

                _entity.Name = Faker.Name.First();
                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Id, _registroAtualizado.Id);
                Assert.Equal(_entity.Name, _registroAtualizado.Name);
                Assert.Equal(_entity.Email, _registroAtualizado.Email);

                var _registroExistente = await _repositorio.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExistente);

                var _selecaoRegistro = await _repositorio.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_selecaoRegistro);
                Assert.Equal(_registroAtualizado.Id, _selecaoRegistro.Id);

                var _todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 1);

                var _deleteRegistro = await _repositorio.DeleteAsync(_selecaoRegistro.Id);
                Assert.True(_deleteRegistro);

                var _login = await _repositorio.FindByLogin("adm@mail.com");
                Assert.NotNull(_login);
                Assert.Equal("adm@mail.com", _login.Email);
            }
        }
    }
}
