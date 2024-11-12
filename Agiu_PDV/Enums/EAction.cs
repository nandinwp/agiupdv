using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Enums
{
    public enum EAction : sbyte
    {
        GenClientes = 0,
        GenProdutos = 1,
        GenVendas = 2,
        GenRelatorios = 3,

        CrudDel = 4,
        CrudEdit = 5,
        CrudSave = 6,
        CrudNew = 7
    }
}
