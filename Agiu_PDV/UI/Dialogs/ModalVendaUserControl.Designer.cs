namespace Agiu_PDV.UI.Dialogs
{
    partial class ModalVendaUserControl
    {
        /// <summary> 
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Designer de Componentes

        /// <summary> 
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gb_elementos = new System.Windows.Forms.GroupBox();
            this.gb_novo_item = new System.Windows.Forms.GroupBox();
            this.tlp_GridProduto = new System.Windows.Forms.TableLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.lb_nomeProduto = new System.Windows.Forms.Label();
            this.lb_qtdEstoque = new System.Windows.Forms.Label();
            this.cbx_produto = new System.Windows.Forms.ComboBox();
            this.lb_estoque = new System.Windows.Forms.Label();
            this.lb_descricao = new System.Windows.Forms.Label();
            this.lb_preco = new System.Windows.Forms.Label();
            this.lb_description = new System.Windows.Forms.Label();
            this.lb_titlePrice = new System.Windows.Forms.Label();
            this.listvendaItens = new System.Windows.Forms.ListView();
            this.ch_vendaId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_vendaItemId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_nomeProduto = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_quantidade = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_valorUnitario = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbx_cliente = new System.Windows.Forms.ComboBox();
            this.dtpDataVenda = new System.Windows.Forms.DateTimePicker();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.lb_valorTotal = new System.Windows.Forms.Label();
            this.lb_tip2 = new System.Windows.Forms.Label();
            this.lb_cliente = new System.Windows.Forms.Label();
            this.txb_valorTotal = new System.Windows.Forms.TextBox();
            this.gb_elementos.SuspendLayout();
            this.gb_novo_item.SuspendLayout();
            this.tlp_GridProduto.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_elementos
            // 
            this.gb_elementos.Controls.Add(this.gb_novo_item);
            this.gb_elementos.Controls.Add(this.listvendaItens);
            this.gb_elementos.Controls.Add(this.cbx_cliente);
            this.gb_elementos.Controls.Add(this.dtpDataVenda);
            this.gb_elementos.Controls.Add(this.btn_confirm);
            this.gb_elementos.Controls.Add(this.lb_valorTotal);
            this.gb_elementos.Controls.Add(this.lb_tip2);
            this.gb_elementos.Controls.Add(this.lb_cliente);
            this.gb_elementos.Controls.Add(this.txb_valorTotal);
            this.gb_elementos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_elementos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gb_elementos.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_elementos.Location = new System.Drawing.Point(0, 0);
            this.gb_elementos.Name = "gb_elementos";
            this.gb_elementos.Size = new System.Drawing.Size(1136, 445);
            this.gb_elementos.TabIndex = 6;
            this.gb_elementos.TabStop = false;
            this.gb_elementos.Text = "groupBox1";
            // 
            // gb_novo_item
            // 
            this.gb_novo_item.Controls.Add(this.tlp_GridProduto);
            this.gb_novo_item.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gb_novo_item.Location = new System.Drawing.Point(645, 19);
            this.gb_novo_item.Name = "gb_novo_item";
            this.gb_novo_item.Size = new System.Drawing.Size(473, 420);
            this.gb_novo_item.TabIndex = 16;
            this.gb_novo_item.TabStop = false;
            this.gb_novo_item.Text = "Adicione novos produtos a lista:";
            // 
            // tlp_GridProduto
            // 
            this.tlp_GridProduto.ColumnCount = 2;
            this.tlp_GridProduto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.92555F));
            this.tlp_GridProduto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 79.07445F));
            this.tlp_GridProduto.Controls.Add(this.btnOk, 1, 4);
            this.tlp_GridProduto.Controls.Add(this.lb_nomeProduto, 0, 0);
            this.tlp_GridProduto.Controls.Add(this.lb_qtdEstoque, 1, 3);
            this.tlp_GridProduto.Controls.Add(this.cbx_produto, 1, 0);
            this.tlp_GridProduto.Controls.Add(this.lb_estoque, 0, 3);
            this.tlp_GridProduto.Controls.Add(this.lb_descricao, 0, 1);
            this.tlp_GridProduto.Controls.Add(this.lb_preco, 1, 2);
            this.tlp_GridProduto.Controls.Add(this.lb_description, 1, 1);
            this.tlp_GridProduto.Controls.Add(this.lb_titlePrice, 0, 2);
            this.tlp_GridProduto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlp_GridProduto.Location = new System.Drawing.Point(3, 25);
            this.tlp_GridProduto.Name = "tlp_GridProduto";
            this.tlp_GridProduto.RowCount = 5;
            this.tlp_GridProduto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.01835F));
            this.tlp_GridProduto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 77.98165F));
            this.tlp_GridProduto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 88F));
            this.tlp_GridProduto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tlp_GridProduto.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tlp_GridProduto.Size = new System.Drawing.Size(467, 392);
            this.tlp_GridProduto.TabIndex = 22;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.BackColor = System.Drawing.Color.PaleGreen;
            this.btnOk.FlatAppearance.BorderSize = 0;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(317, 353);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(147, 36);
            this.btnOk.TabIndex = 17;
            this.btnOk.Text = "Adicionar";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lb_nomeProduto
            // 
            this.lb_nomeProduto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_nomeProduto.AutoSize = true;
            this.lb_nomeProduto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_nomeProduto.Location = new System.Drawing.Point(3, 0);
            this.lb_nomeProduto.Name = "lb_nomeProduto";
            this.lb_nomeProduto.Size = new System.Drawing.Size(91, 49);
            this.lb_nomeProduto.TabIndex = 14;
            this.lb_nomeProduto.Text = "Produto:";
            // 
            // lb_qtdEstoque
            // 
            this.lb_qtdEstoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_qtdEstoque.AutoSize = true;
            this.lb_qtdEstoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_qtdEstoque.Location = new System.Drawing.Point(100, 311);
            this.lb_qtdEstoque.Name = "lb_qtdEstoque";
            this.lb_qtdEstoque.Size = new System.Drawing.Size(364, 39);
            this.lb_qtdEstoque.TabIndex = 21;
            this.lb_qtdEstoque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbx_produto
            // 
            this.cbx_produto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbx_produto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_produto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_produto.FormattingEnabled = true;
            this.cbx_produto.Location = new System.Drawing.Point(100, 3);
            this.cbx_produto.Name = "cbx_produto";
            this.cbx_produto.Size = new System.Drawing.Size(364, 31);
            this.cbx_produto.TabIndex = 15;
            this.cbx_produto.DropDown += new System.EventHandler(this.cbx_produto_DropDown);
            this.cbx_produto.SelectedIndexChanged += new System.EventHandler(this.cbx_produto_SelectedIndexChanged);
            // 
            // lb_estoque
            // 
            this.lb_estoque.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_estoque.AutoSize = true;
            this.lb_estoque.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_estoque.Location = new System.Drawing.Point(3, 311);
            this.lb_estoque.Name = "lb_estoque";
            this.lb_estoque.Size = new System.Drawing.Size(91, 39);
            this.lb_estoque.TabIndex = 20;
            this.lb_estoque.Text = "Estoque:";
            this.lb_estoque.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_descricao
            // 
            this.lb_descricao.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_descricao.AutoSize = true;
            this.lb_descricao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_descricao.Location = new System.Drawing.Point(3, 49);
            this.lb_descricao.Name = "lb_descricao";
            this.lb_descricao.Size = new System.Drawing.Size(91, 174);
            this.lb_descricao.TabIndex = 16;
            this.lb_descricao.Text = "Descrição:";
            // 
            // lb_preco
            // 
            this.lb_preco.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_preco.AutoSize = true;
            this.lb_preco.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_preco.Location = new System.Drawing.Point(100, 223);
            this.lb_preco.Name = "lb_preco";
            this.lb_preco.Size = new System.Drawing.Size(364, 88);
            this.lb_preco.TabIndex = 19;
            this.lb_preco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lb_description
            // 
            this.lb_description.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_description.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_description.Location = new System.Drawing.Point(100, 49);
            this.lb_description.Name = "lb_description";
            this.lb_description.Size = new System.Drawing.Size(364, 174);
            this.lb_description.TabIndex = 17;
            // 
            // lb_titlePrice
            // 
            this.lb_titlePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_titlePrice.AutoSize = true;
            this.lb_titlePrice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_titlePrice.Location = new System.Drawing.Point(3, 223);
            this.lb_titlePrice.Name = "lb_titlePrice";
            this.lb_titlePrice.Size = new System.Drawing.Size(91, 88);
            this.lb_titlePrice.TabIndex = 18;
            this.lb_titlePrice.Text = "Preço:";
            this.lb_titlePrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // listvendaItens
            // 
            this.listvendaItens.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listvendaItens.CheckBoxes = true;
            this.listvendaItens.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_vendaId,
            this.ch_vendaItemId,
            this.ch_nomeProduto,
            this.ch_quantidade,
            this.ch_valorUnitario});
            this.listvendaItens.FullRowSelect = true;
            this.listvendaItens.GridLines = true;
            this.listvendaItens.HideSelection = false;
            this.listvendaItens.LabelEdit = true;
            this.listvendaItens.Location = new System.Drawing.Point(10, 174);
            this.listvendaItens.Name = "listvendaItens";
            this.listvendaItens.Size = new System.Drawing.Size(582, 222);
            this.listvendaItens.TabIndex = 12;
            this.listvendaItens.UseCompatibleStateImageBehavior = false;
            this.listvendaItens.View = System.Windows.Forms.View.Details;
            this.listvendaItens.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listvendaItens_AfterLabelEdit);
            // 
            // ch_vendaId
            // 
            this.ch_vendaId.DisplayIndex = 1;
            this.ch_vendaId.Width = 0;
            // 
            // ch_vendaItemId
            // 
            this.ch_vendaItemId.DisplayIndex = 2;
            this.ch_vendaItemId.Width = 0;
            // 
            // ch_nomeProduto
            // 
            this.ch_nomeProduto.DisplayIndex = 0;
            this.ch_nomeProduto.Text = "Produto";
            this.ch_nomeProduto.Width = 200;
            // 
            // ch_quantidade
            // 
            this.ch_quantidade.Text = "Quantidade";
            this.ch_quantidade.Width = 200;
            // 
            // ch_valorUnitario
            // 
            this.ch_valorUnitario.Text = "Preço unidade";
            this.ch_valorUnitario.Width = 180;
            // 
            // cbx_cliente
            // 
            this.cbx_cliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_cliente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbx_cliente.FormattingEnabled = true;
            this.cbx_cliente.Location = new System.Drawing.Point(108, 40);
            this.cbx_cliente.Name = "cbx_cliente";
            this.cbx_cliente.Size = new System.Drawing.Size(341, 31);
            this.cbx_cliente.TabIndex = 11;
            this.cbx_cliente.SelectedIndexChanged += new System.EventHandler(this.cbx_cliente_SelectedIndexChanged);
            // 
            // dtpDataVenda
            // 
            this.dtpDataVenda.Location = new System.Drawing.Point(108, 92);
            this.dtpDataVenda.Name = "dtpDataVenda";
            this.dtpDataVenda.Size = new System.Drawing.Size(341, 29);
            this.dtpDataVenda.TabIndex = 10;
            // 
            // btn_confirm
            // 
            this.btn_confirm.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_confirm.FlatAppearance.BorderSize = 0;
            this.btn_confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_confirm.Location = new System.Drawing.Point(486, 402);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(117, 37);
            this.btn_confirm.TabIndex = 9;
            this.btn_confirm.Text = "Ok";
            this.btn_confirm.UseVisualStyleBackColor = false;
            // 
            // lb_valorTotal
            // 
            this.lb_valorTotal.AutoSize = true;
            this.lb_valorTotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_valorTotal.Location = new System.Drawing.Point(6, 129);
            this.lb_valorTotal.Name = "lb_valorTotal";
            this.lb_valorTotal.Size = new System.Drawing.Size(90, 23);
            this.lb_valorTotal.TabIndex = 7;
            this.lb_valorTotal.Text = "valor total:";
            // 
            // lb_tip2
            // 
            this.lb_tip2.AutoSize = true;
            this.lb_tip2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_tip2.Location = new System.Drawing.Point(6, 92);
            this.lb_tip2.Name = "lb_tip2";
            this.lb_tip2.Size = new System.Drawing.Size(100, 23);
            this.lb_tip2.TabIndex = 6;
            this.lb_tip2.Text = "Data venda:";
            // 
            // lb_cliente
            // 
            this.lb_cliente.AutoSize = true;
            this.lb_cliente.Location = new System.Drawing.Point(6, 44);
            this.lb_cliente.Name = "lb_cliente";
            this.lb_cliente.Size = new System.Drawing.Size(67, 23);
            this.lb_cliente.TabIndex = 5;
            this.lb_cliente.Text = "Cliente:";
            // 
            // txb_valorTotal
            // 
            this.txb_valorTotal.BackColor = System.Drawing.Color.LightGray;
            this.txb_valorTotal.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_valorTotal.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_valorTotal.Location = new System.Drawing.Point(108, 127);
            this.txb_valorTotal.Name = "txb_valorTotal";
            this.txb_valorTotal.ReadOnly = true;
            this.txb_valorTotal.Size = new System.Drawing.Size(341, 25);
            this.txb_valorTotal.TabIndex = 3;
            // 
            // ModalVendaUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_elementos);
            this.Name = "ModalVendaUserControl";
            this.Size = new System.Drawing.Size(1136, 445);
            this.gb_elementos.ResumeLayout(false);
            this.gb_elementos.PerformLayout();
            this.gb_novo_item.ResumeLayout(false);
            this.tlp_GridProduto.ResumeLayout(false);
            this.tlp_GridProduto.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_elementos;
        public System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Label lb_valorTotal;
        private System.Windows.Forms.Label lb_tip2;
        private System.Windows.Forms.Label lb_cliente;
        private System.Windows.Forms.TextBox txb_valorTotal;
        private System.Windows.Forms.ComboBox cbx_cliente;
        private System.Windows.Forms.DateTimePicker dtpDataVenda;
        private System.Windows.Forms.ListView listvendaItens;
        private System.Windows.Forms.ColumnHeader ch_vendaId;
        private System.Windows.Forms.ColumnHeader ch_vendaItemId;
        private System.Windows.Forms.ColumnHeader ch_nomeProduto;
        private System.Windows.Forms.ColumnHeader ch_quantidade;
        private System.Windows.Forms.ColumnHeader ch_valorUnitario;
        private System.Windows.Forms.ComboBox cbx_produto;
        private System.Windows.Forms.Label lb_nomeProduto;
        private System.Windows.Forms.GroupBox gb_novo_item;
        private System.Windows.Forms.Label lb_descricao;
        private System.Windows.Forms.TableLayoutPanel tlp_GridProduto;
        private System.Windows.Forms.Label lb_qtdEstoque;
        private System.Windows.Forms.Label lb_estoque;
        private System.Windows.Forms.Label lb_preco;
        private System.Windows.Forms.Label lb_description;
        private System.Windows.Forms.Label lb_titlePrice;
        public System.Windows.Forms.Button btnOk;
    }
}
