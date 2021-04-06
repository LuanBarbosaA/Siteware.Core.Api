using Siteware.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Core.Services.Produto
{
    public interface IProdutoService
    {
        IEnumerable<ProdutoDTO> ObterProdutos();
        ProdutoDTO ObterProduto(int id);
        void InserirProduto(ProdutoDTO produto);
        void AlterarProduto(ProdutoDTO produto);
        void RemoverProduto(int id);
    }
}
