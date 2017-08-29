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
    class PedidoDAO
    {
        public PedidoDAO() { }

        public DataSet visualizarGrid()
        {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (SqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */

                    string query = "SELECT cliente.Nome AS Nome_Cliente, cliente.Localidade, cliente.Tipo AS Tipo_Cliente, pedido.Data_Entrega, pedido.PrecoTotal, pedido.Quantidade, produto.nome as Nome_Produto, produto.Peso, produto.UDM AS Unidade_De_Medida, produto.Tamanho, produto.Tipo FROM pedido INNER JOIN cliente ON cliente.Cliente_ID = pedido.Cliente_ID INNER JOIN produto ON produto.Produto_ID = pedido.Produto_ID;";

                    SqlCommand cmd = new SqlCommand(query, conexaoMySQL);

                    SqlDataAdapter sAdapter = new SqlDataAdapter(cmd);

                    SqlCommandBuilder sBuilder = new SqlCommandBuilder(sAdapter);

                    sAdapter.Fill(sDs, "characters");

                    DataTable sTable = sDs.Tables["characters"];
                }
                catch (SqlException msqle)
                {

                }
                finally
                {
                    conexaoMySQL.Close();
                }
                return sDs;
            }
        }

        public DataSet visualizarGridComParametros(PedidoModels pedido)
        {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (SqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */
                    string query = "SELECT cliente.Nome AS Nome_Cliente, cliente.Localidade, cliente.Tipo AS Tipo_Cliente, pedido.Data_Entrega, pedido.PrecoTotal, pedido.Quantidade, produto.nome as Nome_Produto, produto.Peso, produto.UDM AS Unidade_De_Medida, produto.Tamanho, produto.Tipo  FROM  cliente INNER JOIN pedido ON pedido.Cliente_ID = cliente.Cliente_ID INNER JOIN produto ON produto.Produto_ID = pedido.Produto_ID WHERE cliente.Nome LIKE @NomeCliente AND produto.nome LIKE @NomeProduto OR (pedido.Data_Pedido between now() and @Data_Pedido OR pedido.Data_Pedido between @Data_Pedido and NOW()) OR (pedido.Data_Entrega between now() and @Data_Entrega OR pedido.Data_Entrega between @Data_Entrega and NOW());";

                    if (pedido.Data_Pedido == DateTime.MinValue && pedido.Data_Entrega != DateTime.MinValue)
                    {
                        query = "SELECT cliente.Nome AS Nome_Cliente, cliente.Localidade, cliente.Tipo AS Tipo_Cliente, pedido.Data_Entrega, pedido.PrecoTotal, pedido.Quantidade, produto.nome as Nome_Produto, produto.Peso, produto.UDM AS Unidade_De_Medida, produto.Tamanho, produto.Tipo  FROM  cliente INNER JOIN pedido ON pedido.Cliente_ID = cliente.Cliente_ID INNER JOIN produto ON produto.Produto_ID = pedido.Produto_ID WHERE cliente.Nome LIKE @NomeCliente AND produto.nome LIKE @NomeProduto OR (pedido.Data_Entrega between now() and @Data_Entrega OR pedido.Data_Entrega between @Data_Entrega and NOW());";
                    }
                    if (pedido.Data_Pedido == DateTime.MinValue && pedido.Data_Entrega != DateTime.MinValue)
                    {
                        query = "SELECT cliente.Nome AS Nome_Cliente, cliente.Localidade, cliente.Tipo AS Tipo_Cliente, pedido.Data_Entrega, pedido.PrecoTotal, pedido.Quantidade, produto.nome as Nome_Produto, produto.Peso, produto.UDM AS Unidade_De_Medida, produto.Tamanho, produto.Tipo  FROM  cliente INNER JOIN pedido ON pedido.Cliente_ID = cliente.Cliente_ID INNER JOIN produto ON produto.Produto_ID = pedido.Produto_ID WHERE cliente.Nome LIKE @NomeCliente AND produto.nome LIKE @NomeProduto OR (pedido.Data_Pedido between now() and @Data_Pedido OR pedido.Data_Pedido between @Data_Pedido and NOW())";
                    }
                    if (pedido.Data_Pedido != DateTime.MinValue && pedido.Data_Entrega != DateTime.MinValue)
                    {
                        query = "SELECT cliente.Nome AS Nome_Cliente, cliente.Localidade, cliente.Tipo AS Tipo_Cliente, pedido.Data_Entrega, pedido.PrecoTotal, pedido.Quantidade, produto.nome as Nome_Produto, produto.Peso, produto.UDM AS Unidade_De_Medida, produto.Tamanho, produto.Tipo  FROM  cliente INNER JOIN pedido ON pedido.Cliente_ID = cliente.Cliente_ID INNER JOIN produto ON produto.Produto_ID = pedido.Produto_ID WHERE cliente.Nome LIKE @NomeCliente AND produto.nome LIKE @NomeProduto;";
                    }

                    SqlCommand cmd = new SqlCommand(query, conexaoMySQL);

                    if (string.IsNullOrEmpty(pedido.Cliente.nome))
                    {
                        pedido.Cliente.nome = "%";
                    }
                    else {
                        pedido.Cliente.nome = "%" + pedido.Cliente.nome + "%";
                    }

                    if (string.IsNullOrEmpty(pedido.Produto.Nome))
                    {
                        pedido.Cliente.nome = "%";
                    }
                    else
                    {
                        pedido.Produto.Nome = "%" + pedido.Produto.Nome + "%";
                    }

                    cmd.Parameters.AddWithValue("@NomeCliente", pedido.Cliente.nome);
                    cmd.Parameters.AddWithValue("@NomeProduto", pedido.Produto.Nome);
                    cmd.Parameters.AddWithValue("@Data_Pedido", pedido.Data_Pedido);
                    cmd.Parameters.AddWithValue("@Data_Entrega", pedido.Data_Entrega);

                    SqlDataAdapter sAdapter = new SqlDataAdapter(cmd);

                    SqlCommandBuilder sBuilder = new SqlCommandBuilder(sAdapter);

                    sAdapter.Fill(sDs, "characters");

                    DataTable sTable = sDs.Tables["characters"];
                }
                catch (SqlException msqle)
                {

                }
                finally
                {
                    conexaoMySQL.Close();
                }
                return sDs;
            }
        }


        public string cadastrar(PedidoModels pedido)
        {
            string retorno = null;
            using (SqlConnection conexaoMySQL = SingletonBD.getInstancia().getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */
                    SqlCommand cmd = new SqlCommand("SP_pedidoInsert", conexaoMySQL);
                    /* aqui indicamos que usaremos stored procedure como tipo de comando*/
                    cmd.CommandType = CommandType.StoredProcedure;
                    /* aqui passamos os parametros para a procedure spInsere que criamos
                    de acordo com os textbox*/
                    cmd.Parameters.AddWithValue("_Produto_ID", pedido.Produto_ID);
                    cmd.Parameters.AddWithValue("_Cliente_ID", pedido.Cliente_ID);
                    cmd.Parameters.AddWithValue("_Data_Entrega", pedido.Data_Entrega);
                    cmd.Parameters.AddWithValue("_Data_Pedido", pedido.Data_Pedido);
                    cmd.Parameters.AddWithValue("_Quantidade", pedido.Quantidade);
                    cmd.Parameters.AddWithValue("_PrecoTotal", pedido.PrecoTotal);

                    cmd.ExecuteNonQuery();
                    retorno = "OK";
                    return retorno;
                }
                catch (SqlException msqle)
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
