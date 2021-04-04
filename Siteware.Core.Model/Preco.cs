using System;
using System.Collections.Generic;

#nullable disable

namespace Siteware.Core.Model
{
    public partial class Preco
    {
        public Preco()
        {
            ItensPedidos = new HashSet<ItensPedido>();
        }

        public int PkPrecoId { get; set; }
        public decimal Preco1 { get; set; }
        public DateTime DataEntrada { get; set; }
        public int FkProdutoId { get; set; }

        public virtual Produto FkProduto { get; set; }
        public virtual ICollection<ItensPedido> ItensPedidos { get; set; }
    }
}
