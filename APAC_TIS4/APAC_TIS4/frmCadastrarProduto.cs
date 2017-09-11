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
        private Form _frmPrincipal;
        public frmCadastrarProduto(Form frmPrincipal)
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
            produto.Tamanho = cmbTamanho.Text;
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

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarCliente cadastrarCliente = new frmCadastrarCliente(this);
            this.Hide();
            cadastrarCliente.Show();
        }

        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroPedido vfrmCadastroPedido = new frmCadastroPedido(this);
            vfrmCadastroPedido.Show();
            this.Hide();
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAtualizarCliente atualizarCliente = new frmAtualizarCliente(this);
            atualizarCliente.Show();
            this.Hide();
        }

        private void clienteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVisualizarCliente visualizarCliente = new frmVisualizarCliente(this);
            visualizarCliente.Show();
            this.Hide();
        }

        private void pedidoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVisualizarPedido visualizarPedido = new frmVisualizarPedido(this);
            visualizarPedido.Show();
            this.Hide();
        }

        private void produtoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVisualizarProdutos visualizarProdutos = new frmVisualizarProdutos(this);
            visualizarProdutos.Show();
            this.Hide();
        }

        private void insumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarInsumo _frmCadastrarInsumo = new frmCadastrarInsumo(this);
            _frmCadastrarInsumo.Show();
            this.Close();
        }

        private void receitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarReceita _frmCadastrarReceita = new frmCadastrarReceita(this);
            _frmCadastrarReceita.Show();
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
            frmAtualizarCliente _frmAtualizarCliente = new frmAtualizarCliente(this);
            _frmAtualizarCliente.Show();
            this.Hide();
        }

        private void produtoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAtualizarPedido _frmAtualizarPedido = new frmAtualizarPedido(this);
            _frmAtualizarPedido.Show();
            this.Hide();
        }

        private void insumoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVisualizarInsumo _frmVisualizarInsumo = new frmVisualizarInsumo(this);
            _frmVisualizarInsumo.Show();
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
