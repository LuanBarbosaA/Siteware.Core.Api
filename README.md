# Siteware.Core.Api

Comandos DDL:

  USE SITEWARE;

  CREATE TABLE Usuario (
    PK_UsuarioId int not null primary key identity(1,1),
    Email varchar(60) not null,
    Senha varchar(15) not null,
    Cpf varchar(11) not null,
    Cep varchar(8) not null,
    Endereco varchar(200) not null,
    DataNascimento date not null
  );
  GO

  CREATE TABLE Promocao (
    PK_PromocaoId int not null primary key identity(1,1),
    Nome varchar(60) not null,
    QtdMinimoProduto tinyint not null,
    PrecoPromocao money null,
    DataValidade datetime not null
  );
  GO

  CREATE TABLE Produto (
    PK_ProdutoId int not null primary key identity(1,1),
    Nome varchar(60) not null,
    DataEntrada date not null,
  );
  GO

  CREATE TABLE Preco (
    PK_PrecoId int not null primary key identity(1,1),
    Preco money not null,
    DataEntrada date not null,
    FK_ProdutoId int not null,
    FOREIGN KEY (FK_ProdutoId) REFERENCES Produto (PK_ProdutoId) ON DELETE CASCADE,
  );
  GO

  CREATE TABLE PromocaoProduto (
    PK_PromocaoProdutoId int not null primary key identity(1,1),
    FK_ProdutoId int not null,
    FK_PromocaoId int not null,
    FOREIGN KEY (FK_ProdutoId) REFERENCES Produto (PK_ProdutoId) ON DELETE NO ACTION,
    FOREIGN KEY (FK_PromocaoId) REFERENCES Promocao (PK_PromocaoId) ON DELETE CASCADE
  );
  GO

  CREATE TABLE Pedido (
    PK_PedidoId int not null primary key identity(1,1),
    DataEntrada date not null,
    FK_UsuarioId int not null,
    FOREIGN KEY (FK_UsuarioId) REFERENCES Usuario (PK_UsuarioId) ON DELETE CASCADE,
  );
  GO

  CREATE TABLE ItensPedido (
    PK_ItensPedido int not null primary key identity(1,1),
    QuantidadeProduto smallint not null,
    FK_PedidoId int not null,
    FK_PrecoId int not null,
    FK_ProdutoId int not null,
    FOREIGN KEY (FK_PedidoId) REFERENCES Pedido (PK_PedidoId) ON DELETE CASCADE,
    FOREIGN KEY (FK_PrecoId) REFERENCES Preco (PK_PrecoId) ON DELETE CASCADE,
    FOREIGN KEY (FK_ProdutoId) REFERENCES Produto (PK_ProdutoId) ON DELETE NO ACTION,
  );
  GO

Comando para sincronizar a base de dados com o projeto por meio do EF:
  Scaffold-DbContext "Server=.\SQLExpress;Database=SITEWARE;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
