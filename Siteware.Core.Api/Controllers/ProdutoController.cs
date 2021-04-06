using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siteware.Core.DTO;
using Siteware.Core.Services.Produto;

namespace Siteware.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService produtoService;

        public ProdutoController(IProdutoService produto)
        {
            this.produtoService = produto;
        }

        [HttpGet]
        public IEnumerable<ProdutoDTO> ObterProdutos()
        {
            return produtoService.ObterProdutos();
        }

        [HttpGet]
        [Route("{id}")]
        public ProdutoDTO ObterProduto(int id)
        {
            return produtoService.ObterProduto(id);
        }

        [HttpPost]
        public void InserirProduto(ProdutoDTO produto)
        {
            produtoService.InserirProduto(produto);
        }

        [HttpPut]
        public void AlterarProduto(ProdutoDTO produto)
        {
            produtoService.AlterarProduto(produto);
        }

        [HttpDelete]
        [Route("{id}")]
        public void RemoverProdutos(int id)
        {
            produtoService.RemoverProduto(id);
        }
    }
}
