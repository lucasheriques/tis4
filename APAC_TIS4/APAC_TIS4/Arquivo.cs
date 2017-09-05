using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace APAC_TIS4
{
    class Arquivo
    {
        private StreamWriter escrita;
        private string nomeCaminhoArquivo;

        private Object thisLock = new Object();

        public Arquivo(string nomeDoArquivo) {
            string dir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            string path = Path.Combine(dir, "Configuracao");

            this.nomeCaminhoArquivo = path + @"\" + nomeDoArquivo;
        }

        public bool salvaConfiguracao(string servidor, string baseDeDados, string usuario, string senha) {
            bool verifica = false;
            try
            {
                /* Verifica se o arquivo existe, se não existir 
                   o mesmo é criado.*/
                if (!File.Exists(this.nomeCaminhoArquivo))
                {
                    var file = File.Create(this.nomeCaminhoArquivo);
                    file.Close();
                }

                /* Inicia a leitura do arquivo e verifica se o arquivo
                   contem algo já gravado, se tiver será apagado. */
                //this.leitura = new StreamReader(this.nomeCaminhoArquivo);
                int count = File.ReadAllLines(this.nomeCaminhoArquivo).Length;//this.leitura.ReadToEnd().Count();
                if (count > 0)
                {
                    File.Delete(this.nomeCaminhoArquivo);
                }
                if (!File.Exists(this.nomeCaminhoArquivo))
                {
                    var file = File.Create(this.nomeCaminhoArquivo);
                    file.Close();
                }

                /* Inicia a escrita do arquivo */
                this.escrita = new StreamWriter(this.nomeCaminhoArquivo);

                /*Inicia gravação das novas configurações. */
                this.escrita.WriteLine("Servidor: " + servidor);
                this.escrita.WriteLine("Base De Dados: " + baseDeDados);
                this.escrita.WriteLine("Usuario: " + usuario);
                this.escrita.WriteLine("Senha: " + senha);

                verifica = true;
            }
            catch
            {
            }
            finally {
                //this.leitura.Close();
                this.escrita.Close();
            }

            return verifica;
        }

        public SingletonBD leituraConfiguracao() {
            lock (this.thisLock)
            {

                SingletonBD singletonBD = new SingletonBD("");
                try
                {
                    /* Inicia a leitura do arquivo */

                    string[] linhasConfiguracao = File.ReadAllLines(this.nomeCaminhoArquivo);

                    foreach (string linha in linhasConfiguracao)
                    {
                        string atributo;
                        if (linha.ToLower().Contains("servidor: "))
                        {
                            atributo = linha.Replace("Servidor: ", "");
                            singletonBD.Server = atributo;
                        }
                        else if (linha.ToLower().Contains("base de dados: "))
                        {
                            atributo = linha.Replace("Base De Dados: ", "");
                            singletonBD.Database = atributo;
                        }
                        else if (linha.ToLower().Contains("usuario: "))
                        {
                            atributo = linha.Replace("Usuario: ", "");
                            singletonBD.Usuario = atributo;
                        }
                        else if (linha.ToLower().Contains("senha: "))
                        {
                            atributo = linha.Replace("Senha: ", "");
                            singletonBD.Senha = atributo;
                        }
                    }
                }
                catch
                {
                }

                return singletonBD;
            }
        }
    }
}
