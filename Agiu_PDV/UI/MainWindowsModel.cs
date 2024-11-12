using Agiu_PDV.Enums;
using Agiu_PDV.Models;
using Agiu_PDV.Services;
using Agiu_PDV.UI.Dialogs;
using Agiu_PDV.UI.UserControls;
using Agiu_PDV.Utils;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Agiu_PDV.UI
{
    public class MainWindowsModel
    {
        #region [ Elementos ] 
        private Panel _panel_frame;
        public Panel MainPanel { get; set; }

        #endregion

        #region [ UserControl ]
        private ClientesUserControl _clientes;
        private ProdutoUserControl _produtos;
        private VendasUserControl _vendas;

        private ModalDialogUserControl _modalEditCommons;
        private ModalVendaUserControl _modalVenda;
        #endregion

        Venda _venda {  get; set; }

        #region [ Teste ]

        public MainWindowsModel()
        {
            GlobalData.Instance.CurrentIdChanged += Instance_CurrentIdChanged;
        }

        private void Instance_CurrentIdChanged(object sender, int e)
        {
            Console.WriteLine($"ID: {e}");
        }
        #endregion


        private string errorMessage;

        private EAction _buttonAction;
        private EAction _forCurrentSelectedView;
        private EDialogOperation _currentOperation;

        public void CrudAction(ref ToolStripButton btn)
        {
            string tag = btn.Tag.ToString();

            EAction action = (EAction)Enum.Parse(typeof(EAction), tag);

            switch (action) 
            {

                case EAction.GenClientes:
                case EAction.GenProdutos:
                case EAction.GenVendas:
                    _forCurrentSelectedView =_buttonAction = action;
                    GlobalData.Instance.ActionAtualView = action;
                    OperateViews();
                    break;
                case EAction.GenRelatorios:
                    _buttonAction = action;
                    OperarRelatorio();
                    break;
                case EAction.CrudNew:
                case EAction.CrudEdit:
                    _buttonAction = action;
                    ProcessChoice();
                    break;
                case EAction.CrudDel:
                    _buttonAction = action;
                    ProcessChoice();
                    break;
            }

        }

        void ProcessChoice()
        {
            EDialogOperation operation = GetOperation();

            string op = operation.ToString().ToLower();

            if (op.Contains("editar") || op.Contains("del"))
            {
                if (GlobalData.Instance.CurrentId == 0)
                    return;
            }

            if (operation == EDialogOperation.EditarVenda || operation == EDialogOperation.NovaVenda)
                OperarModalVenda(operation);
            else if (operation.ToString().Contains("Apagar"))
                OperarDelecaoAsync(operation);
            else if (operation == EDialogOperation.Relatorio)
                OperarRelatorio();
            else
                OperarModal(operation);
        }

        private async Task OperarRelatorio()
        {
            Form form = new Form();

            int largura = Screen.PrimaryScreen.Bounds.Width;
            int altura = Screen.PrimaryScreen.Bounds.Height;

            form.Width = largura / 2;
            form.Height = altura - 100;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.FormBorderStyle = FormBorderStyle.Sizable;
            form.Name = "Relatorio";
            form.Text = "Relatório";
            form.ShowIcon = false;

            ReportViewer reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;
            form.Controls.Add(reportViewer);

            reportViewer.LocalReport.ReportPath = "C:\\Users\\luyfe\\source\\repos\\Agiu_PDV\\Agiu_PDV\\Reports\\VendasReport.rdlc";

            var vendas = (await GlobalData.Instance.VendaService.ObterTodasVendasAsync()).ToList(); ;

            ReportDataSource dataSource = new ReportDataSource("VendasDataSet", CriarDataTable(vendas));

            reportViewer.LocalReport.DataSources.Clear();
            reportViewer.LocalReport.DataSources.Add(dataSource);

            reportViewer.RefreshReport();

            form.Show();
        }

        private DataTable CriarDataTable(List<Venda> vendas)
        {
            var dataTable = new DataTable();

            dataTable.Columns.Add("VendaId", typeof(int));
            dataTable.Columns.Add("ClienteId", typeof(int));
            dataTable.Columns.Add("Cliente", typeof(string));
            dataTable.Columns.Add("DataVenda", typeof(DateTime));
            dataTable.Columns.Add("ValorTotal", typeof(decimal));

            foreach (var venda in vendas)
            {
                var row = dataTable.NewRow();
                row["VendaId"] = venda.VendaId;
                row["ClienteId"] = venda.ClienteId;
                row["Cliente"] = venda.Cliente.Nome;
                row["DataVenda"] = venda.DataVenda;
                row["ValorTotal"] = venda.ValorTotal;
                dataTable.Rows.Add(row);
            }

            return dataTable;
        }



        private async Task OperarDelecaoAsync(EDialogOperation operation)
        {
            int id = GlobalData.Instance.CurrentId;

            var confirmResult = MessageBox.Show("Você tem certeza que quer apagar?",
                                                   Application.ProductName,
                                                   MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes)
                return;

            if (operation == EDialogOperation.ApagarVenda)
            {
               
                bool sucesso = await GlobalData.Instance.VendaService.DeleteAsync(id);
                if (sucesso)
                {
                    MessageBox.Show("Venda apagada com sucesso!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao apagar a venda. Tente novamente.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (operation == EDialogOperation.ApagarCliente)
            {
                bool sucesso = await GlobalData.Instance.ClienteService.DeleteAsync(id);
                if (sucesso)
                {
                    MessageBox.Show("Cliente apagado com sucesso!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao apagar o cliente. Tente novamente.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (operation == EDialogOperation.ApagarProduto)
            {
                bool sucesso = await GlobalData.Instance.ProdutoService.DeleteAsync(id);
                if (sucesso)
                {
                    MessageBox.Show("Produto apagado com sucesso!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Erro ao apagar o produto. Tente novamente.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Não foi possível entender a sua solicitação!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            OperateViews();
        }


        // Opera o modal de vendas, com o sistema mais complexo de relacionamento de produto, cliente e venda item
        async void OperarModalVenda(EDialogOperation operation)
        {
            _modalVenda = null;
            _modalVenda = new ModalVendaUserControl(operation);
            _modalVenda.Dock = DockStyle.Fill;

            var windwos = CreateWindow(_modalVenda, ref operation);

            _modalVenda.btn_confirm.Click += async (sender, e) =>
            {

                Tuple<bool, object> response = ValidaCampos(operation);

                if (response.Item1==true)
                {
                    if (MessageBox.Show("Tem certeza?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    var resp = await AddOrUpdate(response.Item2);
                    if(resp==true)
                        MessageBox.Show($"Salvo com sucesso!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"Valide as informações pois não foi possível salvar!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show($"Os seguintes erros foram encontrados!\n{errorMessage}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                windwos.Close();
                windwos = null;
                OperateViews();
            };

            windwos.ShowDialog();
        }

        //Opera o madal de cliente e produtos - logica similar e simples
        async void OperarModal(EDialogOperation operation)
        {
            _modalEditCommons = null;

            _modalEditCommons = new ModalDialogUserControl(operation);
            _modalEditCommons.Dock = DockStyle.Fill;

            var windwos = CreateWindow(_modalEditCommons, ref operation);

            _modalEditCommons.btn_confirm.Click += async (sender, e) =>
            {

                Tuple<bool, object> response = ValidaCampos(operation);

                if (response.Item1==true)
                {
                    if (MessageBox.Show("Tem certeza?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                        return;

                    var resp = await AddOrUpdate(response.Item2);
                    if (resp == true)
                        MessageBox.Show($"Salvo com sucesso!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show($"Valide as informações pois não foi possível salvar!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show($"Os seguintes erros foram encontrados!\n{errorMessage}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                windwos.Close();
                windwos = null;
                OperateViews();
            };

            windwos.ShowDialog();
        }

        //Cria uma janela para a edição e adição de valores
        Form CreateWindow(IModalControl modal, ref EDialogOperation operation)
        {
            Form windwos = new Form();
            windwos.StartPosition = FormStartPosition.CenterParent;
            windwos.ShowIcon = false;
            windwos.ShowInTaskbar = false;
            windwos.Name = "Agiu";
            windwos.Text = "Agiu";

            switch (operation)
            {
                /* Para o caso de adição e subtração de valores optei em usar um tamanho dinamico
                 * O primeiro case é referente ao modal de produtos e clientes, é mais simples e usa uma unica tela modular
                 * O segundo case é para o caso de edição de venda existente, neste caso o formulario é maior por conter uma complexidade maior
                 * O terceio usa do mesmo modal pois para adicionar uma nova venda basta expandir o layout
                 * 
                 * Obs: Fiz desta forma para diminuir a quantidade de telas e instancias no fluxo da aplicação, com isso tive um aumento na complexidade lógica
                 */

                case EDialogOperation.EditarCliente:
                case EDialogOperation.NovoCliente:
                case EDialogOperation.EditarProduto:
                case EDialogOperation.NovoProduto:
                    windwos.Size = new System.Drawing.Size(450, 300);
                    break;
                case EDialogOperation.EditarVenda:
                    windwos.Size = new System.Drawing.Size(650, 500);
                    break;
                    case EDialogOperation.NovaVenda:
                    windwos.Size = new System.Drawing.Size(1136, 500);
                    break;

                default:
                    windwos.Size = new System.Drawing.Size(650, 500);
                    break;
            }

            
            windwos.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            windwos.Controls.Add((Control)modal);
            windwos.TopMost = true;
            return windwos;
        }

        // Retorna o tipo de operação atual
        EDialogOperation GetOperation()
        {
            EDialogOperation operation =
                 _buttonAction == EAction.CrudNew ?
                 (_forCurrentSelectedView == EAction.GenClientes ? EDialogOperation.NovoCliente :
                 _forCurrentSelectedView == EAction.GenProdutos ? EDialogOperation.NovoProduto :
                 _forCurrentSelectedView == EAction.GenVendas ? EDialogOperation.NovaVenda :
                 EDialogOperation.None) :
                 _buttonAction == EAction.CrudEdit ?
                 (_forCurrentSelectedView == EAction.GenClientes ? EDialogOperation.EditarCliente :
                 _forCurrentSelectedView == EAction.GenProdutos ? EDialogOperation.EditarProduto :
                 _forCurrentSelectedView == EAction.GenVendas ? EDialogOperation.EditarVenda :
                 EDialogOperation.None) :
                 _buttonAction == EAction.CrudDel?
                 (_forCurrentSelectedView == EAction.GenClientes? EDialogOperation.ApagarCliente:
                 _forCurrentSelectedView  == EAction.GenVendas ? EDialogOperation.ApagarVenda:
                 _forCurrentSelectedView == EAction.GenProdutos ? EDialogOperation.ApagarProduto : 
                 EDialogOperation.None):
                 EDialogOperation.None;

            _currentOperation = operation;

            return operation;
        }

        // Valida os campos, seja update ou novo dado
        Tuple<bool, object> ValidaCampos(EDialogOperation op)
        {
            object entity = null;

            switch (op)
            {
                case EDialogOperation.NovoCliente:
                case EDialogOperation.EditarCliente:
                    entity = _modalEditCommons.GetClienteWithValue();
                    break;

                case EDialogOperation.NovoProduto:
                case EDialogOperation.EditarProduto:
                    entity = _modalEditCommons.GetProdutoWithValue();
                    break;

                case EDialogOperation.EditarVenda:
                    entity = _modalVenda.GetEditVenda();
                    break;

                case EDialogOperation.NovaVenda:
                    entity = _modalVenda.GetNewVenda();
                    break;

                default:
                    return new Tuple<bool, object>(false, null);
            }

            return ValidarEntidade(entity);
        }

        Tuple<bool,object> ValidarEntidade(object entity)
        {
            if (ValidationHelper.Validar(entity, out List<string> erros))
            {
                return new Tuple<bool,object>(true, entity);
            }
            else
            {
                AppendError(erros);
                return new Tuple<bool, object>(false,null);
            }
        }

        async Task<bool> AddOrUpdate(object entity)
        {
            string[] currentView = _currentOperation.ToString().InsertSpace().Split(' ');

            if (currentView[0].ToLower().Contains("nov"))
            {//create

                if(entity is Produto)
                    return await GlobalData.Instance.ProdutoService.AdicionarProdutoAsync((Produto)entity);
                else if(entity is Cliente) 
                    return await GlobalData.Instance.ClienteService.AdicionarClienteAsync((Cliente)entity);
                else if (entity is Venda)
                    return await GlobalData.Instance.VendaService.AddAsync((Venda)entity);
                else
                {

                    MessageBox.Show($"Lamentamos por isso! Mas não foi possível identificar alterações!", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            else if (currentView[0].ToLower().Contains("editar"))
            {//update
                if (entity is Produto)
                    return await GlobalData.Instance.ProdutoService.UpdateAsync((Produto)entity);
                else if (entity is Cliente)
                    return await GlobalData.Instance.ClienteService.UpdateAsync((Cliente)entity);
                else if(entity is Venda)
                    return await GlobalData.Instance.VendaService.UpdateAsync((Venda)entity);
                else
                {
                    MessageBox.Show($"Lamentamos por isso! Mas não foi possível identificar alterações!", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                string concat = currentView[0] == "editar" ? currentView[0] : "alterar";
                MessageBox.Show($"Não foi possível {concat} o {currentView[1]}", Application.CompanyName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

        }

        #region [ Função que formata os erros ]
        void AppendError(List<string> errors)
        {
            string errosList = string.Empty;
            foreach (var erro in errors)
            {
                errosList += $"{erro}\n";
            }
            errorMessage = errosList;
        }
        #endregion

        // Carrega os listviews com os dados corretos
        async void OperateViews()
        {
            MainPanel.Controls.Clear();

            _clientes = null;
            _produtos = null;
            _vendas = null;

            //Cria o userControl de clientes
            if (_buttonAction.Equals(EAction.GenClientes) && _clientes==null)
            {
                _clientes = new ClientesUserControl();
                _clientes.Dock = DockStyle.Fill;
                MainPanel.Controls.Add( _clientes );

                var clientes = await GlobalData.Instance.ClienteService.ObterTodosClientesAsync();

                await _clientes.PreencherListViewClientesAsync(clientes);
            }
            //Cria o userControl de produtos
            else if (_buttonAction.Equals(EAction.GenProdutos) && _produtos == null)
            {
                _produtos = new ProdutoUserControl();
                _produtos.Dock = DockStyle.Fill;
                MainPanel.Controls.Add(_produtos);

                var produtos = await GlobalData.Instance.ProdutoService.ObterTodosProdutosAsync();

                await _produtos.PreencherListViewProdutosAsync(produtos.Produtos);
            }
            else if(_buttonAction.Equals(EAction.GenVendas) && _vendas == null)
            {
                _vendas = new VendasUserControl();
                _vendas.Dock = DockStyle.Fill;
                MainPanel.Controls.Add(_vendas);

                var vendas = await GlobalData.Instance.VendaService.ObterTodasVendasAsync();

                await _vendas.PreencherListViewVendasAsync(vendas);
            }
        }
    }
}
