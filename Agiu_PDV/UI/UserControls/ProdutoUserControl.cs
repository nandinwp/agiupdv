using Agiu_PDV.Models;
using Agiu_PDV.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agiu_PDV.UI.UserControls
{
    public partial class ProdutoUserControl : UserControl
    {
        public ProdutoUserControl()
        {
            InitializeComponent();
        }

        public async Task PreencherListViewProdutosAsync(IEnumerable<Produto> produtos)
        {
            listProdutos.Items.Clear();

            await Task.Run(() =>
            {
                listProdutos.Invoke(new Action(() =>
                {
                    foreach (var produto in produtos)
                    {
                        var item = new ListViewItem(produto.ProdutoId.ToString());
                        item.SubItems.Add(produto.Nome);
                        item.SubItems.Add(produto.Descricao);
                        item.SubItems.Add(produto.Preco.ToReal());
                        item.SubItems.Add(produto.Estoque.ToString());

                        listProdutos.Items.Add(item);
                    }
                }));
            });
        }

        private void listProdutos_Click(object sender, EventArgs e)
        {
            if (listProdutos.SelectedItems.Count > 0)
            {
                var selectedItem = listProdutos.SelectedItems[0];

                if (selectedItem.SubItems.Count >= 4)
                {
                    string currentId = selectedItem.SubItems[0].Text;

                    string data = string.Format("{0}#{1}#{2}#{3}",
                        selectedItem.SubItems[1].Text,
                        selectedItem.SubItems[2].Text,
                        selectedItem.SubItems[3].Text,
                        selectedItem.SubItems[4].Text);

                    GlobalData.Instance.LastListViewValue = data;

                    if (int.TryParse(currentId, out int parsedId))
                    {
                        GlobalData.Instance.CurrentId = parsedId;
                    }
                }
            }
        }
    }
}
