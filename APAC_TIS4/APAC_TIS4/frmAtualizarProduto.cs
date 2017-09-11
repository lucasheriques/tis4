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

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarCliente _frmCadastrarCliente = new frmCadastrarCliente(this);
            _frmCadastrarCliente.Show();
            this.Hide();
        }

        private void insumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarInsumo _frmCadastrarInsumo = new frmCadastrarInsumo(this);
            _frmCadastrarInsumo.Show();
            this.Close();
        }

        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroPedido _frmCadastroPedido = new frmCadastroPedido(this);
            _frmCadastroPedido.Show();
            this.Hide();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarProduto _frmCadastrarProduto = new frmCadastrarProduto(this);
            _frmCadastrarProduto.Show();
            this.Hide();
        }

        private void receitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarReceita _frmCadastrarReceita = new frmCadastrarReceita(this);
            _frmCadastrarReceita.Show();
            this.Hide();
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAtualizarCliente _frmAtualizarCliente = new frmAtualizarCliente(this);
            _frmAtualizarCliente.Show();
            this.Hide();
        }

        private void insumoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAtualizarInsumo _frmAtualizarInsumo = new frmAtualizarInsumo(this);
            _frmAtualizarInsumo.Show();
            this.Hide();
        }

        private void pedidoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAtualizarPedido _frmAtualizarPedido = new frmAtualizarPedido(this);
            _frmAtualizarPedido.Show();
            this.Hide();
        }

        private void produtoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAtualizarProduto _frmAtualizarProduto = new frmAtualizarProduto(this);
            _frmAtualizarProduto.Show();
            this.Hide();
        }

        private void clienteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVisualizarCliente _frmVisualizarCliente = new frmVisualizarCliente(this);
            _frmVisualizarCliente.Show();
            this.Hide();
        }

        private void insumoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVisualizarInsumo _frmVisualizarInsumo = new frmVisualizarInsumo(this);
            _frmVisualizarInsumo.Show();
            this.Hide();
        }

        private void pedidoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVisualizarPedido _frmVisualizarPedido = new frmVisualizarPedido(this);
            _frmVisualizarPedido.Show();
            this.Hide();
        }

        private void produtoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVisualizarProdutos _frmVisualizarProdutos = new frmVisualizarProdutos(this);
            _frmVisualizarProdutos.Show();
            this.Hide();
        }

        private void receitaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVisualizarReceita _frmVisualizarReceita = new frmVisualizarReceita(this);
            _frmVisualizarReceita.Show();
            this.Hide();
        }

        private void bancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoDoBancoDeDados configuracaoDoBancoDeDados = new ConfiguracaoDoBancoDeDados();
            configuracaoDoBancoDeDados.setFrmPrincipal(this);
            this.Hide();
            configuracaoDoBancoDeDados.Show();
        }
    }
}
