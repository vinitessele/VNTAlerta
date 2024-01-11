using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VNT_CentralDeNotificacao
{
    public partial class BaseConsultaForm : Form
    {
        public string Valor
        {
            get { return IdPesquisa; }
            set { textBoxPesquisa.Text = value; }
        }
        string IdPesquisa = string.Empty;
        public BaseConsultaForm()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            IdPesquisa = dataGridView1.SelectedRows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            this.Close();
        }
    }
}
