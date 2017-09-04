using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4
{
    class InsumoModels
    {
        private int insumo_ID;
        private string nome;
        private string descricao;
        private float peso_Por_Unidade;
        private string unidade_De_Medida;
        private float peso_Total;
        private float custo;
        private int quantidade_Estoque;
        private float custo_Total;

        public string Nome { get { return this.nome; } set { this.nome = value; } }
        public string Descricao { get { return this.descricao; } set { this.descricao = value; } }
        public float Peso_Por_Unidade { get { return this.peso_Por_Unidade; } set { this.peso_Por_Unidade = value; } }
        public string Unidade_De_Medida { get { return this.unidade_De_Medida; } set { this.unidade_De_Medida = value; } }
        public float Peso_Total { get { return this.peso_Total; } set { this.peso_Total = value; } }
        public float Custo { get { return this.custo; } set { this.custo = value; } }
        public int Quantidade_Estoque { get { return this.quantidade_Estoque; } set { this.quantidade_Estoque = value; } }
        public float Custo_Total { get { return this.custo_Total; } set { this.custo_Total = value; } }
        public int Insumo_ID { get { return this.insumo_ID; } set { this.insumo_ID = value; } }

    }
}
