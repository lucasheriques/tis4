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
    public partial class frmCadastrarCliente : Form
    {
        frmPrincipal principal;
        public frmCadastrarCliente(frmPrincipal principal)
        {
            this.principal = principal;
            InitializeComponent();
        }

        public frmCadastrarCliente()
        {
            InitializeComponent();
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.principal.Show();
        }

        private void bntSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bntCadastrar_Click(object sender, EventArgs e)
        {
            CienteModels cliente = new CienteModels();

            cliente.nome = txtNome.Text;
            cliente.localidade = txtLocalidade.Text;
            cliente.Tipo = cmbTipo.Text;

            ClienteDAO clienteDAO = new ClienteDAO();
            string retorno = clienteDAO.cadastrar(cliente);

            if (String.IsNullOrEmpty(retorno)) {
                MessageBox.Show("Erro ao criar cliente!!!");
            }
            else if(retorno.Contains("Erro de acesso ao MySQL : ")){
                MessageBox.Show(retorno);
            }
            else{
                MessageBox.Show("Cliente inserido com sucesso!!!");
            }
        }
    }
}
