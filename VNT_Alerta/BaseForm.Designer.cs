namespace VNT_CentralDeNotificacao
{
    partial class BaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            panelMenu = new Panel();
            btnPesquisar = new Button();
            btnEditar = new Button();
            btnCancelar = new Button();
            btnExcluir = new Button();
            btnSalvar = new Button();
            btnNovo = new Button();
            groupBox1 = new GroupBox();
            paneltop = new Panel();
            toolTip1 = new ToolTip(components);
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = SystemColors.ActiveBorder;
            panelMenu.Controls.Add(btnPesquisar);
            panelMenu.Controls.Add(btnEditar);
            panelMenu.Controls.Add(btnCancelar);
            panelMenu.Controls.Add(btnExcluir);
            panelMenu.Controls.Add(btnSalvar);
            panelMenu.Controls.Add(btnNovo);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.ForeColor = SystemColors.ControlDarkDark;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(800, 61);
            panelMenu.TabIndex = 0;
            // 
            // btnPesquisar
            // 
            btnPesquisar.BackColor = SystemColors.AppWorkspace;
            btnPesquisar.BackgroundImage = (Image)resources.GetObject("btnPesquisar.BackgroundImage");
            btnPesquisar.BackgroundImageLayout = ImageLayout.Center;
            btnPesquisar.Location = new Point(384, 13);
            btnPesquisar.Name = "btnPesquisar";
            btnPesquisar.Size = new Size(33, 35);
            btnPesquisar.TabIndex = 5;
            toolTip1.SetToolTip(btnPesquisar, "Pesquisa");
            btnPesquisar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            btnEditar.BackColor = SystemColors.AppWorkspace;
            btnEditar.BackgroundImage = (Image)resources.GetObject("btnEditar.BackgroundImage");
            btnEditar.BackgroundImageLayout = ImageLayout.Center;
            btnEditar.Location = new Point(51, 12);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(33, 35);
            btnEditar.TabIndex = 1;
            toolTip1.SetToolTip(btnEditar, "Alterar");
            btnEditar.UseVisualStyleBackColor = false;
            btnEditar.Click += BntEditar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = SystemColors.AppWorkspace;
            btnCancelar.BackgroundImage = (Image)resources.GetObject("btnCancelar.BackgroundImage");
            btnCancelar.BackgroundImageLayout = ImageLayout.Center;
            btnCancelar.Location = new Point(168, 12);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(33, 35);
            btnCancelar.TabIndex = 4;
            toolTip1.SetToolTip(btnCancelar, "Cancelar");
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += BtnCancelar_Click;
            // 
            // btnExcluir
            // 
            btnExcluir.BackColor = SystemColors.AppWorkspace;
            btnExcluir.BackgroundImage = (Image)resources.GetObject("btnExcluir.BackgroundImage");
            btnExcluir.BackgroundImageLayout = ImageLayout.Center;
            btnExcluir.Location = new Point(129, 12);
            btnExcluir.Name = "btnExcluir";
            btnExcluir.Size = new Size(33, 35);
            btnExcluir.TabIndex = 3;
            toolTip1.SetToolTip(btnExcluir, "Excluir");
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += BtnExcluir_Click;
            // 
            // btnSalvar
            // 
            btnSalvar.BackColor = SystemColors.AppWorkspace;
            btnSalvar.BackgroundImage = (Image)resources.GetObject("btnSalvar.BackgroundImage");
            btnSalvar.BackgroundImageLayout = ImageLayout.Center;
            btnSalvar.Enabled = false;
            btnSalvar.Location = new Point(90, 12);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(33, 35);
            btnSalvar.TabIndex = 2;
            toolTip1.SetToolTip(btnSalvar, "Salvar");
            btnSalvar.UseVisualStyleBackColor = false;
            btnSalvar.Click += BntSalvar_Click;
            // 
            // btnNovo
            // 
            btnNovo.BackColor = SystemColors.AppWorkspace;
            btnNovo.BackgroundImage = (Image)resources.GetObject("btnNovo.BackgroundImage");
            btnNovo.BackgroundImageLayout = ImageLayout.Center;
            btnNovo.Location = new Point(12, 12);
            btnNovo.Name = "btnNovo";
            btnNovo.Size = new Size(33, 35);
            btnNovo.TabIndex = 0;
            toolTip1.SetToolTip(btnNovo, "Incluir");
            btnNovo.UseVisualStyleBackColor = false;
            btnNovo.Click += BtnNovo_Click;
            // 
            // groupBox1
            // 
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(12, 82);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 356);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            // 
            // paneltop
            // 
            paneltop.BackColor = SystemColors.ButtonHighlight;
            paneltop.Dock = DockStyle.Top;
            paneltop.Location = new Point(0, 61);
            paneltop.Name = "paneltop";
            paneltop.Size = new Size(800, 15);
            paneltop.TabIndex = 2;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(paneltop);
            Controls.Add(panelMenu);
            Controls.Add(groupBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "BaseForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "BaseForm";
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private Panel paneltop;
        protected GroupBox groupBox1;
        protected Button btnSalvar;
        protected Button btnNovo;
        protected Button btnCancelar;
        protected Button btnExcluir;
        protected Button btnEditar;
        protected Button btnPesquisar;
        private ToolTip toolTip1;
    }
}