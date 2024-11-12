using Agiu_PDV.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agiu_PDV.Services
{
    public interface IProdutoService
    {
        Task<bool> AdicionarProdutoAsync(Produto produto);
        Task<(bool Success, IEnumerable<Produto> Produtos)> ObterTodosProdutosAsync();
        Task<bool> UpdateAsync(Produto produto);
        Task<bool> DeleteAsync(int produtoId);
    }
}