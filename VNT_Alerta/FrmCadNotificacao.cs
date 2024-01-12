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
    public partial class FrmCadNotificacao : BaseForm
    {
        public FrmCadNotificacao()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            textDescricao.Focus();
            textId.Text = string.Empty;
        }

        private void bntEditar_Click(object sender, EventArgs e)
        {
            textDescricao.Focus();
        }
    }
}
