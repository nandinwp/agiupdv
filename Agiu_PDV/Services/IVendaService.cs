using Agiu_PDV.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agiu_PDV.Services
{
    public interface IVendaService
    {
        Task<IEnumerable<Venda>> ObterTodasVendasAsync();
        Task<Venda> GetByIdAsync(int id);
        Task<bool> SaveAsync(Venda venda);
        Task<bool> UpdateAsync(Venda venda);
        Task<bool> AddAsync(Venda venda);
        Task<bool> DeleteAsync(int vendaId);
    }
}