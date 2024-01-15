using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNT_CentralDeNotificacao
{
    public partial class FrmMenu : Form
    {
        public FrmMenu()
        {
            InitializeComponent();

            FormAtivacao formAtivacao = new();
            if (!formAtivacao.VerificaLicenca())
            {
                FormAtivacao fr = new();
                fr.ShowDialog();
            }
            timer1.Start();
        }

        private void notificaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadNotificacao fr = new();
            fr.Show();
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadEmpresa fr = new();
            fr.Show();
        }

        private void tipoRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoRegistro fr = new();
            fr.Show();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmCfgNotificacao fr = new();
            fr.Show();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            Model get = new();
            List<DtoNotificacao> n = new();
            n = get.GetNotificacaoAll();
            CarregarGrid(n);
        }
        private void CarregarGrid(List<DtoNotificacao> d)
        {
            dataGridViewNotificações.DataSource = null;
            dataGridViewNotificações.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewNotificações.MultiSelect = false;
            dataGridViewNotificações.AutoGenerateColumns = false;
            dataGridViewNotificações.DataSource = d;
            dataGridViewNotificações.Refresh();
        }

        private void FrmMenu_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                this.Hide();
            }
        }

        private void VNTCentralNotificacao_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Model m = new();
            m.EnviaNotificacao();
        }

        private void MenuNotificacoes_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name.ToString() == "toolStripMenuExit")
            {
                this.Close();
            }
            else
            if (e.ClickedItem.Name.ToString() == "toolStripMenuRestaurar")
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
                if (e.ClickedItem.Name.ToString() == "toolStripMenuEnviarNotificacao")
            {
                Model m = new();
                m.EnviaNotificacao();
            }
        }
    }
}
