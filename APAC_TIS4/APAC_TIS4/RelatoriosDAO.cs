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
            if (chartGrafico.Series.Count == 0) {
                SingletonBD singleton = SingletonBD.getInstancia();
                using (MySqlConnection conexaoMySQL = singleton.getConexao())
                {
                    conexaoMySQL.Open();
                    try
                    {
                        MySqlCommand cmd = new MySqlCommand("SELECT ifnull(sum(vw_RelatorioLucros.LUCRO_JAN),0) AS LUCRO_JAN, ifnull(sum(vw_RelatorioLucros.LUCRO_FEV), 0) AS LUCRO_FEV, ifnull(sum(vw_RelatorioLucros.LUCRO_MAR),0) AS LUCRO_MAR, ifnull(sum(vw_RelatorioLucros.LUCRO_ABR),0) AS LUCRO_ABR, ifnull(sum(vw_RelatorioLucros.LUCRO_MAI), 0) AS LUCRO_MAI, ifnull(sum(vw_RelatorioLucros.LUCRO_JUN), 0) AS LUCRO_JUN, ifnull(sum(vw_RelatorioLucros.LUCRO_JUL), 0) AS LUCRO_JUL, ifnull(sum(vw_RelatorioLucros.LUCRO_AGO), 0) AS LUCRO_AGO, ifnull(sum(vw_RelatorioLucros.LUCRO_SET), 0) AS LUCRO_SET, ifnull(sum(vw_RelatorioLucros.LUCRO_OUT), 0) AS LUCRO_OUT, ifnull(sum(vw_RelatorioLucros.LUCRO_NOV), 0) AS LUCRO_NOV, ifnull(sum(vw_RelatorioLucros.LUCRO_DEZ), 0) AS LUCRO_DEZ FROM vw_RelatorioLucros", conexaoMySQL);
                        //cmd.Transaction = tran;
                        MySqlDataReader myReader = cmd.ExecuteReader();

                        if (chartGrafico.Series.Count == 0) {
                            while (myReader.Read())
                            {
                                if (chartGrafico.Series.Count != 12) {
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
                        }

                    }
                    finally
                    {
                        conexaoMySQL.Close();
                    }
                }
            }
            return chartGrafico;
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

