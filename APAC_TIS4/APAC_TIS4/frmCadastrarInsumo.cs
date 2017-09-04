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
    public partial class frmCadastrarInsumo : Form
    {
        private Form _frmPrincipal;

        public frmCadastrarInsumo(Form frmPrincipal)
        {
            InitializeComponent();
            this._frmPrincipal = frmPrincipal;
            popularGrid();
        }

        private void popularGrid()
        {
            //ClienteDAO cliente = new ClienteDAO();
            InsumoDAO insumo = new InsumoDAO();

            DataSet dataSet = insumo.visualizarGrid();
            dataGridView1.DataSource = dataSet.Tables["characters"];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 400;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            this._frmPrincipal.Show();
        }

        private static bool IsNumeric(string data)
        {
            bool isnumeric = false;
            char[] datachars = data.ToCharArray();

            foreach (var datachar in datachars) {
                if (char.IsNumber(datachar)) {
                    isnumeric = true;
                }
            }

            return isnumeric;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            string strQuantidadeEstoque = textBox3.Text;
            string strPesoPorUnidade = textBox2.Text;
            string strCusto = textBox4.Text;
            if (!string.IsNullOrEmpty(strQuantidadeEstoque) && !string.IsNullOrEmpty(strPesoPorUnidade) && !string.IsNullOrEmpty(strCusto)) {
                if (IsNumeric(strQuantidadeEstoque) && (IsNumeric(strPesoPorUnidade) || IsNumeric(strCusto)))
                {
                    int quantidadeEstoque = int.Parse(strQuantidadeEstoque);

                    int pesoPorUnidade = 0;
                    if (string.IsNullOrEmpty(strPesoPorUnidade))
                    {
                        pesoPorUnidade = int.Parse(strPesoPorUnidade) * quantidadeEstoque;
                        textBox5.Text = pesoPorUnidade.ToString();
                    }

                    int custo = 0;
                    if (string.IsNullOrEmpty(strCusto))
                    {
                        custo = int.Parse(strCusto) * quantidadeEstoque;
                        textBox6.Text = custo.ToString();
                    }
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string strQuantidadeEstoque = textBox3.Text;
            string strPesoPorUnidade = textBox2.Text;

            if (IsNumeric(strQuantidadeEstoque) && IsNumeric(strPesoPorUnidade)) {
                int quantidadeEstoque = int.Parse(strQuantidadeEstoque);

                int pesoPorUnidade = int.Parse(strPesoPorUnidade) * quantidadeEstoque;

                textBox5.Text = pesoPorUnidade.ToString();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            string strQuantidadeEstoque = textBox3.Text;
            string strCusto = textBox4.Text;

            if (IsNumeric(strQuantidadeEstoque) && IsNumeric(strCusto)) {
                int quantidadeEstoque = int.Parse(strQuantidadeEstoque);
                int custo = 0;
                custo = int.Parse(strCusto) * quantidadeEstoque;
                textBox6.Text = custo.ToString();
            }
        }

        private void bntCadastrar_Click(object sender, EventArgs e)
        {
            InsumoModels insumo = new InsumoModels();

            insumo.Nome = textBox1.Text;
            insumo.Peso_Por_Unidade = float.Parse(textBox2.Text);
            insumo.Unidade_De_Medida = comboBox1.Text;
            insumo.Quantidade_Estoque = int.Parse(textBox3.Text);
            insumo.Custo = float.Parse(textBox4.Text);
            insumo.Peso_Total = float.Parse(textBox5.Text);
            insumo.Custo_Total = float.Parse(textBox6.Text);
            insumo.Descricao = textBox7.Text;

            InsumoDAO insumoDAO = new InsumoDAO();
            string retorno = insumoDAO.cadastrar(insumo);

            if (String.IsNullOrEmpty(retorno))
            {
                MessageBox.Show("Erro ao cadastrar insumo!!!");
            }
            else if (retorno.Contains("Erro de acesso ao MySQL : "))
            {
                MessageBox.Show(retorno);
            }
            else
            {
                MessageBox.Show("Insumo cadastrado com sucesso!!!");
            }
            popularGrid();
        }
    }
}
