using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siteware.Core.DTO;
using Siteware.Core.Services.Pedido;

namespace Siteware.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService pedidoService;

        public PedidoController(IPedidoService pedido)
        {
            this.pedidoService = pedido;
        }

        [HttpGet]
        [Route("usuario/{id}")]
        public IEnumerable<PedidoDTO> ObterPedidos(int id)
        {
            return pedidoService.ObterPedidosUsuario(id);
        }

        [HttpGet]
        [Route("{id}")]
        public PedidoDTO ObterPedido(int id)
        {
            return pedidoService.ObterPedido(id);
        }

        [HttpPost]
        public void InserirProduto(PedidoDTO pedido)
        {
            pedidoService.InserirPedido(pedido);
        }

        [HttpPut]
        public void AlterarProduto(PedidoDTO pedido)
        {
            pedidoService.AlterarPedido(pedido);
        }

        [HttpDelete]
        [Route("{id}")]
        public void RemoverProdutos(int id)
        {
            pedidoService.RemoverPedido(id);
        }
    }
}
