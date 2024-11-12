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
    public partial class ModalDialogUserControl : UserControl, IModalControl
    {
        private EDialogOperation _op;
        public Cliente _cliente;
        public Produto _produto;
        public ModalDialogUserControl(EDialogOperation operation)
        {
            _op = operation;
            InitializeComponent();
            ProcessaOperacao();
        }

        public Cliente GetClienteWithValue()
        {
            _cliente = null;
            _cliente = new Cliente();

            _cliente.ClienteId = GlobalData.Instance.CurrentId;
            _cliente.Nome = txb_nome.Text;
            _cliente.Endereco = txb_endereco.Text;
            _cliente.Telefone = txb_telefone.Text;
            _cliente.Email = txb_email.Text;

            return _cliente;
        }

        public Produto GetProdutoWithValue()
        {
            _produto = null;
            _produto = new Produto();

            _produto.ProdutoId = GlobalData.Instance.CurrentId;
            _produto.Nome = txb_nome.Text;
            _produto.Descricao = txb_endereco.Text;
            _produto.Preco = txb_telefone.Text.LimpaFormatacao();
            _produto.Estoque = txb_email.Text.ToInt();

            return _produto;
        }

        private void ProcessaOperacao()
        {
            switch (_op)
            {
                    case EDialogOperation.EditarCliente:
                    lb_tip1.Text = "Nome: ";
                    lb_tip2.Text = "Endereço: ";
                    lb_tip3.Text = "Telefone: ";
                    lb_tip4.Text = "E-mail: ";

                    txb_nome.Text = GlobalData.Instance.LastListViewValue.Split('#')[0];
                    txb_endereco.Text = GlobalData.Instance.LastListViewValue.Split('#')[1];
                    txb_telefone.Text = GlobalData.Instance.LastListViewValue.Split('#')[2];
                    txb_email.Text = GlobalData.Instance.LastListViewValue.Split('#')[3];

                    gb_elementos.Text = "Editar cliente";
                        break;

                    case EDialogOperation.NovoCliente:
                    lb_tip1.Text = "Nome: ";
                    lb_tip2.Text = "Endereço: ";
                    lb_tip3.Text = "Telefone: ";
                    lb_tip4.Text = "E-mail: ";
                    gb_elementos.Text = "Novo cliente";
                    break;

                    case EDialogOperation.EditarProduto:
                    lb_tip1.Text = "Nome: ";
                    lb_tip2.Text = "Descrição: ";
                    lb_tip3.Text = "Preço: ";
                    lb_tip4.Text = "Estoque: ";

                    txb_nome.Text = GlobalData.Instance.LastListViewValue.Split('#')[0];
                    txb_endereco.Text = GlobalData.Instance.LastListViewValue.Split('#')[1];
                    txb_telefone.Text = GlobalData.Instance.LastListViewValue.Split('#')[2];
                    txb_email.Text = GlobalData.Instance.LastListViewValue.Split('#')[3];

                    gb_elementos.Text = "Editar produto";
                    break;

                    case EDialogOperation.NovoProduto:
                    lb_tip1.Text = "Nome: ";
                    lb_tip2.Text = "Descrição: ";
                    lb_tip3.Text = "Preço: ";
                    lb_tip4.Text = "Estoque: ";
                    gb_elementos.Text = "Novo produto";
                    break;
            }
        }

        private void txb_email_TextChanged(object sender, EventArgs e)
        {
            string op = _op.ToString();
            if (op.ToLower().Contains("produto"))
            {
                string valor = txb_email.Text;
                var numeros = new string(valor.Where(char.IsDigit).ToArray());
                txb_email.Text = string.IsNullOrEmpty(numeros) ? "0" : numeros;
            }
        }
    }
}
