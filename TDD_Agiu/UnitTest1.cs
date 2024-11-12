using Agiu_PDV.Data.Repositories;
using Agiu_PDV.Models;
using Agiu_PDV.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace TDD_Agiu
{

    [TestClass]
    public class UnitTest1
    {
        private string connectionString = "Host=localhost;Port=5432;Database=AgiuPDV;Username=agiupdv;Password=agiupdv";


        /// <summary>
        /// Testa o processo de criação de um cliente no sistema.
        /// Verifica se o cliente é adicionado ao banco de dados e recuperado corretamente.
        /// </summary>
        [TestMethod]
        public async Task Teste_CriarCliente()
        {
            var clienteRepository = new ClienteRepository(connectionString);
            var clienteService = new ClienteService(clienteRepository);

            var cliente = new Cliente()
            {
                Email = $"luis{Guid.NewGuid():N}@gmail.com",
                Endereco = "Rua do condado",
                Nome = "Edelfonso Rodrigues",
                Telefone = "219822222"
            };

            await clienteService.AdicionarClienteAsync(cliente);

           
            var clienteAdicionado = await clienteRepository.GetByNameAsync(cliente.Nome);
            Assert.IsNotNull(clienteAdicionado);
            Assert.AreEqual(cliente.Nome, clienteAdicionado.Nome);
        }

        /// <summary>
        /// Testa o processo de exclusão de um cliente no sistema.
        /// Verifica se o cliente é removido do banco de dados após a exclusão.
        /// </summary>
        [TestMethod]
        public async Task Teste_ApagarCliente()
        {
            var clienteRepository = new ClienteRepository(connectionString);
            var clienteService = new ClienteService(clienteRepository);

            
            var cliente = new Cliente()
            {
                Email = $"luis{Guid.NewGuid():N}@gmail.com",
                Endereco = "Rua do condado",
                Nome = "Edelfonso Rodrigues"
            };

            await clienteService.AdicionarClienteAsync(cliente);

            await clienteService.DeleteAsync(cliente.ClienteId);

            var clienteDeletado = await clienteRepository.GetByIdAsync(cliente.ClienteId);
            Assert.IsNull(clienteDeletado);
        }

    }
}
