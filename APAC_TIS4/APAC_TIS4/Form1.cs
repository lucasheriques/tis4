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
    }
}
