using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Entities;
using Api.Domain.Models;

namespace Api.Service.Test.AutoMapper
{
    public class MunicipioMapper : BaseTestService
    {
        [Fact(DisplayName = "É Possivel Mapear os Modelos")]
        public void E_Possivel_Mapear_Modelos()
        {
            var model = new MunicipioModel()
            {
                Id = Guid.NewGuid(),
                Nome = Faker.Address.City(),
                CodIBGE = Faker.RandomNumber.Next(1, 10000),
                UfId = Guid.NewGuid(),
                CreatAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listaEntity = new List<MunicipioEntity>();
            for (int i = 0; i < 5; i++)
            {
                var municipios = new MunicipioEntity
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid(),
                    CreatAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow,
                    Uf = new UfEntity
                    {
                        Id = Guid.NewGuid(),
                        Sigla = Faker.Address.UsState().Substring(1, 3),
                        NameUf = Faker.Address.UsState(),
                    }
                };
                listaEntity.Add(municipios);
            }

            #region ModelToEntity
            // Model => Entity
            var entity = Mapper.Map<MunicipioEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Nome, model.Nome);
            Assert.Equal(entity.CodIBGE, model.CodIBGE);
            Assert.Equal(entity.UfId, model.UfId);
            Assert.Equal(entity.CreatAt, model.CreatAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            // Entity => Model
            var entityToModel = Mapper.Map<MunicipioModel>(entity);
            Assert.Equal(entityToModel.Id, entity.Id);
            Assert.Equal(entityToModel.Nome, entity.Nome);
            Assert.Equal(entityToModel.CodIBGE, entity.CodIBGE);
            Assert.Equal(entityToModel.UfId, entity.UfId);
            Assert.Equal(entityToModel.CreatAt, entity.CreatAt);
            Assert.Equal(entityToModel.UpdateAt, entity.UpdateAt);
            #endregion
            #region EntityToDto
            // Entity => Dto
            var dto = Mapper.Map<MunicipioDto>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.Nome, entity.Nome);
            Assert.Equal(dto.CodIBGE, entity.CodIBGE);
            Assert.Equal(dto.UfId, entity.UfId);

