using Agiu_PDV.Data.Repositories;
using Agiu_PDV.Data;
using Agiu_PDV.Services;
using Agiu_PDV.UI;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace Agiu_PDV
{
    internal static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string connectionString = "Host=localhost;Port=5432;Database=AgiuPDV;Username=agiupdv;Password=agiupdv";

            var clienteRepository = new ClienteRepository(connectionString);
            var produtoRepository = new ProdutoRepository(connectionString);
            var vendaRepository = new VendaRepository(connectionString);

            var clienteService = new ClienteService(clienteRepository);
            var produtoService = new ProdutoService(produtoRepository);
            var vendaService = new VendaService(vendaRepository, produtoRepository);

            Application.Run(new MainWindows(clienteService, produtoService, vendaService));
        }
    }
}
