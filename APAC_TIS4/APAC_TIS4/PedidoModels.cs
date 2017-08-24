using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4
{
    class PedidoModels
    {
        private ProdutoModels produto;
        private CienteModels cliente;
        private int produto_ID;
        private int cliente_ID;
        private DateTime data_Entrega;
        private DateTime data_Pedido;
        private int quantidade;
        private float precoTotal;

        public int Produto_ID { get { return produto_ID; } set { this.produto_ID = value; } }
        public int Cliente_ID { get { return this.cliente_ID; } set { this.cliente_ID = value; } }
        public ProdutoModels Produto { get { return produto; } set { this.produto = value; } }
        public CienteModels Cliente { get { return this.cliente; } set { this.cliente = value; } }
        public DateTime Data_Entrega { get { return this.data_Entrega; } set { this.data_Entrega = value; } }
        public DateTime Data_Pedido { get { return this.data_Pedido; } set { this.data_Pedido = value; } }
        public int Quantidade { get { return this.quantidade; } set { this.quantidade = value; } }
        public float PrecoTotal { get { return this.precoTotal; } set { this.precoTotal = value; } }

        public PedidoModels() { }

        public PedidoModels(ProdutoModels pProduto_ID, CienteModels pCliente_ID) {
            this.Produto = pProduto_ID;
            this.Cliente = pCliente_ID;
        }
    }
}
