using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace APAC_TIS4
{
    class RelatoriosDAO
    {

        public RelatoriosDAO() {
        }

        public Chart loadChart(Chart chartGrafico) {
            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                conexaoMySQL.Open();
                try
                {
                    MySqlCommand cmd = new MySqlCommand("SELECT * FROM vw_RelatorioLucros", conexaoMySQL);
                    //cmd.Transaction = tran;
                    MySqlDataReader myReader = cmd.ExecuteReader();

                    while (myReader.Read())
                    {
                        chartGrafico.Series.Add("Lucro Janeiro");
                        chartGrafico.Series["Lucro Janeiro"].Points.AddXY("", myReader.GetInt32("LUCRO_JAN"));
                        chartGrafico.Series.Add("Lucro Fevereiro");
                        chartGrafico.Series["Lucro Fevereiro"].Points.AddXY("", myReader.GetInt32("LUCRO_FEV"));
                        chartGrafico.Series.Add("Lucro Março");
                        chartGrafico.Series["Lucro Março"].Points.AddXY("", myReader.GetInt32("LUCRO_MAR"));
                        chartGrafico.Series.Add("Lucro Abril");
                        chartGrafico.Series["Lucro Abril"].Points.AddXY("", myReader.GetInt32("LUCRO_ABR"));
                        chartGrafico.Series.Add("Lucro Maio");
                        chartGrafico.Series["Lucro Maio"].Points.AddXY("", myReader.GetInt32("LUCRO_MAI"));
                        chartGrafico.Series.Add("Lucro Junho");
                        chartGrafico.Series["Lucro Junho"].Points.AddXY("", myReader.GetInt32("LUCRO_JUN"));
                        chartGrafico.Series.Add("Lucro Julho");
                        chartGrafico.Series["Lucro Julho"].Points.AddXY("", myReader.GetInt32("LUCRO_JUL"));
                        chartGrafico.Series.Add("Lucro Agosto");
                        chartGrafico.Series["Lucro Agosto"].Points.AddXY("", myReader.GetInt32("LUCRO_AGO"));
                        chartGrafico.Series.Add("Lucro Setembro");
                        chartGrafico.Series["Lucro Setembro"].Points.AddXY("", myReader.GetInt32("LUCRO_SET"));
                        chartGrafico.Series.Add("Lucro Outubro");
                        chartGrafico.Series["Lucro Outubro"].Points.AddXY("", myReader.GetInt32("LUCRO_OUT"));
                        chartGrafico.Series.Add("Lucro Novembro");
                        chartGrafico.Series["Lucro Novembro"].Points.AddXY("", myReader.GetInt32("LUCRO_NOV"));
                        chartGrafico.Series.Add("Lucro Dezembro");
                        chartGrafico.Series["Lucro Dezembro"].Points.AddXY("", myReader.GetInt32("LUCRO_DEZ"));
                    }
                }
                finally
                {
                    conexaoMySQL.Close();
                }

                return chartGrafico;
            }
        }

        public DataSet loadGrid() {
            DataSet sDs = new DataSet();
            SingletonBD singleton = SingletonBD.getInstancia();
            using (MySqlConnection conexaoMySQL = singleton.getConexao())
            {
                try
                {
                    conexaoMySQL.Open();

                    /* criando o comando sql indicando a nossa conexão e a nossa
                    procedure */
                    string query = "SELECT * FROM vw_relatoriolucros;";

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
    }
}

