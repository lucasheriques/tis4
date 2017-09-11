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
    public partial class frmVisualizarPedido : Form
    {
        private Form _frmPrincipal;
        public frmVisualizarPedido(Form pFrmPrincipal)
        {
            this._frmPrincipal = pFrmPrincipal;
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
            PedidoDAO pedido = new PedidoDAO();

            DataSet ds = pedido.visualizarGrid();
            dataGridView1.DataSource = ds.Tables["characters"];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 400;
            }
        }

        private void bntPesquisar_Click(object sender, EventArgs e)
        {
            CienteModels cliente = new CienteModels();
            if (string.IsNullOrEmpty(txtNomeCliente.Text))
            {
                cliente.nome = "%";
            }
            else {
                cliente.nome = txtNomeCliente.Text;
            }
            

            ProdutoModels produto = new ProdutoModels();

            if (string.IsNullOrEmpty(txtNomeProduto.Text))
            {
                produto.Nome = "%";
            }
            else {
                produto.Nome = txtNomeProduto.Text;
            }


            PedidoModels pedido = new PedidoModels(produto, cliente);
            if (dtpDataPedido.Enabled)
            {
                pedido.Data_Pedido = DateTime.Parse(dtpDataPedido.Value.ToShortDateString());
            }
            else {
                pedido.Data_Pedido = DateTime.MinValue;
            }

            if (dtpDataEntrega.Enabled)
            {
                pedido.Data_Entrega = DateTime.Parse(dtpDataEntrega.Value.ToShortDateString());
            }
            else
            {
                pedido.Data_Entrega = DateTime.MinValue;
            }

            PedidoDAO pedidoDAO = new PedidoDAO();
            DataSet sDs = pedidoDAO.visualizarGridComParametros(pedido);
            dataGridView1.DataSource = sDs.Tables["characters"];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 400;
            }

            //            visualizarGridComParametros();
        }

        private void bntDesabilitarEntrega_Click(object sender, EventArgs e)
        {
            dtpDataEntrega.Enabled = false;
        }

        private void bntDesabilitarPedido_Click(object sender, EventArgs e)
        {
            dtpDataPedido.Enabled = false;
        }

        private void bntHabilitarEntregar_Click(object sender, EventArgs e)
        {
            dtpDataEntrega.Enabled = true;
        }

        private void bntHabilitarPedido_Click(object sender, EventArgs e)
        {
            dtpDataPedido.Enabled = true;
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

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarProduto _frmCadastrarProduto = new frmCadastrarProduto(this);
            _frmCadastrarProduto.Show();
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
