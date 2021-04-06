using Siteware.Core.Model;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using Siteware.Core.Data;
using Siteware.Core.DTO;
using Siteware.Core.Utils;
using AutoMapper;

namespace Siteware.Core.Services.Promocao
{
    public class PromocaoService : IPromocaoService
    {
        private readonly PromocaoData promocaoData = new PromocaoData();
        private readonly IMapper mapper;
        public PromocaoService(IMaps mapper)
        {
            this.mapper = mapper.Configurar().CreateMapper();
        }
        public IEnumerable<PromocaoDTO> ObterPromocoes()
        {
            return mapper.Map<IEnumerable<PromocaoDTO>>(promocaoData.ObterPromocoes());
        }

        public PromocaoDTO ObterPromocao(int id)
        {
            return mapper.Map<PromocaoDTO>(promocaoData.ObterPromocao(id));
        }

        public void InserirPromocao(PromocaoDTO promocao)
        {
            var map = mapper.Map<Model.Promocao>(promocao);
            promocaoData.InserirPromocao(map);
        }

        public void AlterarPromocao(PromocaoDTO promocao)
        {
            var map = mapper.Map<Model.Promocao>(promocao);
            promocaoData.AlterarPromocao(map);
        }

        public void RemoverPromocao(int id)
        {
            promocaoData.RemoverPromocao(id);
        }
        public void AdicionarProdutoEmPromocao(int IdProduto, int IdPromocao)
        {
            PromocaoProduto promocaoProduto = new PromocaoProduto();
            promocaoProduto.FkProdutoId = IdProduto;
            promocaoProduto.FkPromocaoId = IdPromocao;
            this.promocaoData.AssociarProdutoPromocao(promocaoProduto);
        }

        public void RemoverProdutoDePromocao(int IdProduto, int IdPromocao)
        {
            PromocaoProduto promocaoProduto = new PromocaoProduto();
            promocaoProduto.FkProdutoId = IdProduto;
            promocaoProduto.FkPromocaoId = IdPromocao;
            this.promocaoData.DesassociarProdutoPromocao(promocaoProduto);
        }
    }
}
