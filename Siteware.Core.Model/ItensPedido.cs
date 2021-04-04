using System;
using System.Collections.Generic;

#nullable disable

namespace Siteware.Core.Model
{
    public partial class ItensPedido
    {
        public int PkItensPedido { get; set; }
        public short QuantidadeProduto { get; set; }
        public int FkPedidoId { get; set; }
        public int FkPrecoId { get; set; }
        public int FkProdutoId { get; set; }

        public virtual Pedido FkPedido { get; set; }
        public virtual Preco FkPreco { get; set; }
        public virtual Produto FkProduto { get; set; }
    }
}
