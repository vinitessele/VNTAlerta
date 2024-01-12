namespace VNT_CentralDeNotificacao
{
    partial class FrmCadNotificacao
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            textDataIniProcesso = new MaskedTextBox();
            textDataFimProcesso = new MaskedTextBox();
            textDataNotificacao = new MaskedTextBox();
            comboBoxTipoRegistro = new ComboBox();
            comboBoxEmpresa = new ComboBox();
            checkBox1 = new CheckBox();
            textId = new TextBox();
            textDescricao = new TextBox();
            textBox2 = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox2);
            groupBox1.Controls.Add(textDescricao);
            groupBox1.Controls.Add(textId);
            groupBox1.Controls.Add(checkBox1);
            groupBox1.Controls.Add(comboBoxEmpresa);
            groupBox1.Controls.Add(comboBoxTipoRegistro);
            groupBox1.Controls.Add(textDataNotificacao);
            groupBox1.Controls.Add(textDataFimProcesso);
            groupBox1.Controls.Add(textDataIniProcesso);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            // 
            // btnNovo
            // 
            btnNovo.Click += btnNovo_Click;
            // 
            // bntEditar
            // 
            bntEditar.Click += bntEditar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 23);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 51);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 1;
            label2.Text = "Descrição";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 79);
            label3.Name = "label3";
            label3.Size = new Size(76, 15);
            label3.TabIndex = 2;
            label3.Text = "Tipo Registro";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 107);
            label4.Name = "label4";
            label4.Size = new Size(52, 15);
            label4.TabIndex = 3;
            label4.Text = "Empresa";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(14, 135);
            label5.Name = "label5";
            label5.Size = new Size(132, 15);
            label5.TabIndex = 4;
            label5.Text = "Data Inicial do Processo";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(259, 135);
            label6.Name = "label6";
            label6.Size = new Size(126, 15);
            label6.TabIndex = 5;
            label6.Text = "Data Final do Processo";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(501, 135);
            label7.Name = "label7";
            label7.Size = new Size(109, 15);
            label7.TabIndex = 6;
            label7.Text = "Data de notificação";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(14, 167);
            label8.Name = "label8";
            label8.Size = new Size(28, 15);
            label8.TabIndex = 7;
            label8.Text = "Obs";
            // 
            // textDataIniProcesso
            // 
            textDataIniProcesso.Location = new Point(152, 132);
            textDataIniProcesso.Mask = "00/00/0000";
            textDataIniProcesso.Name = "textDataIniProcesso";
            textDataIniProcesso.Size = new Size(100, 23);
            textDataIniProcesso.TabIndex = 9;
            textDataIniProcesso.ValidatingType = typeof(DateTime);
            // 
            // textDataFimProcesso
            // 
            textDataFimProcesso.Location = new Point(391, 132);
            textDataFimProcesso.Mask = "00/00/0000";
            textDataFimProcesso.Name = "textDataFimProcesso";
            textDataFimProcesso.Size = new Size(100, 23);
            textDataFimProcesso.TabIndex = 10;
            textDataFimProcesso.ValidatingType = typeof(DateTime);
            // 
            // textDataNotificacao
            // 
            textDataNotificacao.Location = new Point(609, 132);
            textDataNotificacao.Mask = "00/00/0000";
            textDataNotificacao.Name = "textDataNotificacao";
            textDataNotificacao.Size = new Size(100, 23);
            textDataNotificacao.TabIndex = 11;
            textDataNotificacao.ValidatingType = typeof(DateTime);
            // 
            // comboBoxTipoRegistro
            // 
            comboBoxTipoRegistro.FormattingEnabled = true;
            comboBoxTipoRegistro.Location = new Point(96, 76);
            comboBoxTipoRegistro.Name = "comboBoxTipoRegistro";
            comboBoxTipoRegistro.Size = new Size(395, 23);
            comboBoxTipoRegistro.TabIndex = 12;
            // 
            // comboBoxEmpresa
            // 
            comboBoxEmpresa.FormattingEnabled = true;
            comboBoxEmpresa.Location = new Point(96, 104);
            comboBoxEmpresa.Name = "comboBoxEmpresa";
            comboBoxEmpresa.Size = new Size(395, 23);
            comboBoxEmpresa.TabIndex = 13;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(501, 185);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(138, 19);
            checkBox1.TabIndex = 14;
            checkBox1.Text = "Status da Notificação";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // textId
            // 
            textId.Enabled = false;
            textId.Location = new Point(46, 20);
            textId.Name = "textId";
            textId.Size = new Size(100, 23);
            textId.TabIndex = 15;
            // 
            // textDescricao
            // 
            textDescricao.Location = new Point(96, 48);
            textDescricao.Name = "textDescricao";
            textDescricao.Size = new Size(613, 23);
            textDescricao.TabIndex = 16;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(14, 185);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(477, 101);
            textBox2.TabIndex = 17;
            // 
            // FrmCadNotificacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "FrmCadNotificacao";
            Text = "***Cadastro de Notificações";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox2;
        private TextBox textDescricao;
        private TextBox textId;
        private CheckBox checkBox1;
        private ComboBox comboBoxEmpresa;
        private ComboBox comboBoxTipoRegistro;
        private MaskedTextBox textDataNotificacao;
        private MaskedTextBox textDataFimProcesso;
        private MaskedTextBox textDataIniProcesso;
    }
}