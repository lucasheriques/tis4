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
    public partial class frmCadastrarReceita : Form
    {
        private Form _frmPrincipal;

        public frmCadastrarReceita(Form frmPrincipal)
        {
            InitializeComponent();
            this._frmPrincipal = frmPrincipal;
            preencheCombos();
            preencheGrid();
        }

        private void preencheGrid() {
            ReceitaDAO receitaDAO = new ReceitaDAO();
            DataSet dataSet = receitaDAO.visualizarGrid();

            dataGridView1.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 400;
            }
        }

        private void preencheCombos() {
            ProdutoDAO produtoDAO = new ProdutoDAO();

            DataSet dsProduto = produtoDAO.preencheCombo();
            comboBox1.ValueMember = "Produto_ID";
            comboBox1.DisplayMember = "nome";
            comboBox1.DataSource = dsProduto.Tables["characters"];

            InsumoDAO insumoDAO = new InsumoDAO();
            DataSet dsInsumo = insumoDAO.preencheCombo();
            comboBox2.ValueMember = "Insumo_ID";
            comboBox2.DisplayMember = "Nome";
            comboBox2.DataSource = dsInsumo.Tables["characters"];

            DataSet dsInsumo2 = insumoDAO.preencheCombo();
            comboBox3.ValueMember = "Insumo_ID";
            comboBox3.DisplayMember = "Nome";
            comboBox3.DataSource = dsInsumo2.Tables["characters"];

            DataSet dsInsumo3 = insumoDAO.preencheCombo();
            comboBox4.ValueMember = "Insumo_ID";
            comboBox4.DisplayMember = "Nome";
            comboBox4.DataSource = dsInsumo3.Tables["characters"];

            DataSet dsInsumo4 = insumoDAO.preencheCombo();
            comboBox5.ValueMember = "Insumo_ID";
            comboBox5.DisplayMember = "Nome";
            comboBox5.DataSource = dsInsumo4.Tables["characters"];

            DataSet dsInsumo5 = insumoDAO.preencheCombo();
            comboBox6.ValueMember = "Insumo_ID";
            comboBox6.DisplayMember = "Nome";
            comboBox6.DataSource = dsInsumo5.Tables["characters"];

            DataSet dsInsumo6 = insumoDAO.preencheCombo();
            comboBox7.ValueMember = "Insumo_ID";
            comboBox7.DisplayMember = "Nome";
            comboBox7.DataSource = dsInsumo6.Tables["characters"];

            DataSet dsInsumo7 = insumoDAO.preencheCombo();
            comboBox8.ValueMember = "Insumo_ID";
            comboBox8.DisplayMember = "Nome";
            comboBox8.DataSource = dsInsumo7.Tables["characters"];

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
            ReceitaModels receita = new ReceitaModels();
            receita.Observacao = textBox2.Text;
            receita.ModoDePreparo = textBox1.Text;
            receita.Produto = new ProdutoModels();
            receita.Produto.Produto_ID = int.Parse(comboBox1.SelectedValue.ToString());

            receita.Receita_Insumo = new Receita_InsumoModels();
            receita.Receita_Insumo.Insumo = new List<InsumoModels>();
            receita.Receita_Insumo.UnidadeDeMedida = new List<string>();

            if (!string.IsNullOrEmpty(comboBox2.SelectedValue.ToString()))
            {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Insumo_ID = int.Parse(comboBox2.SelectedValue.ToString());
                receita.Receita_Insumo.Insumo.Add(insumoModels);
                receita.Receita_Insumo.UnidadeDeMedida.Add(textBox3.Text);
            }
            else {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Insumo_ID = 0;
                receita.Receita_Insumo.Insumo.Add(insumoModels);
                receita.Receita_Insumo.UnidadeDeMedida.Add("---");
            }

            if (!string.IsNullOrEmpty(comboBox3.SelectedValue.ToString()))
            {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Insumo_ID = int.Parse(comboBox3.SelectedValue.ToString());
                receita.Receita_Insumo.Insumo.Add(insumoModels);
                receita.Receita_Insumo.UnidadeDeMedida.Add(textBox4.Text);
            }
            else {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Insumo_ID = 0;
                receita.Receita_Insumo.Insumo.Add(insumoModels);
                receita.Receita_Insumo.UnidadeDeMedida.Add("---");
            }

            if (!string.IsNullOrEmpty(comboBox4.SelectedValue.ToString()))
            {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Insumo_ID = int.Parse(comboBox4.SelectedValue.ToString());
                receita.Receita_Insumo.Insumo.Add(insumoModels);
                receita.Receita_Insumo.UnidadeDeMedida.Add(textBox5.Text);
            }
            else {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Insumo_ID = 0;
                receita.Receita_Insumo.Insumo.Add(insumoModels);
                receita.Receita_Insumo.UnidadeDeMedida.Add("---");
            }

            if (!string.IsNullOrEmpty(comboBox5.SelectedValue.ToString()))
            {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Insumo_ID = int.Parse(comboBox5.SelectedValue.ToString());
                receita.Receita_Insumo.Insumo.Add(insumoModels);
                receita.Receita_Insumo.UnidadeDeMedida.Add(textBox6.Text);
            }
            else {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Insumo_ID = 0;
                receita.Receita_Insumo.Insumo.Add(insumoModels);
                receita.Receita_Insumo.UnidadeDeMedida.Add("---");
            }

            if (!string.IsNullOrEmpty(comboBox6.SelectedValue.ToString()))
            {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Insumo_ID = int.Parse(comboBox6.SelectedValue.ToString());
                receita.Receita_Insumo.Insumo.Add(insumoModels);
                receita.Receita_Insumo.UnidadeDeMedida.Add(textBox7.Text);
            }
            else {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Insumo_ID = 0;
                receita.Receita_Insumo.Insumo.Add(insumoModels);
                receita.Receita_Insumo.UnidadeDeMedida.Add("---");
            }

            if (!string.IsNullOrEmpty(comboBox7.SelectedValue.ToString()))
            {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Insumo_ID = int.Parse(comboBox7.SelectedValue.ToString());
                receita.Receita_Insumo.Insumo.Add(insumoModels);
                receita.Receita_Insumo.UnidadeDeMedida.Add(textBox8.Text);
            }
            else {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Insumo_ID = 0;
                receita.Receita_Insumo.Insumo.Add(insumoModels);
                receita.Receita_Insumo.UnidadeDeMedida.Add("---");
            }

            if (!string.IsNullOrEmpty(comboBox8.SelectedValue.ToString()))
            {
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Insumo_ID = int.Parse(comboBox8.SelectedValue.ToString());
                receita.Receita_Insumo.Insumo.Add(insumoModels);
                receita.Receita_Insumo.UnidadeDeMedida.Add(textBox9.Text);
            }
            else{
                InsumoModels insumoModels = new InsumoModels();
                insumoModels.Insumo_ID = 0;
                receita.Receita_Insumo.Insumo.Add(insumoModels);
                receita.Receita_Insumo.UnidadeDeMedida.Add("---");
            }

            ReceitaDAO receitaDAO = new ReceitaDAO();

            string retorno = receitaDAO.cadastrar(receita);
            if (String.IsNullOrEmpty(retorno))
            {
                MessageBox.Show("Erro ao cadastrar receita!!!");
            }
            else if (retorno.Contains("Erro de acesso ao MySQL : "))
            {
                MessageBox.Show(retorno);
            }
            else
            {
                MessageBox.Show("Receita foi cadastrado com sucesso!!!");
                setValoresEmBanco();
            }
            preencheGrid();
        }

        private void setValoresEmBanco() {
            preencheCombos();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox7.Text = "";
            textBox9.Text = "";
            
        }
    }
}
