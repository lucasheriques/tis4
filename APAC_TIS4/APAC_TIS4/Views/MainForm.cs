﻿using System;
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
        private static string verificaAtualizar = "0";
        public frmPrincipal()
        {
            InitializeComponent();
            popularCliente();
            popularProduto();
            popularPedidos();
            popularComboPedidos();
            inicializarProdutos();
            inicializarPedidos();
        }

        private void popularPedidos() {
            PedidoDAO pedidoDAO= new PedidoDAO();

            DataSet dataSet = pedidoDAO.visualizarGridComID();

            dvgPedidos.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dvgPedidos.Columns.Count; i++)
            {
                dvgPedidos.Columns[i].Width = 400;
            }
        }

        private void popularComboPedidos() {
            popularComboCliente();
            popularComboProduto();
        }

        private void popularComboProduto() {
            ProdutoDAO produtoDAO = new ProdutoDAO();

            DataSet dataSet = produtoDAO.preencheCombo();
            metroComboBox2.ValueMember = "Produto_ID";
            metroComboBox2.DisplayMember = "nome";
            metroComboBox2.DataSource = dataSet.Tables["characters"];
        }

        private void popularComboCliente() {
            ClienteDAO clienteDAO = new ClienteDAO();

            DataSet dataSet = clienteDAO.preencheCombo();
            metroComboBox1.ValueMember = "Cliente_ID";
            metroComboBox1.DisplayMember = "nome";
            metroComboBox1.DataSource = dataSet.Tables["characters"];

        }
        //inicializarPedidos()

        private void inicializarPedidos()
        {
            metroLabel18.Hide();
            metroTextBox3.Hide();
            metroButton7.Hide();
            metroButton6.Hide();
            metroButton8.Hide();
            setReadOnlyGridPedidos(true);
        }

        private void inicializarProdutos() {
            metroLabel17.Hide();
            mtxtID.Hide();
            mbAtualizarProdutos.Hide();
            mbAdicionarProdutos.Hide();
            mbExcluirProdutos.Hide();
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
            metroLabel17.Hide();
            mtxtID.Hide();
            mbAdicionarProdutos.Show();
            mbAtualizarProdutos.Hide();
            mbExcluirProdutos.Hide();
            setReadOnlyGridProduto(true);
        }

        private void setReadOnlyGridPedidos(bool alterar)
        {
            for (int i = 0; i < dvgPedidos.ColumnCount; i++)
            {
                dvgPedidos.Columns[i].ReadOnly = alterar;
            }
        }

        private void metroButtonAtualizar_Click(object sender, EventArgs e)
        {
            metroLabel17.Show();
            mtxtID.Show();
            mbAdicionarProdutos.Hide();
            mbAtualizarProdutos.Show();
            mbExcluirProdutos.Hide();
            setReadOnlyGridProduto(false);
        }

        private void setReadOnlyGridPedido(bool alterar) {
            for (int i = 0; i < dvgPedidos.ColumnCount; i++)
            {
                dvgPedidos.Columns[i].ReadOnly = alterar;
            }
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
                metroLabel9.Show();
                metroLabel9.Text = "Produto adicionado com sucesso!";
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

            if (string.IsNullOrEmpty(mcmbTipo.Text))
            {
                MessageBox.Show("Selecione o Produto que deseja atualizar.");
                return;
            }


            List<ProdutoModels> listProdutoModels = new List<ProdutoModels>();

            ProdutoModels produtoModels = new ProdutoModels();

            produtoModels.Tipo = mcmbTipo.Text;
            produtoModels.Tamanho = mcmbTamanho.Text;
            produtoModels.UDM = mcmbUDM.Text.Substring(0, 2).Trim();
            produtoModels.Peso = float.Parse(mtxtPeso.Text);
            produtoModels.Nome = mtxtNome.Text;
            produtoModels.CustoPorUnidade = float.Parse(mtxtCustoPorUnidade.Text);
            produtoModels.PrecoDeVendaUnidade = float.Parse(mtxtPVU.Text);
            produtoModels.Descricao = mtxtDescricao.Text;

            listProdutoModels.Add(produtoModels);
/*
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
*/
            ProdutoDAO produtoDAO = new ProdutoDAO();
            bool verifica = produtoDAO.atualizarProdutos(listProdutoModels);
            if (verifica) {
                metroLabel9.Show();
                metroLabel9.Text = "Produto atualizado com sucesso!";
                popularProduto();
                setReadOnlyGridProduto(true);
            }

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (verificaAtualizar == "2") {
                verificaAtualizar = "0";
                return;
            }
            string quantidadeStr = mtxtQantidade.Text.ToString();
            if (metroComboBox2.SelectedValue != null || !string.IsNullOrEmpty(quantidadeStr) || !string.IsNullOrWhiteSpace(quantidadeStr)) {
                string strProduto_ID = metroComboBox2.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(strProduto_ID) || !string.IsNullOrWhiteSpace(strProduto_ID))
                {
                    int produto_ID = int.Parse(strProduto_ID);

                    ProdutoDAO produtoDAO = new ProdutoDAO();

                    float precodeVendaUnidade = produtoDAO.getPrecoDeVendaUnidade(produto_ID);

                    float quantidade = float.Parse(mtxtQantidade.Text.ToString());

                    float precoTotal = precodeVendaUnidade * quantidade;

                    metroTextBox2.Text = precoTotal.ToString();
                }
            }
        }

        private void metroComboBox2_TextChanged(object sender, EventArgs e)
        {
            if (verificaAtualizar == "1")
            {
                verificaAtualizar = "2";
                return;
            }
            string strQuantidade = mtxtQantidade.Text.ToString();
            string strProduto = metroComboBox2.Text.ToString();
            if (!string.IsNullOrEmpty(strQuantidade) || !string.IsNullOrWhiteSpace(strQuantidade)) {
                if (!string.IsNullOrEmpty(strProduto) || !string.IsNullOrWhiteSpace(strProduto))
                {
                    string strProduto_ID = metroComboBox2.SelectedValue.ToString();

                    int produto_ID = int.Parse(strProduto_ID);

                    ProdutoDAO produtoDAO = new ProdutoDAO();

                    float precodeVendaUnidade = produtoDAO.getPrecoDeVendaUnidade(produto_ID);

                    float quantidade = float.Parse(strQuantidade);

                    float precoTotal = precodeVendaUnidade * quantidade;

                    metroTextBox2.Text = precoTotal.ToString();
                }
            }
        }

        private void metroButton7_Click(object sender, EventArgs e)
        {
            PedidoModels pedidoModels = new PedidoModels();
            pedidoModels.Pedido_ID = int.Parse(metroTextBox3.Text.ToString());

            pedidoModels._ItemPedido = new ItemPedido();
            pedidoModels._ItemPedido.Cliente_ID = int.Parse(metroComboBox1.SelectedValue.ToString());
            pedidoModels._ItemPedido.Produto_ID = int.Parse(metroComboBox2.SelectedValue.ToString());
            pedidoModels.Data_Pedido = dateTimePicker1.Value.Date;
            pedidoModels.Data_Entrega = dateTimePicker2.Value.Date;
            pedidoModels.Quantidade = int.Parse(mtxtQantidade.Text);
            pedidoModels.PrecoTotal = float.Parse(metroTextBox2.Text);

            PedidoDAO pedidoDAO = new PedidoDAO();

            bool verificaAtualizacao = pedidoDAO.atualizar(pedidoModels);
            if (verificaAtualizacao)
            {
                metroProgressSpinner2.Hide();
                metroLabel16.Show();
                metroLabel16.Text = "Pedido atualizado com sucesso!";
                popularPedidos();
                setReadOnlyGridPedidos(true);
            }
            else
            {
                MessageBox.Show("Erro na atualização dos dados.");
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            spiClientActions.Show();
            Util.WaitNSeconds(0.5);

            PedidoModels pedidoModels = new PedidoModels();

            pedidoModels._ItemPedido = new ItemPedido();
            pedidoModels._ItemPedido.Cliente_ID = int.Parse(metroComboBox1.SelectedValue.ToString());
            pedidoModels._ItemPedido.Produto_ID = int.Parse(metroComboBox2.SelectedValue.ToString());
            pedidoModels.Data_Pedido = dateTimePicker1.Value.Date;
            pedidoModels.Data_Entrega = dateTimePicker2.Value.Date;
            pedidoModels.Quantidade = int.Parse(mtxtQantidade.Text);
            pedidoModels.PrecoTotal = float.Parse(metroTextBox2.Text);


            PedidoDAO pedidoDAO = new PedidoDAO();

            String retorno = pedidoDAO.cadastrar(pedidoModels);

            if (retorno == "OK")
            {
                spiClientActions.Hide();
                lblReturnLabel.Show();
                lblReturnLabel.Text = "Pedido adicionado com sucesso!";
                popularPedidos();
                setReadOnlyGridPedidos(false);
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar Pedido: " + retorno);
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            metroLabel18.Hide();
            metroTextBox3.Hide();
            metroButton7.Hide();
            metroButton6.Show();
            metroButton8.Hide();
            setReadOnlyGridPedidos(false);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            metroLabel18.Show();
            metroTextBox3.Show();
            metroButton7.Show();
            metroButton6.Hide();
            metroButton8.Hide();
            setReadOnlyGridPedidos(true);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            metroComboBox1.SelectedIndex = -1;
            metroComboBox2.SelectedIndex = -1;
            mtxtQantidade.Text = "";
            metroTextBox2.Text = "";
        }

        private void metroButtonExcluir_Click(object sender, EventArgs e)
        {
            metroLabel17.Hide();
            mtxtID.Hide();
            mbAtualizarProdutos.Hide();
            mbAdicionarProdutos.Hide();
            mbExcluirProdutos.Show();
            setReadOnlyGridProduto(true);
        }

        private void mgProduto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) {
                string unidadeDeMedida = mgProduto.Rows[e.RowIndex].Cells[7].Value.ToString();
                if (unidadeDeMedida == "Kg") {
                    unidadeDeMedida += " - Quilograma";
                }
                else if (unidadeDeMedida == "gr") {
                    unidadeDeMedida += " - Grama";
                }
                else if (unidadeDeMedida == "mg") {
                    unidadeDeMedida += " - Miligrama";
                }
                mtxtID.Text = mgProduto.Rows[e.RowIndex].Cells[2].Value.ToString();
                mtxtNome.Text = mgProduto.Rows[e.RowIndex].Cells[3].Value.ToString();
                mcmbTipo.SelectedIndex = mcmbTipo.FindStringExact(mgProduto.Rows[e.RowIndex].Cells[4].Value.ToString());
                mcmbTamanho.SelectedIndex = mcmbTamanho.FindStringExact(mgProduto.Rows[e.RowIndex].Cells[5].Value.ToString());
                mtxtPeso.Text = mgProduto.Rows[e.RowIndex].Cells[6].Value.ToString();
                mcmbUDM.SelectedIndex = mcmbUDM.FindStringExact(unidadeDeMedida);
                mtxtCustoPorUnidade.Text = mgProduto.Rows[e.RowIndex].Cells[8].Value.ToString();
                mtxtPVU.Text = mgProduto.Rows[e.RowIndex].Cells[9].Value.ToString();
                mtxtDescricao.Text = mgProduto.Rows[e.RowIndex].Cells[10].Value.ToString();
            }
            else if (e.ColumnIndex == 0) {
                var checkbox = mgProduto.Rows[e.RowIndex].Cells[0].Value;

                if (checkbox != null)
                {
                    if (checkbox.ToString().ToLower() == "true")
                    {
                        mgProduto.Rows[e.RowIndex].Cells[0].Value = false;
                    }
                    else
                    {
                        mgProduto.Rows[e.RowIndex].Cells[0].Value = true;
                    }
                }
                else {
                    mgProduto.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }
        }

        private void mbExcluirProdutos_Click(object sender, EventArgs e)
        {
            spiClientActions.Show();
            Util.WaitNSeconds(0.5);
            List<int> listProductID = new List<int>();
                        for (int i = 0; i < mgProduto.RowCount; i++)
                        {
                            ProdutoModels produtoModels = new ProdutoModels();

                            var checkbox = mgProduto.Rows[i].Cells[0].Value;

                            if (checkbox != null) {
                                if (checkbox.ToString().ToLower() == "true") {
                                    listProductID.Add(int.Parse(mgProduto.Rows[i].Cells[2].Value.ToString()));
                                }
                            }

                        }

            ProdutoDAO produtoDAO = new ProdutoDAO();
            bool verifica = produtoDAO.excluirProdutos(listProductID);
            if (verifica)
            {
                metroLabel9.Show();
                metroLabel9.Text = "Produto(s) deletado(s) com sucesso!";
                popularProduto();
                setReadOnlyGridProduto(true);
            }

        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroLabel18.Hide();
            metroTextBox3.Hide();
            metroButton7.Hide();
            metroButton6.Hide();
            metroButton8.Show();
            setReadOnlyGridPedidos(true);
        }

        private void dvgPedidos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1) {
                verificaAtualizar = "1";
                metroTextBox3.Text = dvgPedidos.Rows[e.RowIndex].Cells[2].Value.ToString();
                metroComboBox1.SelectedIndex = metroComboBox1.FindStringExact(dvgPedidos.Rows[e.RowIndex].Cells[3].Value.ToString());
                metroComboBox2.SelectedIndex = metroComboBox2.FindStringExact(dvgPedidos.Rows[e.RowIndex].Cells[9].Value.ToString());
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Value = DateTime.Parse(dvgPedidos.Rows[e.RowIndex].Cells[6].Value.ToString());
                mtxtQantidade.Text = dvgPedidos.Rows[e.RowIndex].Cells[8].Value.ToString();
                metroTextBox2.Text = dvgPedidos.Rows[e.RowIndex].Cells[7].Value.ToString();
            }
            else if (e.ColumnIndex == 0) {
                var checkbox = dvgPedidos.Rows[e.RowIndex].Cells[0].Value;

                if (checkbox != null)
                {
                    if (checkbox.ToString().ToLower() == "true")
                    {
                        dvgPedidos.Rows[e.RowIndex].Cells[0].Value = false;
                    }
                    else
                    {
                        dvgPedidos.Rows[e.RowIndex].Cells[0].Value = true;
                    }
                }
                else
                {
                    dvgPedidos.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            spiClientActions.Show();
            Util.WaitNSeconds(0.5);
            List<int> listPedidosID = new List<int>();
            for (int i = 0; i < mgProduto.RowCount-1; i++)
            {
                PedidoModels pedidoModels = new PedidoModels();

                var checkbox = dvgPedidos.Rows[i].Cells[0].Value;

                if (checkbox != null)
                {
                    if (checkbox.ToString().ToLower() == "true")
                    {
                        listPedidosID.Add(int.Parse(dvgPedidos.Rows[i].Cells[2].Value.ToString()));
                    }
                }

            }

            PedidoDAO pedidoDAO = new PedidoDAO();
            bool verifica = pedidoDAO.excluirPedidos(listPedidosID);
            if (verifica)
            {
                metroLabel16.Show();
                metroLabel16.Text = "Pedidos(s) deletado(s) com sucesso!";
                popularPedidos();
                setReadOnlyGridProduto(true);
            }

        }

        
    }
}