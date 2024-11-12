using Agiu_PDV.Enums;
using Agiu_PDV.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agiu_PDV.Utils
{
    public sealed class GlobalData
    {
        private static readonly Lazy<GlobalData> instance = new Lazy<GlobalData>(() => new GlobalData());
        private int _currentId;
        private string _listviewDataValue;
        public event EventHandler<int> CurrentIdChanged;
        public static GlobalData Instance => instance.Value;

        private GlobalData() { }

        public EAction ActionAtualView { get; set; }

        #region [ Banco ]
        private IClienteService _clienteService;
        private IProdutoService _produtoService;
        private IVendaService _vendaService;

        public IClienteService ClienteService { get => _clienteService; set => _clienteService = value; }
        public IProdutoService ProdutoService { get => _produtoService; set => _produtoService = value; }
        public IVendaService VendaService { get => _vendaService; set => _vendaService = value; }
        #endregion

        public int CurrentId
        {
            get => _currentId;
            set
            {
                if (_currentId != value)
                {
                    _currentId = value;
                    CurrentIdChanged?.Invoke(this, _currentId);
                }
            }
        }
        public string LastListViewValue
        {
            get => _listviewDataValue;
            set
            {
                if (_listviewDataValue != value)
                {
                    _listviewDataValue = value;
                }
            }
        }

    }
}
