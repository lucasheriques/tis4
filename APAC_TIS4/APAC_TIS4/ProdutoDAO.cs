﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4
{
    class ProdutoDAO
    {
        public ProdutoDAO() { }

        public DataSet visualizarGridComNomeTtipo(string strTipo, string strNome) {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    string query = "select nome, Tipo, Tamanho, Peso, UDM, CustoPorUnidade, PrecoDeVendaUnidade, Descricao from produto where nome LIKE @nome AND Tipo LIKE @Tipo;";

                    if (string.IsNullOrEmpty(strTipo)) {
                        strTipo = "%%%";
                    }
                    else
                    {
                        strTipo = "%" + strTipo + "%";
                    }

                    if (string.IsNullOrEmpty(strNome))
                    {
                        strNome = "%%%";
                    }
                    else {
                        strNome = "%" + strNome + "%";
                    }

                    MySqlCommand cmd = new MySqlCommand(query, conexaoMySQL);

                    cmd.Parameters.AddWithValue("@nome", strNome);
                    cmd.Parameters.AddWithValue("@Tipo", strTipo);


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
                    MySqlCommand cmd = new MySqlCommand("SELECT '' AS nome, '' AS Produto_ID  UNION SELECT nome, Produto_ID FROM produto;", conexaoMySQL);

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
                    MySqlCommand cmd = new MySqlCommand("select nome, Tipo, Tamanho, Peso, UDM, CustoPorUnidade, PrecoDeVendaUnidade, Descricao from produto;", conexaoMySQL);

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

        public DataSet visualizarGridEID()
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
                    MySqlCommand cmd = new MySqlCommand("select Produto_ID, nome, Tipo, Tamanho, Peso, UDM, CustoPorUnidade, PrecoDeVendaUnidade, Descricao from produto;", conexaoMySQL);

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
                    string query = "select nome, Tipo, Tamanho, Peso, UDM, CustoPorUnidade, PrecoDeVendaUnidade, Descricao from produto where nome LIKE @nome AND Tipo LIKE @Tipo AND Tamanho LIKE @Tamanho AND Descricao LIKE @Descricao;";

                    if (string.IsNullOrEmpty(produto.Nome))
                    {
                        produto.Nome = "%";
                    }
                    else
                    {
                        produto.Nome = "%" + produto.Nome + "%";
                    }

                    if (string.IsNullOrEmpty(produto.Tipo))
                    {
                        produto.Tipo = "%";
                    }
                    else
                    {
                        produto.Tipo = "%" + produto.Tipo + "%";
                    }

                    if (string.IsNullOrEmpty(produto.Tamanho))
                    {
                        produto.Tamanho = "%";
                    }
                    else
                    {
                        produto.Tamanho = "%" + produto.Tamanho + "%";
                    }
                    if (string.IsNullOrEmpty(produto.Descricao))
                    {
                        produto.Descricao = "%";
                    }
                    else
                    {
                        produto.Descricao = "%" + produto.Descricao + "%";
                    }

                    conexaoMySQL.Open();

                    /*
                    string query = "select nome, Tipo, Tamanho, Peso, UDM, CustoPorUnidade, PrecoDeVendaUnidade, Descricao from produto where nome LIKE @nome OR Tipo LIKE @Tipo OR Tamanho LIKE @Tamanho OR Descricao LIKE @Descricao;";
                    if ((!string.IsNullOrEmpty(produto.Nome) || !string.IsNullOrEmpty(produto.Tipo) || !string.IsNullOrEmpty(produto.Tamanho)) && produto.Descricao == "%%%") { 
                        query = "select nome, Tipo, Tamanho, Peso, UDM, CustoPorUnidade, PrecoDeVendaUnidade, Descricao from produto where (nome LIKE @nome OR Tipo LIKE @Tipo OR Tamanho LIKE @Tamanho) AND Descricao LIKE @Descricao;";
                    }*/

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
                finally
                {
                    conexaoMySQL.Close();
                }
                return sDs;
            }
        }

        public DataSet visualizarGridComParametrosEID(ProdutoModels produto)
        {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    string query = "select Produto_ID, nome, Tipo, Tamanho, Peso, UDM, CustoPorUnidade, PrecoDeVendaUnidade, Descricao from produto where nome LIKE @nome AND Tipo LIKE @Tipo AND Tamanho LIKE @Tamanho AND Descricao LIKE @Descricao;";

                    if (string.IsNullOrEmpty(produto.Nome))
                    {
                        produto.Nome = "%";
                    }
                    else
                    {
                        produto.Nome = "%" + produto.Nome + "%";
                    }

                    if (string.IsNullOrEmpty(produto.Tipo))
                    {
                        produto.Tipo = "%";
                    }
                    else
                    {
                        produto.Tipo = "%" + produto.Tipo + "%";
                    }

                    if (string.IsNullOrEmpty(produto.Tamanho))
                    {
                        produto.Tamanho = "%";
                    }
                    else
                    {
                        produto.Tamanho = "%" + produto.Tamanho + "%";
                    }
                    if (string.IsNullOrEmpty(produto.Descricao))
                    {
                        produto.Descricao = "%";
                    }
                    else
                    {
                        produto.Descricao = "%" + produto.Descricao + "%";
                    }

                    conexaoMySQL.Open();

                    /*
                    string query = "select nome, Tipo, Tamanho, Peso, UDM, CustoPorUnidade, PrecoDeVendaUnidade, Descricao from produto where nome LIKE @nome OR Tipo LIKE @Tipo OR Tamanho LIKE @Tamanho OR Descricao LIKE @Descricao;";
                    if ((!string.IsNullOrEmpty(produto.Nome) || !string.IsNullOrEmpty(produto.Tipo) || !string.IsNullOrEmpty(produto.Tamanho)) && produto.Descricao == "%%%") { 
                        query = "select nome, Tipo, Tamanho, Peso, UDM, CustoPorUnidade, PrecoDeVendaUnidade, Descricao from produto where (nome LIKE @nome OR Tipo LIKE @Tipo OR Tamanho LIKE @Tamanho) AND Descricao LIKE @Descricao;";
                    }*/

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
                finally
                {
                    conexaoMySQL.Close();
                }
                return sDs;
            }
        }

        public bool atualizarProdutos(List<ProdutoModels> listProduto)
        {
            bool verificaAtualizacao = false;

            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                conexaoMySQL.Open();

                //MySqlTransaction tran = conexaoMySQL.BeginTransaction();

                try
                {
                    foreach (ProdutoModels produto in listProduto)
                    {
                        MySqlCommand cmd = new MySqlCommand("UPDATE produto SET  Tipo = @Tipo, Tamanho = @Tamanho, Peso = @Peso, UDM = @UDM, nome = @nome, CustoPorUnidade = @CustoPorUnidade, PrecoDeVendaUnidade = @PrecoDeVendaUnidade, Descricao = @Descricao WHERE Produto_ID = @Produto_ID;", conexaoMySQL);
                        //cmd.Transaction = tran;

                        cmd.Parameters.AddWithValue("@nome", produto.Nome);
                        cmd.Parameters.AddWithValue("@Tipo", produto.Tipo);
                        cmd.Parameters.AddWithValue("@Tamanho", produto.Tamanho);
                        cmd.Parameters.AddWithValue("@Peso", produto.Peso);
                        cmd.Parameters.AddWithValue("@UDM", produto.UDM);
                        cmd.Parameters.AddWithValue("@CustoPorUnidade", produto.CustoPorUnidade);
                        cmd.Parameters.AddWithValue("@PrecoDeVendaUnidade", produto.PrecoDeVendaUnidade);
                        cmd.Parameters.AddWithValue("@Descricao", produto.Descricao);
                        cmd.Parameters.AddWithValue("@Produto_ID", produto.Produto_ID);

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

        public bool excluirProdutos(List<int> listProdutosId) {
            bool verifica = false;

            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                conexaoMySQL.Open();

                //MySqlTransaction tran = conexaoMySQL.BeginTransaction();

                try
                {
                    foreach (int produtoID in listProdutosId)
                    {
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM produto WHERE Produto_ID = @Produto_ID;", conexaoMySQL);
                        //cmd.Transaction = tran;

                        cmd.Parameters.AddWithValue("@Produto_ID", produtoID);

                        cmd.ExecuteNonQuery();
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
