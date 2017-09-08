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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void bntCadastrarCliente_Click(object sender, EventArgs e)
        {
            frmCadastrarCliente cadastrarCliente = new frmCadastrarCliente(this);
            this.Hide();
            cadastrarCliente.Show();
        }

        private void bancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoDoBancoDeDados configuracaoDoBancoDeDados = new ConfiguracaoDoBancoDeDados();
            configuracaoDoBancoDeDados.setFrmPrincipal(this);
            this.Hide();
            configuracaoDoBancoDeDados.Show();
        }

        private void bntCadastrarProduto_Click(object sender, EventArgs e)
        {
            frmCadastrarProduto _frmCadastrarProduto = new frmCadastrarProduto(this);

            _frmCadastrarProduto.Show();
            this.Hide();
        }

        private void btnCadastrarPedio_Click(object sender, EventArgs e)
        {
            frmCadastroPedido vfrmCadastroPedido = new frmCadastroPedido(this);
            vfrmCadastroPedido.Show();
            this.Hide();
        }

        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroPedido vfrmCadastroPedido = new frmCadastroPedido(this);
            vfrmCadastroPedido.Show();
            this.Hide();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarCliente cadastrarCliente = new frmCadastrarCliente(this);
            this.Hide();
            cadastrarCliente.Show();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarProduto _frmCadastrarProduto = new frmCadastrarProduto(this);

            _frmCadastrarProduto.Show();
            this.Hide();

        }

        private void bntVisualizarCliente_Click(object sender, EventArgs e)
        {
            frmVisualizarCliente _frmVisualizarCliente = new frmVisualizarCliente(this);
            this.Hide();
            _frmVisualizarCliente.Show();
        }

        private void bntVisualizarPedido_Click(object sender, EventArgs e)
        {
            frmVisualizarPedido _frmVisualizarPedido = new frmVisualizarPedido(this);
            _frmVisualizarPedido.Show();
            this.Hide();
        }

        private void bntVisualizarProduto_Click(object sender, EventArgs e)
        {
            frmVisualizarProdutos _frmVisualizarProdutos = new frmVisualizarProdutos(this);
            this.Hide();
            _frmVisualizarProdutos.Show();
        }

        private void bntAtualizarCliente_Click(object sender, EventArgs e)
        {
            frmAtualizarCliente _frmAtualizarCliente = new frmAtualizarCliente(this);
            this.Hide();
            _frmAtualizarCliente.Show();
        }

        private void insumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarInsumo _frmCadastrarInsumo = new frmCadastrarInsumo(this);
            _frmCadastrarInsumo.Show();
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

        private void btnCadastrarInsumos_Click(object sender, EventArgs e)
        {
            frmCadastrarInsumo _frmCadastrarInsumo = new frmCadastrarInsumo(this);

            this.Hide();
            _frmCadastrarInsumo.Show();
        }

        private void bntCadastrarReceita_Click(object sender, EventArgs e)
        {
            frmCadastrarReceita _frmCadastrarReceita = new frmCadastrarReceita(this);

            _frmCadastrarReceita.Show();
            this.Hide();
        }

        private void bntVisualizarInsumo_Click(object sender, EventArgs e)
        {
            frmVisualizarInsumo _frmVisualizarInsumo = new frmVisualizarInsumo(this);
            _frmVisualizarInsumo.Show();
            this.Hide();
        }

        private void bntVisualizarReceita_Click(object sender, EventArgs e)
        {
            frmVisualizarReceita _frmVisualizarReceita = new frmVisualizarReceita(this);
            this.Hide();
            _frmVisualizarReceita.Show();
        }

        private void bntAtualizarInsumo_Click(object sender, EventArgs e)
        {
            frmAtualizarInsumo _frmAtualizarInsumo = new frmAtualizarInsumo(this);
            this.Hide();
            _frmAtualizarInsumo.Show();
        }

        private void bntAtualizarPedido_Click(object sender, EventArgs e)
        {
            frmAtualizarPedido _frmAtualizarPedido = new frmAtualizarPedido(this);
            this.Hide();
            _frmAtualizarPedido.Show();
        }

        private void bntAtualizarProduto_Click(object sender, EventArgs e)
        {
            frmAtualizarProduto _frmAtualizarProduto = new frmAtualizarProduto(this);
            _frmAtualizarProduto.Show();
            this.Hide();
        }

        private void receitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarReceita _frmCadastrarReceita = new frmCadastrarReceita(this);
            _frmCadastrarReceita.Show();
            this.Hide();
        }

        private void insumoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAtualizarCliente _frmAtualizarCliente = new frmAtualizarCliente(this);
            _frmAtualizarCliente.Show();
            this.Hide();
        }

        private void pedidoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAtualizarPedido _frmAtualizarPedido = new frmAtualizarPedido(this);
            _frmAtualizarPedido.Show();]
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
            frmVisualizarProdutos _frmVisualizarProdutos = new frmVisualizarProdutos(this);
            _frmVisualizarProdutos.Show();
            this.Hide();
        }
    }
}
