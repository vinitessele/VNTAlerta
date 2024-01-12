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
    public partial class ConsultaEmpresa : BaseConsultaForm
    {
        public ConsultaEmpresa()
        {
            InitializeComponent();
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            Model get = new();
            List<DaoEmpresa> d = get.GetListEmpresaNome(textBoxPesquisa.Text);
            CarregarGrid(d);
        }
        private void CarregarGrid(List<DaoEmpresa> d)
        {
            dataGridView1.DataSource = null;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.DataSource = d;
            dataGridView1.Refresh();
        }
    }
}
