using Agiu_PDV.Data.Repositories;
using Agiu_PDV.Models;
using Agiu_PDV.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_Agiu
{
    [TestClass]
    public class VendaRepositoryTests
    {
        private string connectionString = "Host=localhost;Port=5432;Database=AgiuPDV;Username=agiupdv;Password=agiupdv";

        [TestMethod]
        public async Task SaveAsync_ShouldSaveVendaSuccessfully()
        {
            var vendaRepository = new VendaRepository(connectionString);
            var produtoRepository = new ProdutoRepository(connectionString);
            var vendaService = new VendaService(vendaRepository, produtoRepository); 

            var venda = new Venda
            {
                ClienteId = 1,
                DataVenda = DateTime.Now,
                ValorTotal = 150.0m,
                Itens = new List<VendaItem>
                {
                    new VendaItem { ProdutoId = 6, Quantidade = 20, PrecoUnitario = 2.0m },
                }
            };

            var result = await vendaService.SaveAsync(venda);

            Assert.IsTrue(result, "Venda não foi salva com sucesso.");
        }

        [TestMethod]
        public async Task GetByIdAsync_ShouldReturnVendaWithCorrectId()
        {
            var vendaRepository = new VendaRepository(connectionString);
            var produtoRepository = new ProdutoRepository(connectionString);
            var vendaService = new VendaService(vendaRepository, produtoRepository);

            int vendaId = 6; 

            var venda = await vendaService.GetByIdAsync(vendaId);

            Assert.IsNotNull(venda, "Venda não encontrada.");
            Assert.AreEqual(vendaId, venda.VendaId, "O ID da venda retornada não corresponde.");
        }
    }
}
