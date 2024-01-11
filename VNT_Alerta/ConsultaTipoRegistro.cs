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
    public partial class ConsultaTipoRegistro : BaseConsultaForm
    {
        public ConsultaTipoRegistro()
        {
            InitializeComponent();
        }

        private void textBoxPesquisa_TextChanged(object sender, EventArgs e)
        {
            Model get = new();
            List<DaoTipoRegistro> d = get.GetTipoRegistro(textBoxPesquisa.Text);
            CarregarGrid(d);
        }

        private void CarregarGrid(List<DaoTipoRegistro> d)
        {
            dataGridView1.DataSource = null;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.MultiSelect = false;
            dataGridView1.DataSource = d;
            dataGridView1.Refresh();
        }
    }
}
