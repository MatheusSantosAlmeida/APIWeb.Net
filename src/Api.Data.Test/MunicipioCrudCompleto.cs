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
    public class MunicipioCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public MunicipioCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD Municipio")]
        [Trait("CRUD", "MunicipioEntity")]
        public async Task E_Possivel_Realizar_CRUD_Municipio()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                MunicipioImplementation _repositorio = new MunicipioImplementation(context);
                MunicipioEntity _entity = new MunicipioEntity()
                {
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                    UfId = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee")
                };


                var _registroCriado = await _repositorio.InsertAsync(_entity);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entity.Nome, _registroCriado.Nome);
                Assert.Equal(_entity.CodIBGE, _registroCriado.CodIBGE);
                Assert.Equal(_entity.UfId, _registroCriado.UfId);
                Assert.False(_registroCriado.Id == Guid.Empty);

                _entity.Nome = Faker.Address.City();
                var _registroAtualizado = await _repositorio.UpdateAsync(_entity);
                Assert.NotNull(_registroAtualizado);
                Assert.Equal(_entity.Id, _registroAtualizado.Id);
                Assert.Equal(_entity.Nome, _registroAtualizado.Nome);
                Assert.Equal(_entity.CodIBGE, _registroAtualizado.CodIBGE);

                var _registroExistente = await _repositorio.ExistAsync(_registroAtualizado.Id);
                Assert.True(_registroExistente);

                var _selecaoRegistro = await _repositorio.SelectAsync(_registroAtualizado.Id);
                Assert.NotNull(_selecaoRegistro);
                Assert.Equal(_registroAtualizado.Id, _selecaoRegistro.Id);
                Assert.Equal(_registroAtualizado.Nome, _selecaoRegistro.Nome);
                Assert.Equal(_registroAtualizado.CodIBGE, _selecaoRegistro.CodIBGE);
                Assert.Equal(_registroAtualizado.UfId, _selecaoRegistro.UfId);
                Assert.Null(_selecaoRegistro.Uf);

                var _selecaoCompletaPorCodIBGE = await _repositorio.GetCompleteByIBGE(_registroAtualizado.CodIBGE);
                Assert.NotNull(_selecaoCompletaPorCodIBGE);
                Assert.Equal(_registroAtualizado.CodIBGE, _selecaoCompletaPorCodIBGE.CodIBGE);
                Assert.Equal(_registroAtualizado.UfId, _selecaoCompletaPorCodIBGE.UfId);
                Assert.NotNull(_selecaoCompletaPorCodIBGE.Uf);

                var _selecaoCompletaPorId = await _repositorio.GetCompleteById(_registroAtualizado.Id);
                Assert.NotNull(_selecaoCompletaPorId);
                Assert.Equal(_registroAtualizado.Id, _selecaoCompletaPorId.Id);
                Assert.Equal(_registroAtualizado.UfId, _selecaoCompletaPorId.UfId);
                Assert.NotNull(_selecaoCompletaPorId.Uf);

                var _todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 0);

                var _deleteRegistro = await _repositorio.DeleteAsync(_selecaoRegistro.Id);
                Assert.True(_deleteRegistro);

                _todosRegistros = await _repositorio.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() == 0);

            }
        }
    }
}
