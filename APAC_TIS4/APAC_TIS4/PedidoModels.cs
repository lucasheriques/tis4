using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APAC_TIS4
{
    class PedidoModels
    {
        private ItemPedido itemPedido = new ItemPedido();

        private int pedido_ID;
        private DateTime data_Entrega;
        private DateTime data_Pedido;
        private int quantidade;
        private float precoTotal;
        private string strData_Entrega;

        public int Pedido_ID { get { return this.pedido_ID; } set { this.pedido_ID = value; } }
        public DateTime Data_Entrega { get { return this.data_Entrega; } set { this.data_Entrega = value; } }
        public DateTime Data_Pedido { get { return this.data_Pedido; } set { this.data_Pedido = value; } }
        public int Quantidade { get { return this.quantidade; } set { this.quantidade = value; } }
        public float PrecoTotal { get { return this.precoTotal; } set { this.precoTotal = value; } }
        public ItemPedido _ItemPedido { get { return this.itemPedido; } set { this.itemPedido = value; } }
        public string StrData_Entrega { get { return this.strData_Entrega; } set { this.strData_Entrega = value; } }


        public PedidoModels() { }

        public PedidoModels(ProdutoModels pProduto_ID, CienteModels pCliente_ID) {
            this._ItemPedido.Produto = pProduto_ID;
            this._ItemPedido.Cliente = pCliente_ID;
        }
    }
}
