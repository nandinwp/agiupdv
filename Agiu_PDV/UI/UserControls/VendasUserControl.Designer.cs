namespace Agiu_PDV.UI.UserControls
{
    partial class VendasUserControl
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
            this.listVendas = new System.Windows.Forms.ListView();
            this.ch_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_nome = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_endereco = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_telefone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch_email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listVendas
            // 
            this.listVendas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listVendas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch_id,
            this.ch_nome,
            this.ch_endereco,
            this.ch_telefone,
            this.ch_email});
            this.listVendas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listVendas.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listVendas.FullRowSelect = true;
            this.listVendas.HideSelection = false;
            this.listVendas.Location = new System.Drawing.Point(0, 0);
            this.listVendas.MultiSelect = false;
            this.listVendas.Name = "listVendas";
            this.listVendas.Size = new System.Drawing.Size(1346, 515);
            this.listVendas.TabIndex = 1;
            this.listVendas.UseCompatibleStateImageBehavior = false;
            this.listVendas.View = System.Windows.Forms.View.Details;
            this.listVendas.Click += new System.EventHandler(this.listVendas_Click);
            // 
            // ch_id
            // 
            this.ch_id.Width = 0;
            // 
            // ch_nome
            // 
            this.ch_nome.Text = "Nome do cliente";
            this.ch_nome.Width = 250;
            // 
            // ch_endereco
            // 
            this.ch_endereco.Text = "Data da venda";
            this.ch_endereco.Width = 250;
            // 
            // ch_telefone
            // 
            this.ch_telefone.Text = "Valor total";
            this.ch_telefone.Width = 250;
            // 
            // ch_email
            // 
            this.ch_email.Text = "E-mail do cliente";
            this.ch_email.Width = 250;
            // 
            // VendasUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listVendas);
            this.Name = "VendasUserControl";
            this.Size = new System.Drawing.Size(1346, 515);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listVendas;
        private System.Windows.Forms.ColumnHeader ch_id;
        private System.Windows.Forms.ColumnHeader ch_nome;
        private System.Windows.Forms.ColumnHeader ch_endereco;
        private System.Windows.Forms.ColumnHeader ch_telefone;
        private System.Windows.Forms.ColumnHeader ch_email;
    }
}
