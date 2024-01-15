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
            FormAtivacao formAtivacao = new ();
            if (!formAtivacao.VerificaLicenca())
            {
                FormAtivacao fr = new();
                fr.ShowDialog();               
            }
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
            List<DaoNotificacao> n = new();
            n = get.GetNotificacaoAll();
            CarregarGrid(n);
        }
        private void CarregarGrid(List<DaoNotificacao> d)
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
            new FrmMenu().Show();
        }
    }
}
