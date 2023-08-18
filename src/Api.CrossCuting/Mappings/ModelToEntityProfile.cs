using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCuting.Mappings
{
    public class ModelToEntityProfile : Profile
    {
        public ModelToEntityProfile()
        {
            CreateMap<UserEntity, UserModel>().ReverseMap();

            CreateMap<UfEntity, UfModel>().ReverseMap();

            CreateMap<MunicipioEntity, MunicipioModel>().ReverseMap();

            CreateMap<CepEntity, CepModel>().ReverseMap();
        }
    }
}
