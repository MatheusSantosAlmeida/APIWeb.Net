using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoCreatResult
    {
        public Guid Id { get; set; }

        public string Cep { get; set; }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public Guid MunicipioId { get; set; }

        public DateTime CreatAt { get; set; }
    }
}
