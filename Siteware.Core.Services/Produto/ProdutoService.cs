using AutoMapper;
using Siteware.Core.Data;
using Siteware.Core.DTO;
using Siteware.Core.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Core.Services.Produto
{
    public class ProdutoService : IProdutoService
    {
        private readonly ProdutoData produtoData = new ProdutoData();
        private readonly IMapper mapper;

        public ProdutoService(IMaps mapper)
        {
            this.mapper = mapper.Configurar().CreateMapper();
        }

        public IEnumerable<ProdutoDTO> ObterProdutos()
        {
            return mapper.Map<IEnumerable<ProdutoDTO>>(produtoData.ObterProdutosPrecos());
        }

        public ProdutoDTO ObterProduto(int id)
        {
            return mapper.Map<ProdutoDTO>(produtoData.ObterProdutoPrecos(id));
        }

        public void InserirProduto(ProdutoDTO produto)
        {
            var map = mapper.Map<Model.Produto>(produto);
            produtoData.InserirProduto(map);
        }

        public void AlterarProduto(ProdutoDTO produto)
        {
            var map = mapper.Map<Model.Produto>(produto);
            produtoData.AlterarProduto(map);
        }

        public void RemoverProduto(int id)
        {
            produtoData.RemoverProduto(id);
        }
    }
}
