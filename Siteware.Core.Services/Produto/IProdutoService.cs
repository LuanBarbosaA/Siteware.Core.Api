using Siteware.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Core.Services.Produto
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoDTO> ObterProdutos();
    }
}
