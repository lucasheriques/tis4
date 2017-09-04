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
    public partial class frmVisualizarReceita : Form
    {
        Form _frmPrincipal;
        public frmVisualizarReceita(Form frmPrincipal)
        {
            InitializeComponent();
            this._frmPrincipal = frmPrincipal;
            this.preencheGrid();
            this.preencheCombo();
        }

        private void preencheGrid() {
            ReceitaDAO receitaDAO = new ReceitaDAO();
            DataSet dataSet = receitaDAO.visualizarGrid();

            dataGridView1.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 400;
            }
        }

        private void preencheCombo() {
            ProdutoDAO produtoDAO = new ProdutoDAO();

            DataSet dsProduto = produtoDAO.preencheCombo();
            comboBox1.ValueMember = "Produto_ID";
            comboBox1.DisplayMember = "nome";
            comboBox1.DataSource = dsProduto.Tables["characters"];
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
            this._frmPrincipal.Show();
            this.Close();
        }

        private void bntCadastrar_Click(object sender, EventArgs e)
        {
            ProdutoModels produtoModels = new ProdutoModels();

            if (string.IsNullOrEmpty(comboBox1.SelectedValue.ToString()))
            {
                produtoModels.Produto_ID = 0;
                produtoModels.Nome = "%";
            }
            else {
                produtoModels.Produto_ID = int.Parse(comboBox1.SelectedValue.ToString());
                produtoModels.Nome = "";
            }

            ReceitaDAO receitaDAO = new ReceitaDAO();
            DataSet sDs = receitaDAO.visualizarGridComParametros(produtoModels);

            dataGridView1.DataSource = sDs.Tables["characters"];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 400;
            }
            //visualizarGridComParametros();

        }
    }
}
