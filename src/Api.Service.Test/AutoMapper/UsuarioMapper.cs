using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.User;
using Api.Domain.Entities;
using Api.Domain.Models;

namespace Api.Service.Test.AutoMapper
{
    public class UsuarioMapper : BaseTestService
    {
        [Fact(DisplayName = "É Possivel Mapear os Modelos")]
        public void E_Possivel_Mapear_Modelos()
        {
            var model = new UserModel
            {
                Id = Guid.NewGuid(),
                Name = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreatAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            var listaEntity = new List<UserEntity>();
            for (int i = 0; i < 5; i++)
            {
                var user = new UserEntity
                {
                    Id = Guid.NewGuid(),
                    Name = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreatAt = DateTime.UtcNow,
                    UpdateAt = DateTime.UtcNow
                };
                listaEntity.Add(user);
            }

            #region ModelToEntity
            // Model => Entity
            var entity = Mapper.Map<UserEntity>(model);
            Assert.Equal(entity.Id, model.Id);
            Assert.Equal(entity.Name, model.Name);
            Assert.Equal(entity.Email, model.Email);
            Assert.Equal(entity.CreatAt, model.CreatAt);
            Assert.Equal(entity.UpdateAt, model.UpdateAt);

            // Entity => Model
            var entityToModel = Mapper.Map<UserModel>(entity);
            Assert.Equal(entityToModel.Id, entity.Id);
            Assert.Equal(entityToModel.Name, entity.Name);
            Assert.Equal(entityToModel.Email, entity.Email);
            Assert.Equal(entityToModel.CreatAt, entity.CreatAt);
            Assert.Equal(entityToModel.UpdateAt, entity.UpdateAt);
            #endregion
            #region EntityToDto
            // Entity => Dto
            var dto = Mapper.Map<UserDto>(entity);
            Assert.Equal(dto.Id, entity.Id);
            Assert.Equal(dto.Name, entity.Name);
            Assert.Equal(dto.Email, entity.Email);
            Assert.Equal(dto.CreatAt, entity.CreatAt);

            // Entity => DtoCreatResult
            var dtoCreatResult = Mapper.Map<UserDtoCreateResult>(entity);
            Assert.Equal(dtoCreatResult.Name, entity.Name);
            Assert.Equal(dtoCreatResult.Email, entity.Email);
            Assert.Equal(dtoCreatResult.CreatAt, entity.CreatAt);

            // Entity => DtoUpdateResult
            var dtoUpdateResult = Mapper.Map<UserDtoUpdateResult>(entity);
            Assert.Equal(dtoUpdateResult.Id, entity.Id);
            Assert.Equal(dtoUpdateResult.Name, entity.Name);
            Assert.Equal(dtoUpdateResult.Email, entity.Email);
            Assert.Equal(dtoUpdateResult.UpdateAt, entity.UpdateAt);

            // Dto => Entity
            var dtoToEntity = Mapper.Map<UserEntity>(dto);
            Assert.Equal(dtoToEntity.Id, dto.Id);
            Assert.Equal(dtoToEntity.Name, dto.Name);
            Assert.Equal(dtoToEntity.Email, dto.Email);
            Assert.Equal(dtoToEntity.CreatAt, dto.CreatAt);

            // DtoCreatResult => Entity
            var dtoCreatResultToEntity = Mapper.Map<UserEntity>(dtoCreatResult);
            Assert.Equal(dtoCreatResultToEntity.Name, dtoCreatResult.Name);
            Assert.Equal(dtoCreatResultToEntity.Email, dtoCreatResult.Email);
            Assert.Equal(dtoCreatResultToEntity.CreatAt, dtoCreatResult.CreatAt);

            // DtoUpdateResult => Entity
            var dtoUpdateResultToEntity = Mapper.Map<UserEntity>(dtoUpdateResult);
            Assert.Equal(dtoUpdateResultToEntity.Id, dtoUpdateResult.Id);
            Assert.Equal(dtoUpdateResultToEntity.Name, dtoUpdateResult.Name);
            Assert.Equal(dtoUpdateResultToEntity.Email, dtoUpdateResult.Email);
            Assert.Equal(dtoUpdateResultToEntity.UpdateAt, dtoUpdateResult.UpdateAt);
            #endregion
            #region DtoToModel
            // Model => Dto
            var modelToDto = Mapper.Map<UserDto>(model);
            Assert.Equal(modelToDto.Id, model.Id);
            Assert.Equal(modelToDto.Name, model.Name);
            Assert.Equal(modelToDto.Email, model.Email);
            Assert.Equal(modelToDto.CreatAt, model.CreatAt);

            // Model => DtoCreat
            var dtoCreat = Mapper.Map<UserDtoCreate>(model);
            Assert.Equal(dtoCreat.Name, model.Name);
            Assert.Equal(dtoCreat.Email, model.Email);

            // Model => DtoUpdate
            var dtoUpdate = Mapper.Map<UserDtoUpdate>(model);
            Assert.Equal(dtoUpdate.Id, model.Id);
            Assert.Equal(dtoUpdate.Name, model.Name);
            Assert.Equal(dtoUpdate.Email, model.Email);

            // Dto => Model
            var dtoToModelV = Mapper.Map<UserModel>(modelToDto);
            Assert.Equal(dtoToModelV.Id, modelToDto.Id);
            Assert.Equal(dtoToModelV.Name, modelToDto.Name);
            Assert.Equal(dtoToModelV.Email, modelToDto.Email);
            Assert.Equal(dtoToModelV.CreatAt, modelToDto.CreatAt);

            //DtoCreat => Model
            var dtoCreateToModel = Mapper.Map<UserModel>(dtoCreat);
            Assert.Equal(dtoCreateToModel.Name, dtoCreat.Name);
            Assert.Equal(dtoCreateToModel.Email, dtoCreat.Email);

            //DtoUpdate => Model
            var dtoUpdateToModel = Mapper.Map<UserModel>(dtoUpdate);
            Assert.Equal(dtoUpdateToModel.Id, dtoUpdate.Id);
            Assert.Equal(dtoUpdateToModel.Name, dtoUpdate.Name);
            Assert.Equal(dtoUpdateToModel.Email, dtoUpdate.Email);
            #endregion

            // ListaEntity => ListaDto
            var listaDto = Mapper.Map<List<UserDto>>(listaEntity);
            Assert.True(listaDto.Count() == listaEntity.Count());
            for (int i = 0; i < listaDto.Count(); i++)
            {
                Assert.Equal(listaDto[i].Id, listaEntity[i].Id);
                Assert.Equal(listaDto[i].Name, listaEntity[i].Name);
                Assert.Equal(listaDto[i].Email, listaEntity[i].Email);
                Assert.Equal(listaDto[i].CreatAt, listaEntity[i].CreatAt);
            }
        }
    }
}
