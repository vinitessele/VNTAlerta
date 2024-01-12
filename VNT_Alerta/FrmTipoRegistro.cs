using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VNT_CentralDeNotificacao
{
    public partial class FrmTipoRegistro : BaseForm
    {
        public FrmTipoRegistro()
        {
            InitializeComponent();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            textDescricao.Focus();
            textID.Text = string.Empty;
        }

        private void BntEditar_Click(object sender, EventArgs e)
        {
            textDescricao.Focus();
        }

        private void BntSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Model m = new();
                DaoTipoRegistro d = new();

                d.Descricao = textDescricao.Text;

                if (textID.Text == string.Empty)
                {
                    m.SetTipoRegistro(d);
                }
                else
                {
                    d.Id = int.Parse(textID.Text);
                    m.AlterTipoRegistro(d);
                }
                MessageBox.Show("Registro salvo com sucesso");
            }
            catch { throw; }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsultaTipoRegistro fr = new();
            fr.ShowDialog();
            textID.Text = fr.Valor;
        }

        private void textID_TextChanged(object sender, EventArgs e)
        {
            Model get = new();
            string descricao = string.Empty;

            if (textID.Text != string.Empty)
                descricao = get.GetTipoRegistroID(textID.Text);

            textDescricao.Text = descricao;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                int id = 0;
                if (textID.Text != string.Empty)
                {
                    id = int.Parse(textID.Text);
                    Model m = new();

                    m.DeleteTipoRegistro(id);

                    MessageBox.Show("Registro Excluido com sucesso");
                }
            }
            catch { throw; }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            textDescricao.Text= string.Empty;
        }
    }
}
