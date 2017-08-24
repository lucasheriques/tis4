using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4
{
    class ProdutoDAO
    {
        public ProdutoDAO() { }

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
                    MySqlCommand cmd = new MySqlCommand("SELECT nome, Produto_ID FROM produto;", conexaoMySQL);

                    MySqlDataAdapter sAdapter = new MySqlDataAdapter(cmd);

                    MySqlCommandBuilder sBuilder = new MySqlCommandBuilder(sAdapter);

                    sAdapter.Fill(sDs, "characters");

                    DataTable sTable = sDs.Tables["characters"];
                }
                catch (MySqlException msqle)
                {

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
                    MySqlCommand cmd = new MySqlCommand("select nome, Tipo, Tamanho, Peso, UDM, CustoPorUnidade, PrecoDeVendaUnidade, Descricao from produto;", conexaoMySQL);

                    MySqlDataAdapter sAdapter = new MySqlDataAdapter(cmd);

                    MySqlCommandBuilder sBuilder = new MySqlCommandBuilder(sAdapter);

                    sAdapter.Fill(sDs, "characters");

                    DataTable sTable = sDs.Tables["characters"];
                }
                catch (MySqlException msqle)
                {

                }
                finally
                {
                    conexaoMySQL.Close();
                }
                return sDs;
            }
        }

        public string cadastrar(ProdutoModels produto)
        {
            string retorno = null;
            using (MySqlConnection conexaoMySQL = SingletonBD.getInstancia().getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */
                    MySqlCommand cmd = new MySqlCommand("SP_produtoInsert", conexaoMySQL);
                    /* aqui indicamos que usaremos stored procedure como tipo de comando*/
                    cmd.CommandType = CommandType.StoredProcedure;
                    /* aqui passamos os parametros para a procedure spInsere que criamos
                    de acordo com os textbox*/
                    cmd.Parameters.AddWithValue("_nome", produto.Nome);
                    cmd.Parameters.AddWithValue("_tipo", produto.Tipo);
                    cmd.Parameters.AddWithValue("_Tamanho", produto.Tamanho);
                    cmd.Parameters.AddWithValue("_Peso", produto.Peso);
                    cmd.Parameters.AddWithValue("_UDM", produto.UDM);
                    cmd.Parameters.AddWithValue("_CustoPorUnidade", produto.CustoPorUnidade);
                    cmd.Parameters.AddWithValue("_PrecoDeVendaUnidade", produto.PrecoDeVendaUnidade);
                    cmd.Parameters.AddWithValue("_Descricao", produto.Descricao);

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
        public float getPrecoDeVendaUnidade(int Produto_ID)
        {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();

            float precoDeVendaUnidade = 0;
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */
                    MySqlCommand cmd = new MySqlCommand("SELECT PrecoDeVendaUnidade FROM produto WHERE Produto_ID = @Produto_ID;", conexaoMySQL);

                    cmd.Parameters.AddWithValue("@Produto_ID", Produto_ID);

                    MySqlDataAdapter sAdapter = new MySqlDataAdapter(cmd);

                    MySqlCommandBuilder sBuilder = new MySqlCommandBuilder(sAdapter);

                    sAdapter.Fill(sDs, "characters");
                    precoDeVendaUnidade = float.Parse(sDs.Tables["characters"].Rows[0]["PrecoDeVendaUnidade"].ToString());
                }
                catch (MySqlException msqle)
                {

                }
                finally
                {
                    conexaoMySQL.Close();
                }
                return precoDeVendaUnidade;
            }
        }

        public DataSet visualizarGridComParametros(ProdutoModels produto)
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
                    string query = "select nome, Tipo, Tamanho, Peso, UDM, CustoPorUnidade, PrecoDeVendaUnidade, Descricao from produto where nome LIKE @nome OR Tipo LIKE @Tipo OR Tamanho LIKE @Tamanho OR Descricao LIKE @Descricao;";
                    if (produto.Descricao == "%%%") {
                        query = "select nome, Tipo, Tamanho, Peso, UDM, CustoPorUnidade, PrecoDeVendaUnidade, Descricao from produto where (nome LIKE @nome OR Tipo LIKE @Tipo OR Tamanho LIKE @Tamanho) AND Descricao LIKE @Descricao;";
                    }
                    MySqlCommand cmd = new MySqlCommand(query, conexaoMySQL);

                    cmd.Parameters.AddWithValue("@nome", produto.Nome);
                    cmd.Parameters.AddWithValue("@Tipo", produto.Tipo);
                    cmd.Parameters.AddWithValue("@Tamanho", produto.Tamanho);
                    cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);


                    MySqlDataAdapter sAdapter = new MySqlDataAdapter(cmd);

                    MySqlCommandBuilder sBuilder = new MySqlCommandBuilder(sAdapter);

                    sAdapter.Fill(sDs, "characters");

                    DataTable sTable = sDs.Tables["characters"];
                }
                catch (MySqlException msqle)
                {

                }
                finally
                {
                    conexaoMySQL.Close();
                }
                return sDs;
            }
        }
    }
}
