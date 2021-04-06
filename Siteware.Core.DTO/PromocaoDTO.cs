using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Core.DTO
{
    public class PromocaoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte QtdMinimoProduto { get; set; }
        public decimal? PrecoPromocao { get; set; }
        public DateTime DataValidade { get; set; }
    }
}
