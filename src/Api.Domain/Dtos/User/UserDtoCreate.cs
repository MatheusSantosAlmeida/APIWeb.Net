using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.User
{
    public class UserDtoCreate
    {
        [Required(ErrorMessage = "Nome obrigatorio")]
        [StringLength(60, ErrorMessage = "Nome deve conter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é campo obrigatorio")]
        [EmailAddress(ErrorMessage = "Email contém formato invalido")]
        [StringLength(100, ErrorMessage = "Email deve conter {1} caracteres.")]
        public string Email { get; set; }
    }
}
