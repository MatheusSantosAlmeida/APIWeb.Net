using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Email obrigatorio para o login")]
        [EmailAddress(ErrorMessage = "Email contém formato invalido")]
        [StringLength(100, ErrorMessage = "Email deve conter {1} caracteres.")]
        public string Email { get; set; }
    }
}
