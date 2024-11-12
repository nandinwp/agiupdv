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
    public partial class VendasUserControl : UserControl
    {
        public VendasUserControl()
        {
            InitializeComponent();
        }

        public async Task PreencherListViewVendasAsync(IEnumerable<Venda> vendas)
        {
            listVendas.Items.Clear();

            await Task.Run(() =>
            {
                listVendas.Invoke(new Action(() =>
                {
                    foreach (var venda in vendas)
                    {
                        var item = new ListViewItem(venda.VendaId.ToString());
                        item.SubItems.Add(venda.Cliente.Nome);
                        item.SubItems.Add(venda.DataVenda.ToString("G"));
                        item.SubItems.Add(venda.ValorTotal.ToReal());
                        item.SubItems.Add(venda.Cliente.Email);

                        listVendas.Items.Add(item);
                    }
                }));
            });
        }

        private void listVendas_Click(object sender, EventArgs e)
        {
            if (listVendas.SelectedItems.Count > 0)
            {
                var selectedItem = listVendas.SelectedItems[0];

                if (selectedItem.SubItems.Count >= 4)
                {
                    string currentId = selectedItem.SubItems[0].Text;

                    string data = string.Format("{0}#{1}#{2}#{3}",
                        selectedItem.SubItems[1].Text,
                        selectedItem.SubItems[3].Text,
                        selectedItem.SubItems[4].Text,
                        selectedItem.SubItems[2].Text);

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
