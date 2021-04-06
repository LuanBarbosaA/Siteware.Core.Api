using Siteware.Core.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace Siteware.Core.Data
{
    public class PromocaoData
    {
        public IEnumerable<Promocao> ObterPromocoes()
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    IEnumerable<Promocao> promocoes = context.Promocaos.ToList();
                    return promocoes;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Promocao ObterPromocao(int id)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    Promocao promocao = context.Promocaos.Where(x => x.PkPromocaoId == id).FirstOrDefault();
                    return promocao;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AssociarProdutoPromocao(PromocaoProduto promocaoProduto)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    context.PromocaoProdutos.Add(promocaoProduto);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void DesassociarProdutoPromocao(PromocaoProduto promocaoProduto)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    var result = context.PromocaoProdutos
                                            .Where(x => x.FkPromocaoId == promocaoProduto.FkPromocaoId && x.FkProdutoId == promocaoProduto.FkProdutoId)
                                            .FirstOrDefault();
                    context.PromocaoProdutos.Remove(result);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void InserirPromocao(Promocao promocao)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    context.Promocaos.Add(promocao);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AlterarPromocao(Promocao promocao)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    var result = context.Promocaos.FirstOrDefault(x => x.PkPromocaoId == promocao.PkPromocaoId);
                    result = promocao;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void RemoverPromocao(int id)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    var result = context.Promocaos.FirstOrDefault(x => x.PkPromocaoId == id);
                    context.Promocaos.Remove(result);
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
