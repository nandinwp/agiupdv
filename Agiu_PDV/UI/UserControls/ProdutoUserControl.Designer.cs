namespace Agiu_PDV.UI.UserControls
{
    partial class ProdutoUserControl
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
            this.listProdutos = new System.Windows.Forms.ListView();
            this.ch_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_descricao = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_preco = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_estoque = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listProdutos
            // 
            this.listProdutos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listProdutos.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_id,
            this.ch_nome,
            this.ch_descricao,
            this.ch_preco,
            this.ch_estoque});
            this.listProdutos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listProdutos.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listProdutos.FullRowSelect = true;
            this.listProdutos.HideSelection = false;
            this.listProdutos.Location = new System.Drawing.Point(0, 0);
            this.listProdutos.MultiSelect = false;
            this.listProdutos.Name = "listProdutos";
            this.listProdutos.Size = new System.Drawing.Size(1346, 515);
            this.listProdutos.TabIndex = 1;
            this.listProdutos.UseCompatibleStateImageBehavior = false;
            this.listProdutos.View = System.Windows.Forms.View.Details;
            this.listProdutos.Click += new System.EventHandler(this.listProdutos_Click);
            // 
            // ch_id
            // 
            this.ch_id.Width = 0;
            // 
            // ch_nome
            // 
            this.ch_nome.Text = "Nome";
            this.ch_nome.Width = 250;
            // 
            // ch_descricao
            // 
            this.ch_descricao.Text = "Descrição";
            this.ch_descricao.Width = 250;
            // 
            // ch_preco
            // 
            this.ch_preco.Text = "Preço";
            this.ch_preco.Width = 250;
            // 
            // ch_estoque
            // 
            this.ch_estoque.Text = "Estoque";
            this.ch_estoque.Width = 250;
            // 
            // ProdutoUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listProdutos);
            this.Name = "ProdutoUserControl";
            this.Size = new System.Drawing.Size(1346, 515);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listProdutos;
        private System.Windows.Forms.ColumnHeader ch_id;
        private System.Windows.Forms.ColumnHeader ch_nome;
        private System.Windows.Forms.ColumnHeader ch_descricao;
        private System.Windows.Forms.ColumnHeader ch_preco;
        private System.Windows.Forms.ColumnHeader ch_estoque;
    }
}
