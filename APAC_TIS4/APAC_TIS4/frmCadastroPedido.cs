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
    public partial class frmCadastroPedido : Form
    {
        private Form _frmPrincipal;
        private ClienteDAO cliente;
        private ProdutoDAO produto;

        public frmCadastroPedido(Form frmPrincipal)
        {
            InitializeComponent();
            this._frmPrincipal = frmPrincipal;

            DataSet dsProduto;
            produto = new ProdutoDAO();
            dsProduto = produto.preencheCombo();
            cmbProduto.ValueMember = "Produto_ID";
            cmbProduto.DisplayMember = "nome";
            cmbProduto.DataSource = dsProduto.Tables["characters"];

            DataSet dsCliente;
            cliente = new ClienteDAO();
            dsCliente = cliente.preencheCombo();
            cmbCliente.ValueMember = "Cliente_ID";
            cmbCliente.DisplayMember = "Nome";
            cmbCliente.DataSource = dsCliente.Tables["characters"];

            popularGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this._frmPrincipal.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PedidoModels pedido = new PedidoModels();
            pedido._ItemPedido = new ItemPedido();
            pedido._ItemPedido.Cliente_ID = (int) cmbCliente.SelectedValue;
            pedido._ItemPedido.Produto_ID = int.Parse(cmbProduto.SelectedValue.ToString());
            pedido.Data_Pedido = dateTimePicker1.Value.Date;
            pedido.Data_Entrega =  dateTimePicker2.Value.Date;
            pedido.Quantidade = int.Parse(textBox1.Text);
            pedido.PrecoTotal = float.Parse(textBox3.Text);

            PedidoDAO pedidoDAO = new PedidoDAO();

            String retorno = pedidoDAO.cadastrar(pedido);

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

        private void setValoresEmBanco() {
            textBox1.Text = "";
            textBox3.Text = "";

            DataSet dsProduto;
            produto = new ProdutoDAO();
            dsProduto = produto.preencheCombo();
            cmbProduto.ValueMember = "Produto_ID";
            cmbProduto.DataSource = dsProduto.Tables["characters"];

            DataSet dsCliente;
            cliente = new ClienteDAO();
            dsCliente = cliente.preencheCombo();
            cmbCliente.ValueMember = "Cliente_ID";
            cmbCliente.DataSource = dsCliente.Tables["characters"];


        }
        private void popularGrid() {
            PedidoDAO pedido = new PedidoDAO();

            DataSet ds = pedido.visualizarGrid();
            dataGridView1.DataSource = ds.Tables["characters"];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 400;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            ProdutoModels produto = new ProdutoModels();
            ProdutoDAO produtoDAO = new ProdutoDAO();

            int Produto_ID = (int)cmbProduto.SelectedValue;

            produto.PrecoDeVendaUnidade = produtoDAO.getPrecoDeVendaUnidade(Produto_ID);

            float precoTotal = produto.PrecoDeVendaUnidade * float.Parse(textBox1.Text);

            textBox3.Text = precoTotal.ToString();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text)) {
                ProdutoModels produto = new ProdutoModels();
                ProdutoDAO produtoDAO = new ProdutoDAO();

                int Produto_ID = int.Parse(cmbProduto.SelectedValue.ToString());

                produto.PrecoDeVendaUnidade = produtoDAO.getPrecoDeVendaUnidade(Produto_ID);

                float precoTotal = produto.PrecoDeVendaUnidade * float.Parse(textBox1.Text);

                textBox3.Text = precoTotal.ToString();
            }
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

