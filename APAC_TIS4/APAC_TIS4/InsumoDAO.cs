using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4
{
    class InsumoDAO
    {
        public InsumoDAO() { }

        public DataSet preencheCombo() {
            DataSet dsInsumo = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */
                    MySqlCommand cmd = new MySqlCommand("SELECT Nome, Insumo_ID FROM insumo;", conexaoMySQL);

                    MySqlDataAdapter sAdapter = new MySqlDataAdapter(cmd);

                    MySqlCommandBuilder sBuilder = new MySqlCommandBuilder(sAdapter);

                    sAdapter.Fill(dsInsumo, "characters");

                    DataTable sTable = dsInsumo.Tables["characters"];
                }
                finally
                {
                    conexaoMySQL.Close();
                }
                return dsInsumo;
            }


        }

        public DataSet visualizarGridComParametros(InsumoModels insumoModels)
        {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    string query = "SELECT Nome, Descrição, Peso_Por_Unidade, Unidade_De_Medida, Peso_Total, Custo, Quantidade_Estoque, Custo_Total FROM insumo WHERE (Insumo_ID = @Insumo_ID OR Nome LIKE @Nome) AND Descrição LIKE @Descricao;";

                    conexaoMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conexaoMySQL);

                    cmd.Parameters.AddWithValue("@Insumo_ID", insumoModels.Insumo_ID);
                    cmd.Parameters.AddWithValue("@Descricao", insumoModels.Descricao);
                    cmd.Parameters.AddWithValue("@Nome", insumoModels.Nome);

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

        public DataSet visualizarGridComParametrosEID(InsumoModels insumoModels)
        {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    string query = "SELECT Insumo_ID, Nome, Descrição, Peso_Por_Unidade, Unidade_De_Medida, Peso_Total, Custo, Quantidade_Estoque, Custo_Total FROM insumo WHERE (Insumo_ID = @Insumo_ID OR Nome LIKE @Nome) AND Descrição LIKE @Descricao;";

                    conexaoMySQL.Open();

                    MySqlCommand cmd = new MySqlCommand(query, conexaoMySQL);

                    cmd.Parameters.AddWithValue("@Insumo_ID", insumoModels.Insumo_ID);
                    cmd.Parameters.AddWithValue("@Descricao", insumoModels.Descricao);
                    cmd.Parameters.AddWithValue("@Nome", insumoModels.Nome);

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

                    string query = "SELECT Nome, Descrição, Peso_Por_Unidade, Unidade_De_Medida, Peso_Total, Custo, Quantidade_Estoque, Custo_Total FROM insumo;";

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

                    string query = "SELECT Insumo_ID, Nome, Descrição, Peso_Por_Unidade, Unidade_De_Medida, Peso_Total, Custo, Quantidade_Estoque, Custo_Total FROM insumo;";

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

        public string cadastrar(InsumoModels insumo)
        {
            string retorno = null;
            using (MySqlConnection conexaoMySQL = SingletonBD.getInstancia().getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */
                    MySqlCommand cmd = new MySqlCommand("SP_insumoInsert", conexaoMySQL);
                    /* aqui indicamos que usaremos stored procedure como tipo de comando*/
                    cmd.CommandType = CommandType.StoredProcedure;
                    /* aqui passamos os parametros para a procedure spInsere que criamos
                    de acordo com os textbox*/
                    cmd.Parameters.AddWithValue("_Nome", insumo.Nome);
                    cmd.Parameters.AddWithValue("_Descrição", insumo.Descricao);
                    cmd.Parameters.AddWithValue("_Peso_Por_Unidade", insumo.Peso_Por_Unidade);
                    cmd.Parameters.AddWithValue("_Unidade_De_Medida", insumo.Unidade_De_Medida);
                    cmd.Parameters.AddWithValue("_Peso_Total", insumo.Peso_Total);
                    cmd.Parameters.AddWithValue("_Custo", insumo.Custo);
                    cmd.Parameters.AddWithValue("_Quantidade_Estoque", insumo.Quantidade_Estoque);
                    cmd.Parameters.AddWithValue("_Custo_Total", insumo.Custo_Total);

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

        public bool atualizarInumos(List<InsumoModels> insumoModels)
        {
            bool verificaAtualizacao = false;

            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                conexaoMySQL.Open();

                //MySqlTransaction tran = conexaoMySQL.BeginTransaction();

                try
                {
                    foreach (InsumoModels insumo in insumoModels)
                    {
                        MySqlCommand cmd = new MySqlCommand("UPDATE insumo SET Nome = @Nome, Descrição = @Descricao, Peso_Por_Unidade = @Peso_Por_Unidade, Unidade_De_Medida = @Unidade_De_Medida, Peso_Total = @Peso_Total, Custo = @Custo, Quantidade_Estoque = @Quantidade_Estoque, Custo_Total = @Custo_Total WHERE Insumo_ID = @Insumo_ID;", conexaoMySQL);

                        //cmd.Transaction = tran;

                        cmd.Parameters.AddWithValue("@Insumo_ID", insumo.Insumo_ID);
                        cmd.Parameters.AddWithValue("@Nome", insumo.Nome);
                        cmd.Parameters.AddWithValue("@Descricao", insumo.Descricao);
                        cmd.Parameters.AddWithValue("@Peso_Por_Unidade", insumo.Peso_Por_Unidade);
                        cmd.Parameters.AddWithValue("@Unidade_De_Medida", insumo.Unidade_De_Medida);
                        cmd.Parameters.AddWithValue("@Peso_Total", insumo.Peso_Total);
                        cmd.Parameters.AddWithValue("@Custo", insumo.Custo);
                        cmd.Parameters.AddWithValue("@Quantidade_Estoque", insumo.Quantidade_Estoque);
                        cmd.Parameters.AddWithValue("@Custo_Total", insumo.Custo_Total);

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
