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
    }
}
