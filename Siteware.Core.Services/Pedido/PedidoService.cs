using AutoMapper;
using Siteware.Core.Data;
using Siteware.Core.DTO;
using Siteware.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Core.Services.Pedido
{
    public class PedidoService : IPedidoService
    {
        private readonly PedidoData pedidoData = new PedidoData();
        private readonly IMapper mapper;
        public PedidoService(IMaps mapper)
        {
            this.mapper = mapper.Configurar().CreateMapper();
        }

        public IEnumerable<PedidoDTO> ObterPedidosUsuario(int id)
        {
            return mapper.Map<IEnumerable<PedidoDTO>>(pedidoData.ObterPedido(id));
        }

        public PedidoDTO ObterPedido(int id)
        {
            return mapper.Map<PedidoDTO>(pedidoData.ObterPedido(id));
        }

        public void InserirPedido(PedidoDTO pedido)
        {
            // Falta relacionar produtos e precos
            var map = mapper.Map<Model.Pedido>(pedido);
            pedidoData.InserirPedido(map);
        }

        public void AlterarPedido(PedidoDTO pedido)
        {
            var map = mapper.Map<Model.Pedido>(pedido);
            pedidoData.AlterarPedido(map);
        }

        public void RemoverPedido(int id)
        {
            pedidoData.RemoverPedido(id);
        }
    }
}
