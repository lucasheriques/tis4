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
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */

                    string query = "SELECT cliente.Nome AS Nome_Cliente, cliente.Localidade, cliente.Tipo AS Tipo_Cliente, pedido.Data_Entrega, pedido.PrecoTotal, pedido.Quantidade, produto.nome as Nome_Produto, produto.Peso, produto.UDM AS Unidade_De_Medida, produto.Tamanho, produto.Tipo FROM pedido INNER JOIN cliente ON cliente.Cliente_ID = pedido.Cliente_ID INNER JOIN itemPedido ON itemPedido.Pedido_ID = pedido.Pedido_ID INNER JOIN produto ON produto.Produto_ID = itemPedido.Produto_ID;";

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

                    string query = "SELECT pedido.Pedido_ID, cliente.Nome AS Nome_Cliente, cliente.Localidade, cliente.Tipo AS Tipo_Cliente, pedido.Data_Entrega, pedido.PrecoTotal, pedido.Quantidade, produto.nome as Nome_Produto, produto.Peso, produto.UDM AS Unidade_De_Medida, produto.Tamanho, produto.Tipo FROM pedido INNER JOIN cliente ON cliente.Cliente_ID = pedido.Cliente_ID INNER JOIN itemPedido ON itemPedido.Pedido_ID = pedido.Pedido_ID INNER JOIN produto ON produto.Produto_ID = itemPedido.Produto_ID;";

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

        public bool atualizarInumos(List<PedidoModels> listPedidos) {
            bool verificaAtualizacao = false;

            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                conexaoMySQL.Open();

                //MySqlTransaction tran = conexaoMySQL.BeginTransaction();

                try
                {
                    foreach (PedidoModels pedido in listPedidos)
                    {
                        MySqlCommand cmd = new MySqlCommand("SP_UpdatePedidos", conexaoMySQL);

                        //cmd.Transaction = tran;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("_Pedido_ID", pedido.Pedido_ID);
                        cmd.Parameters.AddWithValue("_Data_Entrega", pedido.Data_Entrega);
                        cmd.Parameters.AddWithValue("_Quantidade", pedido.Quantidade);

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

        public DataSet visualizarGridComParametros(PedidoModels pedido)
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
                    string query = "SELECT cliente.Nome AS Nome_Cliente, cliente.Localidade, cliente.Tipo AS Tipo_Cliente, pedido.Data_Entrega, pedido.PrecoTotal, pedido.Quantidade, produto.nome as Nome_Produto, produto.Peso, produto.UDM AS Unidade_De_Medida, produto.Tamanho, produto.Tipo FROM pedido INNER JOIN cliente ON cliente.Cliente_ID = pedido.Cliente_ID INNER JOIN itemPedido ON itemPedido.Pedido_ID = pedido.Pedido_ID INNER JOIN produto ON produto.Produto_ID = itemPedido.Produto_ID WHERE cliente.Nome LIKE @NomeCliente AND produto.nome LIKE @NomeProduto AND (pedido.Data_Pedido = @Data_Pedido OR year(pedido.Data_Pedido) between Year('1900-01-01') and YEAR(NOW())) OR (pedido.Data_Entrega = @Data_Entrega OR year(pedido.Data_Entrega) between Year('1900-01-01') and YEAR(NOW()));";

                    MySqlCommand cmd = new MySqlCommand(query, conexaoMySQL);

                    if (string.IsNullOrEmpty(pedido._ItemPedido.Cliente.nome))
                    {
                        pedido._ItemPedido.Cliente.nome = "%";
                    }
                    else
                    {
                        pedido._ItemPedido.Cliente.nome = "%" + pedido._ItemPedido.Cliente.nome + "%";
                    }

                    if (string.IsNullOrEmpty(pedido._ItemPedido.Produto.Nome))
                    {
                        pedido._ItemPedido.Cliente.nome = "%";
                    }
                    else
                    {
                        pedido._ItemPedido.Produto.Nome = "%" + pedido._ItemPedido.Produto.Nome + "%";
                    }

                    cmd.Parameters.AddWithValue("@NomeCliente", pedido._ItemPedido.Cliente.nome);
                    cmd.Parameters.AddWithValue("@NomeProduto", pedido._ItemPedido.Produto.Nome);
                    cmd.Parameters.AddWithValue("@Data_Pedido", pedido.Data_Pedido);
                    cmd.Parameters.AddWithValue("@Data_Entrega", pedido.Data_Entrega);

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
        public DataSet visualizarGridComParametrosEID(PedidoModels pedido)
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
                    string query = "SELECT pedido.Pedido_ID, cliente.Nome AS Nome_Cliente, cliente.Localidade, cliente.Tipo AS Tipo_Cliente, pedido.Data_Entrega, pedido.PrecoTotal, pedido.Quantidade, produto.nome as Nome_Produto, produto.Peso, produto.UDM AS Unidade_De_Medida, produto.Tamanho, produto.Tipo FROM pedido INNER JOIN cliente ON cliente.Cliente_ID = pedido.Cliente_ID INNER JOIN itemPedido ON itemPedido.Pedido_ID = pedido.Pedido_ID INNER JOIN produto ON produto.Produto_ID = itemPedido.Produto_ID WHERE cliente.Nome LIKE @NomeCliente AND produto.nome LIKE @NomeProduto AND (pedido.Data_Pedido = @Data_Pedido OR year(pedido.Data_Pedido) between Year('1900-01-01') and YEAR(NOW())) OR (pedido.Data_Entrega = @Data_Entrega OR year(pedido.Data_Entrega) between Year('1900-01-01') and YEAR(NOW()));";

                    MySqlCommand cmd = new MySqlCommand(query, conexaoMySQL);

                    if (string.IsNullOrEmpty(pedido._ItemPedido.Cliente.nome))
                    {
                        pedido._ItemPedido.Cliente.nome = "%";
                    }
                    else
                    {
                        pedido._ItemPedido.Cliente.nome = "%" + pedido._ItemPedido.Cliente.nome + "%";
                    }

                    if (string.IsNullOrEmpty(pedido._ItemPedido.Produto.Nome))
                    {
                        pedido._ItemPedido.Cliente.nome = "%";
                    }
                    else
                    {
                        pedido._ItemPedido.Produto.Nome = "%" + pedido._ItemPedido.Produto.Nome + "%";
                    }

                    cmd.Parameters.AddWithValue("@NomeCliente", pedido._ItemPedido.Cliente.nome);
                    cmd.Parameters.AddWithValue("@NomeProduto", pedido._ItemPedido.Produto.Nome);
                    cmd.Parameters.AddWithValue("@Data_Pedido", pedido.Data_Pedido);
                    cmd.Parameters.AddWithValue("@Data_Entrega", pedido.Data_Entrega);

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


        public string cadastrar(PedidoModels pedido)
        {
            string retorno = null;
            using (MySqlConnection conexaoMySQL = SingletonBD.getInstancia().getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */
                    MySqlCommand cmd = new MySqlCommand("SP_pedidoInsert", conexaoMySQL);
                    /* aqui indicamos que usaremos stored procedure como tipo de comando*/
                    cmd.CommandType = CommandType.StoredProcedure;
                    /* aqui passamos os parametros para a procedure spInsere que criamos
                    de acordo com os textbox*/
                    cmd.Parameters.AddWithValue("_Produto_ID", pedido._ItemPedido.Produto_ID);
                    cmd.Parameters.AddWithValue("_Cliente_ID", pedido._ItemPedido.Cliente_ID);
                    cmd.Parameters.AddWithValue("_Data_Entrega", pedido.Data_Entrega);
                    cmd.Parameters.AddWithValue("_Data_Pedido", pedido.Data_Pedido);
                    cmd.Parameters.AddWithValue("_Quantidade", pedido.Quantidade);
                    cmd.Parameters.AddWithValue("_PrecoTotal", pedido.PrecoTotal);

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
