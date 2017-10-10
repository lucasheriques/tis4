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
    class ReceitaDAO
    {
        public ReceitaDAO() { }

        public DataSet visualizarGridComParametros(ProdutoModels produtoModels) {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */

                    string query = "SELECT Produto.Nome, produto.Tipo, produto.Tamanho, PRODUTO.Peso, produto.UDM, produto.Descricao, insumo.Nome, Receita_Insumo.unidadeDeMedida, receita.Modo_de_Preparo, Receita.Observacao FROM Produto INNER JOIN Receita ON Produto.Produto_ID = Receita.Produto_ID INNER JOIN Receita_Insumo ON Receita_Insumo.Receita_ID = Receita.Receita_ID INNER JOIN insumo ON Receita_Insumo.Insumo_ID = insumo.Insumo_ID WHERE produto.Produto_ID = @Produto_ID OR produto.nome LIKE @nome;";

                    MySqlCommand cmd = new MySqlCommand(query, conexaoMySQL);

                    cmd.Parameters.AddWithValue("@Produto_ID", produtoModels.Produto_ID);
                    cmd.Parameters.AddWithValue("@nome", produtoModels.Nome);


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

        public DataSet visualizarGridComID() {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */

                    string query = "SELECT receita.Receita_ID, Produto.Nome, produto.Tipo, produto.Tamanho, PRODUTO.Peso, produto.UDM, produto.Descricao, insumo.Nome, Receita_Insumo.unidadeDeMedida, receita.Modo_de_Preparo, Receita.Observacao FROM Produto INNER JOIN Receita ON Produto.Produto_ID = Receita.Produto_ID INNER JOIN Receita_Insumo ON Receita_Insumo.Receita_ID = Receita.Receita_ID INNER JOIN insumo ON Receita_Insumo.Insumo_ID = insumo.Insumo_ID;";

                    MySqlCommand cmd = new MySqlCommand(query, conexaoMySQL);

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

                    string query = "SELECT Produto.Nome, produto.Tipo, produto.Tamanho, PRODUTO.Peso, produto.UDM, produto.Descricao, insumo.Nome, Receita_Insumo.unidadeDeMedida, receita.Modo_de_Preparo, Receita.Observacao FROM Produto INNER JOIN Receita ON Produto.Produto_ID = Receita.Produto_ID INNER JOIN Receita_Insumo ON Receita_Insumo.Receita_ID = Receita.Receita_ID INNER JOIN insumo ON Receita_Insumo.Insumo_ID = insumo.Insumo_ID;";

                    MySqlCommand cmd = new MySqlCommand(query, conexaoMySQL);

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

        public string cadastrar(ReceitaModels receita)
        {
            string retorno = null;
            using (MySqlConnection conexaoMySQL = SingletonBD.getInstancia().getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */
                    MySqlCommand cmd = new MySqlCommand("SP_receitaInsert", conexaoMySQL);
                    /* aqui indicamos que usaremos stored procedure como tipo de comando*/
                    cmd.CommandType = CommandType.StoredProcedure;
                    /* aqui passamos os parametros para a procedure spInsere que criamos
                    de acordo com os textbox*/
                    SqlParameter output = new SqlParameter("_Receita_ID", SqlDbType.Int);
                    cmd.Parameters.AddWithValue("_Observacao", receita.Observacao);
                    cmd.Parameters.AddWithValue("_Produto_ID", receita.Produto.Produto_ID);
                    cmd.Parameters.AddWithValue("_Modo_de_Preparo", receita.ModoDePreparo);
                    cmd.Parameters.AddWithValue("_Receita_ID", receita.ReceitaID);
                    cmd.Parameters["_Receita_ID"].Direction = ParameterDirection.InputOutput;

                    cmd.ExecuteNonQuery();
                    string strReceita_ID = cmd.Parameters["_Receita_ID"].Value.ToString();
                    receita.ReceitaID = int.Parse(strReceita_ID);

                    string[] arrayInsumo = new string[receita.Receita_Insumo.Insumo.Count];
                    int i = 0;
                    foreach (InsumoModels insumo in receita.Receita_Insumo.Insumo) {
                        arrayInsumo[i++] = insumo.Nome;
                    }

                    float[] arrayPeso = new float[receita.Receita_Insumo.Peso.Count];
                    i = 0;
                    foreach (float peso in receita.Receita_Insumo.Peso) {
                        arrayPeso[i++] = peso;
                    }

                    string[] arrayUnidadeDeMedida = new string[receita.Receita_Insumo.UnidadeDeMedida.Count];
                    i = 0;
                    foreach (string unidadeDeMedida in receita.Receita_Insumo.UnidadeDeMedida) {
                        arrayUnidadeDeMedida[i++] = unidadeDeMedida;
                    }

                    for (int j = 0; j < arrayInsumo.Length; j++) {
                        MySqlCommand receita_insumoCmd = new MySqlCommand("SP_receita_insumoInsert", conexaoMySQL);
                        /* aqui indicamos que usaremos stored procedure como tipo de comando*/
                        receita_insumoCmd.CommandType = CommandType.StoredProcedure;
                        /* aqui passamos os parametros para a procedure spInsere que criamos
                        de acordo com os textbox*/
                        receita_insumoCmd.Parameters.AddWithValue("_Insumo", arrayInsumo[j]);
                        receita_insumoCmd.Parameters.AddWithValue("_Peso", arrayPeso[j]);
                        receita_insumoCmd.Parameters.AddWithValue("_UnidadeDeMedida", arrayUnidadeDeMedida[j]);
                        receita_insumoCmd.Parameters.AddWithValue("_Receita_ID", receita.ReceitaID);

                        receita_insumoCmd.ExecuteNonQuery();
                    }

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

        public bool excluirPedidos(List<int> listReceitaID) {
            bool verifica = false;

            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                conexaoMySQL.Open();

                //MySqlTransaction tran = conexaoMySQL.BeginTransaction();

                try
                {
                    foreach (int ReceitaID in listReceitaID)
                    {
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM receita WHERE Receita_ID = @Receita_ID;", conexaoMySQL);

                        cmd.Parameters.AddWithValue("@Receita_ID", ReceitaID);

                        cmd.ExecuteNonQuery();

                        MySqlCommand cmdReceita_Insumo = new MySqlCommand("DELETE FROM receita_insumo WHERE Receita_ID = @Receita_ID;", conexaoMySQL);

                        cmdReceita_Insumo.Parameters.AddWithValue("@Receita_ID", ReceitaID);

                        cmdReceita_Insumo.ExecuteNonQuery();

                    }

                    //tran.Commit();
                    verifica = true;
                }
                finally
                {
                    conexaoMySQL.Close();
                }
            }

            return verifica;
        }
    }
}
