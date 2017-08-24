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
    public partial class frmCadastrarProduto : Form
    {
        private frmPrincipal _frmPrincipal;
        public frmCadastrarProduto(frmPrincipal frmPrincipal)
        {
            _frmPrincipal = frmPrincipal;
            InitializeComponent();
            popularGrid();
        }

        private void bntCadastrar_Click(object sender, EventArgs e)
        {
            ProdutoModels produto = new ProdutoModels();
            produto.Nome = txtNome.Text;
            produto.Peso = float.Parse(txtPeso.Text);
            produto.CustoPorUnidade = float.Parse(txtCustoPorUnidade.Text);
            produto.PrecoDeVendaUnidade = float.Parse(txtPrecoVendaPorUnidade.Text);
            produto.Tamanho = txtTamanho.Text;
            produto.Tipo = txtTipo.Text;
            produto.UDM = txtUDM.Text;
            produto.Descricao = txtDescricao.Text;

            ProdutoDAO produtoDAO = new ProdutoDAO();

            String retorno = produtoDAO.cadastrar(produto);

            if (String.IsNullOrEmpty(retorno))
            {
                MessageBox.Show("Erro ao criar cliente!!!");
            }
            else if (retorno.Contains("Erro de acesso ao MySQL : "))
            {
                MessageBox.Show(retorno);
            }
            else
            {
                MessageBox.Show("Cliente inserido com sucesso!!!");
                setValoresEmBanco();
            }
            popularGrid();
        }

        private void setValoresEmBanco()
        {
            txtNome.Text = "";
            txtCustoPorUnidade.Text = "";
            txtDescricao.Text = "";
            txtPeso.Text = "";
            txtPrecoVendaPorUnidade.Text = "";
            txtTamanho.Text = "";
            txtTipo.Text = "";
            txtUDM.Text = "";
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
            this.Hide();
            this._frmPrincipal.Show();
        }

    }
}
