using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Models
{
    public class VendaItem
    {
        public int VendaItemId { get; set; }

        [Required(ErrorMessage = "O ID da venda é obrigatório.")]
        public int VendaId { get; set; }

        [Required(ErrorMessage = "O ID do produto é obrigatório.")]
        public int ProdutoId { get; set; }

        [Required(ErrorMessage = "A quantidade é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser maior que zero.")]
        public int Quantidade { get; set; }

        [Required(ErrorMessage = "O preço unitário é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O preço unitário deve ser um valor positivo.")]
        public decimal PrecoUnitario { get; set; }

        public Venda Venda { get; set; }
        public Produto Produto { get; set; }
    }
}
