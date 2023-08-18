using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Dtos.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCuting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region User
            CreateMap<UserModel, UserDtoCreate>().ReverseMap();
            CreateMap<UserModel, UserDtoUpdate>().ReverseMap();
            CreateMap<UserModel, UserDto>().ReverseMap();
            #endregion

            #region Uf
            CreateMap<UfModel, UfDto>().ReverseMap();
            #endregion

            #region Municipio
            CreateMap<MunicipioModel, MunicipioDtoCreat>().ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoUpdate>().ReverseMap();
            CreateMap<MunicipioModel, MunicipioDto>().ReverseMap();
            CreateMap<MunicipioModel, MunicipioDtoCompleto>().ReverseMap();
            #endregion

            #region Cep
            CreateMap<CepModel, CepDtoCreat>().ReverseMap();
            CreateMap<CepModel, CepDtoUpdate>().ReverseMap();
            CreateMap<CepModel, CepDto>().ReverseMap();
            #endregion
        }
    }
}
