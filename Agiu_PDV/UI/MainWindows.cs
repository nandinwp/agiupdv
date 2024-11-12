using Agiu_PDV.Models;
using Agiu_PDV.Services;
using Agiu_PDV.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agiu_PDV.UI
{
    public partial class MainWindows : Form
    {
        public MainWindows(IClienteService clienteService, IProdutoService produtoService, IVendaService vendaService)
        {
            // Carrega o banco de dados
            GlobalData.Instance.ClienteService = clienteService;
            GlobalData.Instance.ProdutoService = produtoService;
            GlobalData.Instance.VendaService = vendaService;

            InitializeComponent();

            MainWindowsModel.MainPanel = this.pnl_main_frame;
        }

        //Evento para atualizar a data e hora:
        private void tm_clock_Tick(object sender, EventArgs e)
        {
            lb_time.Text = DateTime.Now.ToString("G");
        }

        private void OnCrudActions(object sender, EventArgs e) 
        {
            ToolStripButton btn = (ToolStripButton)sender;
            MainWindowsModel.CrudAction(ref btn);
        }

        private void encerrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Environment.Exit(0);
        }
    }
}
