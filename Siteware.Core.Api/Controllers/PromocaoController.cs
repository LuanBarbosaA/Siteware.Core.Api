using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siteware.Core.DTO;
using Siteware.Core.Services.Promocao;

namespace Siteware.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocaoController : ControllerBase
    {
        private readonly IPromocaoService promocaoService;

        public PromocaoController(IPromocaoService promocao)
        {
            this.promocaoService = promocao;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<PromocaoDTO> ObterPromocoes()
        {
            return promocaoService.ObterPromocoes();
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize]
        public PromocaoDTO ObterPromocao(int id)
        {
            return promocaoService.ObterPromocao(id);
        }

        [HttpPost]
        [Authorize]
        public void InserirPromocao(PromocaoDTO promocao)
        {
            promocaoService.InserirPromocao(promocao);
        }

        [HttpPut]
        [Authorize]
        public void AlterarPromocao(PromocaoDTO promocao)
        {
            promocaoService.AlterarPromocao(promocao);
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize]
        public void RemoverPromocao(int id)
        {
            promocaoService.RemoverPromocao(id);
        }
    }
}
