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
    public partial class frmVisualizarProdutos : Form
    {
        frmPrincipal _frmPrincipal;
        public frmVisualizarProdutos(frmPrincipal frmPrincipal)
        {
            this._frmPrincipal = frmPrincipal;
            InitializeComponent();
            popularGrid();
        }

        private void bntSair_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this._frmPrincipal.Show();
        }

        private void popularGrid()
        {
            ProdutoDAO produto = new ProdutoDAO();

            DataSet dataSet = produto.visualizarGrid();
            dgvProduto.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dgvProduto.Columns.Count; i++)
            {
                dgvProduto.Columns[i].Width = 400;
            }
        }

        private void bntPesquisar_Click(object sender, EventArgs e)
        {
            ProdutoModels produtoModels = new ProdutoModels();

            produtoModels.Nome = txtNome.Text;
            produtoModels.Tipo = txtTipo.Text;
            produtoModels.Tamanho = cmbTamanho.Text;
            produtoModels.Descricao = txtDescricao.Text;

            if ((!string.IsNullOrEmpty(produtoModels.Nome) || !string.IsNullOrEmpty(produtoModels.Tipo) || !string.IsNullOrEmpty(produtoModels.Tamanho)) && string.IsNullOrEmpty(produtoModels.Descricao))
            {
                produtoModels.Descricao = "%%%";
            }

            ProdutoDAO produtoDAO = new ProdutoDAO();
            DataSet sDs = produtoDAO.visualizarGridComParametros(produtoModels);

            dgvProduto.DataSource = sDs.Tables["characters"];

            for (int i = 0; i < dgvProduto.Columns.Count; i++)
            {
                dgvProduto.Columns[i].Width = 400;
            }
            //visualizarGridComParametros();
        }
    }
}
