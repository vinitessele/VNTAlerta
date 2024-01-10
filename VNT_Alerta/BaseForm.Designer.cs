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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseForm));
            panelMenu = new Panel();
            bntEditar = new Button();
            btnCancelar = new Button();
            btnExcluir = new Button();
            bntSalvar = new Button();
            btnNovo = new Button();
            groupBox1 = new GroupBox();
            paneltop = new Panel();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = SystemColors.ActiveBorder;
            panelMenu.Controls.Add(bntEditar);
            panelMenu.Controls.Add(btnCancelar);
            panelMenu.Controls.Add(btnExcluir);
            panelMenu.Controls.Add(bntSalvar);
            panelMenu.Controls.Add(btnNovo);
            panelMenu.Dock = DockStyle.Top;
            panelMenu.ForeColor = SystemColors.ControlDarkDark;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(800, 61);
            panelMenu.TabIndex = 0;
            // 
            // bntEditar
            // 
            bntEditar.BackColor = SystemColors.AppWorkspace;
            bntEditar.BackgroundImage = (Image)resources.GetObject("bntEditar.BackgroundImage");
            bntEditar.BackgroundImageLayout = ImageLayout.Center;
            bntEditar.Location = new Point(51, 12);
            bntEditar.Name = "bntEditar";
            bntEditar.Size = new Size(33, 35);
            bntEditar.TabIndex = 1;
            bntEditar.UseVisualStyleBackColor = false;
            bntEditar.Click += bntEditar_Click;
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
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
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
            btnExcluir.UseVisualStyleBackColor = false;
            btnExcluir.Click += btnExcluir_Click;
            // 
            // bntSalvar
            // 
            bntSalvar.BackColor = SystemColors.AppWorkspace;
            bntSalvar.BackgroundImage = (Image)resources.GetObject("bntSalvar.BackgroundImage");
            bntSalvar.BackgroundImageLayout = ImageLayout.Center;
            bntSalvar.Location = new Point(90, 12);
            bntSalvar.Name = "bntSalvar";
            bntSalvar.Size = new Size(33, 35);
            bntSalvar.TabIndex = 2;
            bntSalvar.UseVisualStyleBackColor = false;
            bntSalvar.Click += bntSalvar_Click;
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
            btnNovo.UseVisualStyleBackColor = false;
            btnNovo.Click += btnNovo_Click;
            // 
            // groupBox1
            // 
            groupBox1.Enabled = false;
            groupBox1.Location = new Point(12, 82);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(776, 356);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "BaseForm";
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
            Controls.Add(groupBox1);
            Controls.Add(panelMenu);
            Name = "BaseForm";
            Text = "BaseForm";
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMenu;
        private GroupBox groupBox1;
        private Button bntSalvar;
        private Button btnNovo;
        private Button btnCancelar;
        private Button btnExcluir;
        private Panel paneltop;
        private Button bntEditar;
    }
}