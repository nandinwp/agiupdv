using Agiu_PDV.Data.Repositories;
using Agiu_PDV.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agiu_PDV.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ClienteRepository _clienteRepository;

        public ClienteService(ClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<IEnumerable<Cliente>> ObterTodosClientesAsync()
        {
            return (IEnumerable<Cliente>)await _clienteRepository.GetAllAsync();
        }

        public async Task<bool> AdicionarClienteAsync(Cliente cliente)
        {
            return await _clienteRepository.AddAsync(cliente);
        }

        public async Task<bool> UpdateAsync(Cliente cliente)
        {
            return await _clienteRepository.UpdateAsync(cliente);
        }

        public async Task<bool> DeleteAsync(int clienteId)
        {
            return await _clienteRepository.DeleteAsync(clienteId);
        }

        public async Task<Cliente> GetByIdAsync(int clienteId)
        {
            return await _clienteRepository.GetByIdAsync(clienteId);
        }

        public async Task<Cliente> GetByNameAsync(string nome)
        {
            return await _clienteRepository.GetByNameAsync(nome);
        }
    }
}
