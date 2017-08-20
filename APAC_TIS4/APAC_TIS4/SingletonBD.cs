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
        private string Server = "localhost";
        private string Database = "padaria";
        private string Usuario = "root";
        private string Senha = "123456";


        private static readonly SingletonBD instanciaMySQL = new SingletonBD();

        private SingletonBD() { }

        public static SingletonBD getInstancia()
        {
            return instanciaMySQL;
        }

        public MySqlConnection getConexao()
        {
            string conn = "Data Source=" + Server + ";Initial Catalog=" + Database + ";User ID=" + Usuario + @";Password='" + Senha + @"'";
            return new MySqlConnection(conn);
        }
    }
}
