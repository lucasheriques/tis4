using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4
{
    class Receita_InsumoModels
    {
        private int receita_ID;
        private ReceitaModels receita;
        private List<InsumoModels> insumo;
        private List<string> unidadeDeMedida;

        public int Receita_ID { get { return this.receita_ID; } set { this.receita_ID = value; } }
        public ReceitaModels Receita { get { return this.receita; } set { this.receita = value; } }
        public List<InsumoModels> Insumo { get { return this.insumo; } set { this.insumo = value; } }
        public List<string> UnidadeDeMedida { get { return this.unidadeDeMedida; } set { this.unidadeDeMedida = value; } }

    }
}
