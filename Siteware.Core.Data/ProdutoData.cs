using Siteware.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Siteware.Core.Data
{
    public class ProdutoData
    {
        public IEnumerable<Preco> ObterProdutosPrecos()
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    IEnumerable<Preco> precosProdutos = context.Precos.Include(x => x.FkProduto)
                                                                            .Include(x => x.FkProduto.PromocaoProdutos.Select(x => new { x, x.FkPromocao })
                                                                                                                              .AsEnumerable()
                                                                                                                              .Select(x => x.FkPromocao)
                                                                                                                              .ToList());
                    return precosProdutos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
