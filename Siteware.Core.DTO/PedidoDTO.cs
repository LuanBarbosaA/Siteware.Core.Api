using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Core.DTO
{
    public class PedidoDTO
    {
        public int Id { get; set; }
        public DateTime DataEntrada { get; set; }
        public IEnumerable<PrecoDTO> Precos { get; set; }
        public IEnumerable<ProdutoDTO> Produtos { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
