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
    public partial class frmAtualizarCliente : Form
    {
        private Form _frmPrincipal;

        public frmAtualizarCliente(Form pfrmPrincipal)
        {
            this._frmPrincipal = pfrmPrincipal;
            InitializeComponent();
            popularGrid();
        }

        public void popularGrid()
        {
            ClienteDAO cliente = new ClienteDAO();

            DataSet dataSet = cliente.visualizarGridComID();
            dgvClientes.DataSource = dataSet.Tables["characters"];

            this.dgvClientes.Columns[0].Visible = false;

            for (int i = 0; i < dgvClientes.Columns.Count; i++)
            {
                dgvClientes.Columns[i].Width = 405;
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

        private void bntCadastrar_Click(object sender, EventArgs e)
        {
            CienteModels cliente = new CienteModels();

            cliente.nome = txtNome.Text;
            cliente.localidade = txtLocalidade.Text;
            cliente.Tipo = cmbTipo.Text.ToString();

            if ((string.IsNullOrEmpty(cliente.nome) && (string.IsNullOrEmpty(cliente.localidade)) && (string.IsNullOrEmpty(cliente.Tipo))))
            {
                cliente.nome = "%";
                cliente.localidade = "%";
                cliente.Tipo = "%";
            }

            preencheGridComParametros(cliente);
        }

        private void preencheGridComParametros(CienteModels ciente)
        {
            ClienteDAO cliente = new ClienteDAO();

            DataSet dataSet = cliente.visualizarGridComParametrosEID(ciente);
            dgvClientes.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dgvClientes.Columns.Count; i++)
            {
                dgvClientes.Columns[i].Width = 400;
            }
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this._frmPrincipal.Show();
        }

        private void bntAtualizar_Click(object sender, EventArgs e)
        {
            List<CienteModels> listClientes = new List<CienteModels>();

            for (int i = 0; i < dgvClientes.Rows.Count - 1; i++)
            {
                System.Threading.Thread.Sleep(50);
                CienteModels cliente = new CienteModels();
                cliente.Cliente_ID = int.Parse(dgvClientes.Rows[i].Cells[0].Value.ToString());
                cliente.nome = dgvClientes.Rows[i].Cells[1].Value.ToString();
                cliente.localidade = dgvClientes.Rows[i].Cells[2].Value.ToString();
                cliente.Tipo = dgvClientes.Rows[i].Cells[3].Value.ToString();
                listClientes.Add(cliente);
            }

            ClienteDAO clienteDAO = new ClienteDAO();

            bool verificaAtualizacao = clienteDAO.atualizarClientes(listClientes);
            if (verificaAtualizacao)
            {
                MessageBox.Show("Dados atualizados com sucesso.");
            }
            else {
                MessageBox.Show("Erro na atualização dos dados.");
            }

            popularGrid();
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
    }
}
