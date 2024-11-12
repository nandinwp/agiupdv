using Agiu_PDV.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agiu_PDV.Services
{
    public interface IClienteService
    {
        Task<bool> AdicionarClienteAsync(Cliente cliente);
        Task<IEnumerable<Cliente>> ObterTodosClientesAsync();
        Task<bool> UpdateAsync(Cliente cliente);
        Task<bool> DeleteAsync(int clienteId);
        Task<Cliente> GetByIdAsync(int clienteId);
        Task<Cliente> GetByNameAsync(string nome);
    }
}