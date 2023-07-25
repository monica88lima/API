INSERT INTO Categorias (Nome, ImagemUrl)
VALUES
     ('Alimentacao', 'alimentacao.png'),
	 ('Decoracao', 'decoracao.png'),
	 ('Limpeza', 'limpeza.png'),
     ('Brinquedos', 'brinquedos.png'),
     ('Cosmeticos', 'cosmeticos.png');
 
 INSERT INTO Produtos (Nome, Descricao, Preco, ImagemUrl, Estoque, CategoriaId)
 VALUES
     ('Base', 'Cor Bege', 25.99, 'base.png', 2.0 ,5),
     ('Base', 'Cor Branca', 25.99, 'base.png', 2.0 ,5),
     ('Base', 'Cor Negra', 25.99, 'base.png', 2.0 ,5),
     ('Base', 'Cor Morena', 25.99, 'base.png', 2.0 ,5),
     ('Baton', 'Vermelho', 12.99, 'baton.png', 2.0 ,5),
     ('Baton', 'Nude', 12.99, 'baton.png', 2.0 ,5),
     ('Blush', 'Pessego', 20.00, 'blush.png', 2.0 ,5),
     ('Sombra', 'Paleta Rosa', 45.00, 'sombra.png', 2.0 ,5),
     ('Rimel', 'Cor Negra', 25.99, 'rimel.png', 2.0 ,5),
     ('Prime', 'Preparo da Pele', 75.99, 'primer.png', 2.0 ,5),
	 ('Barbie', 'Boneca', 39.99, 'boneca.png', 1.0 ,4),
     ('Lego', 'Blocos', 35.99, 'lego.png', 3.0 ,4),
     ('Quebra-cabeça', 'Peças de Montar', 42.99, 'quebracabeca.png', 1.0 ,4),
     ('Pelucia', 'Bicho de Pelucia', 89.00, 'pelucia.png', 1.0 ,4),
     ('Tabuleiro', 'Xadrez', 87.99, 'tabuleiro.png', 3.0 ,4),
     ('Drones', 'Brinquedos de Controle Remoto', 775.99, 'drone.png', 2.0 ,4),
	 ('Candida', 'Alvejante', 9.99, 'limpeza.png', 1.0 ,3),
     ('Sabão em Pó', 'Lava Roupa', 35.99, 'limpezao.png', 3.0 ,3),
     ('Detergente', 'Lava louça', 2.99, 'limpeza.png', 1.0 ,3),
     ('Cortina', 'Marrom para sala', 189.00, 'sala.png', 1.0 ,2),
     ('Manta de Sofá', 'Bege', 87.99, 'sala.png', 3.0 ,2),
     ('Vasos', 'Ceramica branco', 70.99, 'sala.png', 2.0 ,2),
     ('Torta de Limão', 'Sobremesa', 80.00, 'sobremesa.png', 1.0 ,1),
     ('Bolo', 'Sobremesa', 50.99, 'bolo.png', 3.0 ,1),
     ('Lasanha', 'Refeição', 99.99, 'refeicao.png', 2.0 ,1);

SELECT * 
FROM Categorias;

SELECT *
FROM Produtos


select*from Categorias;
 select*from Produtos;
     