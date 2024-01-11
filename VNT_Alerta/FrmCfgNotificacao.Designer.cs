namespace VNT_CentralDeNotificacao
{
    partial class FrmCfgNotificacao
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textId = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label9 = new Label();
            textPara = new TextBox();
            textAssunto = new TextBox();
            textMensagem = new TextBox();
            checkBoxNotificacaoEmail = new CheckBox();
            checkBoxNotificacaoWindows = new CheckBox();
            textDias = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textDias);
            groupBox1.Controls.Add(checkBoxNotificacaoWindows);
            groupBox1.Controls.Add(checkBoxNotificacaoEmail);
            groupBox1.Controls.Add(textMensagem);
            groupBox1.Controls.Add(textAssunto);
            groupBox1.Controls.Add(textPara);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(textId);
            groupBox1.Controls.Add(label1);
            // 
            // bntSalvar
            // 
            bntSalvar.Click += bntSalvar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Click += btnNovo_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Click += btnExcluir_Click;
            // 
            // bntEditar
            // 
            bntEditar.Click += bntEditar_Click;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 33);
            label1.Name = "label1";
            label1.Size = new Size(17, 15);
            label1.TabIndex = 0;
            label1.Text = "Id";
            // 
            // textId
            // 
            textId.Enabled = false;
            textId.Location = new Point(62, 30);
            textId.Name = "textId";
            textId.Size = new Size(100, 23);
            textId.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 66);
            label2.Name = "label2";
            label2.Size = new Size(171, 15);
            label2.TabIndex = 2;
            label2.Text = "De: vntnotificacao@gmail.com";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 95);
            label3.Name = "label3";
            label3.Size = new Size(30, 15);
            label3.TabIndex = 3;
            label3.Text = "Para";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 124);
            label4.Name = "label4";
            label4.Size = new Size(50, 15);
            label4.TabIndex = 4;
            label4.Text = "Assunto";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 163);
            label5.Name = "label5";
            label5.Size = new Size(103, 15);
            label5.TabIndex = 5;
            label5.Text = "E-mail mensagem";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 286);
            label9.Name = "label9";
            label9.Size = new Size(270, 15);
            label9.TabIndex = 9;
            label9.Text = "Quantos dias antes do vencimento para Notificar?";
            // 
            // textPara
            // 
            textPara.Location = new Point(62, 92);
            textPara.Name = "textPara";
            textPara.Size = new Size(316, 23);
            textPara.TabIndex = 10;
            // 
            // textAssunto
            // 
            textAssunto.Location = new Point(62, 121);
            textAssunto.Name = "textAssunto";
            textAssunto.Size = new Size(316, 23);
            textAssunto.TabIndex = 11;
            // 
            // textMensagem
            // 
            textMensagem.Location = new Point(6, 181);
            textMensagem.Multiline = true;
            textMensagem.Name = "textMensagem";
            textMensagem.Size = new Size(372, 85);
            textMensagem.TabIndex = 12;
            // 
            // checkBoxNotificacaoEmail
            // 
            checkBoxNotificacaoEmail.AutoSize = true;
            checkBoxNotificacaoEmail.Location = new Point(198, 65);
            checkBoxNotificacaoEmail.Name = "checkBoxNotificacaoEmail";
            checkBoxNotificacaoEmail.Size = new Size(135, 19);
            checkBoxNotificacaoEmail.TabIndex = 14;
            checkBoxNotificacaoEmail.Text = "Notificar por E-mail?";
            checkBoxNotificacaoEmail.UseVisualStyleBackColor = true;
            // 
            // checkBoxNotificacaoWindows
            // 
            checkBoxNotificacaoWindows.AutoSize = true;
            checkBoxNotificacaoWindows.Location = new Point(339, 65);
            checkBoxNotificacaoWindows.Name = "checkBoxNotificacaoWindows";
            checkBoxNotificacaoWindows.Size = new Size(129, 19);
            checkBoxNotificacaoWindows.TabIndex = 15;
            checkBoxNotificacaoWindows.Text = "Notificar Windows?";
            checkBoxNotificacaoWindows.UseVisualStyleBackColor = true;
            // 
            // textDias
            // 
            textDias.Location = new Point(283, 283);
            textDias.Name = "textDias";
            textDias.Size = new Size(77, 23);
            textDias.TabIndex = 16;
            // 
            // FrmCfgNotificacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "FrmCfgNotificacao";
            Text = "***Configuração do envio de notificação***";
            Load += FrmCfgNotificacao_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox textId;
        private Label label1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label9;
        private Label label6;
        private Label label5;
        private TextBox textDias;
        private CheckBox checkBoxNotificacaoWindows;
        private CheckBox checkBoxNotificacaoEmail;
        private TextBox textMensagem;
        private TextBox textAssunto;
        private TextBox textPara;
    }
}