using System;
using System.Collections.Generic;

#nullable disable

namespace Siteware.Core.Model
{
    public partial class Produto
    {
        public Produto()
        {
            ItensPedidos = new HashSet<ItensPedido>();
            Precos = new HashSet<Preco>();
            PromocaoProdutos = new HashSet<PromocaoProduto>();
        }

        public int PkProdutoId { get; set; }
        public string Nome { get; set; }
        public DateTime DataEntrada { get; set; }

        public virtual ICollection<ItensPedido> ItensPedidos { get; set; }
        public virtual ICollection<Preco> Precos { get; set; }
        public virtual ICollection<PromocaoProduto> PromocaoProdutos { get; set; }
    }
}
