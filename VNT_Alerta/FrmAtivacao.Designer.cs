namespace VNT_CentralDeNotificacao
{
    partial class FormAtivacao
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
            textBox1 = new TextBox();
            label3 = new Label();
            openFileDialog1 = new OpenFileDialog();
            FiletextBox = new TextBox();
            btnArquivo = new Button();
            groupBox1 = new GroupBox();
            labelIdentificacao = new Label();
            labelExpira = new Label();
            labelCnpj = new Label();
            labelEmpresa = new Label();
            btnAtivar = new Button();
            labelVersao = new Label();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(180, 25);
            label1.Name = "label1";
            label1.Size = new Size(386, 30);
            label1.TabIndex = 0;
            label1.Text = "Central de Notificação VNT - Sistemas";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 271);
            label2.Name = "label2";
            label2.Size = new Size(168, 15);
            label2.TabIndex = 1;
            label2.Text = "Importar Nova Linceça de uso:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 349);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(379, 23);
            textBox1.TabIndex = 2;
            textBox1.Text = "Serial";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 331);
            label3.Name = "label3";
            label3.Size = new Size(379, 15);
            label3.TabIndex = 3;
            label3.Text = "Se você possui a linceça do software  e deseja reativar solicite seu serial";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            openFileDialog1.Title = "Importar Linceça";
            // 
            // FiletextBox
            // 
            FiletextBox.Location = new Point(12, 289);
            FiletextBox.Name = "FiletextBox";
            FiletextBox.Size = new Size(168, 23);
            FiletextBox.TabIndex = 4;
            // 
            // btnArquivo
            // 
            btnArquivo.Location = new Point(186, 289);
            btnArquivo.Name = "btnArquivo";
            btnArquivo.Size = new Size(141, 23);
            btnArquivo.TabIndex = 5;
            btnArquivo.Text = "Selecionar Arquivo";
            btnArquivo.UseVisualStyleBackColor = true;
            btnArquivo.Click += OpenFileButton_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(labelIdentificacao);
            groupBox1.Controls.Add(labelExpira);
            groupBox1.Controls.Add(labelCnpj);
            groupBox1.Controls.Add(labelEmpresa);
            groupBox1.Location = new Point(12, 58);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 195);
            groupBox1.TabIndex = 6;
            groupBox1.TabStop = false;
            groupBox1.Text = "Software Registrado para";
            // 
            // labelIdentificacao
            // 
            labelIdentificacao.AutoSize = true;
            labelIdentificacao.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelIdentificacao.Location = new Point(17, 132);
            labelIdentificacao.Name = "labelIdentificacao";
            labelIdentificacao.Size = new Size(197, 21);
            labelIdentificacao.TabIndex = 3;
            labelIdentificacao.Text = "Identificação da Empresa:";
            // 
            // labelExpira
            // 
            labelExpira.AutoSize = true;
            labelExpira.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelExpira.Location = new Point(17, 95);
            labelExpira.Name = "labelExpira";
            labelExpira.Size = new Size(85, 21);
            labelExpira.TabIndex = 2;
            labelExpira.Text = "Expira em:";
            // 
            // labelCnpj
            // 
            labelCnpj.AutoSize = true;
            labelCnpj.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelCnpj.Location = new Point(17, 63);
            labelCnpj.Name = "labelCnpj";
            labelCnpj.Size = new Size(50, 21);
            labelCnpj.TabIndex = 1;
            labelCnpj.Text = "CNPJ:";
            // 
            // labelEmpresa
            // 
            labelEmpresa.AutoSize = true;
            labelEmpresa.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelEmpresa.Location = new Point(17, 30);
            labelEmpresa.Name = "labelEmpresa";
            labelEmpresa.Size = new Size(76, 21);
            labelEmpresa.TabIndex = 0;
            labelEmpresa.Text = "Empresa:";
            // 
            // btnAtivar
            // 
            btnAtivar.Location = new Point(397, 349);
            btnAtivar.Name = "btnAtivar";
            btnAtivar.Size = new Size(75, 23);
            btnAtivar.TabIndex = 7;
            btnAtivar.Text = "Ativar";
            btnAtivar.UseVisualStyleBackColor = true;
            // 
            // labelVersao
            // 
            labelVersao.AutoSize = true;
            labelVersao.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelVersao.Location = new Point(641, 351);
            labelVersao.Name = "labelVersao";
            labelVersao.Size = new Size(108, 21);
            labelVersao.TabIndex = 8;
            labelVersao.Text = "Versão: 24.1.0";
            // 
            // FormAtivacao
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(800, 396);
            Controls.Add(labelVersao);
            Controls.Add(btnAtivar);
            Controls.Add(groupBox1);
            Controls.Add(btnArquivo);
            Controls.Add(FiletextBox);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormAtivacao";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ativação do Software de Notificação";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private OpenFileDialog openFileDialog1;
        private TextBox FiletextBox;
        private Button btnArquivo;
        private GroupBox groupBox1;
        private Label labelCnpj;
        private Label labelEmpresa;
        private Label labelExpira;
        private Label labelIdentificacao;
        private Button btnAtivar;
        private Label labelVersao;
    }
}