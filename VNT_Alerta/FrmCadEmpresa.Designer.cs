namespace VNT_CentralDeNotificacao
{
    partial class FrmCadEmpresa
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
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            textId = new TextBox();
            textRazao = new TextBox();
            textFantasia = new TextBox();
            textAtividade = new TextBox();
            textEndereco = new TextBox();
            textBairro = new TextBox();
            textCep = new TextBox();
            textSocios = new TextBox();
            textPercentSocios = new TextBox();
            textObs = new TextBox();
            comboBoxCidade = new ComboBox();
            textCNPJ = new MaskedTextBox();
            textCelular = new MaskedTextBox();
            textTelefone = new MaskedTextBox();
            textAbertura = new MaskedTextBox();
            groupBox2 = new GroupBox();
            btnAddSocios = new Button();
            textPercential = new TextBox();
            textNomeSocio = new TextBox();
            dataGridViewSocios = new DataGridView();
            Nome = new DataGridViewTextBoxColumn();
            PercentualSocios = new DataGridViewTextBoxColumn();
            Excluir = new DataGridViewButtonColumn();
            id = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSocios).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Controls.Add(textAbertura);
            groupBox1.Controls.Add(textTelefone);
            groupBox1.Controls.Add(textCelular);
            groupBox1.Controls.Add(textCNPJ);
            groupBox1.Controls.Add(comboBoxCidade);
            groupBox1.Controls.Add(textObs);
            groupBox1.Controls.Add(textPercentSocios);
            groupBox1.Controls.Add(textSocios);
            groupBox1.Controls.Add(textCep);
            groupBox1.Controls.Add(textBairro);
            groupBox1.Controls.Add(textEndereco);
            groupBox1.Controls.Add(textAtividade);
            groupBox1.Controls.Add(textFantasia);
            groupBox1.Controls.Add(textRazao);
            groupBox1.Controls.Add(textId);
            groupBox1.Controls.Add(label15);
            groupBox1.Controls.Add(label14);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label9);
            groupBox1.Controls.Add(label8);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Size = new Size(794, 639);
            // 
            // btnSalvar
            // 
            btnSalvar.Click += bntSalvar_Click;
            // 
            // btnNovo
            // 
            btnNovo.Click += btnNovo_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.Click += btnExcluir_Click;
            // 
            // btnEditar
            // 
            btnEditar.Click += bntEditar_Click;
            // 
            // btnPesquisar
            // 
            btnPesquisar.Click += btnPesquisar_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 26);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 0;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(11, 54);
            label2.Name = "label2";
            label2.Size = new Size(72, 15);
            label2.TabIndex = 1;
            label2.Text = "Razão Social";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(11, 82);
            label3.Name = "label3";
            label3.Size = new Size(86, 15);
            label3.TabIndex = 2;
            label3.Text = "Nome Fantasia";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(533, 54);
            label4.Name = "label4";
            label4.Size = new Size(34, 15);
            label4.TabIndex = 3;
            label4.Text = "CNPJ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(11, 111);
            label5.Name = "label5";
            label5.Size = new Size(57, 15);
            label5.TabIndex = 4;
            label5.Text = "Atividade";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(11, 139);
            label6.Name = "label6";
            label6.Size = new Size(56, 15);
            label6.TabIndex = 5;
            label6.Text = "Endereço";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(434, 139);
            label7.Name = "label7";
            label7.Size = new Size(38, 15);
            label7.TabIndex = 6;
            label7.Text = "Bairro";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(624, 139);
            label8.Name = "label8";
            label8.Size = new Size(28, 15);
            label8.TabIndex = 7;
            label8.Text = "Cep";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(11, 168);
            label9.Name = "label9";
            label9.Size = new Size(44, 15);
            label9.TabIndex = 8;
            label9.Text = "Cidade";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(11, 197);
            label10.Name = "label10";
            label10.Size = new Size(41, 15);
            label10.TabIndex = 9;
            label10.Text = "Sócios";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(11, 225);
            label11.Name = "label11";
            label11.Size = new Size(76, 15);
            label11.TabIndex = 10;
            label11.Text = "% dos Sócios";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(11, 255);
            label12.Name = "label12";
            label12.Size = new Size(51, 15);
            label12.TabIndex = 11;
            label12.Text = "Telefone";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(223, 255);
            label13.Name = "label13";
            label13.Size = new Size(44, 15);
            label13.TabIndex = 12;
            label13.Text = "Celular";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(11, 284);
            label14.Name = "label14";
            label14.Size = new Size(78, 15);
            label14.TabIndex = 13;
            label14.Text = "Data abertura";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(430, 247);
            label15.Name = "label15";
            label15.Size = new Size(28, 15);
            label15.TabIndex = 14;
            label15.Text = "Obs";
            // 
            // textId
            // 
            textId.Enabled = false;
            textId.Location = new Point(50, 18);
            textId.Name = "textId";
            textId.Size = new Size(100, 23);
            textId.TabIndex = 15;
            textId.TextChanged += textId_TextChanged;
            // 
            // textRazao
            // 
            textRazao.Location = new Point(98, 46);
            textRazao.Name = "textRazao";
            textRazao.Size = new Size(426, 23);
            textRazao.TabIndex = 16;
            // 
            // textFantasia
            // 
            textFantasia.Location = new Point(98, 74);
            textFantasia.Name = "textFantasia";
            textFantasia.Size = new Size(426, 23);
            textFantasia.TabIndex = 18;
            // 
            // textAtividade
            // 
            textAtividade.Location = new Point(78, 103);
            textAtividade.Name = "textAtividade";
            textAtividade.Size = new Size(356, 23);
            textAtividade.TabIndex = 19;
            // 
            // textEndereco
            // 
            textEndereco.Location = new Point(77, 131);
            textEndereco.Name = "textEndereco";
            textEndereco.Size = new Size(356, 23);
            textEndereco.TabIndex = 20;
            // 
            // textBairro
            // 
            textBairro.Location = new Point(478, 131);
            textBairro.Name = "textBairro";
            textBairro.Size = new Size(140, 23);
            textBairro.TabIndex = 21;
            // 
            // textCep
            // 
            textCep.Location = new Point(658, 131);
            textCep.Name = "textCep";
            textCep.Size = new Size(112, 23);
            textCep.TabIndex = 22;
            // 
            // textSocios
            // 
            textSocios.Location = new Point(77, 189);
            textSocios.Name = "textSocios";
            textSocios.Size = new Size(447, 23);
            textSocios.TabIndex = 24;
            // 
            // textPercentSocios
            // 
            textPercentSocios.Location = new Point(93, 217);
            textPercentSocios.Name = "textPercentSocios";
            textPercentSocios.Size = new Size(431, 23);
            textPercentSocios.TabIndex = 25;
            // 
            // textObs
            // 
            textObs.Location = new Point(464, 247);
            textObs.Multiline = true;
            textObs.Name = "textObs";
            textObs.Size = new Size(306, 103);
            textObs.TabIndex = 31;
            // 
            // comboBoxCidade
            // 
            comboBoxCidade.AutoCompleteMode = AutoCompleteMode.Suggest;
            comboBoxCidade.FormattingEnabled = true;
            comboBoxCidade.Location = new Point(77, 160);
            comboBoxCidade.Name = "comboBoxCidade";
            comboBoxCidade.Size = new Size(356, 23);
            comboBoxCidade.TabIndex = 23;
            // 
            // textCNPJ
            // 
            textCNPJ.Location = new Point(573, 46);
            textCNPJ.Mask = "00.000.000/0000-99";
            textCNPJ.Name = "textCNPJ";
            textCNPJ.Size = new Size(133, 23);
            textCNPJ.TabIndex = 17;
            // 
            // textCelular
            // 
            textCelular.Location = new Point(272, 247);
            textCelular.Mask = "(99)99999-9999";
            textCelular.Name = "textCelular";
            textCelular.Size = new Size(107, 23);
            textCelular.TabIndex = 27;
            // 
            // textTelefone
            // 
            textTelefone.Location = new Point(93, 247);
            textTelefone.Mask = "(99)99999-9999";
            textTelefone.Name = "textTelefone";
            textTelefone.Size = new Size(107, 23);
            textTelefone.TabIndex = 26;
            // 
            // textAbertura
            // 
            textAbertura.Location = new Point(93, 276);
            textAbertura.Mask = "00/00/0000";
            textAbertura.Name = "textAbertura";
            textAbertura.Size = new Size(107, 23);
            textAbertura.TabIndex = 30;
            textAbertura.ValidatingType = typeof(DateTime);
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnAddSocios);
            groupBox2.Controls.Add(textPercential);
            groupBox2.Controls.Add(textNomeSocio);
            groupBox2.Controls.Add(dataGridViewSocios);
            groupBox2.Location = new Point(11, 374);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(759, 244);
            groupBox2.TabIndex = 35;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cadastro dos Sócios";
            // 
            // btnAddSocios
            // 
            btnAddSocios.Location = new Point(599, 32);
            btnAddSocios.Name = "btnAddSocios";
            btnAddSocios.Size = new Size(119, 23);
            btnAddSocios.TabIndex = 36;
            btnAddSocios.Text = "Adicionar Sócios";
            btnAddSocios.UseVisualStyleBackColor = true;
            btnAddSocios.Click += btnAddSocios_Click;
            // 
            // textPercential
            // 
            textPercential.Location = new Point(453, 33);
            textPercential.Name = "textPercential";
            textPercential.PlaceholderText = "%";
            textPercential.Size = new Size(140, 23);
            textPercential.TabIndex = 35;
            // 
            // textNomeSocio
            // 
            textNomeSocio.Location = new Point(16, 33);
            textNomeSocio.Name = "textNomeSocio";
            textNomeSocio.PlaceholderText = "Nome";
            textNomeSocio.Size = new Size(426, 23);
            textNomeSocio.TabIndex = 34;
            // 
            // dataGridViewSocios
            // 
            dataGridViewSocios.AllowUserToAddRows = false;
            dataGridViewSocios.AllowUserToDeleteRows = false;
            dataGridViewSocios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSocios.Columns.AddRange(new DataGridViewColumn[] { Nome, PercentualSocios, Excluir, id });
            dataGridViewSocios.Location = new Point(16, 72);
            dataGridViewSocios.Name = "dataGridViewSocios";
            dataGridViewSocios.ReadOnly = true;
            dataGridViewSocios.Size = new Size(737, 140);
            dataGridViewSocios.TabIndex = 33;
            dataGridViewSocios.CellClick += dataGridViewSocios_CellClick;
            // 
            // Nome
            // 
            Nome.DataPropertyName = "nome";
            Nome.HeaderText = "Nome";
            Nome.Name = "Nome";
            Nome.ReadOnly = true;
            Nome.Width = 400;
            // 
            // PercentualSocios
            // 
            PercentualSocios.DataPropertyName = "percentualSocios";
            PercentualSocios.HeaderText = "Percentual";
            PercentualSocios.Name = "PercentualSocios";
            PercentualSocios.ReadOnly = true;
            PercentualSocios.Width = 150;
            // 
            // Excluir
            // 
            Excluir.FlatStyle = FlatStyle.Flat;
            Excluir.HeaderText = "Excluir";
            Excluir.Name = "Excluir";
            Excluir.ReadOnly = true;
            Excluir.Text = "Excluir";
            Excluir.ToolTipText = "Excluir";
            Excluir.UseColumnTextForButtonValue = true;
            Excluir.Width = 50;
            // 
            // id
            // 
            id.DataPropertyName = "id";
            id.HeaderText = "id";
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            // 
            // FrmCadEmpresa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(823, 744);
            Name = "FrmCadEmpresa";
            Text = "***Cadastro de Empresas***";
            Load += FrmCadEmpresa_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSocios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textFantasia;
        private TextBox textRazao;
        private TextBox textId;
        private TextBox textObs;
        private TextBox textPercentSocios;
        private TextBox textSocios;
        private TextBox textCep;
        private TextBox textBairro;
        private TextBox textEndereco;
        private TextBox textAtividade;
        private ComboBox comboBoxCidade;
        private MaskedTextBox textCNPJ;
        private MaskedTextBox textCelular;
        private MaskedTextBox textTelefone;
        private MaskedTextBox textAbertura;
        private Button btnAddSocios;
        private GroupBox groupBox2;
        private DataGridView dataGridViewSocios;
        private TextBox textPercential;
        private TextBox textNomeSocio;
        private DataGridViewTextBoxColumn Nome;
        private DataGridViewTextBoxColumn PercentualSocios;
        private DataGridViewButtonColumn Excluir;
        private DataGridViewTextBoxColumn id;
    }
}