using Agiu_PDV.Enums;
using Agiu_PDV.Models;
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

namespace Agiu_PDV.UI.Dialogs
{
    public partial class ModalVendaUserControl : UserControl, IModalControl
    {
        private EDialogOperation _op;
        private Venda _venda;
        
        private IEnumerable<Produto> _produtos;

        private List<int> _clienteID;
        private List<int> _produtoID;

        public ModalVendaUserControl(EDialogOperation operation)
        {
            _op = operation;
            InitializeComponent();

            ProcessaOperacao();
        }

        #region [ Carrega dados iniciais ]
        async Task<bool> LoadFromDb()
        {
            var vendas = await GlobalData.Instance.VendaService.GetByIdAsync(GlobalData.Instance.CurrentId);
            await CarregaCliente(vendas.ClienteId);

            _venda = vendas;

            dtpDataVenda.Value = vendas.DataVenda;
            txb_valorTotal.Text = vendas.ValorTotal.ToReal();

            await PreencherListViewProdutosAsync(vendas);

            return true;
        }
        #endregion

        #region [ Carrega dados select ]
        private async Task CarregaCliente(int id)
        {
            var clientes = await GlobalData.Instance.ClienteService.ObterTodosClientesAsync();

            PopulaSelect(clientes, id);
        }

        private async Task CarregaProduto()
        {
            var (success, produtos) = await GlobalData.Instance.ProdutoService.ObterTodosProdutosAsync();
            _produtos = produtos;
            PopulaSelect(_produtos);
        }
        #endregion

