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
                    MySqlCommand cmd = new MySqlCommand("select nome, Tipo, Tamanho, Peso, UDM, preco, CustoPorUnidade, PrecoDeVendaUnidade, Descricao from produto;", conexaoMySQL);

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
                    cmd.Parameters.AddWithValue("_preco", produto.Preco);
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
    }
}
