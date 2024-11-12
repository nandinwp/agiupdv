using Agiu_PDV.Data.Repositories;
using Agiu_PDV.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoService(ProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<(bool Success, IEnumerable<Produto> Produtos)> ObterTodosProdutosAsync()
        {
            return await _produtoRepository.GetAllAsync();
        }

        public async Task<bool> AdicionarProdutoAsync(Produto produto)
        {
           return await _produtoRepository.AddAsync(produto);
        }

        public async Task<bool> UpdateAsync(Produto produto)
        {
           return await _produtoRepository.UpdateAsync(produto);
        }

        public async Task<bool> DeleteAsync(int produtoId)
        {
            return await _produtoRepository.DeleteAsync(produtoId);
        }
    }
}
