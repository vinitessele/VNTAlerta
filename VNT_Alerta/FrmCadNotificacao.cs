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

        private void bntSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Model m = new();
                DaoNotificacao d = new();
                d.Descricao = textDescricao.Text;
                d.IdEmpresa = Convert.ToInt32(comboBoxEmpresa.SelectedValue);
                d.IdTipoRegistro = Convert.ToInt32(comboBoxTipoRegistro.SelectedValue);
                if (textDataIniProcesso.Text != string.Empty)
                    d.DataInicalProcesso = DateTime.Parse(textDataIniProcesso.Text);
                if (textDataFimProcesso.Text != string.Empty)
                    d.DataFinalProcesso = DateTime.Parse(textDataFimProcesso.Text);
                if (textDataNotificacao.Text != string.Empty)
                    d.DataNotificacao = DateTime.Parse(textDataNotificacao.Text);
                d.Observacao = textObs.Text;

                if (checkBoxStatus.Checked == true)
                    d.notificacaoFinalizada = "S";

                if (textId.Text == string.Empty)
                {
                    m.SetNotificacao(d);
                }
                else
                {
                    d.Id = int.Parse(textId.Text);
                    m.AlterNotificacao(d);
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

                    m.DeleteNotificacao(id);

                    MessageBox.Show("Registro apagado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { throw; }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsultaNotificacoes fr = new();
            fr.ShowDialog();
            textId.Text = fr.Valor;
        }

        private void FrmCadNotificacao_Load(object sender, EventArgs e)
        {
            Model get = new();
            List<DaoTipoRegistro> List = get.GetListTipoRegistroAll();
            comboBoxTipoRegistro.DataSource = null;
            comboBoxTipoRegistro.ValueMember = "id";
            comboBoxTipoRegistro.DisplayMember = "Descricao";
            comboBoxTipoRegistro.DataSource = List;
            comboBoxTipoRegistro.Text = "[Selecione]";

            List<DaoEmpresa> List1 = get.GetListEmpresaAll();
            comboBoxEmpresa.DataSource = null;
            comboBoxEmpresa.ValueMember = "id";
            comboBoxEmpresa.DisplayMember = "RazaoSocial";
            comboBoxEmpresa.DataSource = List1;
            comboBoxEmpresa.Text = "[Selecione]";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void textId_TextChanged(object sender, EventArgs e)
        {
            Model get = new();
            DaoNotificacao no = new();
            if (textId.Text != string.Empty)
                no = get.GetNotificacaoId(int.Parse(textId.Text));


            textDescricao.Text = no.Descricao;
            comboBoxEmpresa.SelectedValue = no.IdEmpresa;
            comboBoxTipoRegistro.SelectedValue = no.IdTipoRegistro;
            textDataIniProcesso.Text = no.DataInicalProcesso.ToString();
            textDataFimProcesso.Text = no.DataFinalProcesso.ToString();
            textDataNotificacao.Text = no.DataNotificacao.ToString();
            textObs.Text = no.Observacao;

            if (no.notificacaoFinalizada == "S")
                checkBoxStatus.Checked = true;

        }
    }
}
