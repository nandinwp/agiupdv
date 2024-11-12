namespace Agiu_PDV.UI.Dialogs
{
    partial class ModalDialogUserControl
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
            this.txb_nome = new System.Windows.Forms.TextBox();
            this.txb_endereco = new System.Windows.Forms.TextBox();
            this.txb_telefone = new System.Windows.Forms.TextBox();
            this.txb_email = new System.Windows.Forms.TextBox();
            this.gb_elementos = new System.Windows.Forms.GroupBox();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.lb_tip4 = new System.Windows.Forms.Label();
            this.lb_tip3 = new System.Windows.Forms.Label();
            this.lb_tip2 = new System.Windows.Forms.Label();
            this.lb_tip1 = new System.Windows.Forms.Label();
            this.gb_elementos.SuspendLayout();
            this.SuspendLayout();
            // 
            // txb_nome
            // 
            this.txb_nome.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_nome.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_nome.Location = new System.Drawing.Point(142, 59);
            this.txb_nome.Name = "txb_nome";
            this.txb_nome.Size = new System.Drawing.Size(232, 25);
            this.txb_nome.TabIndex = 1;
            // 
            // txb_endereco
            // 
            this.txb_endereco.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_endereco.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_endereco.Location = new System.Drawing.Point(142, 92);
            this.txb_endereco.Name = "txb_endereco";
            this.txb_endereco.Size = new System.Drawing.Size(232, 25);
            this.txb_endereco.TabIndex = 2;
            // 
            // txb_telefone
            // 
            this.txb_telefone.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_telefone.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_telefone.Location = new System.Drawing.Point(142, 123);
            this.txb_telefone.Name = "txb_telefone";
            this.txb_telefone.Size = new System.Drawing.Size(232, 25);
            this.txb_telefone.TabIndex = 3;
            // 
            // txb_email
            // 
            this.txb_email.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txb_email.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txb_email.Location = new System.Drawing.Point(142, 154);
            this.txb_email.Name = "txb_email";
            this.txb_email.Size = new System.Drawing.Size(232, 25);
            this.txb_email.TabIndex = 4;
            this.txb_email.TextChanged += new System.EventHandler(this.txb_email_TextChanged);
            // 
            // gb_elementos
            // 
            this.gb_elementos.Controls.Add(this.btn_confirm);
            this.gb_elementos.Controls.Add(this.lb_tip4);
            this.gb_elementos.Controls.Add(this.lb_tip3);
            this.gb_elementos.Controls.Add(this.lb_tip2);
            this.gb_elementos.Controls.Add(this.lb_tip1);
            this.gb_elementos.Controls.Add(this.txb_telefone);
            this.gb_elementos.Controls.Add(this.txb_endereco);
            this.gb_elementos.Controls.Add(this.txb_email);
            this.gb_elementos.Controls.Add(this.txb_nome);
            this.gb_elementos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gb_elementos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gb_elementos.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gb_elementos.Location = new System.Drawing.Point(0, 0);
            this.gb_elementos.Name = "gb_elementos";
            this.gb_elementos.Size = new System.Drawing.Size(395, 258);
            this.gb_elementos.TabIndex = 5;
            this.gb_elementos.TabStop = false;
            this.gb_elementos.Text = "groupBox1";
            // 
            // btn_confirm
            // 
            this.btn_confirm.BackColor = System.Drawing.Color.PaleGreen;
            this.btn_confirm.FlatAppearance.BorderSize = 0;
            this.btn_confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_confirm.Location = new System.Drawing.Point(272, 215);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(117, 37);
            this.btn_confirm.TabIndex = 9;
            this.btn_confirm.Text = "Ok";
            this.btn_confirm.UseVisualStyleBackColor = false;
            // 
            // lb_tip4
            // 
            this.lb_tip4.AutoSize = true;
            this.lb_tip4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_tip4.Location = new System.Drawing.Point(6, 152);
            this.lb_tip4.Name = "lb_tip4";
            this.lb_tip4.Size = new System.Drawing.Size(83, 23);
            this.lb_tip4.TabIndex = 8;
            this.lb_tip4.Text = "Endereço";
            // 
            // lb_tip3
            // 
            this.lb_tip3.AutoSize = true;
            this.lb_tip3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_tip3.Location = new System.Drawing.Point(6, 121);
            this.lb_tip3.Name = "lb_tip3";
            this.lb_tip3.Size = new System.Drawing.Size(56, 23);
            this.lb_tip3.TabIndex = 7;
            this.lb_tip3.Text = "E-mail";
            // 
            // lb_tip2
            // 
            this.lb_tip2.AutoSize = true;
            this.lb_tip2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lb_tip2.Location = new System.Drawing.Point(6, 92);
            this.lb_tip2.Name = "lb_tip2";
            this.lb_tip2.Size = new System.Drawing.Size(76, 23);
            this.lb_tip2.TabIndex = 6;
            this.lb_tip2.Text = "Telefone";
            // 
            // lb_tip1
            // 
            this.lb_tip1.AutoSize = true;
            this.lb_tip1.Location = new System.Drawing.Point(6, 61);
            this.lb_tip1.Name = "lb_tip1";
            this.lb_tip1.Size = new System.Drawing.Size(54, 23);
            this.lb_tip1.TabIndex = 5;
            this.lb_tip1.Text = "Nome";
            // 
            // ModalDialogUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gb_elementos);
            this.Name = "ModalDialogUserControl";
            this.Size = new System.Drawing.Size(395, 258);
            this.gb_elementos.ResumeLayout(false);
            this.gb_elementos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txb_nome;
        private System.Windows.Forms.TextBox txb_endereco;
        private System.Windows.Forms.TextBox txb_telefone;
        private System.Windows.Forms.TextBox txb_email;
        private System.Windows.Forms.GroupBox gb_elementos;
        private System.Windows.Forms.Label lb_tip4;
        private System.Windows.Forms.Label lb_tip3;
        private System.Windows.Forms.Label lb_tip2;
        private System.Windows.Forms.Label lb_tip1;
        public System.Windows.Forms.Button btn_confirm;
    }
}
