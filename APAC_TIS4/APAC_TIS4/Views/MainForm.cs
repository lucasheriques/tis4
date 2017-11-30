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
using System.Windows.Forms.DataVisualization.Charting;

namespace APAC_TIS4
{
    public partial class frmPrincipal : MetroForm
    {
        //Microsoft.Office.Interop.Excel.Application XcelApp = new Microsoft.Office.Interop.Excel.Application();
        private static string verificaAtualizar = "0";
        public frmPrincipal()
        {
            InitializeComponent();
            popularCliente();
            popularProduto();
            popularPedidos();
            popularComboPedidos();
            inicializarCliente();
            inicializarProdutos();
            inicializarPedidos();
            inicializarReceita();
            inicializarInsumo();
            inicializarRelatorios();
        }

        private void inicializarRelatorios() {
            //this.chartGrafico.Legends.Clear();
            //chartGrafico.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            //this.chartGrafico.Series.Add("Dados");
            if (this.chartGrafico.Series.Count > 0) {
                this.chartGrafico.Series.RemoveAt(0);
            }
            loadGrafico();
            loagGrid();

        }

        public void loagGrid() {
            RelatoriosDAO relatoriosDAO = new RelatoriosDAO();

            DataSet dataSet = relatoriosDAO.loadGrid();

            metroGrid3.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < metroGrid3.Columns.Count; i++)
            {
                metroGrid3.Columns[i].Width = 400;
            }

        }

