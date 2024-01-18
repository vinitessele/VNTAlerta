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
        int IDEmpresa;
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
                AdicionarEmpresa();
                MessageBox.Show("Registro salvo com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { throw; }
        }

        private void AdicionarEmpresa()
        {
            Model m = new();
            DaoEmpresa d = new();
            d.RazaoSocial = textRazao.Text;
            d.NomeFantasia = textFantasia.Text;
            d.Cnpj = textCNPJ.Text;
            d.Endereco = textEndereco.Text;
            d.Atividade = textAtividade.Text;
            d.Bairro = textBairro.Text;
            d.Cep = textCep.Text;
            d.IdCidade = Convert.ToInt32(comboBoxCidade.SelectedValue);
            d.Telefone = textTelefone.Text;
            d.Celular = textCelular.Text;
            if (textAbertura.Text.Replace("/", "").Trim() != string.Empty)
                d.DataAbertura = DateTime.Parse(textAbertura.Text);
            d.Observacao = textObs.Text;

            if (textId.Text == string.Empty)
            {
                IDEmpresa =  m.SetEmpresa(d);
                textId.Text = IDEmpresa.ToString();
            }
            else
            {
                d.Id = int.Parse(textId.Text);
                m.AlterEmpresa(d);
            }
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
            comboBoxCidade.Text = "[Selecione]";
        }

        private void textId_TextChanged(object sender, EventArgs e)
        {
            Model get = new();
            DaoEmpresa empresa = new();
            if (textId.Text != string.Empty)
            {
                empresa = get.GetEmpresaId(int.Parse(textId.Text));
                AtualizaGridSocios();
            }

            textRazao.Text = empresa.RazaoSocial;
            textFantasia.Text = empresa.NomeFantasia;
            textCNPJ.Text = empresa.Cnpj;
            textEndereco.Text = empresa.Endereco;
            textAtividade.Text = empresa.Atividade;
            textBairro.Text = empresa.Bairro;
            textCep.Text = empresa.Cep;
            comboBoxCidade.SelectedValue = empresa.IdCidade;
            textTelefone.Text = empresa.Telefone;
            textCelular.Text = empresa.Celular;
            textAbertura.Text = empresa.DataAbertura.ToString();
            textObs.Text = empresa.Observacao;
        }

        private void AtualizaGridSocios()
        {
            Model get = new();
            List<DaoSocios> socios = get.GetSociosEmpresa(int.Parse(textId.Text));
            if (socios.Count > 0)
            {
                dataGridViewSocios.DataSource = null;
                dataGridViewSocios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dataGridViewSocios.MultiSelect = false;
                dataGridViewSocios.AutoGenerateColumns = false;
                dataGridViewSocios.DataSource = socios;
                dataGridViewSocios.Refresh();
            }
        }

        private void btnAddSocios_Click(object sender, EventArgs e)
        {
            AdicionarEmpresa();
            
            Model m = new();
            DaoSocios s = new();

            if (textId.Text != string.Empty)
            {
                s.IdEmpresa = int.Parse(textId.Text);
            }
            else
            {
                s.IdEmpresa = int.Parse(textId.Text);
            }
            s.Nome = textNomeSocio.Text;
            if (textPercential.Text != string.Empty)
                s.PercentualSocios = decimal.Parse(textPercential.Text);
            m.SetSocios(s);

            AtualizaGridSocios();
        }

        private void dataGridViewSocios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                try
                {
                    int id = int.Parse(dataGridViewSocios.Rows[e.RowIndex].Cells[3].Value.ToString());
                    Model m = new();

                    m.DeleteSocios(id);
                    AtualizaGridSocios();

                    MessageBox.Show("Registro apagado com sucesso", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch { throw; }
            }
        }
    }
}
