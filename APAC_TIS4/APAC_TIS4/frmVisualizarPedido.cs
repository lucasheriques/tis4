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
        private frmPrincipal _frmPrincipal;
        public frmVisualizarPedido(frmPrincipal pFrmPrincipal)
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
            cliente.nome = txtNomeCliente.Text;

            ProdutoModels produto = new ProdutoModels();
            produto.Nome = txtNomeProduto.Text;

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
    }
}
