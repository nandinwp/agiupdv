using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "O Nome do Produto é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O Nome do Produto pode ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        public string Descricao { get; set; }

        [Required(ErrorMessage = "O Preço é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O Preço deve ser um valor positivo.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A quantidade em Estoque é obrigatória.")]
        [Range(0, int.MaxValue, ErrorMessage = "O Estoque deve ser um número não negativo.")]
        public int Estoque { get; set; }
    }

}
