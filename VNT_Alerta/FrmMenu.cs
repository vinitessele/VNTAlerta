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
        }

        private void notificaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadNotificacao fr = new FrmCadNotificacao();
            fr.Show();
            this.Hide();
        }

        private void empresasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCadEmpresa fr = new FrmCadEmpresa();
            fr.Show();
            this.Hide();
        }

        private void tipoRegistroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTipoRegistro fr = new FrmTipoRegistro();
            fr.Show();
            this.Hide();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FrmCfgNotificacao fr = new FrmCfgNotificacao();
            fr.Show();
            this.Hide();
        }
    }
}
