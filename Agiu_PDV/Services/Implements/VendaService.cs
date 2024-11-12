using Agiu_PDV.Data.Repositories;
using Agiu_PDV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Services
{
    public class VendaService : IVendaService
    {
        private readonly VendaRepository _vendaRepository;
        private readonly ProdutoRepository _produtoRepository;

        public VendaService(VendaRepository vendaRepository, ProdutoRepository produtoRepository)
        {
            _vendaRepository = vendaRepository;
            _produtoRepository = produtoRepository;
        }

        public async Task<IEnumerable<Venda>> ObterTodasVendasAsync()
        {
            return await _vendaRepository.GetAllAsync();
        }

        public async Task<Venda> GetByIdAsync(int id)
        {
            return await _vendaRepository.GetByIdAsync(id);
        }

        public async Task<bool> SaveAsync(Venda venda)
        {
            return await _vendaRepository.SaveAsync(venda);
        }

        public async Task<bool> UpdateAsync(Venda venda)
        {
            return await _vendaRepository.UpdateAsync(venda);
        }

        public async Task<bool> AddAsync(Venda venda)
        {
            return await _vendaRepository.AddAsync(venda);
        }

        public async Task<bool> DeleteAsync(int vendaId)
        {
            return await _vendaRepository.DeleteAsync(vendaId);
        }

    }
}