        private void loadGrafico() {
            RelatoriosDAO relatoriosDAO = new RelatoriosDAO();
            this.chartGrafico = relatoriosDAO.loadChart(this.chartGrafico);
            //Series series = this.chartGrafico.Series["dados"];
        }
        private void inicializarCliente() {
            lblClientID.Hide();
            txtClientId.Hide();
            btnUpdateClient.Hide();
            spiClientActions.Hide();
            btnAddClient.Hide();
            btnRemoveClients.Hide();
            lblReturnLabel.Hide();
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

            gridInsumo.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < gridInsumo.Columns.Count; i++)
            {
                gridInsumo.Columns[i].Width = 400;
            }

        }

        private void inicializarReceita() {
            popularComboProdutoReceita(); //metroComboBox3
            popularReceita();
            popularInsumo(); // textBoxre3
            popularComboProdutoPesquisaReceita();
            metroTextBox1.Hide();
            metroLabel19.Hide();
            metroButton12.Hide();
            metroButton15.Hide();
            metroButton14.Hide();
        }

        private void popularComboProdutoPesquisaReceita() {
            ProdutoDAO produtoDAO = new ProdutoDAO();

            DataSet dataSet = produtoDAO.preencheCombo();
            txtProdutoPesquisa.ValueMember = "Produto_ID";
            txtProdutoPesquisa.DisplayMember = "nome";
            txtProdutoPesquisa.DataSource = dataSet.Tables["characters"];
        }

        private void popularInsumo()
        {
            listBox1.Items.Clear();
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
            PedidoDAO pedidoDAO = new PedidoDAO();

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

        private void popularComboClientePesquisar()
        {
            ClienteDAO clienteDAO = new ClienteDAO();

            DataSet dataSet = clienteDAO.preencheCombo();
            cmbClientesPesquisarReceitas.ValueMember = "Cliente_ID";
            cmbClientesPesquisarReceitas.DisplayMember = "nome";
            cmbClientesPesquisarReceitas.DataSource = dataSet.Tables["characters"];

        }

        private void popularProdutoPesquisar() {
            ProdutoDAO produtoDAO = new ProdutoDAO();

            DataSet dataSet = produtoDAO.preencheCombo();
            cmbProdutoPedidos.ValueMember = "Produto_ID";
            cmbProdutoPedidos.DisplayMember = "nome";
            cmbProdutoPedidos.DataSource = dataSet.Tables["characters"];
        }

        private void inicializarPedidos()
        {
            metroLabel18.Hide();
            metroTextBox3.Hide();
            metroButton7.Hide();
            metroButton6.Hide();
            btnExcluirPedidos.Hide();
            popularProdutoPesquisar();
            popularComboClientePesquisar();
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
            txtPesquisarNome.Clear();
            txtClientId.Clear();
            txtClientLocal.Clear();
            txtClientName.Clear();
            cmdClientType.SelectedIndex = -1;
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txtClientName.Text.ToString())) && (!string.IsNullOrEmpty(txtClientLocal.Text.ToString())) && (!string.IsNullOrEmpty(cmdClientType.Text.ToString())))
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
                    spiClientActions.Hide();
                    MessageBox.Show("Erro ao criar cliente!!!");
                }
                else if (retorno.Contains("Erro de acesso ao MySQL : "))
                {
                    spiClientActions.Hide();
                    MessageBox.Show(retorno);
                }
                else
                {
                    spiClientActions.Hide();
                    lblReturnLabel.Show();
                    lblReturnLabel.Text = "Cliente adicionado com sucesso!";
                    popularCliente();
                    clearClientFields();
                }
            }
            else {
                MessageBox.Show("Preencha os dados do cliente!!!");
            }

        }

        private void btnClientUpdateMenu_Click(object sender, EventArgs e)
        {
            lblClientID.Show();
            txtClientId.Show();
            btnAddClient.Hide();
            btnUpdateClient.Show();
            lblReturnLabel.Hide();
            btnRemoveClients.Hide();
        }

        private void btnClientAddMenu_Click(object sender, EventArgs e)
        {
            lblClientID.Hide();
            txtClientId.Hide();
            btnAddClient.Show();
            btnUpdateClient.Hide();
            lblReturnLabel.Hide();
            btnRemoveClients.Hide();
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
            if (!verificaPreenchimentoCamposClientes())
            {
                spiClientActions.Show();
                Util.WaitNSeconds(0.5);

                if (string.IsNullOrEmpty(cmdClientType.Text))
                {
                    MessageBox.Show("Selecione o Cliente que deseja atualizar.");
                    spiClientActions.Hide();
                    return;
                }

                List<ClientModel> listClienteModels = new List<ClientModel>();

                ClientModel clienteModels = new ClientModel();

                clienteModels.Cliente_ID = int.Parse(txtClientId.Text.ToString());
                clienteModels.nome = txtClientName.Text;
                clienteModels.localidade = txtClientLocal.Text;
                clienteModels.Tipo = cmdClientType.Text;

                listClienteModels.Add(clienteModels);

                ClienteDAO clienteDAO = new ClienteDAO();
                bool verifica = clienteDAO.atualizarClientes(listClienteModels);
                if (verifica)
                {
                    lblReturnLabel.Show();
                    lblReturnLabel.Text = "Cliente atualizado com sucesso!";
                    spiClientActions.Hide();
                    popularCliente();
                    clearClientFields();
                }
                else
                {
                    lblReturnLabel.Hide();
                    spiClientActions.Hide();
                    popularCliente();
                    MessageBox.Show("Erro ao atualizar cliente!!!");
                }
            }
            else {
                MessageBox.Show("O(s) dado(s) deve(m) ser preenchido(s)!!!");
            }
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
            cmbTipoPesquisar.SelectedIndex = -1;
            txtNomePesquisar.Text = "";

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
            if (!verificaPreenchimentoCamposProdutos())
            {
                spiClientActions.Show();
                Util.WaitNSeconds(0.5);
                ProdutoModels produtoModels = new ProdutoModels();

                produtoModels.Tipo = mcmbTipo.Text;
                produtoModels.Tamanho = mcmbTamanho.Text;
                produtoModels.UDM = mcmbUDM.Text.Substring(0, 2).Trim();
                produtoModels.Peso = float.Parse(mtxtPeso.Text);
                produtoModels.Nome = mtxtNome.Text;
                produtoModels.CustoPorUnidade = float.Parse(mtxtCustoPorUnidade.Text);
                produtoModels.PrecoDeVendaUnidade = float.Parse(mtxtPVU.Text);
                produtoModels.Descricao = mtxtDescricao.Text;

                ProdutoDAO produtoDAO = new ProdutoDAO();
                string retorno = produtoDAO.cadastrar(produtoModels);

                if (retorno == "OK")
                {
                    metroProgressSpinner1.Hide();
                    metroLabel9.Show();
                    metroLabel9.Text = "Produto adicionado com sucesso!";
                    popularProduto();
                    clearProductFields();
                    setReadOnlyGridProduto(false);
                }
                else
                {
                    metroProgressSpinner1.Hide();
                    metroLabel9.Show();
                    MessageBox.Show("Erro ao cadastrar produto: " + retorno);
                    popularProduto();
                    setReadOnlyGridProduto(false);
                }
            }
            else {
                MessageBox.Show("O(s) campo(s) deve(m) ser preenchido(s)!!!");
            }
        }

        private bool verificaPreenchimentoCamposProdutos() {
            if (string.IsNullOrEmpty(mtxtID.Text) && string.IsNullOrEmpty(mcmbTipo.Text) 
                && string.IsNullOrEmpty(mcmbTamanho.Text) && string.IsNullOrEmpty(mtxtPeso.Text)
                && string.IsNullOrEmpty(mcmbUDM.Text) && string.IsNullOrEmpty(mtxtNome.Text)
                && string.IsNullOrEmpty(mtxtCustoPorUnidade.Text) && string.IsNullOrEmpty(mtxtPVU.Text)
                && string.IsNullOrEmpty(mtxtDescricao.Text)) {
                return true;
            }
            return false;
        }

        private void mbAtualizarProdutos_Click(object sender, EventArgs e)
        {
            if (!verificaPreenchimentoCamposProdutos())
            {
                metroProgressSpinner1.Show();
                Util.WaitNSeconds(0.5);

                if (string.IsNullOrEmpty(mcmbTipo.Text))
                {
                    MessageBox.Show("Selecione o Produto que deseja atualizar.");
                    return;
                }


                List<ProdutoModels> listProdutoModels = new List<ProdutoModels>();

                ProdutoModels produtoModels = new ProdutoModels();

                produtoModels.Produto_ID = int.Parse(mtxtID.Text);
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
                if (verifica)
                {
                    metroProgressSpinner1.Hide();
                    metroLabel9.Show();
                    metroLabel9.Text = "Produto atualizado com sucesso!";
                    popularProduto();
                    clearProductFields();
                    setReadOnlyGridProduto(true);
                }
                else
                {
                    metroProgressSpinner1.Hide();
                    metroLabel9.Hide();
                    MessageBox.Show("Erro ao atualizar produto!!!");
                    popularProduto();
                    setReadOnlyGridProduto(true);
                }
            }
            else {
                MessageBox.Show("O(s) campo(s) deve(m) ser preenchido(s)!!!");
            }

        }

        private void metroTextBox1_TextChanged(object sender, EventArgs e)
        {
            Util util2 = new Util();
            string strQuantidade2 = mtxtQantidade.Text;
            if (!util2.IsFloatOrInt(strQuantidade2)) {
                return;
            }

            if (verificaAtualizar == "2") {
                verificaAtualizar = "0";
                return;
            }
            string quantidadeStr = mtxtQantidade.Text.ToString();
            if (metroComboBox2.SelectedValue != null || !string.IsNullOrEmpty(quantidadeStr) || !string.IsNullOrWhiteSpace(quantidadeStr)) {
                string strProduto_ID = metroComboBox2.SelectedValue.ToString();
                if (!string.IsNullOrEmpty(strProduto_ID) || !string.IsNullOrWhiteSpace(strProduto_ID))
                {
                    string strQuantidade = mtxtQantidade.Text.ToString();
                    Util util = new Util();
                    if (util.IsFloatOrInt(strProduto_ID) && util.IsFloatOrInt(strQuantidade)) {
                        int produto_ID = int.Parse(strProduto_ID);

                        ProdutoDAO produtoDAO = new ProdutoDAO();

                        float precodeVendaUnidade = produtoDAO.getPrecoDeVendaUnidade(produto_ID);

                        float quantidade = float.Parse(mtxtQantidade.Text.ToString());

                        float precoTotal = precodeVendaUnidade * quantidade;

                        metroTextBox2.Text = precoTotal.ToString();
                    }
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
            if (verificaDadosPreenchidosPedidos())
            {
                metroProgressSpinner2.Show();
                Util.WaitNSeconds(0.5);

                PedidoModels pedidoModels = new PedidoModels();
                pedidoModels.Pedido_ID = int.Parse(metroTextBox3.Text.ToString());

                pedidoModels._ItemPedido = new ItemPedido();
                pedidoModels._ItemPedido.Cliente_ID = int.Parse(metroComboBox1.SelectedValue.ToString());
                pedidoModels._ItemPedido.Produto_ID = int.Parse(metroComboBox2.SelectedValue.ToString());
                pedidoModels.Data_Pedido = dateTimePicker1.Value.Date;
                pedidoModels.Data_Entrega = dateTimePicker2.Value.Date;
                pedidoModels._ItemPedido.Quantidade = int.Parse(mtxtQantidade.Text);
                pedidoModels.PrecoTotal = float.Parse(metroTextBox2.Text);

                PedidoDAO pedidoDAO = new PedidoDAO();

                bool verificaAtualizacao = pedidoDAO.atualizar(pedidoModels);
                if (verificaAtualizacao)
                {
                    metroProgressSpinner2.Hide();
                    metroLabel16.Show();
                    metroLabel16.Text = "Pedido atualizado com sucesso!";
                    popularPedidos();
                    clearPedidos();
                    setReadOnlyGridPedidos(true);
                }
                else
                {
                    MessageBox.Show("Erro na atualização dos dados.");
                }
            }
            else {
                metroLabel16.Hide();
                MessageBox.Show("O(s) dado(s) deve(m) ser preenchido(s)!!!");
            }
        }

        private void metroButton6_Click(object sender, EventArgs e)
        {
            if (!verificaDadosPreenchidosPedidos())
            {
                metroProgressSpinner2.Show();
                Util.WaitNSeconds(0.5);

                PedidoModels pedidoModels = new PedidoModels();

                pedidoModels._ItemPedido = new ItemPedido();
                pedidoModels._ItemPedido.Cliente_ID = int.Parse(metroComboBox1.SelectedValue.ToString());
                pedidoModels._ItemPedido.Produto_ID = int.Parse(metroComboBox2.SelectedValue.ToString());
                pedidoModels.Data_Pedido = dateTimePicker1.Value.Date;
                pedidoModels.Data_Entrega = dateTimePicker2.Value.Date;
                pedidoModels._ItemPedido.Quantidade = int.Parse(mtxtQantidade.Text);
                pedidoModels.PrecoTotal = float.Parse(metroTextBox2.Text);


                PedidoDAO pedidoDAO = new PedidoDAO();

                String retorno = pedidoDAO.cadastrar(pedidoModels);

                if (retorno == "OK")
                {
                    metroProgressSpinner2.Hide();
                    metroLabel16.Show();
                    metroLabel16.Text = "Pedido adicionado com sucesso!";
                    popularPedidos();
                    clearPedidos();
                    setReadOnlyGridPedidos(false);
                }
                else
                {
                    metroProgressSpinner2.Hide();
                    MessageBox.Show("Erro ao cadastrar Pedido: " + retorno);
                }
            }
            else
            {
                metroLabel16.Hide();
                MessageBox.Show("O(s) dado(s) deve(m) ser preenchido(s)!!!");
            }
        }

        private void metroButton4_Click(object sender, EventArgs e)
        {
            metroLabel18.Hide();
            metroTextBox3.Hide();
            metroButton7.Hide();
            metroButton6.Show();
            btnExcluirPedidos.Hide();
            setReadOnlyGridPedidos(false);
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            metroLabel18.Show();
            metroTextBox3.Show();
            metroButton7.Show();
            metroButton6.Hide();
            btnExcluirPedidos.Hide();
            setReadOnlyGridPedidos(true);
        }

        private void metroButton5_Click(object sender, EventArgs e)
        {
            clearPedidosFields();
        }

        private void clearPedidosFields() {
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
            metroProgressSpinner1.Show();
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
                metroProgressSpinner1.Hide();
                metroLabel9.Show();
                metroLabel9.Text = "Produto(s) deletado(s) com sucesso!";
                popularProduto();
                setReadOnlyGridProduto(true);
            }
            else {
                metroProgressSpinner1.Hide();
                metroLabel9.Hide();
                MessageBox.Show("Erro ao apagar o(s) produto(s)!!!");
                popularProduto();
                setReadOnlyGridProduto(true);
            }

        }

/*        private void clearProducts() {
            mcmbTipo.Text = "";
            mcmbTamanho.Text = "";
            mcmbUDM.Text = "";
            mtxtPeso.Text = "";
            mtxtNome.Text = "";
            mtxtCustoPorUnidade.Text = "";
            mtxtPVU.Text = "";
            mtxtDescricao.Text = "";
        }*/

        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroLabel18.Hide();
            metroTextBox3.Hide();
            metroButton7.Hide();
            metroButton6.Hide();
            btnExcluirPedidos.Show();
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

        private bool verificaDadosPreenchidosPedidos() {
            if ((!string.IsNullOrEmpty(metroTextBox3.Text)) && (!string.IsNullOrEmpty(metroComboBox1.Text)) && (!string.IsNullOrEmpty(mtxtQantidade.Text) && !string.IsNullOrEmpty(metroTextBox2.Text))) {
                return true;
            }
            return false;
        }

        private void metroButton8_Click(object sender, EventArgs e)
        {
            metroProgressSpinner2.Show();
            Util.WaitNSeconds(0.5);
            List<Tuple<int, int>> listPedidosID = new List<Tuple<int, int>>();
            for (int i = 0; i < dvgPedidos.RowCount; i++)
            {
                PedidoModels pedidoModels = new PedidoModels();

                var checkbox = dvgPedidos.Rows[i].Cells[0].Value;

                if (checkbox != null)
                {
                    if (checkbox.ToString().ToLower() == "true")
                    {
                        listPedidosID.Add(new Tuple<int, int>(int.Parse(dvgPedidos.Rows[i].Cells[2].Value.ToString()), int.Parse(dvgPedidos.Rows[i].Cells[14].Value.ToString())));
                    }
                }

            }

            PedidoDAO pedidoDAO = new PedidoDAO();
            bool verifica = pedidoDAO.excluirPedidos(listPedidosID);
            if (verifica)
            {
                metroProgressSpinner2.Hide();
                metroLabel16.Show();
                metroLabel16.Text = "Pedidos(s) deletado(s) com sucesso!";
                popularPedidos();
                clearPedidos();
                setReadOnlyGridProduto(true);
            }
            else
            {
                metroProgressSpinner2.Hide();
                metroLabel16.Hide();
                MessageBox.Show("Erro ao deletar Pedidos(s)!!");
                popularPedidos();
                clearPedidos();
                setReadOnlyGridProduto(true);
            }
        }

        private void clearPedidos() {
            metroComboBox1.SelectedIndex = -1;
            metroComboBox2.SelectedIndex = -1;
            mtxtQantidade.Text = "";
            metroTextBox2.Text = "";
            metroTextBox3.Text = "";
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
            clearReceitaFields();
        }

        private void clearReceitaFields()
        {
            txtProdutoPesquisa.SelectedIndex = -1;
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
            if (!verificaPreenchimentoCamposReceita()) {
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
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    nomeInsumo[i] = listBox2.Items[i].ToString();
                }

                foreach (string nome in nomeInsumo)
                {
                    InsumoModels insumoModels = new InsumoModels();
                    insumoModels.Nome = nome;
                    receita.Receita_Insumo.Insumo.Add(insumoModels);
                }
                //receita.Receita_Insumo.Insumo
                string[] strPeso = textBox4.Text.Split('\n');
                receita.Receita_Insumo.Peso = new List<float>();
                for (int i = 0; i < strPeso.Length; i++)
                {
                    receita.Receita_Insumo.Peso.Add(float.Parse(strPeso[i].ToString()));
                }

                string[] strUnidadeDeMedida = textBox5.Text.Split('\n');
                receita.Receita_Insumo.UnidadeDeMedida = new List<string>();
                for (int i = 0; i < strUnidadeDeMedida.Length; i++)
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
                    clearReceita();
                    //setReadOnlyGridPedidos(false);
                }
                else
                {
                    metroProgressSpinner3.Hide();
                    metroLabel23.Hide();
                    MessageBox.Show("Erro ao cadastrar a receita: " + retorno);
                    clearReceita();
                }
            }
            else
            {
                MessageBox.Show("O(s) campo(s) deve(m) ser preenchido(s)!!!");
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
            metroProgressSpinner3.Show();
            Util.WaitNSeconds(0.5);
            List<Tuple<int, int>> listReceitaID = new List<Tuple<int, int>>();
            for (int i = 0; i < metroGrid1.RowCount; i++)
            {
                ReceitaModels pedidoModels = new ReceitaModels();

                var checkbox = metroGrid1.Rows[i].Cells[0].Value;

                if (checkbox != null)
                {
                    if (checkbox.ToString().ToLower() == "true")
                    {
                        listReceitaID.Add(new Tuple<int, int>(int.Parse(metroGrid1.Rows[i].Cells[2].Value.ToString()), int.Parse(metroGrid1.Rows[i].Cells[14].Value.ToString())));
                    }
                }
            }

            ReceitaDAO receitaDAO = new ReceitaDAO();
            bool verifica = receitaDAO.excluirPedidos(listReceitaID);
            if (verifica)
            {
                metroProgressSpinner3.Hide();
                metroLabel23.Show();
                metroLabel23.Text = "Receitas(s) deletada(s) com sucesso!";
                popularReceita();
                clearReceita();
            }
            else {
                metroProgressSpinner3.Hide();
                metroLabel23.Hide();
                MessageBox.Show("Erro ao apagar receitas(s)!");
                popularReceita();
                clearReceita();
            }
        }

        private void clearReceita()
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

                for (int i = 0; i < listBox1.Items.Count; i++) {
                    if (listBox1.Items[i].ToString().Equals(metroGrid1.Rows[e.RowIndex].Cells[9].Value.ToString())) {
                        listBox1.Items.RemoveAt(i);
                    }
                }
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

        private bool verificaPreenchimentoCamposReceita() {
            if (string.IsNullOrEmpty(metroTextBox1.Text) && string.IsNullOrEmpty(metroComboBox3.Text)
                 && string.IsNullOrEmpty(metroTextBox4.Text) && string.IsNullOrEmpty(textBox1.Text)
                  && string.IsNullOrEmpty(listBox2.Text) && string.IsNullOrEmpty(textBox4.Text)
                   && string.IsNullOrEmpty(textBox5.Text)) {
                return true;
            }
            return false;
        }

        private void metroButton15_Click(object sender, EventArgs e)
        {
            if (!verificaPreenchimentoCamposReceita())
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
                    clearReceita();
                    //setReadOnlyGridPedidos(true);
                }
                else
                {
                    metroProgressSpinner3.Hide();
                    metroLabel23.Hide();
                    clearReceita();
                    MessageBox.Show("Erro na atualização dos dados.");
                }
            }

            else {
                MessageBox.Show("O(s) campo(s) deve(m) ser preenchido(s)!!!");
            }
        }

        private void metroButton16_Click(object sender, EventArgs e)
        {
            /*if (metroGrid1.Rows.Count > 0)
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 3; i < metroGrid1.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i - 2] = metroGrid1.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < metroGrid1.Rows.Count; i++)
                    {
                        for (int j = 2; j < metroGrid1.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j - 1] = metroGrid1.Rows[i].Cells[j].Value.ToString();
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
            else {
                MessageBox.Show("Não existem dados para serem exportados!!!");
            }*/
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
            clearInsumoFields();
        }

        private void clearInsumoFields() {
            txtNomePesquisarInsumo.Clear();
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
            insumoModels.Unidade_De_Medida = metroComboBox4.Text.Substring(0, 2).Trim();
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
                clearInsumo();
                //setReadOnlyGridPedidos(false);
            }
            else
            {
                metroProgressSpinner4.Hide();
                metroLabel37.Hide();
                MessageBox.Show("Erro ao cadastrar o insumo: " + retorno);
                clearInsumo();
            }

        }

        private void metroButton20_Click(object sender, EventArgs e)
        {
            metroProgressSpinner4.Show();
            Util.WaitNSeconds(0.5);
            List<int> listInsumosID = new List<int>();
            for (int i = 0; i < gridInsumo.RowCount; i++)
            {
                var checkbox = gridInsumo.Rows[i].Cells[0].Value;

                if (checkbox != null)
                {
                    if (checkbox.ToString().ToLower() == "true")
                    {
                        listInsumosID.Add(int.Parse(gridInsumo.Rows[i].Cells[2].Value.ToString()));
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
                clearInsumo();
            }
            else {
                metroProgressSpinner4.Hide();
                metroLabel37.Hide();
                MessageBox.Show("Erro ao apagar inumo(s)!!!");
                popularGridInsumo();
                clearInsumo();
            }
        }

        private void clearInsumo()
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

        private void metroGrid2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                string unidadeDeMedida = gridInsumo.Rows[e.RowIndex].Cells[6].Value.ToString();
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
                metroTextBox5.Text = gridInsumo.Rows[e.RowIndex].Cells[2].Value.ToString();
                metroTextBox6.Text = gridInsumo.Rows[e.RowIndex].Cells[3].Value.ToString();
                metroTextBox7.Text = gridInsumo.Rows[e.RowIndex].Cells[5].Value.ToString();
                metroComboBox4.SelectedIndex = metroComboBox4.FindStringExact(unidadeDeMedida);
                metroTextBox8.Text = gridInsumo.Rows[e.RowIndex].Cells[7].Value.ToString();
                metroTextBox9.Text = gridInsumo.Rows[e.RowIndex].Cells[9].Value.ToString();
                metroTextBox10.Text = gridInsumo.Rows[e.RowIndex].Cells[8].Value.ToString();
                metroTextBox11.Text = gridInsumo.Rows[e.RowIndex].Cells[10].Value.ToString();
                metroTextBox12.Text = gridInsumo.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
            else if (e.ColumnIndex == 0)
            {
                var checkbox = gridInsumo.Rows[e.RowIndex].Cells[0].Value;

                if (checkbox != null)
                {
                    if (checkbox.ToString().ToLower() == "true")
                    {
                        gridInsumo.Rows[e.RowIndex].Cells[0].Value = false;
                    }
                    else
                    {
                        gridInsumo.Rows[e.RowIndex].Cells[0].Value = true;
                    }
                }
                else
                {
                    mgProduto.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }
        }

        private bool verificaPreenchimentoCamposInsumos() {
            if (string.IsNullOrEmpty(metroTextBox5.Text) && string.IsNullOrEmpty(metroTextBox6.Text)
                && string.IsNullOrEmpty(metroTextBox7.Text) && string.IsNullOrEmpty(metroComboBox4.Text)
                && string.IsNullOrEmpty(metroTextBox8.Text) && string.IsNullOrEmpty(metroTextBox9.Text)
                && string.IsNullOrEmpty(metroTextBox10.Text) && string.IsNullOrEmpty(metroTextBox11.Text)
                && string.IsNullOrEmpty(metroTextBox12.Text)) {
                return true;
            }
            return false;
        }

        private void metroButton23_Click(object sender, EventArgs e)
        {
            if (!verificaPreenchimentoCamposInsumos())
            {
                metroProgressSpinner4.Show();
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
                    clearInsumo();
                    //setReadOnlyGridPedidos(false);
                }
                else
                {
                    metroProgressSpinner4.Hide();
                    metroLabel37.Hide();
                    clearInsumo();
                    MessageBox.Show("Erro ao atualizar o insumo: " + retorno);
                }
            }
            else {
                MessageBox.Show("O(s) campo(s) deve(m) ser preenchido(s)");
            }
        }

        private void metroButton24_Click(object sender, EventArgs e)
        {
            /*if (dvgClientes.Rows.Count > 0)
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 3; i < dvgClientes.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i - 2] = dvgClientes.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < dvgClientes.Rows.Count; i++)
                    {
                        for (int j = 2; j < dvgClientes.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j - 1] = dvgClientes.Rows[i].Cells[j].Value.ToString();
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
            }*/
        }

        private void metroButton25_Click(object sender, EventArgs e)
        {
            /*if (mgProduto.Rows.Count > 0)
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 3; i < mgProduto.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i - 2] = mgProduto.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < mgProduto.Rows.Count; i++)
                    {
                        for (int j = 2; j < mgProduto.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j - 1] = mgProduto.Rows[i].Cells[j].Value.ToString();
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
            }*/
        }

        private void metroButton26_Click(object sender, EventArgs e)
        {
            /*if (dvgPedidos.Rows.Count > 0)
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 3; i < dvgPedidos.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i - 2] = dvgPedidos.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < dvgPedidos.Rows.Count; i++)
                    {
                        for (int j = 2; j < dvgPedidos.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j - 1] = dvgPedidos.Rows[i].Cells[j].Value.ToString();
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
            }*/
        }

        private void btnClientDelMenu_Click(object sender, EventArgs e)
        {
            lblClientID.Hide();
            txtClientId.Hide();
            btnAddClient.Hide();
            btnUpdateClient.Hide();
            lblReturnLabel.Hide();
            btnRemoveClients.Show();
        }

        private void metroButton27_Click(object sender, EventArgs e)
        {
            spiClientActions.Show();
            Util.WaitNSeconds(0.5);

            List<int> listClienteID = new List<int>();

            for (int i = 0; i < dvgClientes.RowCount; i++)
            {
                var checkbox = dvgClientes.Rows[i].Cells[0].Value;

                if (checkbox != null)
                {
                    if (checkbox.ToString().ToLower() == "true")
                    {
                        listClienteID.Add(int.Parse(dvgClientes.Rows[i].Cells[2].Value.ToString()));
                    }
                }

            }

            ClienteDAO clienteDAO = new ClienteDAO();
            bool verifica = clienteDAO.excluirClientes(listClienteID);
            if (verifica)
            {
                lblReturnLabel.Show();
                lblReturnLabel.Text = "Cliente(s) deletado(s) com sucesso!";
                spiClientActions.Hide();
                popularCliente();
            }

        }

        private void dvgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                txtClientId.Text = dvgClientes.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtClientName.Text = dvgClientes.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtClientLocal.Text = dvgClientes.Rows[e.RowIndex].Cells[4].Value.ToString();
                cmdClientType.SelectedIndex = cmdClientType.FindStringExact(dvgClientes.Rows[e.RowIndex].Cells[5].Value.ToString());
            }
            else if (e.ColumnIndex == 0)
            {
                var checkbox = dvgClientes.Rows[e.RowIndex].Cells[0].Value;

                if (checkbox != null)
                {
                    if (checkbox.ToString().ToLower() == "true")
                    {
                        dvgClientes.Rows[e.RowIndex].Cells[0].Value = false;
                    }
                    else
                    {
                        dvgClientes.Rows[e.RowIndex].Cells[0].Value = true;
                    }
                }
                else
                {
                    dvgClientes.Rows[e.RowIndex].Cells[0].Value = true;
                }
            }
        }

        private void metroButton28_Click(object sender, EventArgs e)
        {
            /*if (metroGrid3.Rows.Count > 0)
            {
                try
                {
                    XcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 3; i < metroGrid3.Columns.Count + 1; i++)
                    {
                        XcelApp.Cells[1, i - 2] = metroGrid3.Columns[i - 1].HeaderText;
                    }
                    //
                    for (int i = 0; i < metroGrid3.Rows.Count; i++)
                    {
                        for (int j = 2; j < metroGrid3.Columns.Count; j++)
                        {
                            XcelApp.Cells[i + 2, j - 1] = metroGrid3.Rows[i].Cells[j].Value.ToString();
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
            }*/
        }

        private void entityTab_TabIndexChanged(object sender, EventArgs e)
        {
            /*            popularCliente();
                        popularProduto();
                        popularPedidos();
                        popularComboPedidos();
                        inicializarCliente();
                        inicializarProdutos();
                        inicializarPedidos();
                        inicializarReceita();
                        inicializarInsumo();
                        inicializarRelatorios();
                        clearClientFields();
                        clearProductFields();
                        clearPedidosFields();
                        clearInsumoFields();
                        clearReceitaFields();
              */
        }

        private void entityTab_Selected(object sender, TabControlEventArgs e)
        {
            popularCliente();
            popularProduto();
            popularPedidos();
            popularComboPedidos();
            inicializarCliente();
            inicializarProdutos();
            inicializarPedidos();
            inicializarReceita();
            inicializarInsumo();
            inicializarRelatorios();
            clearClientFields();
            clearProductFields();
            clearPedidosFields();
            clearInsumoFields();
            clearReceitaFields();
        }

        private bool verificaPreenchimentoCamposClientes() {
            if (!string.IsNullOrEmpty(txtClientId.Text) && !string.IsNullOrEmpty(txtClientName.Text) && !string.IsNullOrEmpty(cmdClientType.Text) && !string.IsNullOrEmpty(txtClientLocal.Text)) {
                return false;
            }
            return true;
        }

        private void bntPesquisar_Click(object sender, EventArgs e)
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            string nomeCliente = txtPesquisarNome.Text;

            if (string.IsNullOrEmpty(nomeCliente)) {
                nomeCliente = "%%%";
            }

            DataSet dataSet = clienteDAO.pesquisaPorNome(nomeCliente);

            dvgClientes.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dvgClientes.Columns.Count; i++)
            {
                dvgClientes.Columns[i].Width = 400;
            }

        }

        private void bntPesquisarProduto_Click(object sender, EventArgs e)
        {
            string strTipo = cmbTipoPesquisar.Text;
            string strNome = txtNomePesquisar.Text.ToString();

            ProdutoDAO produtoDAO = new ProdutoDAO();

            DataSet dataSet = produtoDAO.visualizarGridComNomeTtipo(strTipo, strNome);

            mgProduto.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < mgProduto.Columns.Count; i++)
            {
                mgProduto.Columns[i].Width = 400;
            }
        }

        private void bntPesquisarInsumo_Click(object sender, EventArgs e)
        {
            string strNome = txtNomePesquisarInsumo.Text.ToString();

            InsumoDAO insumoDAO = new InsumoDAO();

            DataSet dataSet = insumoDAO.visualizarGridComNome(strNome);

            gridInsumo.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < gridInsumo.Columns.Count; i++)
            {
                gridInsumo.Columns[i].Width = 400;
            }
        }

        private void btnPesquisarReceita_Click(object sender, EventArgs e)
        {
            string produto_ID = txtProdutoPesquisa.SelectedValue.ToString();
            if (string.IsNullOrEmpty(produto_ID)) {
                produto_ID = "%%%";
            }

            ReceitaDAO receitaDAO = new ReceitaDAO();

            DataSet dataSet = receitaDAO.visualizarGridComIDPorProduto(produto_ID);

            metroGrid1.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < metroGrid1.Columns.Count; i++)
            {
                metroGrid1.Columns[i].Width = 400;
            }

        }

        private void bntPesquisarPedido_Click(object sender, EventArgs e)
        {
            int clienteID = 0;
            int produtoID = 0;
            if (!string.IsNullOrEmpty(cmbClientesPesquisarReceitas.SelectedValue.ToString()) || cmbClientesPesquisarReceitas.SelectedValue.ToString() != "") {
                clienteID = int.Parse(cmbClientesPesquisarReceitas.SelectedValue.ToString());
            }

            if (!string.IsNullOrEmpty(cmbProdutoPedidos.SelectedValue.ToString()) || cmbProdutoPedidos.SelectedValue.ToString() != "") {
                produtoID = int.Parse(cmbProdutoPedidos.SelectedValue.ToString());
            }

            PedidoDAO pedidoDAO = new PedidoDAO();

            DataSet dataSet = pedidoDAO.visualizarGridComIDClienteProduto(clienteID, produtoID);

            dvgPedidos.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dvgPedidos.Columns.Count; i++)
            {
                dvgPedidos.Columns[i].Width = 400;
            }

        }

        private void clientPage_Click(object sender, EventArgs e)
        {

        }

        private void ReceitaPage_Click(object sender, EventArgs e)
        {

        }

        private void chartGrafico_Click(object sender, EventArgs e)
        {

        }

        private void mcmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mtxtNome_Click(object sender, EventArgs e)
        {

        }
    }
}
