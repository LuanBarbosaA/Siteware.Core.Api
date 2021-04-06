using Siteware.Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Core.Services.Pedido
{
    public interface IPedidoService
    {
        IEnumerable<PedidoDTO> ObterPedidosUsuario(int id);
        PedidoDTO ObterPedido(int id);
        void InserirPedido(PedidoDTO pedido);
        void AlterarPedido(PedidoDTO pedido);
        void RemoverPedido(int id);
    }
}
