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
    public partial class frmCadastrarCliente : Form
    {
        Form principal;
        public frmCadastrarCliente(Form principal)
        {
            this.principal = principal;
            InitializeComponent();
            popularGrid();

        }

        public frmCadastrarCliente()
        {
            InitializeComponent();
        }

        public void popularGrid() {
            ClienteDAO cliente = new ClienteDAO();

            DataSet dataSet = cliente.visualizarGrid();
            dgvClientes.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dgvClientes.Columns.Count; i++) {
                dgvClientes.Columns[i].Width = 400;
            }
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.principal.Show();
        }

        private void bntSair_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo);
            if(result1 == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bntCadastrar_Click(object sender, EventArgs e)
        {
            CienteModels cliente = new CienteModels();

            cliente.nome = txtNome.Text;
            cliente.localidade = txtLocalidade.Text;
            cliente.Tipo = cmbTipo.Text;

            ClienteDAO clienteDAO = new ClienteDAO();
            string retorno = clienteDAO.cadastrar(cliente);

            if (String.IsNullOrEmpty(retorno)) {
                MessageBox.Show("Erro ao criar cliente!!!");
            }
            else if(retorno.Contains("Erro de acesso ao MySQL : ")){
                MessageBox.Show(retorno);
            }
            else{
                MessageBox.Show("Cliente inserido com sucesso!!!");
            }
            popularGrid();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {

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
    }
}
