using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;

namespace Api.Service.Test.Municipio
{
    public class MunicipioTeste
    {
        public static Guid IdMunicipio { get; set; }
        public static string NomeMunicipio { get; set; }
        public static string NomeMunicipioAlterado { get; set; }
        public static int CodIBGEMunicipio { get; set; }
        public static int CodIBGEMunicipioAlterado { get; set; }
        public static Guid IdUf { get; set; }

        public List<MunicipioDto> listaMunicipioDto = new List<MunicipioDto>();
        public MunicipioDto municipioDto;
        public MunicipioDtoCompleto municipioDtoCompleto;
        public MunicipioDtoCreat municipioDtoCreat;
        public MunicipioCreatDtoResult municipioCreatDtoResult;
        public MunicipioDtoUpdate municipioDtoUpdate;
        public MunicipioDtoUpdateResult municipioDtoUpdateResult;

        public MunicipioTeste()
        {
            IdMunicipio = Guid.NewGuid();
            NomeMunicipio = Faker.Address.City();
            CodIBGEMunicipio = Faker.RandomNumber.Next(1, 10000);
            NomeMunicipioAlterado = Faker.Address.City();
            CodIBGEMunicipioAlterado = Faker.RandomNumber.Next(1, 10000);
            IdUf = Guid.NewGuid();

            for (int i = 0; i < 10; i++)
            {
                var dto = new MunicipioDto
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid()
                };
                listaMunicipioDto.Add(dto);
            }

            municipioDto = new MunicipioDto
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodIBGEMunicipio,
                UfId = IdUf
            };

            municipioDtoCompleto = new MunicipioDtoCompleto
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodIBGEMunicipio,
                UfId = IdUf,
                Uf = new UfDto
                {
                    Id = Guid.NewGuid(),
                    NameUf = Faker.Address.UsState(),
                    Sigla = Faker.Address.UsState().Substring(1, 3)
                }
            };

            municipioDtoCreat = new MunicipioDtoCreat
            {
                Nome = NomeMunicipio,
                CodIBGE = CodIBGEMunicipio,
                UfId = IdUf
            };

            municipioCreatDtoResult = new MunicipioCreatDtoResult
            {
                Id = IdMunicipio,
                Nome = NomeMunicipio,
                CodIBGE = CodIBGEMunicipio,
                UfId = IdUf,
                CreatAt = DateTime.UtcNow
            };

            municipioDtoUpdate = new MunicipioDtoUpdate
            {
                Id = IdMunicipio,
                Nome = NomeMunicipioAlterado,
                CodIBGE = CodIBGEMunicipioAlterado,
                UfId = IdUf
            };

            municipioDtoUpdateResult = new MunicipioDtoUpdateResult
            {
                Id = IdMunicipio,
                Nome = NomeMunicipioAlterado,
                CodIBGE = CodIBGEMunicipioAlterado,
                UfId = IdUf,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}
