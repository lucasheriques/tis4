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
    public partial class frmAtualizarInsumo : Form
    {
        private Form _frmPrincipal;

        private InsumoDAO insumoDAO;

        private void preencheGrid()
        {
            insumoDAO = new InsumoDAO();
            DataSet dataSet = insumoDAO.visualizarGridComID();
            dataGridView1.DataSource = dataSet.Tables["characters"];

            dataGridView1.Columns[0].Visible = false;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 400;
            }
        }
        public frmAtualizarInsumo(Form frmPrincipal)
        {
            InitializeComponent();
            this._frmPrincipal = frmPrincipal;
            preencheGrid();
            preencheCombo();
        }

        private void preencheCombo()
        {
            this.insumoDAO = new InsumoDAO();
            DataSet dsInsumo4 = insumoDAO.preencheCombo();
            comboBox1.ValueMember = "Insumo_ID";
            comboBox1.DisplayMember = "Nome";
            comboBox1.DataSource = dsInsumo4.Tables["characters"];
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
            else
            {
                insumoModels.Insumo_ID = int.Parse(comboBox1.SelectedValue.ToString());
                insumoModels.Nome = "";
            }
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                insumoModels.Descricao = "%";
            }
            else
            {
                insumoModels.Descricao = "%" + textBox7.Text + "%";
            }

            DataSet dataSet = new DataSet();
            dataSet = insumoDAO.visualizarGridComParametrosEID(insumoModels);
            dataGridView1.DataSource = dataSet.Tables["characters"];

            dataGridView1.Columns[0].Visible = false;
            for (int i = 1; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].Width = 400;
            }
            preencheCombo();
        }

        private void bntAtualizar_Click(object sender, EventArgs e)
        {
            List<InsumoModels> listInsumo = new List<InsumoModels>();

            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                System.Threading.Thread.Sleep(50);
                InsumoModels insumo = new InsumoModels();
                insumo.Insumo_ID = int.Parse(dataGridView1.Rows[i].Cells[0].Value.ToString());
                insumo.Nome = dataGridView1.Rows[i].Cells[1].Value.ToString();
                insumo.Descricao = dataGridView1.Rows[i].Cells[2].Value.ToString();
                insumo.Peso_Por_Unidade = float.Parse(dataGridView1.Rows[i].Cells[3].Value.ToString());
                insumo.Unidade_De_Medida = dataGridView1.Rows[i].Cells[4].Value.ToString();
                insumo.Custo = float.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString());
                insumo.Quantidade_Estoque = int.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString());
                insumo.Custo_Total = insumo.Quantidade_Estoque * insumo.Custo;
                insumo.Peso_Total = insumo.Quantidade_Estoque * insumo.Peso_Por_Unidade;
                listInsumo.Add(insumo);
            }

            InsumoDAO insumoDAO = new InsumoDAO();
            ClienteDAO clienteDAO = new ClienteDAO();

            bool verificaAtualizacao = insumoDAO.atualizarInumos(listInsumo);
            if (verificaAtualizacao)
            {
                MessageBox.Show("Dados atualizados com sucesso.");
            }
            else
            {
                MessageBox.Show("Erro na atualização dos dados.");
            }

            preencheGrid();

        }
    }
}
