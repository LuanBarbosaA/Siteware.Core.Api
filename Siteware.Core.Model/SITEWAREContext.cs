using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Siteware.Core.Model
{
    public partial class SITEWAREContext : DbContext
    {
        public SITEWAREContext()
        {
        }

        public SITEWAREContext(DbContextOptions<SITEWAREContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ItensPedido> ItensPedidos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Preco> Precos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Promocao> Promocaos { get; set; }
        public virtual DbSet<PromocaoProduto> PromocaoProdutos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SITEWARE;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<ItensPedido>(entity =>
            {
                entity.HasKey(e => e.PkItensPedido)
                    .HasName("PK__ItensPed__63BD4DDF4A68532E");

                entity.ToTable("ItensPedido");

                entity.Property(e => e.PkItensPedido).HasColumnName("PK_ItensPedido");

                entity.Property(e => e.FkPedidoId).HasColumnName("FK_PedidoId");

                entity.Property(e => e.FkPrecoId).HasColumnName("FK_PrecoId");

                entity.Property(e => e.FkProdutoId).HasColumnName("FK_ProdutoId");

                entity.HasOne(d => d.FkPedido)
                    .WithMany(p => p.ItensPedidos)
                    .HasForeignKey(d => d.FkPedidoId)
                    .HasConstraintName("FK__ItensPedi__FK_Pe__571DF1D5");

                entity.HasOne(d => d.FkPreco)
                    .WithMany(p => p.ItensPedidos)
                    .HasForeignKey(d => d.FkPrecoId)
                    .HasConstraintName("FK__ItensPedi__FK_Pr__5812160E");

                entity.HasOne(d => d.FkProduto)
                    .WithMany(p => p.ItensPedidos)
                    .HasForeignKey(d => d.FkProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ItensPedi__FK_Pr__59063A47");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.PkPedidoId)
                    .HasName("PK__Pedido__616FFCCC80F05176");

                entity.ToTable("Pedido");

                entity.Property(e => e.PkPedidoId).HasColumnName("PK_PedidoId");

                entity.Property(e => e.DataEntrada).HasColumnType("date");

                entity.Property(e => e.FkUsuarioId).HasColumnName("FK_UsuarioId");

                entity.HasOne(d => d.FkUsuario)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.FkUsuarioId)
                    .HasConstraintName("FK__Pedido__FK_Usuar__5441852A");
            });

            modelBuilder.Entity<Preco>(entity =>
            {
                entity.HasKey(e => e.PkPrecoId)
                    .HasName("PK__Preco__FF2367E24C399E01");

                entity.ToTable("Preco");

                entity.Property(e => e.PkPrecoId).HasColumnName("PK_PrecoId");

                entity.Property(e => e.DataEntrada).HasColumnType("date");

                entity.Property(e => e.FkProdutoId).HasColumnName("FK_ProdutoId");

                entity.Property(e => e.Preco1)
                    .HasColumnType("money")
                    .HasColumnName("Preco");

                entity.HasOne(d => d.FkProduto)
                    .WithMany(p => p.Precos)
                    .HasForeignKey(d => d.FkProdutoId)
                    .HasConstraintName("FK__Preco__FK_Produt__3D5E1FD2");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.PkProdutoId)
                    .HasName("PK__Produto__B8B6CEBEE615AD34");

                entity.ToTable("Produto");

                entity.Property(e => e.PkProdutoId).HasColumnName("PK_ProdutoId");

                entity.Property(e => e.DataEntrada).HasColumnType("date");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Promocao>(entity =>
            {
                entity.HasKey(e => e.PkPromocaoId)
                    .HasName("PK__Promocao__2CB2F7D590A56EF1");

                entity.ToTable("Promocao");

                entity.Property(e => e.PkPromocaoId).HasColumnName("PK_PromocaoId");

                entity.Property(e => e.DataValidade).HasColumnType("datetime");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.PrecoPromocao).HasColumnType("money");
            });

            modelBuilder.Entity<PromocaoProduto>(entity =>
            {
                entity.HasKey(e => e.PkPromocaoProdutoId)
                    .HasName("PK__Promocao__51F2A4DE2D3E9EF3");

                entity.ToTable("PromocaoProduto");

                entity.Property(e => e.PkPromocaoProdutoId).HasColumnName("PK_PromocaoProdutoId");

                entity.Property(e => e.FkProdutoId).HasColumnName("FK_ProdutoId");

                entity.Property(e => e.FkPromocaoId).HasColumnName("FK_PromocaoId");

                entity.HasOne(d => d.FkProduto)
                    .WithMany(p => p.PromocaoProdutos)
                    .HasForeignKey(d => d.FkProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PromocaoP__FK_Pr__5070F446");

                entity.HasOne(d => d.FkPromocao)
                    .WithMany(p => p.PromocaoProdutos)
                    .HasForeignKey(d => d.FkPromocaoId)
                    .HasConstraintName("FK__PromocaoP__FK_Pr__5165187F");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.PkUsuarioId)
                    .HasName("PK__Usuario__A0D2916B4AAD4A7A");

                entity.ToTable("Usuario");

                entity.Property(e => e.PkUsuarioId).HasColumnName("PK_UsuarioId");

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
