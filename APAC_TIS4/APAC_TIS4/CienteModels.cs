using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4
{
    class CienteModels
    {
        public String nome { get; set; }

        public String localidade { get; set; }

        private string tipo;

        public String Tipo { get { return this.tipo; } set { if (value == "Escola Municipal" || value == "Escola Estadual" || value == "Escola" || value == "Outros") { tipo = value; } } }
    }
}
