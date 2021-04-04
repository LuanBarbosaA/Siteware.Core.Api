using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Core.DTO
{
    public class ProdutoDTO
    {
        public string Nome { get; set; }
        public DateTime DataEntrada { get; set; }
        public PrecoDTO Preco { get; set; }
        public IEnumerable<PromocaoDTO>?  Promocao { get; set; }
    }
}
