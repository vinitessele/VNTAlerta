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
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            HabilitaGroupBox();
        }

        private void BntEditar_Click(object sender, EventArgs e)
        {
            HabilitaGroupBox();
        }

        private void DesabilitaGroupBox()
        {
            groupBox1.Enabled = false;
        }
        private void HabilitaGroupBox()
        {
            groupBox1.Enabled = true;
        }

        private void BntSalvar_Click(object sender, EventArgs e)
        {
            DesabilitaGroupBox();
        }

        private void BtnExcluir_Click(object sender, EventArgs e)
        {
            DesabilitaGroupBox();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DesabilitaGroupBox();
        }
    }
}
