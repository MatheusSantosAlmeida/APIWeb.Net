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
    public class UfGets : BaseTest, IClassFixture<DbTeste>
    {
        private ServiceProvider _serviceProvide;

        public UfGets(DbTeste dbTeste)
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Fact(DisplayName = "Uf Gets")]
        [Trait("GETs", "UfEntity")]
        public async Task Gets_UF()
        {
            using (var context = _serviceProvide.GetService<MyContext>())
            {
                UfImplementation _repositorio = new UfImplementation(context);
                UfEntity _entity = new UfEntity()
                {
                    Id = new Guid("1109ab04-a3a5-476e-bdce-6c3e2c2badee"),
                    Sigla = "PB",
                    NameUf = "Paraíba",
                };

                var result = await _repositorio.ExistAsync(_entity.Id);
                Assert.True(result);

                var _resultGetId = await _repositorio.SelectAsync(_entity.Id);
                Assert.NotNull(_resultGetId);
                Assert.Equal(_entity.Id, _resultGetId.Id);
                Assert.Equal(_entity.NameUf, _resultGetId.NameUf);
                Assert.Equal(_entity.Sigla, _resultGetId.Sigla);

                var _resultGetSigla = await _repositorio.SelectAsync(_entity.Sigla);
                Assert.NotNull(_resultGetSigla);
                Assert.Equal(_entity.Sigla, _resultGetSigla.Sigla);
                Assert.Equal(_entity.NameUf, _resultGetSigla.NameUf);

                var _resultGetAll = await _repositorio.SelectAsync();
                Assert.NotNull(_resultGetAll);
                Assert.True(_resultGetAll.Count() == 27);

            }
        }
    }
}
