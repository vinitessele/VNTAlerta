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
                this.Close();
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
            string descricao = get.GetTipoRegistroID(textID.Text);
            textDescricao.Text = descricao;
        }
    }
}
