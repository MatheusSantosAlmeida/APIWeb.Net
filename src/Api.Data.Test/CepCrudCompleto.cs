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
    public class CepCrudCompleto : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public CepCrudCompleto(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "CRUD Cep")]
        [Trait("CRUD", "CepEntity")]
        public async Task E_Possivel_Realizar_CRUD_Cep()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                MunicipioImplementation _repositorioMunicipio = new MunicipioImplementation(context);
                MunicipioEntity _entityMunicipio = new MunicipioEntity()
                {
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1000000, 9999999),
                    UfId = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee")
                };


                var _registroCriado = await _repositorioMunicipio.InsertAsync(_entityMunicipio);
                Assert.NotNull(_registroCriado);
                Assert.Equal(_entityMunicipio.Nome, _registroCriado.Nome);
                Assert.Equal(_entityMunicipio.CodIBGE, _registroCriado.CodIBGE);
                Assert.Equal(_entityMunicipio.UfId, _registroCriado.UfId);
                Assert.False(_registroCriado.Id == Guid.Empty);

                CepImplementation _repositorioCep = new CepImplementation(context);
                CepEntity _entityCep = new CepEntity()
                {
                    Cep = "58714-000",
                    Logradouro = Faker.Address.StreetName(),
                    Numero = "0 até 2000",
                    MunicipioId = _registroCriado.Id
                };

                var _registroCriadoCep = await _repositorioCep.InsertAsync(_entityCep);
                Assert.NotNull(_registroCriadoCep);
                Assert.Equal(_entityCep.Cep, _registroCriadoCep.Cep);
                Assert.Equal(_entityCep.Logradouro, _registroCriadoCep.Logradouro);
                Assert.Equal(_entityCep.Numero, _registroCriadoCep.Numero);
                Assert.False(_registroCriadoCep.Id == Guid.Empty);
                Assert.Equal(_entityCep.MunicipioId, _registroCriadoCep.MunicipioId);

                _entityCep.Logradouro = Faker.Address.StreetName();
                var _registroCriadoCepAtualizado = await _repositorioCep.UpdateAsync(_entityCep);
                Assert.NotNull(_registroCriadoCepAtualizado);
                Assert.Equal(_entityCep.Cep, _registroCriadoCepAtualizado.Cep);
                Assert.Equal(_entityCep.Logradouro, _registroCriadoCepAtualizado.Logradouro);
                Assert.Equal(_entityCep.Numero, _registroCriadoCepAtualizado.Numero);
                Assert.Equal(_entityCep.MunicipioId, _registroCriadoCepAtualizado.MunicipioId);
                Assert.Equal(_entityCep.Id, _registroCriadoCepAtualizado.Id);

                var _existeRegistro = await _repositorioCep.ExistAsync(_registroCriadoCepAtualizado.Id);
                Assert.True(_existeRegistro);

                var _registroSelecionadoCep = await _repositorioCep.SelectAsync(_registroCriadoCepAtualizado.Id);
                Assert.NotNull(_registroSelecionadoCep);
                Assert.Equal(_registroCriadoCepAtualizado.Cep, _registroSelecionadoCep.Cep);
                Assert.Equal(_registroCriadoCepAtualizado.Logradouro, _registroSelecionadoCep.Logradouro);
                Assert.Equal(_registroCriadoCepAtualizado.Numero, _registroSelecionadoCep.Numero);
                Assert.Equal(_registroCriadoCepAtualizado.MunicipioId, _registroSelecionadoCep.MunicipioId);
                Assert.Equal(_registroCriadoCepAtualizado.Id, _registroSelecionadoCep.Id);

                _registroSelecionadoCep = await _repositorioCep.SelectAsync(_registroCriadoCepAtualizado.Cep);
                Assert.NotNull(_registroSelecionadoCep);
                Assert.Equal(_registroCriadoCepAtualizado.Cep, _registroSelecionadoCep.Cep);
                Assert.Equal(_registroCriadoCepAtualizado.Logradouro, _registroSelecionadoCep.Logradouro);
                Assert.Equal(_registroCriadoCepAtualizado.Numero, _registroSelecionadoCep.Numero);
                Assert.Equal(_registroCriadoCepAtualizado.MunicipioId, _registroSelecionadoCep.MunicipioId);
                Assert.Equal(_registroCriadoCepAtualizado.Id, _registroSelecionadoCep.Id);
                Assert.NotNull(_registroSelecionadoCep.Municipio);
                Assert.Equal(_registroCriadoCepAtualizado.Municipio.Nome, _registroSelecionadoCep.Municipio.Nome);
                Assert.NotNull(_registroSelecionadoCep.Municipio.Uf);
                Assert.Equal("PB", _registroSelecionadoCep.Municipio.Uf.Sigla);

                var _todosRegistros = await _repositorioCep.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() > 0);

                var _removeu = await _repositorioCep.DeleteAsync(_registroCriadoCep.Id);
                Assert.True(_removeu);

                _todosRegistros = await _repositorioCep.SelectAsync();
                Assert.NotNull(_todosRegistros);
                Assert.True(_todosRegistros.Count() == 0);
            }
        }

    }
}
