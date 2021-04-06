using Siteware.Core.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;

namespace Siteware.Core.Data
{
    public class PedidoData
    {
        public IEnumerable<Pedido> ObterPedidosUsuario(int idUsuario)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    IEnumerable<Pedido> pedidos = context.Pedidos.Include(x => x.FkUsuario.PkUsuarioId == idUsuario)
                                                                    .Include(x => x.ItensPedidos)
                                                                        .ThenInclude(x => x.FkProduto)
                                                                            .Include(x => x.FkUsuario)
                                                                            .Include(x => x.ItensPedidos)
                                                                                .ThenInclude(x => x.FkPreco)
                                                                                    .ToList();
                    return pedidos;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public Pedido ObterPedido(int id)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    Pedido pedido = context.Pedidos.Where(x => x.PkPedidoId == id).FirstOrDefault();
                    return pedido;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void InserirPedido(Pedido pedido)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    context.Pedidos.Add(pedido);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void AlterarPedido(Pedido pedido)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    var result = context.Pedidos.FirstOrDefault(x => x.PkPedidoId == pedido.PkPedidoId);
                    result = pedido;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public void RemoverPedido(int id)
        {
            try
            {
                using (var context = new SITEWAREContext())
                {
                    var result = context.Pedidos.FirstOrDefault(x => x.PkPedidoId == id);
                    context.Pedidos.Remove(result);
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
