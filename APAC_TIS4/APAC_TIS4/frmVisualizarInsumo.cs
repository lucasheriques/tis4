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
    public partial class frmVisualizarInsumo : Form
    {
        private Form _frmPrincipal;

        private InsumoDAO insumoDAO;

        private void preencheGrid() {
            insumoDAO = new InsumoDAO();
            DataSet dataSet = insumoDAO.visualizarGrid();
            dataGridView1.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 400;
            }
        }

        private void preencheCombo() {
            this.insumoDAO = new InsumoDAO();
            DataSet dsInsumo4 = insumoDAO.preencheCombo();
            comboBox1.ValueMember = "Insumo_ID";
            comboBox1.DisplayMember = "Nome";
            comboBox1.DataSource = dsInsumo4.Tables["characters"];
        }

        public frmVisualizarInsumo(Form frmPrincipal)
        {
            InitializeComponent();
            this._frmPrincipal = frmPrincipal;
            preencheGrid();
            preencheCombo();
        }

        private void bntSair_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this._frmPrincipal.Show();
        }

        private void bntCadastrar_Click(object sender, EventArgs e)
        {
            InsumoModels insumoModels = new InsumoModels();
            if (string.IsNullOrEmpty(comboBox1.SelectedValue.ToString()))
            {
                insumoModels.Insumo_ID = 0;
                insumoModels.Nome = "%";
            }
            else {
                insumoModels.Insumo_ID = int.Parse(comboBox1.SelectedValue.ToString());
                insumoModels.Nome = "";
            }
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                insumoModels.Descricao = "%";
            }
            else {
                insumoModels.Descricao = "%" + textBox7.Text + "%";
            }

            DataSet dataSet = new DataSet();
            dataSet = insumoDAO.visualizarGridComParametros(insumoModels);
            dataGridView1.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 400;
            }
            preencheCombo();
        }
    }
}
