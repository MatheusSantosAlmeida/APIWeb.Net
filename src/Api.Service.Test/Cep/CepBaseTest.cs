using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Cep;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;

namespace Api.Service.Test.Cep
{
    public class CepBaseTest
    {
        public static Guid IdCep { get; set; }
        public static string CepC { get; set; }
        public static string LogradouroC { get; set; }
        public static string NumeroCep { get; set; }
        public static string NumeroCepAlterado { get; set; }
        public static Guid MunicipioId { get; set; }

        public CepDto cepDto;
        public CepDtoCreat cepDtoCreat;
        public CepDtoUpdate cepDtoUpdate;
        public CepDtoCreatResult cepDtoCreatResult;
        public CepDtoUpdateResult cepDtoUpdateResult;

        public CepBaseTest()
        {
            IdCep = Guid.NewGuid();
            CepC = Faker.RandomNumber.Next(1, 10000).ToString();
            LogradouroC = Faker.Address.StreetName();
            NumeroCep = Faker.RandomNumber.Next(1, 10000).ToString();
            NumeroCepAlterado = Faker.RandomNumber.Next(1, 10000).ToString();
            MunicipioId = Guid.NewGuid();

            cepDto = new CepDto
            {
                Id = IdCep,
                Cep = CepC,
                Logradouro = LogradouroC,
                Numero = NumeroCep,
                MunicipioId = MunicipioId,
                Municipio = new MunicipioDtoCompleto
                {
                    Id = Guid.NewGuid(),
                    Nome = Faker.Address.City(),
                    CodIBGE = Faker.RandomNumber.Next(1, 10000),
                    UfId = Guid.NewGuid(),
                    Uf = new UfDto
                    {
                        Id = Guid.NewGuid(),
                        Sigla = Faker.Address.UsState().Substring(1, 3),
                        NameUf = Faker.Address.UsState()
                    }
                }
            };

            cepDtoCreat = new CepDtoCreat
            {
                Cep = CepC,
                Logradouro = LogradouroC,
                Numero = NumeroCep,
                MunicipioId = MunicipioId
            };

            cepDtoCreatResult = new CepDtoCreatResult
            {
                Id = IdCep,
                Cep = CepC,
                Logradouro = LogradouroC,
                Numero = NumeroCep,
                MunicipioId = MunicipioId,
                CreatAt = DateTime.UtcNow
            };

            cepDtoUpdate = new CepDtoUpdate
            {
                Id = IdCep,
                Cep = CepC,
                Logradouro = LogradouroC,
                Numero = NumeroCepAlterado,
                MunicipioId = MunicipioId
            };

            cepDtoUpdateResult = new CepDtoUpdateResult
            {
                Id = IdCep,
                Cep = CepC,
                Logradouro = LogradouroC,
                Numero = NumeroCepAlterado,
                MunicipioId = MunicipioId,
                UpdateAt = DateTime.UtcNow
            };
        }
    }
}
