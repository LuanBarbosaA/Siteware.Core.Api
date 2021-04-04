using System;
using System.Collections.Generic;

#nullable disable

namespace Siteware.Core.Model
{
    public partial class PromocaoProduto
    {
        public int PkPromocaoProdutoId { get; set; }
        public int FkProdutoId { get; set; }
        public int FkPromocaoId { get; set; }

        public virtual Produto FkProduto { get; set; }
        public virtual Promocao FkPromocao { get; set; }
    }
}
