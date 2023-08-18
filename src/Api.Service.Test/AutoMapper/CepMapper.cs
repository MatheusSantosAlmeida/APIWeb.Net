using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Entities;
using Api.Domain.Models;

namespace Api.Service.Test.AutoMapper
{
    public class CepMapper : BaseTestService
    {
        [Fact(DisplayName = "É Possivel Mapear os Modelos")]
        public void E_Possivel_Mapear_Modelos()
        {
            var model = new CepModel()
            {
                Id = Guid.NewGuid(),
                Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
                Logradouro = Faker.Address.StreetName(),
                Numero = "",
                CreatAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow,
                MunicipioId = Guid.NewGuid()
            };

            var listaEntity = new List<CepEntity>();
            for (int i = 0; i < 5; i++)
            {
                var municipios = new CepEntity
                {
                    Id = Guid.NewGuid(),
                    Cep = Faker.RandomNumber.Next(1, 10000).ToString(),
                    Logradouro = Faker.Address.StreetName(),
                    Numero = Faker.RandomNumber.Next(1, 10000).ToString(),
                    CreatAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    MunicipioId = Guid.NewGuid(),
                    Municipio = new MunicipioEntity
                    {
                        Id = Guid.NewGuid(),
                        Nome = Faker.Address.City(),
                        CodIBGE = Faker.RandomNumber.Next(1, 10000),
                        UfId = Guid.NewGuid(),
                        Uf = new UfEntity
                        {
                            Id = Guid.NewGuid(),
                            Sigla = Faker.Address.UsState().Substring(1, 3),
                            NameUf = Faker.Address.UsState(),
                        }
                    }
                };
                listaEntity.Add(municipios);
            }

            #region ModelToEntity
            // Model => Entity
            var entity = Mapper.Map<CepEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Cep, model.Cep);
            Assert.Equal(entity.Logradouro, model.Logradouro);
            Assert.Equal(entity.Numero, model.Numero);
            Assert.Equal(entity.CreatAt, model.CreatAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);
            Assert.Equal(entity.MunicipioId, model.MunicipioId);

            // Entity => Model
            var entityToModel = Mapper.Map<CepModel>(entity);
            Assert.Equal(entityToModel.Id, entity.Id);
            Assert.Equal(entityToModel.Cep, entity.Cep);
            Assert.Equal(entityToModel.Logradouro, entity.Logradouro);
            Assert.Equal(entityToModel.Numero, entity.Numero);
            Assert.Equal(entityToModel.CreatAt, entity.CreatAt);
            Assert.Equal(entityToModel.UpdateAt, entity.UpdateAt);
            Assert.Equal(entityToModel.MunicipioId, entity.MunicipioId);
            #endregion

            #region EntityToDto
            // Entity => Dto
            var dto = Mapper.Map<CepDto>(listaEntity.FirstOrDefault());
            Assert.Equal(dto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(dto.Cep, listaEntity.FirstOrDefault().Cep);
            Assert.Equal(dto.Numero, listaEntity.FirstOrDefault().Numero);
            Assert.Equal(dto.Logradouro, listaEntity.FirstOrDefault().Logradouro);
            Assert.Equal(dto.MunicipioId, listaEntity.FirstOrDefault().MunicipioId);
            Assert.NotNull(dto.Municipio);
            Assert.NotNull(dto.Municipio.Uf);

            // Entity => DtoCreatResult
            var dtoCreatResult = Mapper.Map<CepDtoCreatResult>(entity);
            Assert.Equal(dtoCreatResult.Id, entity.Id);
            Assert.Equal(dtoCreatResult.Cep, entity.Cep);
            Assert.Equal(dtoCreatResult.Logradouro, entity.Logradouro);
            Assert.Equal(dtoCreatResult.Numero, entity.Numero);
            Assert.Equal(dtoCreatResult.CreatAt, entity.CreatAt);
            Assert.Equal(dtoCreatResult.MunicipioId, entity.MunicipioId);

            // Entity => DtoUpdateResult
            var dtoUpdateResult = Mapper.Map<CepDtoUpdateResult>(entity);
            Assert.Equal(dtoUpdateResult.Id, entity.Id);
            Assert.Equal(dtoUpdateResult.Cep, entity.Cep);
            Assert.Equal(dtoUpdateResult.Logradouro, entity.Logradouro);
            Assert.Equal(dtoUpdateResult.Numero, entity.Numero);
            Assert.Equal(dtoUpdateResult.UpdateAt, entity.UpdateAt);
            Assert.Equal(dtoUpdateResult.MunicipioId, entity.MunicipioId);
            #endregion

            #region DtoToModel
            // Model => Dto
            var dtoToModel = Mapper.Map<CepDto>(model);
            Assert.Equal(dtoToModel.Id, model.Id);
            Assert.Equal(dtoToModel.Cep, model.Cep);
            Assert.Equal(dtoToModel.Logradouro, model.Logradouro);
            Assert.Equal("S/N", model.Numero);
            Assert.Equal(dtoToModel.MunicipioId, model.MunicipioId);

            // Model => DtoCreat
            var dtoCreat = Mapper.Map<CepDtoCreat>(model);
            Assert.Equal(dtoCreat.Cep, model.Cep);
            Assert.Equal(dtoCreat.Logradouro, model.Logradouro);
            Assert.Equal(dtoCreat.Numero, model.Numero);
            Assert.Equal(dtoCreat.MunicipioId, model.MunicipioId);

            // Model => DtoUpdate
            var dtoUpdate = Mapper.Map<CepDtoUpdate>(model);
            Assert.Equal(dtoUpdate.Id, model.Id);
            Assert.Equal(dtoUpdate.Cep, model.Cep);
            Assert.Equal(dtoUpdate.Logradouro, model.Logradouro);
            Assert.Equal(dtoUpdate.Numero, model.Numero);
            Assert.Equal(dtoUpdate.MunicipioId, model.MunicipioId);
            #endregion

            // ListaEntity => ListaDto
            var listaDto = Mapper.Map<List<CepDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Numero, listaEntity[i].Numero);
                Assert.Equal(listaDto[i].Logradouro, listaEntity[i].Logradouro);
                Assert.Equal(listaDto[i].Cep, listaEntity[i].Cep);
            }
        }
    }
}
