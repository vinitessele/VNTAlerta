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
            menuStrip1 = new MenuStrip();
            cadastroToolStripMenuItem = new ToolStripMenuItem();
            notificaçãoToolStripMenuItem = new ToolStripMenuItem();
            empresasToolStripMenuItem = new ToolStripMenuItem();
            tipoRegistroToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            cidadeToolStripMenuItem = new ToolStripMenuItem();
            estadoToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            licençaDeUsoToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { cadastroToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // cadastroToolStripMenuItem
            // 
            cadastroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { notificaçãoToolStripMenuItem, empresasToolStripMenuItem, tipoRegistroToolStripMenuItem, toolStripMenuItem2, toolStripSeparator1, cidadeToolStripMenuItem, estadoToolStripMenuItem, toolStripSeparator2, licençaDeUsoToolStripMenuItem });
            cadastroToolStripMenuItem.Name = "cadastroToolStripMenuItem";
            cadastroToolStripMenuItem.Size = new Size(71, 20);
            cadastroToolStripMenuItem.Text = "Cadastros";
            // 
            // notificaçãoToolStripMenuItem
            // 
            notificaçãoToolStripMenuItem.Name = "notificaçãoToolStripMenuItem";
            notificaçãoToolStripMenuItem.Size = new Size(194, 22);
            notificaçãoToolStripMenuItem.Text = "Notificação";
            notificaçãoToolStripMenuItem.Click += notificaçãoToolStripMenuItem_Click;
            // 
            // empresasToolStripMenuItem
            // 
            empresasToolStripMenuItem.Name = "empresasToolStripMenuItem";
            empresasToolStripMenuItem.Size = new Size(194, 22);
            empresasToolStripMenuItem.Text = "Empresas";
            empresasToolStripMenuItem.Click += empresasToolStripMenuItem_Click;
            // 
            // tipoRegistroToolStripMenuItem
            // 
            tipoRegistroToolStripMenuItem.Name = "tipoRegistroToolStripMenuItem";
            tipoRegistroToolStripMenuItem.Size = new Size(194, 22);
            tipoRegistroToolStripMenuItem.Text = "Tipo Registro";
            tipoRegistroToolStripMenuItem.Click += tipoRegistroToolStripMenuItem_Click;
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(194, 22);
            toolStripMenuItem2.Text = "Configuração de envio";
            toolStripMenuItem2.Click += toolStripMenuItem2_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(191, 6);
            // 
            // cidadeToolStripMenuItem
            // 
            cidadeToolStripMenuItem.Name = "cidadeToolStripMenuItem";
            cidadeToolStripMenuItem.Size = new Size(194, 22);
            cidadeToolStripMenuItem.Text = "Cidade";
            // 
            // estadoToolStripMenuItem
            // 
            estadoToolStripMenuItem.Name = "estadoToolStripMenuItem";
            estadoToolStripMenuItem.Size = new Size(194, 22);
            estadoToolStripMenuItem.Text = "Estado";
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(191, 6);
            // 
            // licençaDeUsoToolStripMenuItem
            // 
            licençaDeUsoToolStripMenuItem.Name = "licençaDeUsoToolStripMenuItem";
            licençaDeUsoToolStripMenuItem.Size = new Size(194, 22);
            licençaDeUsoToolStripMenuItem.Text = "Licença de Uso";
            // 
            // FrmMenu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "FrmMenu";
            Text = "FormMenu";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
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
        private ToolStripMenuItem cidadeToolStripMenuItem;
        private ToolStripMenuItem estadoToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem licençaDeUsoToolStripMenuItem;
    }
}