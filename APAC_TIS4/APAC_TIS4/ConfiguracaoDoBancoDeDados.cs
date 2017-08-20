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
    public partial class ConfiguracaoDoBancoDeDados : Form
    {
        private frmPrincipal _frmPrincipal;
        public ConfiguracaoDoBancoDeDados()
        {
            InitializeComponent();
        }

        public void setFrmPrincipal(frmPrincipal FrmPrincipal) {
            this._frmPrincipal = FrmPrincipal;
        }

        private void bntSair_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void bntSalvar_Click(object sender, EventArgs e)
        {
            Arquivo arquivo = new Arquivo("ConfiguracaoBancoDeDados.txt");
            bool verifica = arquivo.salvaConfiguracao(txtServidor.Text, txtBaseDeDados.Text, txtUsuario.Text, txtSenha.Text);
            if (verifica)
            {
                MessageBox.Show("Configuração salva com sucesso!!!");
            }
            else {
                MessageBox.Show("Erro durante a gravação da configuração!!!");
            }
        }

        private void bntCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
            this._frmPrincipal.Show();
        }
    }
}
