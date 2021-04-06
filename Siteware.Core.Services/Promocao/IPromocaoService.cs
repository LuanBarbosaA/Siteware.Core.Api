using Siteware.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Core.Services.Promocao
{
    public interface IPromocaoService
    {
        void AdicionarProdutoEmPromocao(int IdProduto, int IdPromocao);
        void RemoverProdutoDePromocao(int IdProduto, int IdPromocao);
        void RemoverPromocao(int id);
        void AlterarPromocao(PromocaoDTO promocao);
        void InserirPromocao(PromocaoDTO promocao);
        PromocaoDTO ObterPromocao(int id);
        IEnumerable<PromocaoDTO> ObterPromocoes();
    }
}
