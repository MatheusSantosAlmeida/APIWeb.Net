using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;
using Api.Domain.Entities;
using Api.Domain.Models;

namespace Api.Service.Test.AutoMapper
{
    public class UfMapper : BaseTestService
    {
        [Fact(DisplayName = "É Possivel Mapear os Modelos")]
        public void E_Possivel_Mapear_Modelos()
        {
            var model = new UfModel()
            {
                Id = Guid.NewGuid(),
                Sigla = Faker.Address.UsState().Substring(1, 3),
                NameUf = Faker.Address.UsState(),
                CreatAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listaEntity = new List<UfEntity>();
            for (int i = 0; i < 5; i++)
            {
                var ufs = new UfEntity
                {
                    Id = Guid.NewGuid(),
                    NameUf = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                    CreatAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listaEntity.Add(ufs);
            }

            #region ModelToEntity
            // Model => Entity
            var entity = Mapper.Map<UfEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.NameUf, model.NameUf);
            Assert.Equal(entity.Sigla, model.Sigla);
            Assert.Equal(entity.CreatAt, model.CreatAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            // Entity => Model
            var entityToModel = Mapper.Map<UfModel>(entity);
            Assert.Equal(entityToModel.Id, entity.Id);
            Assert.Equal(entityToModel.NameUf, entity.NameUf);
            Assert.Equal(entityToModel.Sigla, entity.Sigla);
            Assert.Equal(entityToModel.CreatAt, entity.CreatAt);
            Assert.Equal(entityToModel.UpdateAt, entity.UpdateAt);
            #endregion

            #region EntityToDto
            // Entity => Dto
            var dto = Mapper.Map<UfDto>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.NameUf, entity.NameUf);
            Assert.Equal(dto.Sigla, entity.Sigla);

            // Dto => Entity
            var dtoToEntity = Mapper.Map<UfEntity>(dto);
            Assert.Equal(dtoToEntity.Id, dto.Id);
            Assert.Equal(dtoToEntity.NameUf, dto.NameUf);
            Assert.Equal(dtoToEntity.Sigla, dto.Sigla);
            #endregion

            #region ModelToDto
            // Model => Dto
            var modelToDto = Mapper.Map<UfDto>(model);
            Assert.Equal(modelToDto.Id, model.Id);
            Assert.Equal(modelToDto.NameUf, model.NameUf);
            Assert.Equal(modelToDto.Sigla, model.Sigla);

            // Dto => Model
            var dtoToModel = Mapper.Map<UfModel>(modelToDto);
            Assert.Equal(dtoToModel.Id, modelToDto.Id);
            Assert.Equal(dtoToModel.NameUf, modelToDto.NameUf);
            Assert.Equal(dtoToModel.Sigla, modelToDto.Sigla);
            #endregion

            // ListaEntity => ListaDto
            var listaDto = Mapper.Map<List<UfDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].NameUf, listaEntity[i].NameUf);
                Assert.Equal(listaDto[i].Sigla, listaEntity[i].Sigla);
            }
        }
    }
}