            // Entity => DtoCreatResult
            var dtoCreatResult = Mapper.Map<MunicipioCreatDtoResult>(entity);
            Assert.Equal(dtoCreatResult.Id, entity.Id);
            Assert.Equal(dtoCreatResult.Nome, entity.Nome);
            Assert.Equal(dtoCreatResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(dtoCreatResult.UfId, entity.UfId);
            Assert.Equal(dtoCreatResult.CreatAt, entity.CreatAt);

            // Entity => DtoUpdateResult
            var dtoUpdateResult = Mapper.Map<MunicipioDtoUpdateResult>(entity);
            Assert.Equal(dtoUpdateResult.Id, entity.Id);
            Assert.Equal(dtoUpdateResult.Nome, entity.Nome);
            Assert.Equal(dtoUpdateResult.CodIBGE, entity.CodIBGE);
            Assert.Equal(dtoUpdateResult.UfId, entity.UfId);
            Assert.Equal(dtoUpdateResult.UpdateAt, entity.UpdateAt);

            // Entity => DtoCompleto
            var dtoCompleto = Mapper.Map<MunicipioDtoCompleto>(listaEntity.FirstOrDefault());
            Assert.Equal(dtoCompleto.Id, listaEntity.FirstOrDefault().Id);
            Assert.Equal(dtoCompleto.Nome, listaEntity.FirstOrDefault().Nome);
            Assert.Equal(dtoCompleto.CodIBGE, listaEntity.FirstOrDefault().CodIBGE);
            Assert.Equal(dtoCompleto.UfId, listaEntity.FirstOrDefault().UfId);
            Assert.NotNull(dtoCompleto.Uf);
            Assert.Equal(dtoCompleto.Uf.Id, listaEntity.FirstOrDefault().Uf.Id);

            // Dto => Entity
            var dtoToEntity = Mapper.Map<MunicipioEntity>(dto);
            Assert.Equal(dtoToEntity.Id, dto.Id);
            Assert.Equal(dtoToEntity.Nome, dto.Nome);
            Assert.Equal(dtoToEntity.CodIBGE, dto.CodIBGE);
            Assert.Equal(dtoToEntity.UfId, dto.UfId);

            // DtoCompleto => Entity
            var dtoCompletoToEntity = Mapper.Map<MunicipioEntity>(dtoCompleto);
            Assert.Equal(dtoCompletoToEntity.Id, dtoCompleto.Id);
            Assert.Equal(dtoCompletoToEntity.Nome, dtoCompleto.Nome);
            Assert.Equal(dtoCompletoToEntity.CodIBGE, dtoCompleto.CodIBGE);
            Assert.Equal(dtoCompletoToEntity.UfId, dtoCompleto.UfId);
            Assert.NotNull(dtoCompletoToEntity.Uf);
            Assert.Equal(dtoCompletoToEntity.Uf.Id, dtoCompleto.Uf.Id);

            // DtoCreatResult => Entity
            var dtoCreatResultToEntity = Mapper.Map<MunicipioEntity>(dtoCreatResult);
            Assert.Equal(dtoCreatResultToEntity.Id, dtoCreatResult.Id);
            Assert.Equal(dtoCreatResultToEntity.Nome, dtoCreatResult.Nome);
            Assert.Equal(dtoCreatResultToEntity.CodIBGE, dtoCreatResult.CodIBGE);
            Assert.Equal(dtoCreatResultToEntity.UfId, dtoCreatResult.UfId);
            Assert.Equal(dtoCreatResultToEntity.CreatAt, dtoCreatResult.CreatAt);

            // DtoUpdateResult => Entity
            var dtoUpdateResultToEntity = Mapper.Map<MunicipioEntity>(dtoUpdateResult);
            Assert.Equal(dtoUpdateResultToEntity.Id, dtoUpdateResult.Id);
            Assert.Equal(dtoUpdateResultToEntity.Nome, dtoUpdateResult.Nome);
            Assert.Equal(dtoUpdateResultToEntity.CodIBGE, dtoUpdateResult.CodIBGE);
            Assert.Equal(dtoUpdateResultToEntity.UfId, dtoUpdateResult.UfId);
            Assert.Equal(dtoUpdateResultToEntity.UpdateAt, dtoUpdateResult.UpdateAt);
            #endregion
            #region DtoToModel
            // Model => Dto
            var dtoToModel = Mapper.Map<MunicipioDto>(model);
            Assert.Equal(dto.Id, model.Id);
            Assert.Equal(dto.Nome, model.Nome);
            Assert.Equal(dto.CodIBGE, model.CodIBGE);
            Assert.Equal(dto.UfId, model.UfId);

            // Model => DtoCreat
            var dtoCreat = Mapper.Map<MunicipioDtoCreat>(model);
            Assert.Equal(dtoCreat.Nome, model.Nome);
            Assert.Equal(dtoCreat.CodIBGE, model.CodIBGE);
            Assert.Equal(dtoCreat.UfId, model.UfId);

            // Model => DtoUpdate
            var dtoUpdate = Mapper.Map<MunicipioDtoUpdate>(model);
            Assert.Equal(dtoUpdate.Id, model.Id);
            Assert.Equal(dtoUpdate.Nome, model.Nome);
            Assert.Equal(dtoUpdate.CodIBGE, model.CodIBGE);
            Assert.Equal(dtoUpdate.UfId, model.UfId);

            // DtoCompleto => Model
            var dtoCompletoToModel = Mapper.Map<MunicipioModel>(dtoCompleto);
            Assert.Equal(dtoCompletoToModel.Id, dtoCompleto.Id);
            Assert.Equal(dtoCompletoToModel.Nome, dtoCompleto.Nome);
            Assert.Equal(dtoCompletoToModel.CodIBGE, dtoCompleto.CodIBGE);
            Assert.Equal(dtoCompletoToModel.UfId, dtoCompleto.UfId);

            // Model => DtoCompleto
            var modelToDtoCompleto = Mapper.Map<MunicipioDtoCompleto>(dtoCompletoToModel);
            Assert.Equal(dtoCompletoToModel.Id, dtoCompleto.Id);
            Assert.Equal(dtoCompletoToModel.Nome, dtoCompleto.Nome);
            Assert.Equal(dtoCompletoToModel.CodIBGE, dtoCompleto.CodIBGE);
            Assert.Equal(dtoCompletoToModel.UfId, dtoCompleto.UfId);
            Assert.Null(modelToDtoCompleto.Uf);

            // Dto => Model
            var dtoToModelV = Mapper.Map<MunicipioModel>(dto);
            Assert.Equal(dtoToModelV.Id, dto.Id);
            Assert.Equal(dtoToModelV.Nome, dto.Nome);
            Assert.Equal(dtoToModelV.CodIBGE, dto.CodIBGE);
            Assert.Equal(dtoToModelV.UfId, dto.UfId);

            //DtoCreat => Model
            var dtoCreateToModel = Mapper.Map<MunicipioModel>(dtoCreat);
            Assert.Equal(dtoCreateToModel.Nome, dtoCreat.Nome);
            Assert.Equal(dtoCreateToModel.CodIBGE, dtoCreat.CodIBGE);
            Assert.Equal(dtoCreateToModel.UfId, dtoCreat.UfId);

            //DtoUpdate => Model
            var dtoUpdateToModel = Mapper.Map<MunicipioModel>(dtoUpdate);
            Assert.Equal(dtoUpdateToModel.Id, dtoUpdate.Id);
            Assert.Equal(dtoUpdateToModel.Nome, dtoUpdate.Nome);
            Assert.Equal(dtoUpdateToModel.CodIBGE, dtoUpdate.CodIBGE);
            Assert.Equal(dtoUpdateToModel.UfId, dtoUpdate.UfId);
            #endregion

            // ListaEntity => ListaDto
            var listaDto = Mapper.Map<List<MunicipioDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Nome, listaEntity[i].Nome);
                Assert.Equal(listaDto[i].CodIBGE, listaEntity[i].CodIBGE);
                Assert.Equal(listaDto[i].UfId, listaEntity[i].UfId);
            }
        }
    }
}
