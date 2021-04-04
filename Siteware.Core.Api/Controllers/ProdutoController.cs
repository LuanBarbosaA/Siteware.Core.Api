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

        ProdutoController(IProdutoService produto)
        {
            this.produtoService = produto;
        }

        [HttpGet]
        public IEnumerable<ProdutoDTO> ObterProdutos()
        {
            return produtoService.ObterProdutos();
        }
    }
}
