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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VNT_CentralDeNotificacao
{
    public partial class FrmCadEmpresa : BaseForm
    {
        public FrmCadEmpresa()
        {
            InitializeComponent();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            textRazao.Focus();
            textId.Text = string.Empty;
        }

        private void bntEditar_Click(object sender, EventArgs e)
        {
            textRazao.Focus();
        }

        private void bntSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Model m = new();
                DaoEmpresa d = new();
                d.RazaoSocial = textRazao.Text;
                d.NomeFantasia = textFantasia.Text;
                d.Cnpj = textCNPJ.Text;
                d.Endereco = textEndereco.Text;
                d.Atividade = textAtividade.Text;
                d.bairro = textBairro.Text;
                d.cep = textCep.Text;
                d.Socios = textSocios.Text;
                d.idCidade = Convert.ToInt32(comboBoxCidade.SelectedValue);
                d.PercentualSocios = textPercentSocios.Text;
                d.Telefone = textTelefone.Text;
                d.Celular = textCelular.Text;
                if (textAbertura.Text != string.Empty)
                    d.DataAbertura =  DateTime.Parse(textAbertura.Text);
                d.Observacao = textObs.Text;

                if (textId.Text == string.Empty)
                {
                    m.setEmpresa(d);
                }
                else
                {
                    d.Id = int.Parse(textId.Text);
                    m.AlterEmpresa(d);
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

                    m.DeleteEmpresa(id);

                    MessageBox.Show("Registro apagado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch { throw; }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            ConsultaEmpresa fr = new();
            fr.ShowDialog();
            textId.Text = fr.Valor;
        }

        private void FrmCadEmpresa_Load(object sender, EventArgs e)
        {
            Model get = new();
            List<DaoCidade> ListCidades = get.GetAllCidades();
            comboBoxCidade.DataSource = null;
            comboBoxCidade.ValueMember = "id";
            comboBoxCidade.DisplayMember = "nome";
            comboBoxCidade.DataSource = ListCidades;
        }

        private void textId_TextChanged(object sender, EventArgs e)
        {
            Model get = new();
            DaoEmpresa empresa = new();
            if (textId.Text != string.Empty)
                empresa = get.GetEmpresaId(int.Parse(textId.Text));

            textRazao.Text = empresa.RazaoSocial;
            textFantasia.Text = empresa.NomeFantasia;
            textCNPJ.Text = empresa.Cnpj;
            textEndereco.Text = empresa.Endereco;
            textAtividade.Text = empresa.Atividade;
            textBairro.Text = empresa.bairro;
            textCep.Text = empresa.cep;
            textSocios.Text = empresa.Socios;
            comboBoxCidade.SelectedValue = empresa.idCidade;
            textPercentSocios.Text = empresa.PercentualSocios;
            textTelefone.Text = empresa.Telefone;
            textCelular.Text = empresa.Celular;
            textAbertura.Text = empresa.DataAbertura.ToString();
            textObs.Text = empresa.Observacao;
        }
    }
}
