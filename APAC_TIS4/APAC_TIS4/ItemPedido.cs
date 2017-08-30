
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace APAC_TIS4
{
    class ItemPedido
    {
        private ProdutoModels produto;
        private CienteModels cliente;
        private int produto_ID;
        private int cliente_ID;

        public int Produto_ID { get { return produto_ID; } set { this.produto_ID = value; } }
        public int Cliente_ID { get { return this.cliente_ID; } set { this.cliente_ID = value; } }
        public ProdutoModels Produto { get { return produto; } set { this.produto = value; } }
        public CienteModels Cliente { get { return this.cliente; } set { this.cliente = value; } }

    }
}