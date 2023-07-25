
CREATE DATABASE catalogoDB;

use catalogoDB;

CREATE TABLE Categorias (
CategoriaId INT NOT NULL AUTO_INCREMENT,
Nome VARCHAR(250) NOT NULL,
ImagemUrl VARCHAR(250) NOT NULL,
Primary Key(CategoriaId)
);

CREATE TABLE Produtos(
ProdutoId INT NOT NULL AUTO_INCREMENT,
Nome  VARCHAR(250) NOT NULL,
Descricao VARCHAR(250) ,
Preco DECIMAL,
ImagemUrl VARCHAR(250) NOT NULL,
Estoque VARCHAR(250) NOT NULL,
DataCadastro DateTime NOT NULL,
IdCategoria INT NOT NULL,
Primary Key(ProdutoId),
FOREIGN KEY(IdCategoria) REFERENCES CategoriasS(CategoriaId)
);