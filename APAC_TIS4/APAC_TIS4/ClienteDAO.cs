using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4
{
    class ClienteDAO
    {
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

    }
}
