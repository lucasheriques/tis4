﻿using System;
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
    public partial class frmVisualizarInsumo : Form
    {
        private Form _frmPrincipal;

        private InsumoDAO insumoDAO;

        private void preencheGrid() {
            insumoDAO = new InsumoDAO();
            DataSet dataSet = insumoDAO.visualizarGrid();
            dataGridView1.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 400;
            }
        }

        private void preencheCombo() {
            this.insumoDAO = new InsumoDAO();
            DataSet dsInsumo4 = insumoDAO.preencheCombo();
            comboBox1.ValueMember = "Insumo_ID";
            comboBox1.DisplayMember = "Nome";
            comboBox1.DataSource = dsInsumo4.Tables["characters"];
        }

        public frmVisualizarInsumo(Form frmPrincipal)
        {
            InitializeComponent();
            this._frmPrincipal = frmPrincipal;
            preencheGrid();
            preencheCombo();
        }

        private void bntSair_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this._frmPrincipal.Show();
        }

        private void bntCadastrar_Click(object sender, EventArgs e)
        {
            InsumoModels insumoModels = new InsumoModels();
            if (string.IsNullOrEmpty(comboBox1.SelectedValue.ToString()))
            {
                insumoModels.Insumo_ID = 0;
                insumoModels.Nome = "%";
            }
            else {
                insumoModels.Insumo_ID = int.Parse(comboBox1.SelectedValue.ToString());
                insumoModels.Nome = "";
            }
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                insumoModels.Descricao = "%";
            }
            else {
                insumoModels.Descricao = "%" + textBox7.Text + "%";
            }

            DataSet dataSet = new DataSet();
            dataSet = insumoDAO.visualizarGridComParametros(insumoModels);
            dataGridView1.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 400;
            }
            preencheCombo();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarCliente _frmCadastrarCliente = new frmCadastrarCliente(this);
            _frmCadastrarCliente.Show();
            this.Hide();
        }

        private void insumoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarInsumo _frmCadastrarInsumo = new frmCadastrarInsumo(this);
            _frmCadastrarInsumo.Show();
            this.Close();
        }

        private void pedidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroPedido _frmCadastroPedido = new frmCadastroPedido(this);
            _frmCadastroPedido.Show();
            this.Hide();
        }

        private void produtoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarProduto _frmCadastrarProduto = new frmCadastrarProduto(this);
            _frmCadastrarProduto.Show();
            this.Hide();
        }

        private void receitaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastrarReceita _frmCadastrarReceita = new frmCadastrarReceita(this);
            _frmCadastrarReceita.Show();
            this.Hide();
        }

        private void clienteToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAtualizarCliente _frmAtualizarCliente = new frmAtualizarCliente(this);
            _frmAtualizarCliente.Show();
            this.Hide();
        }

        private void insumoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAtualizarInsumo _frmAtualizarInsumo = new frmAtualizarInsumo(this);
            _frmAtualizarInsumo.Show();
            this.Hide();
        }

        private void pedidoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAtualizarPedido _frmAtualizarPedido = new frmAtualizarPedido(this);
            _frmAtualizarPedido.Show();
            this.Hide();
        }

        private void produtoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAtualizarProduto _frmAtualizarProduto = new frmAtualizarProduto(this);
            _frmAtualizarProduto.Show();
            this.Hide();
        }

        private void clienteToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVisualizarCliente _frmVisualizarCliente = new frmVisualizarCliente(this);
            _frmVisualizarCliente.Show();
            this.Hide();
        }

        private void insumoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVisualizarInsumo _frmVisualizarInsumo = new frmVisualizarInsumo(this);
            _frmVisualizarInsumo.Show();
            this.Hide();
        }

        private void pedidoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVisualizarPedido _frmVisualizarPedido = new frmVisualizarPedido(this);
            _frmVisualizarPedido.Show();
            this.Hide();
        }

        private void produtoToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVisualizarProdutos _frmVisualizarProdutos = new frmVisualizarProdutos(this);
            _frmVisualizarProdutos.Show();
            this.Hide();
        }

        private void receitaToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmVisualizarReceita _frmVisualizarReceita = new frmVisualizarReceita(this);
            _frmVisualizarReceita.Show();
            this.Hide();
        }

        private void bancoDeDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConfiguracaoDoBancoDeDados configuracaoDoBancoDeDados = new ConfiguracaoDoBancoDeDados();
            configuracaoDoBancoDeDados.setFrmPrincipal(this);
            this.Hide();
            configuracaoDoBancoDeDados.Show();
        }
    }
}
