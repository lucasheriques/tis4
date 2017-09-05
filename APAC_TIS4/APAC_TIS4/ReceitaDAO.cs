using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
                    cmd.Parameters.AddWithValue("_Observacao", receita.Observacao);
                    cmd.Parameters.AddWithValue("_Produto_ID", receita.Produto.Produto_ID);
                    cmd.Parameters.AddWithValue("_Modo_de_Preparo", receita.ModoDePreparo);
                    cmd.Parameters.AddWithValue("_unidadeDeMedida_1", receita.Receita_Insumo.UnidadeDeMedida.ElementAt(0));
                    cmd.Parameters.AddWithValue("_Insumo_ID_1", receita.Receita_Insumo.Insumo.ElementAt(0).Insumo_ID);
                    cmd.Parameters.AddWithValue("_unidadeDeMedida_2", receita.Receita_Insumo.UnidadeDeMedida.ElementAt(1));
                    cmd.Parameters.AddWithValue("_Insumo_ID_2", receita.Receita_Insumo.Insumo.ElementAt(1).Insumo_ID);
                    cmd.Parameters.AddWithValue("_unidadeDeMedida_3", receita.Receita_Insumo.UnidadeDeMedida.ElementAt(2));
                    cmd.Parameters.AddWithValue("_Insumo_ID_3", receita.Receita_Insumo.Insumo.ElementAt(2).Insumo_ID);
                    cmd.Parameters.AddWithValue("_unidadeDeMedida_4", receita.Receita_Insumo.UnidadeDeMedida.ElementAt(3));
                    cmd.Parameters.AddWithValue("_Insumo_ID_4", receita.Receita_Insumo.Insumo.ElementAt(3).Insumo_ID);
                    cmd.Parameters.AddWithValue("_unidadeDeMedida_5", receita.Receita_Insumo.UnidadeDeMedida.ElementAt(4));
                    cmd.Parameters.AddWithValue("_Insumo_ID_5", receita.Receita_Insumo.Insumo.ElementAt(4).Insumo_ID);
                    cmd.Parameters.AddWithValue("_unidadeDeMedida_6", receita.Receita_Insumo.UnidadeDeMedida.ElementAt(5));
                    cmd.Parameters.AddWithValue("_Insumo_ID_6", receita.Receita_Insumo.Insumo.ElementAt(5).Insumo_ID);
                    cmd.Parameters.AddWithValue("_unidadeDeMedida_7", receita.Receita_Insumo.UnidadeDeMedida.ElementAt(6));
                    cmd.Parameters.AddWithValue("_Insumo_ID_7", receita.Receita_Insumo.Insumo.ElementAt(6).Insumo_ID);
                    
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
    }
}
