using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APAC_TIS4
{
    public partial class frmVisualizarCliente : Form
    {
        private frmPrincipal _frmPrincipal;
        public frmVisualizarCliente(frmPrincipal frmPrincipal)
        {
            InitializeComponent();
            this._frmPrincipal = frmPrincipal;

            preencheGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this._frmPrincipal.Show();
        }

        private void preencheGrid()
        {
            ClienteDAO cliente = new ClienteDAO();

            DataSet dataSet = cliente.visualizarGrid();
            dgvCliente.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dgvCliente.Columns.Count; i++)
            {
                dgvCliente.Columns[i].Width = 400;
            }
        }

        private void preencheGridComParametros(CienteModels ciente)
        {
            ClienteDAO cliente = new ClienteDAO();

            DataSet dataSet = cliente.visualizarGridComParametros(ciente);
            dgvCliente.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dgvCliente.Columns.Count; i++)
            {
                dgvCliente.Columns[i].Width = 400;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CienteModels cliente = new CienteModels();

            cliente.nome = textBox1.Text;
            cliente.localidade = textBox2.Text;
            cliente.Tipo = comboBox1.Text;

            if ((string.IsNullOrEmpty(cliente.nome) && (string.IsNullOrEmpty(cliente.localidade)) && (string.IsNullOrEmpty(cliente.Tipo))))
            {
                cliente.nome = "%";
                cliente.localidade = "%";
                cliente.Tipo = "%";
            }

            if (string.IsNullOrEmpty(cliente.nome))
            {
                cliente.nome = "%";
            }

            if (string.IsNullOrEmpty(cliente.localidade))
            {
                cliente.localidade = "%";
            }

            if (string.IsNullOrEmpty(cliente.Tipo))
            {
                cliente.Tipo = "%";
            }

            preencheGridComParametros(cliente);
        }
    }
}
