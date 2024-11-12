using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O Nome pode ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [MaxLength(150, ErrorMessage = "O Endereço pode ter no máximo 150 caracteres.")]
        public string Endereco { get; set; }

        [Phone(ErrorMessage = "O Telefone deve ser válido.")]
        [MaxLength(15, ErrorMessage = "O Telefone pode ter no máximo 15 caracteres.")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "O Email deve ser válido.")]
        [MaxLength(100, ErrorMessage = "O Email pode ter no máximo 100 caracteres.")]
        public string Email { get; set; }
    }
}
