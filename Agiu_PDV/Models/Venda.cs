using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Models
{
    public class Venda
    {
        public int VendaId { get; set; }

        [Required(ErrorMessage = "O Cliente é obrigatório.")]
        public int ClienteId { get; set; }

        public DateTime DataVenda { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "O Valor Total é obrigatório.")]
        [Range(0, double.MaxValue, ErrorMessage = "O Valor Total deve ser um valor positivo.")]
        public decimal ValorTotal { get; set; }

        public Cliente Cliente { get; set; }

        public List<VendaItem> Itens { get; set; } = new List<VendaItem>();
    }
}
