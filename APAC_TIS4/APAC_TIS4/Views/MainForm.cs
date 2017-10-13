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
        Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
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
            inicializarReceita();
            inicializarInsumo();
        }

        private void inicializarInsumo() {
            popularGridInsumo();
            metroLabel28.Hide();
            metroTextBox5.Hide();
            metroButton20.Hide();
            metroButton23.Hide();
            metroButton22.Hide();
            metroLabel37.Hide();
        }

        private void popularGridInsumo() {
            //metroGrid2
            InsumoDAO insumoDAO = new InsumoDAO();

            DataSet dataSet = insumoDAO.visualizarGridComID();

            metroGrid2.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < metroGrid2.Columns.Count; i++)
            {
                metroGrid2.Columns[i].Width = 400;
            }

        }

        private void inicializarReceita() {
            popularComboProdutoReceita(); //metroComboBox3
            popularReceita();
            popularInsumo(); // textBox3
            metroTextBox1.Hide();
            metroLabel19.Hide();
            metroButton12.Hide();
            metroButton15.Hide();
            metroButton14.Hide();
        }

        private void popularInsumo()
        {
            InsumoDAO insumoDAO = new InsumoDAO();

            DataSet dataSet = insumoDAO.preencheCombo();

            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    listBox1.Items.Add(dr["Nome"].ToString());
                }
            }
        }

        private void popularReceita() {
            ReceitaDAO receitaDAO = new ReceitaDAO();

            DataSet dataSet = receitaDAO.visualizarGridComID();

            metroGrid1.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < metroGrid1.Columns.Count; i++)
            {
                metroGrid1.Columns[i].Width = 400;
            }
        }

        private void popularComboProdutoReceita() {
            ProdutoDAO produtoDAO = new ProdutoDAO();

            DataSet dataSet = produtoDAO.preencheCombo();
            metroComboBox3.ValueMember = "Produto_ID";
            metroComboBox3.DisplayMember = "nome";
            metroComboBox3.DataSource = dataSet.Tables["characters"];
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

        private void metroButton11_Click(object sender, EventArgs e)
        {
            metroLabel19.Hide();
            metroTextBox1.Hide();
            metroButton12.Hide();
            metroButton15.Hide();
            metroButton14.Show();
        }

        private void metroButton9_Click(object sender, EventArgs e)
        {
            metroLabel19.Hide();
            metroTextBox1.Hide();
            metroButton12.Show();
            metroButton15.Hide();
            metroButton14.Hide();
        }

        private void metroButton10_Click(object sender, EventArgs e)
        {
            metroLabel19.Show();
            metroTextBox1.Show();
            metroButton12.Hide();
            metroButton15.Show();
            metroButton14.Hide();
        }

        private void metroButton13_Click(object sender, EventArgs e)
        {
            metroTextBox1.Text = "";
            metroTextBox4.Text = "";
            textBox1.Text = "";
            metroComboBox3.SelectedIndex = -1;

            foreach (string strItem in listBox2.Items)
            {
                listBox1.Items.Add(strItem);
            }
            foreach (string s in listBox2.Items.OfType<string>().ToList())
                listBox2.Items.Remove(s);

            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void metroButton14_Click(object sender, EventArgs e)
        {
            metroProgressSpinner3.Show();
            Util.WaitNSeconds(0.5);

            ReceitaModels receita = new ReceitaModels();
            receita.Observacao = metroTextBox4.Text;
            receita.ModoDePreparo = textBox1.Text;
            receita.Produto = new ProdutoModels();
            receita.Produto.Produto_ID = int.Parse(metroComboBox3.SelectedValue.ToString());

            receita.Receita_Insumo = new Receita_InsumoModels();
            receita.Receita_Insumo.Insumo = new List<InsumoModels>();
            string[] nomeInsumo = new string[listBox2.Items.Count];
            for (int i = 0; i < listBox2.Items.Count; i++) {
                nomeInsumo[i] = listBox2.Items[i].ToString();
            }

            foreach (string nome in nomeInsumo) {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Nome = nome;
                receita.Receita_Insumo.Insumo.Add(insumoModels);
            }
            //receita.Receita_Insumo.Insumo
            string[] strPeso = textBox4.Text.Split('\n');
            receita.Receita_Insumo.Peso = new List<float>();
            for (int i = 0; i< strPeso.Length; i++) {
                receita.Receita_Insumo.Peso.Add(float.Parse(strPeso[i].ToString()));
            }

            string[] strUnidadeDeMedida = textBox5.Text.Split('\n');
            receita.Receita_Insumo.UnidadeDeMedida = new List<string>();
            for(int i = 0; i < strUnidadeDeMedida.Length; i++)
            {
                receita.Receita_Insumo.UnidadeDeMedida.Add(strUnidadeDeMedida[i]);
            }

            ReceitaDAO receitaDAO = new ReceitaDAO();

            String retorno = receitaDAO.cadastrar(receita);

            if (retorno == "OK")
            {
                metroProgressSpinner3.Hide();
                metroLabel23.Show();
                metroLabel23.Text = "Receita adicionada com sucesso!";
                popularReceita();
                //setReadOnlyGridPedidos(false);
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar a receita: " + retorno);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (string strItem in listBox1.SelectedItems) {
                listBox2.Items.Add(strItem);
            }
            foreach (string s in listBox1.SelectedItems.OfType<string>().ToList())
                listBox1.Items.Remove(s);            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (string strItem in listBox2.SelectedItems)
            {
                listBox1.Items.Add(strItem);
            }
            foreach (string s in listBox2.SelectedItems.OfType<string>().ToList())
                listBox2.Items.Remove(s);

        }

        private void metroButton12_Click(object sender, EventArgs e)
        {
            spiClientActions.Show();
            Util.WaitNSeconds(0.5);
            List<int> listReceitaID = new List<int>();
            for (int i = 0; i < metroGrid1.RowCount; i++)
            {
                ReceitaModels pedidoModels = new ReceitaModels();

                var checkbox = metroGrid1.Rows[i].Cells[0].Value;

                if (checkbox != null)
                {
                    if (checkbox.ToString().ToLower() == "true")
                    {
                        listReceitaID.Add(int.Parse(metroGrid1.Rows[i].Cells[2].Value.ToString()));
                    }
                }
            }

            ReceitaDAO receitaDAO = new ReceitaDAO();
            bool verifica = receitaDAO.excluirPedidos(listReceitaID);
            if (verifica)
            {
                metroLabel23.Show();
                metroLabel23.Text = "Receitas(s) deletada(s) com sucesso!";
                popularReceita();
                setReadOnlyGridProduto(true);
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            int quantidadeInsumo = listBox2.Items.Count;
            int quantidadePeso = textBox1.Text.Split('\n').Length;
            if ((Keys)e.KeyChar == Keys.Enter && e.Handled != true)
            {
                if (quantidadePeso >= quantidadeInsumo)
                {
                    e.Handled = true;
                }
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            int quantidadeInsumo = listBox2.Items.Count;
            int quantidadePeso = textBox5.Text.Split('\n').Length;
            if ((Keys)e.KeyChar == Keys.Enter && e.Handled != true)
            {
                if (quantidadePeso >= quantidadeInsumo)
                {
                    e.Handled = true;
                }
            }
        }

        private void metroGrid1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                metroTextBox1.Text = metroGrid1.Rows[e.RowIndex].Cells[2].Value.ToString();
                metroTextBox4.Text = metroGrid1.Rows[e.RowIndex].Cells[13].Value.ToString();
                metroComboBox3.SelectedIndex = metroComboBox3.FindStringExact(metroGrid1.Rows[e.RowIndex].Cells[3].Value.ToString());
                textBox1.Text = metroGrid1.Rows[e.RowIndex].Cells[12].Value.ToString();
                listBox2.Items.Add(metroGrid1.Rows[e.RowIndex].Cells[9].Value.ToString());
                textBox4.Text = metroGrid1.Rows[e.RowIndex].Cells[10].Value.ToString();
                textBox5.Text = metroGrid1.Rows[e.RowIndex].Cells[11].Value.ToString();

                string clausulaWhere = "";
                foreach (string insumo in listBox1.Items) {
                    clausulaWhere = clausulaWhere + "\'" + insumo + "\',";
                }
                for (int i = 0; i < listBox1.Items.Count; i++) {
                    listBox1.Items.RemoveAt(i);
                }

                clausulaWhere = clausulaWhere.Substring(0, clausulaWhere.Length-1);

                popularComboInsumoReceitaComWhere(clausulaWhere);
            }
            else if (e.ColumnIndex == 0)
            {
                var checkbox = metroGrid1.Rows[e.RowIndex].Cells[0].Value;

                if (checkbox != null)
                {
                    if (checkbox.ToString().ToLower() == "true")
                    {
                        metroGrid1.Rows[e.RowIndex].Cells[0].Value = false;
                    }
                    else
                    {
                        metroGrid1.Rows[e.RowIndex].Cells[0].Value = true;
                    }
                }
                else
                {
                    metroGrid1.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }
        }
        private void popularComboInsumoReceitaComWhere(string clausulaWhere) {
            InsumoDAO insumoDAO = new InsumoDAO();

            DataSet dataSet = insumoDAO.preencheComboComWhere(clausulaWhere);

            foreach (DataTable table in dataSet.Tables)
            {
                foreach (DataRow dr in table.Rows)
                {
                    listBox1.Items.Add(dr["Nome"].ToString());
                }
            }
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            metroProgressSpinner3.Show();
            Util.WaitNSeconds(0.5);
            ReceitaModels receitaModels = new ReceitaModels();

            receitaModels.ReceitaID = int.Parse(metroTextBox1.Text.ToString());

            receitaModels.Produto = new ProdutoModels();
            receitaModels.Produto.Produto_ID = int.Parse(metroComboBox3.SelectedValue.ToString());
            receitaModels.Observacao = metroTextBox4.Text;
            receitaModels.ModoDePreparo = textBox1.Text;

            receitaModels.Receita_Insumo = new Receita_InsumoModels();
            receitaModels.Receita_Insumo.Insumo = new List<InsumoModels>();
            string[] nomeInsumo = new string[listBox2.Items.Count];
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                nomeInsumo[i] = listBox2.Items[i].ToString();
            }

            foreach (string nome in nomeInsumo)
            {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Nome = nome;
                receitaModels.Receita_Insumo.Insumo.Add(insumoModels);
            }
            //receita.Receita_Insumo.Insumo
            string[] strPeso = textBox4.Text.Split('\n');
            receitaModels.Receita_Insumo.Peso = new List<float>();
            for (int i = 0; i < strPeso.Length; i++)
            {
                receitaModels.Receita_Insumo.Peso.Add(float.Parse(strPeso[i].ToString()));
            }

            string[] strUnidadeDeMedida = textBox5.Text.Split('\n');
            receitaModels.Receita_Insumo.UnidadeDeMedida = new List<string>();
            for (int i = 0; i < strUnidadeDeMedida.Length; i++)
            {
                receitaModels.Receita_Insumo.UnidadeDeMedida.Add(strUnidadeDeMedida[i]);
            }



            ReceitaDAO receitaDAO = new ReceitaDAO();

            bool verificaAtualizacao = receitaDAO.atualizar(receitaModels);
            if (verificaAtualizacao)
            {
                metroProgressSpinner3.Hide();
                metroLabel23.Show();
                metroLabel23.Text = "Receita atualizada com sucesso!";
                popularReceita();
                //setReadOnlyGridPedidos(true);
            }
            else
            {
                MessageBox.Show("Erro na atualização dos dados.");
            }
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            if (metroGrid1.Rows.Count > 0)
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 3; i < metroGrid1.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i-2] = metroGrid1.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < metroGrid1.Rows.Count; i++)
                    {
                        for (int j = 2; j < metroGrid1.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j -1] = metroGrid1.Rows[i].Cells[j].Value.ToString();
                        }
                    }
                    //
                    XcelApp.Columns.AutoFit();
                    //
                    XcelApp.Visible = true;
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                    XcelApp.Quit();
                }
            }
        }

        private void metroButton19_Click(object sender, EventArgs e)
        {
            metroLabel28.Hide();
            metroTextBox5.Hide();
            metroButton20.Hide();
            metroButton23.Hide();
            metroButton22.Show();
            metroLabel37.Hide();
        }

        private void metroButton18_Click(object sender, EventArgs e)
        {
            metroLabel28.Show();
            metroTextBox5.Show();
            metroButton20.Hide();
            metroButton23.Show();
            metroButton22.Hide();
            metroLabel37.Hide();
        }

        private void metroButton17_Click(object sender, EventArgs e)
        {
            metroLabel28.Hide();
            metroTextBox5.Hide();
            metroButton20.Show();
            metroButton23.Hide();
            metroButton22.Hide();
            metroLabel37.Hide();
        }

        private void metroButton21_Click(object sender, EventArgs e)
        {
            metroTextBox5.Text = "";
            metroTextBox6.Text = "";
            metroTextBox7.Text = "";
            metroTextBox8.Text = "";
            metroTextBox9.Text = "";
            metroTextBox10.Text = "";
            metroTextBox11.Text = "";
            metroTextBox12.Text = "";
            metroComboBox4.SelectedIndex = -1;
        }

        private void metroTextBox11_TextChanged(object sender, EventArgs e)
        {
            /*if ((!string.IsNullOrEmpty(metroTextBox9.Text)) && (!string.IsNullOrEmpty(metroTextBox10.Text))) {
                int quantidade = int.Parse(metroTextBox9.Text);
                int custoPorUnidade = int.Parse(metroTextBox10.Text);
                int resultado = quantidade * custoPorUnidade;
                metroTextBox11.Text = resultado.ToString();
            }*/
        }

        private void metroTextBox8_TextChanged(object sender, EventArgs e)
        {/*
            if ((!string.IsNullOrEmpty(metroTextBox9.Text)) && (!string.IsNullOrEmpty(metroTextBox10.Text)))
            {
                int quantidade = int.Parse(metroTextBox9.Text);
                int pesoPorUnidade = int.Parse(metroTextBox8.Text);
                int resultado = quantidade * pesoPorUnidade;
                metroTextBox8.Text = resultado.ToString();
            }*/
        }

        private void metroTextBox7_TextChanged(object sender, EventArgs e)
        {
            float output;
            if (((!string.IsNullOrEmpty(metroTextBox9.Text)) && (float.TryParse(metroTextBox9.Text.Trim(), out output))) && (!string.IsNullOrEmpty(metroTextBox7.Text)) && (float.TryParse(metroTextBox7.Text.Trim(), out output)))
            {
                float quantidade = float.Parse(metroTextBox9.Text);
                float pesoPorUnidade = float.Parse(metroTextBox7.Text);
                float resultado = quantidade * pesoPorUnidade;
                metroTextBox8.Text = resultado.ToString();
            }
            else {
                metroTextBox8.Text = "";
            }
        }

        private void metroTextBox10_TextChanged(object sender, EventArgs e)
        {
            float output;
            if (((!string.IsNullOrEmpty(metroTextBox9.Text)) && (float.TryParse(metroTextBox9.Text.Trim(), out output))) && (!string.IsNullOrEmpty(metroTextBox10.Text)) && (float.TryParse(metroTextBox10.Text.Trim(), out output)))
            {
                float quantidade = float.Parse(metroTextBox9.Text);
                float pesoPorUnidade = float.Parse(metroTextBox10.Text);
                float resultado = quantidade * pesoPorUnidade;
                metroTextBox11.Text = resultado.ToString();
            }
            else
            {
                metroTextBox11.Text = "";
            }
        }

        private void metroTextBox9_TextChanged(object sender, EventArgs e)
        {
            float output;
            if (((!string.IsNullOrEmpty(metroTextBox9.Text)) && (float.TryParse(metroTextBox9.Text.Trim(), out output))) && (!string.IsNullOrEmpty(metroTextBox7.Text)) && (float.TryParse(metroTextBox7.Text.Trim(), out output)))
            {
                float quantidade = float.Parse(metroTextBox9.Text);
                float pesoPorUnidade = float.Parse(metroTextBox7.Text);
                float resultado = quantidade * pesoPorUnidade;
                metroTextBox8.Text = resultado.ToString();
            }
            else
            {
                metroTextBox8.Text = "";
            }

            float output2;
            if (((!string.IsNullOrEmpty(metroTextBox9.Text)) && (float.TryParse(metroTextBox9.Text.Trim(), out output2))) && (!string.IsNullOrEmpty(metroTextBox10.Text)) && (float.TryParse(metroTextBox10.Text.Trim(), out output2)))
            {
                float quantidade = float.Parse(metroTextBox9.Text);
                float pesoPorUnidade = float.Parse(metroTextBox10.Text);
                float resultado = quantidade * pesoPorUnidade;
                metroTextBox11.Text = resultado.ToString();
            }
            else
            {
                metroTextBox11.Text = "";
            }

        }

        private void metroButton22_Click(object sender, EventArgs e)
        {
            metroProgressSpinner4.Show();
            Util.WaitNSeconds(0.5);

            InsumoModels insumoModels = new InsumoModels();
            insumoModels.Nome = metroTextBox6.Text;
            insumoModels.Peso_Por_Unidade = float.Parse(metroTextBox7.Text);
            insumoModels.Unidade_De_Medida = metroComboBox4.Text.Substring(0,2).Trim();
            insumoModels.Peso_Total = float.Parse(metroTextBox8.Text);
            insumoModels.Quantidade_Estoque = int.Parse(metroTextBox9.Text);
            insumoModels.Custo = float.Parse(metroTextBox10.Text);
            insumoModels.Custo_Total = float.Parse(metroTextBox11.Text);
            insumoModels.Descricao = metroTextBox12.Text;

            InsumoDAO insumoDAO = new InsumoDAO();

            String retorno = insumoDAO.cadastrar(insumoModels);

            if (retorno == "OK")
            {
                metroProgressSpinner4.Hide();
                metroLabel37.Show();
                metroLabel37.Text = "Insumo adicionado com sucesso!";
                popularGridInsumo();
                //setReadOnlyGridPedidos(false);
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar o insumo: " + retorno);
            }

        }

        private void metroButton20_Click(object sender, EventArgs e)
        {
            metroProgressSpinner4.Show();
            Util.WaitNSeconds(0.5);
            List<int> listInsumosID = new List<int>();
            for (int i = 0; i < metroGrid2.RowCount; i++)
            {
                var checkbox = metroGrid2.Rows[i].Cells[0].Value;

                if (checkbox != null)
                {
                    if (checkbox.ToString().ToLower() == "true")
                    {
                        listInsumosID.Add(int.Parse(metroGrid2.Rows[i].Cells[2].Value.ToString()));
                    }
                }

            }

            InsumoDAO insumoDAO = new InsumoDAO();
            bool verifica = insumoDAO.excluirInsumo(listInsumosID);
            if (verifica)
            {
                metroProgressSpinner4.Hide();
                metroLabel37.Show();
                metroLabel37.Text = "Inumo(s) deletado(s) com sucesso!";
                popularGridInsumo();
                setReadOnlyGridProduto(true);
            }
        }

        private void metroGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string unidadeDeMedida = metroGrid2.Rows[e.RowIndex].Cells[6].Value.ToString();
                if (unidadeDeMedida == "Kg")
                {
                    unidadeDeMedida += " - Quilograma";
                }
                else if (unidadeDeMedida == "gr")
                {
                    unidadeDeMedida += " - Grama";
                }
                else if (unidadeDeMedida == "mg")
                {
                    unidadeDeMedida += " - Miligrama";
                }
                metroTextBox5.Text = metroGrid2.Rows[e.RowIndex].Cells[2].Value.ToString();
                metroTextBox6.Text = metroGrid2.Rows[e.RowIndex].Cells[3].Value.ToString();
                metroTextBox7.Text = metroGrid2.Rows[e.RowIndex].Cells[5].Value.ToString();
                metroComboBox4.SelectedIndex = metroComboBox4.FindStringExact(unidadeDeMedida);
                metroTextBox8.Text = metroGrid2.Rows[e.RowIndex].Cells[7].Value.ToString();
                metroTextBox9.Text = metroGrid2.Rows[e.RowIndex].Cells[9].Value.ToString();
                metroTextBox10.Text = metroGrid2.Rows[e.RowIndex].Cells[8].Value.ToString();
                metroTextBox11.Text = metroGrid2.Rows[e.RowIndex].Cells[10].Value.ToString();
                metroTextBox12.Text = metroGrid2.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            else if (e.ColumnIndex == 0)
            {
                var checkbox = metroGrid2.Rows[e.RowIndex].Cells[0].Value;

                if (checkbox != null)
                {
                    if (checkbox.ToString().ToLower() == "true")
                    {
                        metroGrid2.Rows[e.RowIndex].Cells[0].Value = false;
                    }
                    else
                    {
                        metroGrid2.Rows[e.RowIndex].Cells[0].Value = true;
                    }
                }
                else
                {
                    mgProduto.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }
        }

        private void metroButton23_Click(object sender, EventArgs e)
        {
            metroProgressSpinner3.Show();
            Util.WaitNSeconds(0.5);
            InsumoModels insumoModels = new InsumoModels();

            insumoModels.Insumo_ID = int.Parse(metroTextBox5.Text.ToString());
            insumoModels.Nome = metroTextBox6.Text;
            insumoModels.Peso_Por_Unidade = float.Parse(metroTextBox7.Text);
            insumoModels.Unidade_De_Medida = metroComboBox4.Text.Substring(0, 2).Trim();
            insumoModels.Peso_Total = float.Parse(metroTextBox8.Text);
            insumoModels.Quantidade_Estoque = int.Parse(metroTextBox9.Text);
            insumoModels.Custo = float.Parse(metroTextBox10.Text);
            insumoModels.Custo_Total = float.Parse(metroTextBox11.Text);
            insumoModels.Descricao = metroTextBox12.Text;

            InsumoDAO insumoDAO = new InsumoDAO();

            bool retorno = insumoDAO.atualizarInumos(insumoModels);

            if (retorno)
            {
                metroProgressSpinner4.Hide();
                metroLabel37.Show();
                metroLabel37.Text = "Insumo atualizado com sucesso!";
                popularGridInsumo();
                //setReadOnlyGridPedidos(false);
            }
            else
            {
                MessageBox.Show("Erro ao atualizar o insumo: " + retorno);
            }
        }
    }
}
