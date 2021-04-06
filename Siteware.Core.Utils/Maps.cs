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
                    .ForMember(x => x.Id, map => map.MapFrom(m => m.FkProduto.PkProdutoId))
                    .ForMember(x => x.Nome, map => map.MapFrom(m => m.FkProduto.Nome))
                    .ForMember(x => x.Preco, map => map.MapFrom(m => m.Preco1))
                    .ForMember(x => x.Promocao, map => map.MapFrom(m => m.FkProduto.PromocaoProdutos))
                    .ForMember(x => x.DataEntrada, map => map.MapFrom(m => m.FkProduto.DataEntrada));
                cfg.CreateMap<Preco, ProdutoDTO>()
                    .ForMember(x => x.Id, map => map.MapFrom(m => m.FkProduto.PkProdutoId))
                    .ForMember(x => x.Nome, map => map.MapFrom(m => m.FkProduto.Nome))
                    .ForMember(x => x.Preco, map => map.MapFrom(m => m.Preco1))
                    .ForMember(x => x.Promocao, map => map.MapFrom(m => m.FkProduto.PromocaoProdutos))
                    .ForMember(x => x.DataEntrada, map => map.MapFrom(m => m.FkProduto.DataEntrada))
                    .ReverseMap();

                cfg.CreateMap<Produto, ProdutoDTO>()
                    .ForMember(x => x.Id, map => map.MapFrom(m => m.PkProdutoId));
                cfg.CreateMap<Produto, ProdutoDTO>()
                    .ForMember(x => x.Id, map => map.MapFrom(m => m.PkProdutoId))
                    .ReverseMap();

                cfg.CreateMap<Promocao, PromocaoDTO>()
                    .ForMember(x => x.Id, map => map.MapFrom(m => m.PkPromocaoId));
                cfg.CreateMap<Promocao, PromocaoDTO>()
                    .ForMember(x => x.Id, map => map.MapFrom(m => m.PkPromocaoId))
                    .ReverseMap();

                cfg.CreateMap<Preco, PrecoDTO>()
                    .ForMember(x => x.Id, map => map.MapFrom(m => m.PkPrecoId));
                cfg.CreateMap<Preco, PrecoDTO>()
                    .ForMember(x => x.Id, map => map.MapFrom(m => m.PkPrecoId))
                    .ReverseMap();

                cfg.CreateMap<Usuario, UsuarioDTO>()
                    .ForMember(x => x.Id, map => map.MapFrom(m => m.PkUsuarioId));
                cfg.CreateMap<Usuario, UsuarioDTO>()
                    .ForMember(x => x.Id, map => map.MapFrom(m => m.PkUsuarioId))
                    .ReverseMap();

                cfg.CreateMap<Pedido, PedidoDTO>()
                    .ForMember(x => x.Id, map => map.MapFrom(m => m.PkPedidoId));
                cfg.CreateMap<Pedido, PedidoDTO>()
                    .ForMember(x => x.Id, map => map.MapFrom(m => m.PkPedidoId))
                    .ReverseMap();
            });

            return config;
        }
    }
}
