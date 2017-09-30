using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace APAC_TIS4
{
    public partial class frmPrincipal : MetroForm
    {
        public frmPrincipal()
        {
            InitializeComponent();
            popularCliente();
            popularProduto();
            inicializarProdutos();
        }

        private void inicializarProdutos() {
            mbAtualizarProdutos.Hide();
            mbAdicionarProdutos.Hide();
            setReadOnlyGridProduto(true);
        }

        private void popularProduto() {
            ProdutoDAO produto = new ProdutoDAO();

            DataSet dataSet = produto.visualizarGridEID();

            mgProduto.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < mgProduto.Columns.Count; i++)
            {
                mgProduto.Columns[i].Width = 400;
            }
        }

        public void popularCliente()
        {
            ClienteDAO cliente = new ClienteDAO();

            DataSet dataSet = cliente.visualizarGrid();
            dvgClientes.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dvgClientes.Columns.Count; i++)
            {
                dvgClientes.Columns[i].Width = 400;
            }
        }

        public void clearClientFields()
        {
            txtClientId.Clear();
            txtClientLocal.Clear();
            txtClientName.Clear();
            cmdClientType.ResetText();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            spiClientActions.Show();
            Util.WaitNSeconds(0.5);

            ClientModel cliente = new ClientModel();

            cliente.nome = txtClientName.Text;
            cliente.localidade = txtClientLocal.Text;
            cliente.Tipo = cmdClientType.Text;

            ClienteDAO clienteDAO = new ClienteDAO();
            string retorno = clienteDAO.cadastrar(cliente);

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
                spiClientActions.Hide();
                lblReturnLabel.Show();
                lblReturnLabel.Text = "Cliente adicionado com sucesso!";
                popularCliente();
            }
            
        }

        private void btnClientUpdateMenu_Click(object sender, EventArgs e)
        {
            btnAddClient.Hide();
            btnUpdateClient.Show();
            lblClientID.Show();
            txtClientId.Show();
        }

        private void btnClientAddMenu_Click(object sender, EventArgs e)
        {
            btnAddClient.Show();
            btnUpdateClient.Hide();
            lblClientID.Hide();
            txtClientId.Hide();
        }

        private void dvgClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (txtClientId.Visible)
            {
                txtClientId.Text = dvgClientes.SelectedRows[0].Cells[2].Value.ToString();
                txtClientName.Text = dvgClientes.SelectedRows[0].Cells[3].Value.ToString();
                txtClientLocal.Text = dvgClientes.SelectedRows[0].Cells[4].Value.ToString();
                cmdClientType.Text = dvgClientes.SelectedRows[0].Cells[5].Value.ToString();
            }
        }

        private void btnUpdateClient_Click(object sender, EventArgs e)
        {
        }

        private void lblReturnLabel_Click(object sender, EventArgs e)
        {

        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            clearClientFields();
        }

        public void clearProductFields()
        {
            mcmbTipo.SelectedIndex = -1;
            mcmbUDM.SelectedIndex = -1;
            mcmbTamanho.SelectedIndex = -1;
            mtxtPeso.Text = "";
            mtxtNome.Text = "";
            mtxtCustoPorUnidade.Text = "";
            mtxtPVU.Text = "";
            mtxtDescricao.Text = "";
        }


        private void metroButton1_Click(object sender, EventArgs e)
        {
            clearProductFields();
        }

        private void metroButtonAdicionarProdutos_Click(object sender, EventArgs e)
        {
            //metroButtonAdicionarProdutos.Select();
            mbAdicionarProdutos.Show();
            mbAtualizarProdutos.Hide();
            setReadOnlyGridProduto(true);
        }

        private void metroButtonAtualizar_Click(object sender, EventArgs e)
        {
            mbAdicionarProdutos.Hide();
            mbAtualizarProdutos.Show();
            setReadOnlyGridProduto(false);
        }

        private void setReadOnlyGridProduto(bool alterar) {
            for (int i = 0; i < mgProduto.ColumnCount; i++) {
                mgProduto.Columns[i].ReadOnly = alterar;
            }
        }

        private void mbAdicionarProdutos_Click(object sender, EventArgs e)
        {
            spiClientActions.Show();
            Util.WaitNSeconds(0.5);

            ProdutoModels produtoModels = new ProdutoModels();

            produtoModels.Tipo = mcmbTipo.Text;
            produtoModels.Tamanho = mcmbTamanho.Text;
            produtoModels.UDM = mcmbUDM.Text.Substring(0,2).Trim();
            produtoModels.Peso = float.Parse(mtxtPeso.Text);
            produtoModels.Nome = mtxtNome.Text;
            produtoModels.CustoPorUnidade = float.Parse(mtxtCustoPorUnidade.Text);
            produtoModels.PrecoDeVendaUnidade = float.Parse(mtxtPVU.Text);
            produtoModels.Descricao = mtxtDescricao.Text;

            ProdutoDAO produtoDAO = new ProdutoDAO();
            string retorno = produtoDAO.cadastrar(produtoModels);

            if (retorno == "OK")
            {
                spiClientActions.Hide();
                lblReturnLabel.Show();
                lblReturnLabel.Text = "Cliente adicionado com sucesso!";
                popularProduto();
                setReadOnlyGridProduto(false);
            }
            else {
                MessageBox.Show("Erro ao cadastrar produto: " + retorno);
            }
        }

        private void mbAtualizarProdutos_Click(object sender, EventArgs e)
        {
            spiClientActions.Show();
            Util.WaitNSeconds(0.5);

            List<ProdutoModels> listProdutoModels = new List<ProdutoModels>();

            for (int i = 0; i < mgProduto.RowCount; i++)
            {
                ProdutoModels produtoModels = new ProdutoModels();

                var checkbox = mgProduto.Rows[i].Cells[0].Value;

                if (checkbox != null) {
                    if (checkbox.ToString().ToLower() == "true") {
                        produtoModels.Produto_ID = int.Parse(mgProduto.Rows[i].Cells[2].Value.ToString());
                        produtoModels.Tipo = mgProduto.Rows[i].Cells[4].Value.ToString();
                        produtoModels.Tamanho = mgProduto.Rows[i].Cells[5].Value.ToString();
                        produtoModels.UDM = mgProduto.Rows[i].Cells[7].Value.ToString();
                        produtoModels.Peso = float.Parse(mgProduto.Rows[i].Cells[6].Value.ToString());
                        produtoModels.Nome = mgProduto.Rows[i].Cells[3].Value.ToString();
                        produtoModels.CustoPorUnidade = float.Parse(mgProduto.Rows[i].Cells[8].Value.ToString());
                        produtoModels.PrecoDeVendaUnidade = float.Parse(mgProduto.Rows[i].Cells[9].Value.ToString());
                        produtoModels.Descricao = mgProduto.Rows[i].Cells[10].Value.ToString();

                        listProdutoModels.Add(produtoModels);
                    }
                }

            }

            ProdutoDAO produtoDAO = new ProdutoDAO();
            bool verifica = produtoDAO.atualizarProdutos(listProdutoModels);
            if (verifica) {
                lblReturnLabel.Show();
                lblReturnLabel.Text = "Cliente atualizado com sucesso!";
                popularProduto();
                setReadOnlyGridProduto(true);
            }

        }
    }
}
