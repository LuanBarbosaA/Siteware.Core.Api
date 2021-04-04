using AutoMapper;
using Siteware.Core.DTO;
using Siteware.Core.Model;
using System;

namespace Siteware.Core.Utils
{
    public class Maps : IMaps
    {
        public MapperConfiguration Configurar()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Preco, ProdutoDTO>()
                    .ForMember(x => x.Nome, map => map.MapFrom(m => m.FkProduto.Nome))
                    .ForMember(x => x.Preco, map => map.MapFrom(m => m.Preco1))
                    .ForMember(x => x.Promocao, map => map.MapFrom(m => m.FkProduto.PromocaoProdutos))
                    .ForMember(x => x.DataEntrada, map => map.MapFrom(m => m.FkProduto.DataEntrada));
                cfg.CreateMap<Preco, ProdutoDTO>()
                    .ForMember(x => x.Nome, map => map.MapFrom(m => m.FkProduto.Nome))
                    .ForMember(x => x.Preco, map => map.MapFrom(m => m.Preco1))
                    .ForMember(x => x.Promocao, map => map.MapFrom(m => m.FkProduto.PromocaoProdutos))
                    .ForMember(x => x.DataEntrada, map => map.MapFrom(m => m.FkProduto.DataEntrada))
                    .ReverseMap();
            });

            return config;
        }
    }
}
