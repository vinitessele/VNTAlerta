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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
                if (checkBoxNotificacaoWindows.Checked == true)
                    d.notificacaoWindows = "S";
                if (checkBoxNotificacaoEmail.Checked == true)
                    d.notificacaoEmail = "S";

                if (textId.Text == string.Empty)
                {
                    int ID = m.SetCfgNotificacao(d);
                    textId.Text = ID.ToString();
                }
                else
                {
                    d.Id = int.Parse(textId.Text);
                    m.AlterCfgNotificacao(d);
                }
                MessageBox.Show("Registro salvo com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { throw; }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                if (textId.Text != string.Empty)
                {
                    id = int.Parse(textId.Text);
                    Model m = new();

                    m.DeleteTipoRegistro(id);

                    MessageBox.Show("Registro apagado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { throw; }
        }

        private void FrmCfgNotificacao_Load(object sender, EventArgs e)
        {
            try
            {
                Model m = new();
                DaoCfgNotificacao d = m.GetCfgNotificao();
                if (d != null)
                {
                    textId.Text = d.Id.ToString();
                    textPara.Text = d.emailTo;
                    textAssunto.Text = d.emailSubject;
                    textMensagem.Text = d.emailBody;
                    textDias.Text = d.DiasNotificacao.ToString();
                    if (d.notificacaoWindows == "S")
                        checkBoxNotificacaoWindows.Checked = true;
                    if (d.notificacaoEmail == "S")
                        checkBoxNotificacaoEmail.Checked = true;
                }
            }
            catch { throw; }
        }
    }
}

