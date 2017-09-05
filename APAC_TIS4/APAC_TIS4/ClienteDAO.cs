using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4
{
    class ClienteDAO
    {
        public DataSet preencheCombo()
        {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */
                    MySqlCommand cmd = new MySqlCommand("SELECT Nome, Cliente_ID FROM Cliente;", conexaoMySQL);

                    MySqlDataAdapter sAdapter = new MySqlDataAdapter(cmd);

                    MySqlCommandBuilder sBuilder = new MySqlCommandBuilder(sAdapter);

                    sAdapter.Fill(sDs, "characters");

                    DataTable sTable = sDs.Tables["characters"];
                }
                finally
                {
                    conexaoMySQL.Close();
                }
                return sDs;
            }
        }

        public DataSet visualizarGrid()
        {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */
                    MySqlCommand cmd = new MySqlCommand("SELECT Nome, Localidade, Tipo FROM cliente;", conexaoMySQL);

                    MySqlDataAdapter sAdapter = new MySqlDataAdapter(cmd);

                    MySqlCommandBuilder sBuilder = new MySqlCommandBuilder(sAdapter);

                    sAdapter.Fill(sDs, "characters");

                    DataTable sTable = sDs.Tables["characters"];
                }
                finally
                {
                    conexaoMySQL.Close();
                }
                return sDs;
            }
        }

        public DataSet visualizarGridComParametrosEID(CienteModels cliente)
        {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */

                    string query = "SELECT Cliente_ID, Nome, Localidade, Tipo FROM cliente WHERE Nome LIKE @Nome AND Localidade LIKE @Localidade AND Tipo LIKE @Tipo;";

                    if (string.IsNullOrEmpty(cliente.nome))
                    {
                        cliente.nome = "%";
                    }
                    else
                    {
                        cliente.nome = "%" + cliente.nome + "%";
                    }

                    if (string.IsNullOrEmpty(cliente.localidade))
                    {
                        cliente.localidade = "%";
                    }
                    else
                    {
                        cliente.localidade = "%" + cliente.localidade + "%";
                    }

                    if (string.IsNullOrEmpty(cliente.Tipo))
                    {
                        cliente.Tipo = "%";
                    }
                    else
                    {
                        cliente.Tipo = "%" + cliente.Tipo + "%";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conexaoMySQL);

                    cmd.Parameters.AddWithValue("@nome", "%"+cliente.nome.ToLower()+"%");
                    cmd.Parameters.AddWithValue("@localidade", "%" + cliente.localidade.ToLower());
                    cmd.Parameters.AddWithValue("@tipo", "%" + cliente.Tipo.ToLower() + "%");

                    MySqlDataAdapter sAdapter = new MySqlDataAdapter(cmd);

                    MySqlCommandBuilder sBuilder = new MySqlCommandBuilder(sAdapter);

                    sAdapter.Fill(sDs, "characters");

                    DataTable sTable = sDs.Tables["characters"];
                }
                finally
                {
                    conexaoMySQL.Close();
                }
                return sDs;
            }
        }

        public DataSet visualizarGridComParametros(CienteModels cliente)
        {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */
                    string query = "SELECT Nome, Localidade, Tipo FROM cliente WHERE (LOWER(Nome) LIKE @Nome OR LOWER(Localidade) LIKE @Localidade) AND LOWER(Tipo) LIKE @Tipo;";

                    if (cliente.Tipo == "%" && (cliente.nome != "%" || cliente.localidade != "%"))
                    {
                        query = "SELECT Nome, Localidade, Tipo FROM cliente WHERE LOWER(Nome) LIKE @Nome OR LOWER(Localidade) LIKE @Localidade OR LOWER(Tipo) LIKE @Tipo;";

                        cliente.Tipo = "";

                        if (cliente.nome == "%")
                        {
                            cliente.nome = "";
                        }
                        else
                        {
                            cliente.nome = "%" + cliente.nome + "%";
                        }

                        if (cliente.localidade == "%")
                        {
                            cliente.localidade = "";
                        }
                        else
                        {
                            cliente.localidade = "%" + cliente.localidade + "%";
                        }
                    }
                    else if ((cliente.Tipo != "%" && cliente.nome != "%") && cliente.localidade == "%")
                    {
                        query = "SELECT Nome, Localidade, Tipo FROM cliente WHERE LOWER(Nome) LIKE @Nome AND LOWER(Tipo) LIKE @Tipo;";

                        cliente.nome = "%" + cliente.nome + "%";

                        cliente.Tipo = "%" + cliente.Tipo + "%";
                    }
                    else if (cliente.Tipo != "%" && cliente.nome == "%" && cliente.localidade != "%")
                    {
                        query = "SELECT Nome, Localidade, Tipo FROM cliente WHERE LOWER(Localidade) LIKE @Localidade AND LOWER(Tipo) LIKE @Tipo;";

                        cliente.localidade = "%" + cliente.localidade + "%";

                        cliente.Tipo = "%" + cliente.Tipo + "%";
                    }
                    else {
                        if (cliente.Tipo == "%")
                        {
                            cliente.Tipo = "%";
                        }
                        else
                        {
                            cliente.Tipo = "%" + cliente.Tipo + "%";
                        }

                        if (cliente.nome == "%")
                        {
                            cliente.nome = "%";
                        }
                        else
                        {
                            cliente.nome = "%" + cliente.nome + "%";
                        }

                        if (cliente.nome == "%")
                        {
                            cliente.nome = "%";
                        }
                        else
                        {
                            cliente.nome = "%" + cliente.nome + "%";
                        }

                        if (cliente.localidade == "%")
                        {
                            cliente.localidade = "";
                        }
                        else
                        {
                            cliente.localidade = "%" + cliente.localidade + "%";
                        }

                    }

                    MySqlCommand cmd = new MySqlCommand(query, conexaoMySQL);

                    cmd.Parameters.AddWithValue("@nome", cliente.nome.ToLower());
                    cmd.Parameters.AddWithValue("@localidade", cliente.localidade.ToLower());
                    cmd.Parameters.AddWithValue("@tipo", cliente.Tipo.ToLower());

                    MySqlDataAdapter sAdapter = new MySqlDataAdapter(cmd);

                    MySqlCommandBuilder sBuilder = new MySqlCommandBuilder(sAdapter);

                    sAdapter.Fill(sDs, "characters");

                    DataTable sTable = sDs.Tables["characters"];
                }
                finally
                {
                    conexaoMySQL.Close();
                }
                return sDs;
            }
        }

        public string cadastrar(CienteModels cliente) {
            string retorno = null;
            using (MySqlConnection conexaoMySQL = SingletonBD.getInstancia().getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */
                    MySqlCommand cmd = new MySqlCommand("SP_clienteInsert", conexaoMySQL);
                    /* aqui indicamos que usaremos stored procedure como tipo de comando*/
                    cmd.CommandType = CommandType.StoredProcedure;
                    /* aqui passamos os parametros para a procedure spInsere que criamos
                    de acordo com os textbox*/
                    cmd.Parameters.AddWithValue("_nome", cliente.nome);
                    cmd.Parameters.AddWithValue("_localidade", cliente.localidade);
                    cmd.Parameters.AddWithValue("_tipo", cliente.Tipo);


                    cmd.ExecuteNonQuery();
                    retorno = "OK";
                    return retorno;
                }
                catch (MySqlException msqle)
                {
                   retorno = "Erro de acesso ao MySQL : " + msqle.Message;
                }
                finally
                {
                    conexaoMySQL.Close();
                }
                return retorno;
            }
        }

        public DataSet visualizarGridComID()
        {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */
                    MySqlCommand cmd = new MySqlCommand("SELECT Cliente_ID, Nome, Localidade, Tipo FROM cliente;", conexaoMySQL);

                    MySqlDataAdapter sAdapter = new MySqlDataAdapter(cmd);

                    MySqlCommandBuilder sBuilder = new MySqlCommandBuilder(sAdapter);

                    sAdapter.Fill(sDs, "characters");

                    DataTable sTable = sDs.Tables["characters"];
                }
                finally
                {
                    conexaoMySQL.Close();
                }
                return sDs;
            }
        }

        public bool atualizarClientes(List<CienteModels> listClientes)
        {
            bool verificaAtualizacao = false;

            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                conexaoMySQL.Open();

                //MySqlTransaction tran = conexaoMySQL.BeginTransaction();

                try
                {
                    foreach (CienteModels cliente in listClientes) {
                        MySqlCommand cmd = new MySqlCommand("UPDATE cliente SET Nome = @Nome, Localidade = @Localidade, Tipo = @Tipo WHERE Cliente_ID = @Cliente_ID;", conexaoMySQL);
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Transaction = tran;

                        cmd.Parameters.AddWithValue("@Nome", cliente.nome);
                        cmd.Parameters.AddWithValue("@Localidade", cliente.localidade);
                        cmd.Parameters.AddWithValue("@Tipo", cliente.Tipo);
                        cmd.Parameters.AddWithValue("@Cliente_ID", cliente.Cliente_ID);

                        cmd.ExecuteNonQuery();
                    }

                    //tran.Commit();
                    verificaAtualizacao = true;
                }
                finally
                {
                    conexaoMySQL.Close();
                }
                return verificaAtualizacao;
            }
        }
    }
}
