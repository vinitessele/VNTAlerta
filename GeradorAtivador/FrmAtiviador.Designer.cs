namespace GeradorAtivador
{
    partial class FrmAtiviador
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnChaveAcesso = new Button();
            textChave = new TextBox();
            textEmpresa = new TextBox();
            label1 = new Label();
            textNomeEmpresa = new TextBox();
            textCNPJ = new TextBox();
            textChaveAcesso = new TextBox();
            textStatus = new TextBox();
            textIdCidade = new TextBox();
            textdataInicioAtivacao = new TextBox();
            textexpira = new TextBox();
            textidentificacaoCliente = new TextBox();
            btnArquivo = new Button();
            SuspendLayout();
            // 
            // btnChaveAcesso
            // 
            btnChaveAcesso.Location = new Point(12, 54);
            btnChaveAcesso.Name = "btnChaveAcesso";
            btnChaveAcesso.Size = new Size(105, 46);
            btnChaveAcesso.TabIndex = 1;
            btnChaveAcesso.Text = "Gerador Chave Acesso";
            btnChaveAcesso.UseVisualStyleBackColor = true;
            btnChaveAcesso.Click += btnChaveAcesso_Click;
            // 
            // textChave
            // 
            textChave.Location = new Point(12, 106);
            textChave.Name = "textChave";
            textChave.Size = new Size(289, 23);
            textChave.TabIndex = 2;
            // 
            // textEmpresa
            // 
            textEmpresa.Location = new Point(12, 25);
            textEmpresa.Name = "textEmpresa";
            textEmpresa.Size = new Size(289, 23);
            textEmpresa.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 7);
            label1.Name = "label1";
            label1.Size = new Size(258, 15);
            label1.TabIndex = 3;
            label1.Text = "Identificador da empresa Test0000;dd/MM/yyyy";
            // 
            // textNomeEmpresa
            // 
            textNomeEmpresa.AcceptsTab = true;
            textNomeEmpresa.Location = new Point(12, 160);
            textNomeEmpresa.Name = "textNomeEmpresa";
            textNomeEmpresa.PlaceholderText = "Nome";
            textNomeEmpresa.Size = new Size(289, 23);
            textNomeEmpresa.TabIndex = 4;
            // 
            // textCNPJ
            // 
            textCNPJ.Location = new Point(12, 189);
            textCNPJ.Name = "textCNPJ";
            textCNPJ.PlaceholderText = "Cnpj";
            textCNPJ.Size = new Size(289, 23);
            textCNPJ.TabIndex = 5;
            // 
            // textChaveAcesso
            // 
            textChaveAcesso.Enabled = false;
            textChaveAcesso.Location = new Point(12, 218);
            textChaveAcesso.Name = "textChaveAcesso";
            textChaveAcesso.PlaceholderText = "chave acesso";
            textChaveAcesso.Size = new Size(289, 23);
            textChaveAcesso.TabIndex = 6;
            // 
            // textStatus
            // 
            textStatus.Location = new Point(12, 247);
            textStatus.Name = "textStatus";
            textStatus.PlaceholderText = "Status";
            textStatus.Size = new Size(289, 23);
            textStatus.TabIndex = 7;
            // 
            // textIdCidade
            // 
            textIdCidade.Location = new Point(12, 276);
            textIdCidade.Name = "textIdCidade";
            textIdCidade.PlaceholderText = "IdCidade";
            textIdCidade.Size = new Size(289, 23);
            textIdCidade.TabIndex = 8;
            // 
            // textdataInicioAtivacao
            // 
            textdataInicioAtivacao.Location = new Point(12, 305);
            textdataInicioAtivacao.Name = "textdataInicioAtivacao";
            textdataInicioAtivacao.PlaceholderText = "Data Inicio";
            textdataInicioAtivacao.Size = new Size(289, 23);
            textdataInicioAtivacao.TabIndex = 9;
            // 
            // textexpira
            // 
            textexpira.Location = new Point(12, 334);
            textexpira.Name = "textexpira";
            textexpira.PlaceholderText = "Expira em";
            textexpira.Size = new Size(289, 23);
            textexpira.TabIndex = 10;
            // 
            // textidentificacaoCliente
            // 
            textidentificacaoCliente.Location = new Point(12, 363);
            textidentificacaoCliente.Name = "textidentificacaoCliente";
            textidentificacaoCliente.PlaceholderText = "Identificação Cliente";
            textidentificacaoCliente.Size = new Size(289, 23);
            textidentificacaoCliente.TabIndex = 11;
            // 
            // btnArquivo
            // 
            btnArquivo.Location = new Point(12, 392);
            btnArquivo.Name = "btnArquivo";
            btnArquivo.Size = new Size(105, 46);
            btnArquivo.TabIndex = 12;
            btnArquivo.Text = "Gerar arquivo Licença";
            btnArquivo.UseVisualStyleBackColor = true;
            btnArquivo.Click += btnArquivo_Click;
            // 
            // FrmAtiviador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnArquivo);
            Controls.Add(textidentificacaoCliente);
            Controls.Add(textexpira);
            Controls.Add(textdataInicioAtivacao);
            Controls.Add(textIdCidade);
            Controls.Add(textStatus);
            Controls.Add(textChaveAcesso);
            Controls.Add(textCNPJ);
            Controls.Add(textNomeEmpresa);
            Controls.Add(label1);
            Controls.Add(textEmpresa);
            Controls.Add(textChave);
            Controls.Add(btnChaveAcesso);
            Name = "FrmAtiviador";
            Text = "Gerador de Ativador";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnChaveAcesso;
        private TextBox textChave;
        private TextBox textEmpresa;
        private Label label1;
        private TextBox textNomeEmpresa;
        private TextBox textCNPJ;
        private TextBox textChaveAcesso;
        private TextBox textStatus;
        private TextBox textIdCidade;
        private TextBox textdataInicioAtivacao;
        private TextBox textexpira;
        private TextBox textidentificacaoCliente;
        private Button btnArquivo;
    }
}
