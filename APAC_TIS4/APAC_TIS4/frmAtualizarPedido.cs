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
    public partial class frmAtualizarPedido : Form
    {
        private Form _frmPrincipal;

        public frmAtualizarPedido(Form pFrmPrincipal)
        {
            this._frmPrincipal = pFrmPrincipal;
            InitializeComponent();
            popularGrid();
        }

        private void popularGrid()
        {
            PedidoDAO pedido = new PedidoDAO();

            DataSet ds = pedido.visualizarGridComID();
            dataGridView1.DataSource = ds.Tables["characters"];

            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 400;
            }

            dataGridView1.Columns[0].Visible = false;

            colunasReadOnly();
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

        private void colunasReadOnly() {
            for (int i = 0; i < dataGridView1.RowCount; i++) {
                dataGridView1.Rows[i].Cells[0].ReadOnly = true;
                dataGridView1.Rows[i].Cells[1].ReadOnly = true;
                dataGridView1.Rows[i].Cells[2].ReadOnly = true;
                dataGridView1.Rows[i].Cells[3].ReadOnly = true;
                dataGridView1.Rows[i].Cells[7].ReadOnly = true;
                dataGridView1.Rows[i].Cells[8].ReadOnly = true;
                dataGridView1.Rows[i].Cells[9].ReadOnly = true;
                dataGridView1.Rows[i].Cells[10].ReadOnly = true;
                dataGridView1.Rows[i].Cells[11].ReadOnly = true;

                dataGridView1.ReadOnly = false;

                dataGridView1.Rows[i].Cells[0].ReadOnly = true;
                dataGridView1.Rows[i].Cells[1].ReadOnly = true;
                dataGridView1.Rows[i].Cells[2].ReadOnly = true;
                dataGridView1.Rows[i].Cells[6].ReadOnly = true;
                dataGridView1.Rows[i].Cells[7].ReadOnly = true;
                dataGridView1.Rows[i].Cells[8].ReadOnly = true;
                dataGridView1.Rows[i].Cells[9].ReadOnly = true;
                dataGridView1.Rows[i].Cells[10].ReadOnly = true;
            }
            dataGridView1.Refresh();
        }

        private void bntPesquisar_Click(object sender, EventArgs e)
        {
            ClientModel cliente = new ClientModel();
            if (string.IsNullOrEmpty(txtNomeCliente.Text))
            {
                cliente.nome = "%";
            }
            else
            {
                cliente.nome = txtNomeCliente.Text;
            }


            ProdutoModels produto = new ProdutoModels();

            if (string.IsNullOrEmpty(txtNomeProduto.Text))
            {
                produto.Nome = "%";
            }
            else
            {
                produto.Nome = txtNomeProduto.Text;
            }


            PedidoModels pedido = new PedidoModels(produto, cliente);
            if (dtpDataPedido.Enabled)
            {
                pedido.Data_Pedido = DateTime.Parse(dtpDataPedido.Value.ToShortDateString());
            }
            else
            {
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
            colunasReadOnly();
        }

        private void bntAtualizar_Click(object sender, EventArgs e)
        {
            List<PedidoModels> listPedidos = new List<PedidoModels>();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                System.Threading.Thread.Sleep(50);
                PedidoModels pedido = new PedidoModels();
                pedido.Pedido_ID = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                pedido.Data_Entrega = DateTime.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());
                pedido._ItemPedido.Quantidade = int.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                pedido.StrData_Entrega = pedido.Data_Entrega.ToString("yyyy-MM-dd HH:mm:ss");
                listPedidos.Add(pedido);
            }

            PedidoDAO pedidoDAO = new PedidoDAO();

            bool verificaAtualizacao = pedidoDAO.atualizarInumos(listPedidos);
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
