using Siteware.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Siteware.Core.DTO;

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
                                                                            .Include(x => x.FkProduto.PromocaoProdutos)
                                                                            .ThenInclude(x => x.FkPromocao)
                                                                            .ToList();
                    return precosProdutos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Preco ObterProdutoPrecos(int id)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    Preco precoProdutos = context.Precos.Include(x => x.FkProduto)
                                                                            .Include(x => x.FkProduto.PromocaoProdutos)
                                                                            .ThenInclude(x => x.FkPromocao)
                                                                            .Where(x => x.FkProdutoId == id)
                                                                            .FirstOrDefault();
                    return precoProdutos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void InserirProduto(Produto produto)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    context.Produtos.Add(produto);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AlterarProduto(Produto produto)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    var result = context.Produtos.FirstOrDefault(x => x.PkProdutoId == produto.PkProdutoId);
                    result = produto;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void RemoverProduto(int id)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    var result = context.Produtos.FirstOrDefault(x => x.PkProdutoId == id);
                    context.Produtos.Remove(result);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}
