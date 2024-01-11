using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace VNT_CentralDeNotificacao
{
    public partial class FrmCfgNotificacao : BaseForm
    {
        public FrmCfgNotificacao()
        {
            InitializeComponent();
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            textPara.Focus();
        }

        private void bntEditar_Click(object sender, EventArgs e)
        {
            textPara.Focus();
        }

        private void bntSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Model m = new();
                DaoCfgNotificacao d = new();
                d.emailFrom = "vntnotificacao@gmail.com";
                d.emailTo = textPara.Text;
                d.emailSubject = textAssunto.Text;
                d.emailBody = textMensagem.Text;
                if (textDias.Text != string.Empty)
                    d.DiasNotificacao = int.Parse(textDias.Text);
                if (checkBoxNotificacaoWindows.Checked)
                    d.notificacaoWindows = "S";
                if (checkBoxNotificacaoEmail.Checked)
                    d.notificacaoEmail = "S";

                if (textId.Text == string.Empty)
                {
                    m.SetCfgNotificacao(d);
                }
                else
                {
                    d.Id = int.Parse(textId.Text);
                    m.AlterCfgNotificacao(d);
                }
                MessageBox.Show("Registro salvo com sucesso");
            }
            catch { throw; }
        }
    }
}

