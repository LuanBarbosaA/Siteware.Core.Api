using System;
using System.Collections.Generic;

#nullable disable

namespace Siteware.Core.Model
{
    public partial class Promocao
    {
        public Promocao()
        {
            PromocaoProdutos = new HashSet<PromocaoProduto>();
        }

        public int PkPromocaoId { get; set; }
        public string Nome { get; set; }
        public byte QtdMinimoProduto { get; set; }
        public decimal? PrecoPromocao { get; set; }
        public DateTime DataValidade { get; set; }

        public virtual ICollection<PromocaoProduto> PromocaoProdutos { get; set; }
    }
}
