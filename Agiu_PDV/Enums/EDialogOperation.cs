using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Enums
{
    /// <summary>
    /// Gerencia o modal de itens para que tenhamos somente um modal de update e edit
    /// </summary>
    public enum EDialogOperation : sbyte
    {
          EditarCliente = 0,
          NovoCliente = 1,

          EditarProduto = 2,
          NovoProduto = 3,

          EditarVenda = 4,
          NovaVenda = 5,

          None=6,

          ApagarCliente = 7,
          ApagarProduto = 8,
          ApagarVenda = 9,

          Relatorio = 10
    }
}
