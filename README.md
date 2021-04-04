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
  
Comandos DML

USE SITEWARE;

INSERT INTO Usuario VALUES ('luan.barbosa@gmail.com', '12345', '12444129610', '30640300', 'Rua A Bairro B', '1997-08-24');
GO

INSERT INTO Produto VALUES ('Controle XBox', '2021-04-02'); /* id 1 */
INSERT INTO Produto VALUES ('Controle PS4', '2021-04-02'); /* id 2 */
INSERT INTO Produto VALUES ('Cabo USB C', '2021-04-02'); /* id 3 */
GO

INSERT INTO Preco VALUES (400.00, '2021-04-02', 1); /* id 1 */
INSERT INTO Preco VALUES (500.00, '2021-04-02', 2); /* id 2 */
INSERT INTO Preco VALUES (5.00, '2021-04-02', 3); /* id 3 */
INSERT INTO Preco VALUES (5.01, '2021-04-03', 3); /* id 4 */
GO

INSERT INTO Promocao VALUES ('Leve 2 e Pague 1', 2, null, '2021-04-07');
INSERT INTO Promocao VALUES ('3 por R$10,00', 3, 10.00, '2021-04-07'); 
GO

INSERT INTO PromocaoProduto VALUES (3, 2);
INSERT INTO PromocaoProduto VALUES (1, 1);
INSERT INTO PromocaoProduto VALUES (2, 1);
GO

INSERT INTO Pedido VALUES ('2021-04-03', 1);
INSERT INTO Pedido VALUES ('2021-04-03', 1);
INSERT INTO Pedido VALUES ('2021-04-04', 1);
GO

INSERT INTO ItensPedido VALUES (30, 1, 3, 3);
INSERT INTO ItensPedido VALUES (10, 2, 4, 3);
INSERT INTO ItensPedido VALUES (1, 3, 1, 2);
GO

Comando para sincronizar a base de dados com o projeto por meio do EF:
  Scaffold-DbContext "Server=.\SQLExpress;Database=SITEWARE;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
