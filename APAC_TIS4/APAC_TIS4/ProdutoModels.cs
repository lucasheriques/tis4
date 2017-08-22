using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4
{
    class ProdutoModels
    {
        private string nome;
        private string tipo;
        private string tamanho;
        private float peso;
        private string uDM;
        private float preco;
        private float custoPorUnidade;
        private float precoDeVendaUnidade;
        private string descricao;

        public string Nome { get { return nome; } set { this.nome = value; } }
        public string Tipo { get { return tipo; } set { this.tipo = value;  } }
        public string Tamanho { get { return tamanho; } set { this.tamanho = value;  } }
        public float Peso { get { return peso; } set { this.peso = value; } }
        public string UDM { get { return uDM;  } set { this.uDM = value; } }
        public float Preco { get { return preco; } set { this.preco = value; } }
        public float CustoPorUnidade { get { return custoPorUnidade; } set { this.custoPorUnidade = value; } }
        public float PrecoDeVendaUnidade { get { return precoDeVendaUnidade; } set { this.precoDeVendaUnidade = value; } }
        public string Descricao { get { return descricao;  } set { this.descricao = value; } }
    }
}
