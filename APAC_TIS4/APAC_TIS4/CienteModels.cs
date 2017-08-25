using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4
{
    class CienteModels
    {
        private int cliente_ID;

        public String nome { get; set; }

        public String localidade { get; set; }

        private string tipo;

        public int Cliente_ID { get { return this.cliente_ID; } set { this.cliente_ID = value; } }

        public String Tipo { get { return this.tipo; } set { if (value == "Pátio de Obras" || value == "Escolas" || value == "Casas de Acolhimento") { tipo = value; } } }
    }
}
