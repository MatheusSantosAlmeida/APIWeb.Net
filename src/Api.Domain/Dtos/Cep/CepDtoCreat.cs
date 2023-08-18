using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Cep
{
    public class CepDtoCreat
    {
        [Required(ErrorMessage = "CEP obrigatorio")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "Logradouro obrigatorio")]
        public string Logradouro { get; set; }

        public string? Numero { get; set; }

        [Required(ErrorMessage = "Id do municipio obrigatorio")]
        public Guid MunicipioId { get; set; }
    }
}
