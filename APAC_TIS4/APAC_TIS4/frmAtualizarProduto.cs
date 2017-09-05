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
    public partial class frmAtualizarProduto : Form
    {
        private Form _frmPrincipal;

        public frmAtualizarProduto(Form frmPrincipal)
        {
            InitializeComponent();
            this._frmPrincipal = frmPrincipal;
            popularGrid();
        }

        private void popularGrid()
        {
            ProdutoDAO produto = new ProdutoDAO();

            DataSet dataSet = produto.visualizarGridEID();
            dgvProduto.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dgvProduto.Columns.Count; i++)
            {
                dgvProduto.Columns[i].Width = 400;
            }
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

        private void bntPesquisar_Click(object sender, EventArgs e)
        {
            ProdutoModels produtoModels = new ProdutoModels();

            produtoModels.Nome = txtNome.Text;
            produtoModels.Tipo = txtTipo.Text;
            produtoModels.Tamanho = cmbTamanho.Text;
            produtoModels.Descricao = txtDescricao.Text;

            if (string.IsNullOrEmpty(produtoModels.Descricao))
            {
                produtoModels.Descricao = "%%%";
            }


            ProdutoDAO produtoDAO = new ProdutoDAO();
            DataSet sDs = produtoDAO.visualizarGridComParametrosEID(produtoModels);

            dgvProduto.DataSource = sDs.Tables["characters"];

            for (int i = 0; i < dgvProduto.Columns.Count; i++)
            {
                dgvProduto.Columns[i].Width = 400;
            }
            dgvProduto.Columns[0].Visible = false;
            //visualizarGridComParametros();
        }

        private void bntAtualizar_Click(object sender, EventArgs e)
        {
            List<ProdutoModels> listProduto = new List<ProdutoModels>();

            for (int i = 0; i < dgvProduto.Rows.Count - 1; i++)
            {
                System.Threading.Thread.Sleep(50);
                ProdutoModels produto = new ProdutoModels();
                produto.Produto_ID = int.Parse(dgvProduto.Rows[i].Cells[0].Value.ToString());
                produto.Nome = dgvProduto.Rows[i].Cells[1].Value.ToString();
                produto.Tipo = dgvProduto.Rows[i].Cells[2].Value.ToString();
                produto.Tamanho = dgvProduto.Rows[i].Cells[3].Value.ToString();
                produto.Peso = float.Parse(dgvProduto.Rows[i].Cells[4].Value.ToString());
                produto.UDM = dgvProduto.Rows[i].Cells[5].Value.ToString();
                produto.CustoPorUnidade = float.Parse(dgvProduto.Rows[i].Cells[6].Value.ToString());
                produto.PrecoDeVendaUnidade = float.Parse(dgvProduto.Rows[i].Cells[7].Value.ToString());
                produto.Descricao = dgvProduto.Rows[i].Cells[8].Value.ToString();

                listProduto.Add(produto);
            }

            ProdutoDAO produtoDAO = new ProdutoDAO();

            bool verificaAtualizacao = produtoDAO.atualizarProdutos(listProduto);
            if (verificaAtualizacao)
            {
                MessageBox.Show("Dados atualizados com sucesso.");
            }
            else
            {
                MessageBox.Show("Erro na atualização dos dados.");
            }

            popularGrid();

        }
    }
}