        #region [ Preenche o objeto na listview ]
        public async Task PreencherListViewProdutosAsync(Venda vendas)
        {
            listvendaItens.Items.Clear();

            await Task.Run(() =>
            {
                listvendaItens.Invoke(new Action(() =>
                {
                    // Adiciona item a item no listview
                    foreach (var itens in vendas.Itens)
                    {
                        bool itemExists = listvendaItens.Items.Cast<ListViewItem>()
                            .Any(i => i.Text == itens.ProdutoId.ToString());

                        if (!itemExists)
                        {
                            var item = new ListViewItem(itens.ProdutoId.ToString());

                            item.SubItems.Add(itens.VendaItemId.ToString());
                            item.SubItems.Add(itens.Produto.Nome);
                            item.SubItems.Add(itens.Quantidade.ToString());
                            item.SubItems.Add(itens.PrecoUnitario.ToReal());

                            listvendaItens.Items.Add(item);

                            //Calcula valor total
                            txb_valorTotal.Text = CalcularTotal(listvendaItens).ToReal();

                        }
                        else
                        {
                            MessageBox.Show("Você já adicionou este item!\n Por favor edite a quantidade ao lado!",
                                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                }));
            });
        }
        #endregion

        #region [ Calcula valor total da lista ]
        public decimal CalcularTotal(ListView listView)
        {
            decimal total = 0;

            foreach (ListViewItem item in listView.Items)
            {
                if (item.SubItems.Count > 4)
                {
                    decimal quantidade = decimal.Parse(item.SubItems[3].Text);

                    string precoTotal = item.SubItems[4].Text;
                    precoTotal = precoTotal.Replace("R$", "");
                    precoTotal = precoTotal.Replace(" ", "");
                    
                    precoTotal = precoTotal.Remove(precoTotal.IndexOf(","),3);

                    decimal precoUnitario = decimal.Parse(precoTotal);

                    total += quantidade * precoUnitario;
                }
            }

            return total;
        }
        #endregion

        #region [ Popula select clientes ]
        private void PopulaSelect(IEnumerable<Cliente> clientes, int clienteId)
        {
            cbx_cliente.Items.Clear();
            cbx_cliente.BeginUpdate();

            _clienteID = new List<int>(clientes.Count());

            if (_clienteID!=null)
                _clienteID.Clear();

            int selectedIndex = -1;

            foreach (var item in clientes)
            {
                cbx_cliente.Items.Add(item.Nome);
                _clienteID.Add(item.ClienteId);

                if (item.ClienteId == clienteId)
                {
                    selectedIndex = cbx_cliente.Items.Count - 1;
                }
            }

            cbx_cliente.EndUpdate();

            if (selectedIndex != -1)
            {
                cbx_cliente.SelectedIndex = selectedIndex;
            }
        }

        #endregion

        #region [ Popula select produtos ]
        private void PopulaSelect(IEnumerable<Produto> produtos)
        {
            cbx_produto.Items.Clear();
            cbx_produto.BeginUpdate();

            _produtoID = new List<int>(produtos.Count());

            if (_produtoID != null)
                _produtoID.Clear();

            int selectedIndex = -1;

            foreach (var item in produtos)
            {
                cbx_produto.Items.Add(item.Nome);
                _produtoID.Add(item.ProdutoId);

                selectedIndex = cbx_produto.Items.Count - 1;
            }

            cbx_produto.EndUpdate();

            if (selectedIndex != -1)
            {
                cbx_produto.SelectedIndex = selectedIndex;
            }
        }
        #endregion 

        #region [ Retorna objeto ]
        public Venda GetNewVenda()
        {
            _venda = new Venda();
            _venda.Cliente = new Cliente();
            //_venda.Itens = new List<VendaItem>();

            _venda.Cliente =  GlobalData.Instance.ClienteService.GetByIdAsync(_clienteID[cbx_cliente.SelectedIndex]).Result;

            _venda.DataVenda = dtpDataVenda.Value;
            _venda.Cliente.Nome = cbx_cliente.Text;
            _venda.ClienteId = _clienteID[cbx_cliente.SelectedIndex];

            return _venda;
        }

        public Venda GetEditVenda()
        {
            return _venda;
        }

        #endregion

        #region [ Processa escolha ]
        private async void ProcessaOperacao()
        {
            if (_op == EDialogOperation.EditarVenda)
            {
                await Task.Run(() =>
                {
                    _ = LoadFromDb();
                });
            }

            switch (_op)
            {
                case EDialogOperation.EditarVenda:
                    lb_cliente.Text = 
                    gb_elementos.Text = "Editar venda: ";
                    break;

                case EDialogOperation.NovaVenda:
                    gb_elementos.Text = "Nova venda: ";
                    await Task.Run(() => 
                    {
                        _ = CarregaCliente(1);
                    });
                    break;
            }
        }
        #endregion

        #region [ Alterar valor da tabela ]
        private void listvendaItens_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                listvendaItens.SelectedItems[0].SubItems[3].Text = e.Label;

                foreach (var item in _venda.Itens)
                {
                    int produtoID = int.Parse(listvendaItens.SelectedItems[0].SubItems[0].Text);

                    if (item.ProdutoId== produtoID)
                    {
                        int quantidade = int.Parse(e.Label);

                        if(item.Produto.Estoque - quantidade >= quantidade)
                        {
                            item.Quantidade = quantidade;
                            item.Produto.Estoque -= quantidade;

                            decimal newValue = item.PrecoUnitario * item.Quantidade;
                            _venda.ValorTotal = newValue;

                            PreencherListViewProdutosAsync(_venda);
                            MessageBox.Show($"Valor atualizado para: {e.Label}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        else
                        {
                            PreencherListViewProdutosAsync(_venda);
                            MessageBox.Show($"Não é possível, o valor atualizado é maior que o disponível!\n Valor solicitado: {e.Label} em estoque: {item.Produto.Estoque}", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        #region [ Carrega produtos ]
        private async void cbx_produto_DropDown(object sender, EventArgs e)
        {
            await CarregaProduto();
        }
        #endregion

        #region [ Carrega descrição produtos ]
        private void cbx_produto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbx_produto.SelectedIndex != -1)
            {

                var produto = _produtos.FirstOrDefault
                    (
                        a => a.ProdutoId == _produtoID[cbx_produto.SelectedIndex]
                    );

                lb_description.Text = produto?.Descricao ?? "Descrição não disponível!";
                lb_preco.Text = produto?.Preco.ToReal() ?? "Preço não disponível";
                lb_qtdEstoque.Text = produto?.Estoque.ToString() ?? "Estoque não está disponível!";
            }
        }
        #endregion

        #region [ Adiciona novo item a lista ]
        private void btnOk_Click(object sender, EventArgs e)
        {
            if(cbx_produto.SelectedIndex != -1)
            {
                int produtoid = _produtoID[cbx_produto.SelectedIndex];

                VendaItem vendaitem = new VendaItem()
                {
                    ProdutoId = produtoid,
                    Quantidade = 1,
                    Produto = _produtos.FirstOrDefault(p=>p.ProdutoId==produtoid),
                    PrecoUnitario = _produtos.FirstOrDefault(a => a.ProdutoId == produtoid).Preco
                };

                if (_venda == null)
                {
                    _venda = new Venda();
                }
                _venda.Itens.Add(vendaitem);

               PreencherListViewProdutosAsync(_venda);
            }
        }
        #endregion

        private void cbx_cliente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // atualizar a lista sobre o cliente id
            if (cbx_cliente.SelectedIndex != -1 && _clienteID != null && _venda != null)
            {
                _venda.ClienteId = _clienteID[cbx_cliente.SelectedIndex];

                MessageBox.Show("Cliente atualizado com sucesso!", Application.ProductName,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
