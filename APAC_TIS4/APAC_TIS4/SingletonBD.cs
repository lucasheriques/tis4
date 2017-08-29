using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4
{
    public sealed class SingletonBD
    {
        // Variaveis de configuração de acesso ao banco de dados
        private string server;
        private string database;
        private string usuario;
        private string senha;

        private static Arquivo arquivo;

        public string Server { get { return server; } set { server = value; } }
        public string Database { get { return database; } set { database = value; } }
        public string Usuario { get { return usuario; } set { usuario = value; } }
        public string Senha { get { return senha; } set { senha = value;  } }


        private static readonly SingletonBD instanciaMySQL = leituraConfiguracao();
        public SingletonBD(string construtor) { }
        private SingletonBD() {
            
        }

        private static SingletonBD leituraConfiguracao() {
            arquivo = new Arquivo("ConfiguracaoBancoDeDados.txt");
            return arquivo.leituraConfiguracao();
        }

        public static SingletonBD getInstancia()
        {

            return instanciaMySQL;
        }

        public SqlConnection getConexao()
        {
            string conn = "Data Source=" + Server + ";Initial Catalog=" + Database + ";User ID=" + Usuario + @";Password='" + Senha + @"'";
            return new SqlConnection(conn);
        }
    }
}
