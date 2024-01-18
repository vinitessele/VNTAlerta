namespace VNT_CentralDeNotificacao
{
    partial class FrmMenu
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            menuStrip1 = new MenuStrip();
            cadastroToolStripMenuItem = new ToolStripMenuItem();
            notificaçãoToolStripMenuItem = new ToolStripMenuItem();
            empresasToolStripMenuItem = new ToolStripMenuItem();
            tipoRegistroToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            licençaDeUsoToolStripMenuItem = new ToolStripMenuItem();
            dataGridViewNotificações = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            DataNotificacao = new DataGridViewTextBoxColumn();
            descricao = new DataGridViewTextBoxColumn();
            NomeEmpresa = new DataGridViewTextBoxColumn();
            TipoRegistro = new DataGridViewTextBoxColumn();
            VNTCentralNotificacao = new NotifyIcon(components);
            MenuNotificacoes = new ContextMenuStrip(components);
            toolStripMenuRestaurar = new ToolStripMenuItem();
            toolStripMenuExit = new ToolStripMenuItem();
            toolStripMenuEnviarNotificacao = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotificações).BeginInit();
            MenuNotificacoes.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ScrollBar;
            menuStrip1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastroToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1388, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastroToolStripMenuItem
            // 
            cadastroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { notificaçãoToolStripMenuItem, empresasToolStripMenuItem, tipoRegistroToolStripMenuItem, toolStripMenuItem2, toolStripSeparator1, licençaDeUsoToolStripMenuItem });
            cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            cadastroToolStripMenuItem.Size = new Size(72, 20);
            cadastroToolStripMenuItem.Text = "Cadastros";
            // 
            // notificaçãoToolStripMenuItem
            // 
            notificaçãoToolStripMenuItem.Name = "notificaçãoToolStripMenuItem";
            notificaçãoToolStripMenuItem.Size = new Size(198, 22);
            notificaçãoToolStripMenuItem.Text = "Notificação";
            notificaçãoToolStripMenuItem.Click += notificaçãoToolStripMenuItem_Click;
            // 
            // empresasToolStripMenuItem
            // 
            empresasToolStripMenuItem.Name = "empresasToolStripMenuItem";
            empresasToolStripMenuItem.Size = new Size(198, 22);
            empresasToolStripMenuItem.Text = "Empresas";
            empresasToolStripMenuItem.Click += empresasToolStripMenuItem_Click;
            // 
            // tipoRegistroToolStripMenuItem
            // 
            tipoRegistroToolStripMenuItem.Name = "tipoRegistroToolStripMenuItem";
            tipoRegistroToolStripMenuItem.Size = new Size(198, 22);
            tipoRegistroToolStripMenuItem.Text = "Tipo Registro";
            tipoRegistroToolStripMenuItem.Click += tipoRegistroToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(198, 22);
            toolStripMenuItem2.Text = "Configuração de envio";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(195, 6);
            // 
            // licençaDeUsoToolStripMenuItem
            // 
            licençaDeUsoToolStripMenuItem.Name = "licençaDeUsoToolStripMenuItem";
            licençaDeUsoToolStripMenuItem.Size = new Size(198, 22);
            licençaDeUsoToolStripMenuItem.Text = "Licença de Uso";
            licençaDeUsoToolStripMenuItem.Click += licençaDeUsoToolStripMenuItem_Click;
            // 
            // dataGridViewNotificações
            // 
            dataGridViewNotificações.AllowUserToAddRows = false;
            dataGridViewNotificações.AllowUserToDeleteRows = false;
            dataGridViewNotificações.Anchor = AnchorStyles.Bottom;
            dataGridViewNotificações.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNotificações.Columns.AddRange(new DataGridViewColumn[] { id, DataNotificacao, descricao, NomeEmpresa, TipoRegistro });
            dataGridViewNotificações.Location = new Point(12, 424);
            dataGridViewNotificações.Name = "dataGridViewNotificações";
            dataGridViewNotificações.ReadOnly = true;
            dataGridViewNotificações.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewNotificações.Size = new Size(1400, 250);
            dataGridViewNotificações.TabIndex = 1;
            // 
            // id
            // 
            id.DataPropertyName = "id";
            id.HeaderText = "ID";
            id.Name = "id";
            id.ReadOnly = true;
            id.Visible = false;
            // 
            // DataNotificacao
            // 
            DataNotificacao.DataPropertyName = "dataNotificacao";
            DataNotificacao.HeaderText = "Data da Notificação";
            DataNotificacao.Name = "DataNotificacao";
            DataNotificacao.ReadOnly = true;
            DataNotificacao.Width = 150;
            // 
            // descricao
            // 
            descricao.AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            descricao.DataPropertyName = "descricao";
            descricao.FillWeight = 150F;
            descricao.HeaderText = "Descrição";
            descricao.Name = "descricao";
            descricao.ReadOnly = true;
            descricao.Width = 350;
            // 
            // NomeEmpresa
            // 
            NomeEmpresa.DataPropertyName = "NomeEmpresa";
            NomeEmpresa.HeaderText = "Empresa";
            NomeEmpresa.Name = "NomeEmpresa";
            NomeEmpresa.ReadOnly = true;
            NomeEmpresa.Width = 350;
            // 
            // TipoRegistro
            // 
            TipoRegistro.DataPropertyName = "TipoRegistro";
            TipoRegistro.HeaderText = "Tipo Registro";
            TipoRegistro.Name = "TipoRegistro";
            TipoRegistro.ReadOnly = true;
            TipoRegistro.Width = 350;
            // 
            // VNTCentralNotificacao
            // 
            VNTCentralNotificacao.ContextMenuStrip = MenuNotificacoes;
            VNTCentralNotificacao.Icon = (Icon)resources.GetObject("VNTCentralNotificacao.Icon");
            VNTCentralNotificacao.Text = "VNT Central de Notificação";
            VNTCentralNotificacao.Visible = true;
            VNTCentralNotificacao.Click += VNTCentralNotificacao_Click;
            // 
            // MenuNotificacoes
            // 
            MenuNotificacoes.Items.AddRange(new ToolStripItem[] { toolStripMenuRestaurar, toolStripMenuExit, toolStripMenuEnviarNotificacao });
            MenuNotificacoes.Name = "MenuNotificacoes";
            MenuNotificacoes.Size = new Size(214, 70);
            MenuNotificacoes.ItemClicked += MenuNotificacoes_ItemClicked;
            // 
            // toolStripMenuRestaurar
            // 
            toolStripMenuRestaurar.Name = "toolStripMenuRestaurar";
            toolStripMenuRestaurar.Size = new Size(213, 22);
            toolStripMenuRestaurar.Text = "Restaurar";
            // 
            // toolStripMenuExit
            // 
            toolStripMenuExit.Name = "toolStripMenuExit";
            toolStripMenuExit.Size = new Size(213, 22);
            toolStripMenuExit.Text = "Exit";
            // 
            // toolStripMenuEnviarNotificacao
            // 
            toolStripMenuEnviarNotificacao.Name = "toolStripMenuEnviarNotificacao";
            toolStripMenuEnviarNotificacao.Size = new Size(213, 22);
            toolStripMenuEnviarNotificacao.Text = "Enviar Notificação Manual";
            // 
            // timer1
            // 
            timer1.Interval = 3600000;
            timer1.Tick += timer1_Tick;
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.PapayaWhip;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(1388, 716);
            Controls.Add(dataGridViewNotificações);
            Controls.Add(menuStrip1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Name = "FrmMenu";
            Text = "*** Central de notificação VNT - Sistemas ***";
            WindowState = FormWindowState.Maximized;
            Load += FrmMenu_Load;
            Resize += FrmMenu_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNotificações).EndInit();
            MenuNotificacoes.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem cadastroToolStripMenuItem;
        private ToolStripMenuItem notificaçãoToolStripMenuItem;
        private ToolStripMenuItem empresasToolStripMenuItem;
        private ToolStripMenuItem tipoRegistroToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem licençaDeUsoToolStripMenuItem;
        private DataGridView dataGridViewNotificações;
        private NotifyIcon VNTCentralNotificacao;
        private System.Windows.Forms.Timer timer1;
        private ContextMenuStrip MenuNotificacoes;
        private ToolStripMenuItem toolStripMenuRestaurar;
        private ToolStripMenuItem toolStripMenuExit;
        private ToolStripMenuItem toolStripMenuEnviarNotificacao;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn DataNotificacao;
        private DataGridViewTextBoxColumn descricao;
        private DataGridViewTextBoxColumn NomeEmpresa;
        private DataGridViewTextBoxColumn TipoRegistro;
    }
}