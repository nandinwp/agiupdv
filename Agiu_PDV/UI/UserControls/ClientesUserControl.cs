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

namespace Agiu_PDV.UI.UserControls
{
    public partial class ClientesUserControl : UserControl
    {
        public ClientesUserControl()
        {
            InitializeComponent();
        }

        public async Task PreencherListViewClientesAsync(IEnumerable<Cliente> clientes)
        {
            listClientes.Items.Clear();

            await Task.Run(() =>
            {
                listClientes.Invoke(new Action(() =>
                {
                    foreach (var cliente in clientes)
                    {
                        var item = new ListViewItem(cliente.ClienteId.ToString());
                        item.SubItems.Add(cliente.Nome);
                        item.SubItems.Add(cliente.Endereco);
                        item.SubItems.Add(cliente.Telefone);
                        item.SubItems.Add(cliente.Email);

                        listClientes.Items.Add(item);
                    }
                }));
            });
        }

        private void listClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listClientes.SelectedItems.Count > 0)
            {
                var selectedItem = listClientes.SelectedItems[0];

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
