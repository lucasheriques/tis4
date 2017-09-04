using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4
{
    class ReceitaModels
    {
        private DateTime dataCriacao;
        private DateTime dataUltimaAtualizacao;
        private string observacao;
        private string modoDePreparo;
        private Receita_InsumoModels receita_Insumo;
        private ProdutoModels produto;

        public DateTime DataCriacao { get { return this.dataCriacao; } set { this.dataCriacao = value; } }
        public DateTime DataUltimaAtualizacao { get { return this.dataUltimaAtualizacao; } set { this.dataUltimaAtualizacao = value; } }
        public string Observacao { get { return this.observacao; } set { this.observacao = value; } }
        public string ModoDePreparo { get { return this.modoDePreparo; } set { this.modoDePreparo = value; } }
        public Receita_InsumoModels Receita_Insumo { get { return this.receita_Insumo; } set { this.receita_Insumo = value; } }
        public ProdutoModels Produto { get { return this.produto; } set { this.produto = value; } }
    }
}
