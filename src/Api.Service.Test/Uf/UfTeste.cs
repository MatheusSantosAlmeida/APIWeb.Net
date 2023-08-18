using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Uf;

namespace Api.Service.Test.Uf
{
    public class UfTeste
    {
        public static string Sigla { get; set; }
        public static string NameUf { get; set; }
        public static Guid IdUf { get; set; }

        public List<UfDto> listaUfDto = new List<UfDto>();
        public UfDto ufDto;

        public UfTeste()
        {
            IdUf = Guid.NewGuid();
            Sigla = Faker.Address.UsState().Substring(1, 3);
            NameUf = Faker.Address.UsState();

            for (int i = 0; i < 10; i++)
            {
                var dto = new UfDto
                {
                    Id = Guid.NewGuid(),
                    Sigla = Faker.Address.UsState().Substring(1, 3),
                    NameUf = Faker.Address.UsState()
                };
                listaUfDto.Add(dto);
            }

            ufDto = new UfDto
            {
                Id = IdUf,
                Sigla = Sigla,
                NameUf = NameUf
            };
        }
    }
}
