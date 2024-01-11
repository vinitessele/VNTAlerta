namespace VNT_CentralDeNotificacao
{
    partial class FrmTipoRegistro
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
            label2 = new Label();
            label3 = new Label();
            textID = new TextBox();
            textDescricao = new TextBox();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textDescricao);
            groupBox1.Controls.Add(textID);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            // 
            // bntSalvar
            // 
            bntSalvar.Click += BntSalvar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Click += BtnNovo_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Click += btnExcluir_Click;
            // 
            // bntEditar
            // 
            bntEditar.Click += BntEditar_Click;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 33);
            label2.Name = "label2";
            label2.Size = new Size(18, 15);
            label2.TabIndex = 0;
            label2.Text = "ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 68);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 1;
            label3.Text = "Descrição";
            // 
            // textID
            // 
            textID.Enabled = false;
            textID.Location = new Point(70, 30);
            textID.Name = "textID";
            textID.Size = new Size(100, 23);
            textID.TabIndex = 2;
            textID.TextChanged += textID_TextChanged;
            // 
            // textDescricao
            // 
            textDescricao.Location = new Point(70, 65);
            textDescricao.Name = "textDescricao";
            textDescricao.Size = new Size(486, 23);
            textDescricao.TabIndex = 3;
            // 
            // FrmTipoRegistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Name = "FrmTipoRegistro";
            Text = "****Cadastro do tipo de registro****";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textID;
        private TextBox textDescricao;
    }
}