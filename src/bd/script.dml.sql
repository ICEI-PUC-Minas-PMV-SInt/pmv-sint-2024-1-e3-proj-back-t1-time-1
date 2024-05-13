INSERT INTO Pessoa (id_pessoa, cpf_cnpj, dt_nascimento, nome_completo, genero, email, dtcadastro, ddd_telefone, nr_telefone, ddd_celular, nr_celular)
VALUES (1, '12345678900', '1990-01-01', 'Usuario Admin', 'M', 'usuario@mail.com', '2024-04-13 10:30:00', '011', '998765432', '011', '998765432');

INSERT INTO Pessoa 
VALUES  
    (2, '78945612300', '1985-05-10', 'Cliente', 'F', 'cliente@mail.com', '2024-04-13 11:00:00', '', '', '011', '998765433'),
    (3, '98765432100', '1970-10-15', 'Fornecedor', 'M', 'fornecedor@mail.com', '2024-04-13 12:00:00', '011', '98765434', '011', '998765434'),
    (4, '12345612312', '1985-10-15', 'U', 'M', 'usuario2@mail.com', '2024-04-13 12:00:00', '015', '32925322', '011', '998332211');

INSERT INTO Endereco (id_endereco, id_pessoa, cep, logradouro, numero, complemento, bairro, cidade, uf)
VALUES 
    (1, 1, '12345678', 'Rua Bahia', '123', 'Apto 101', 'Centro', 'Cidade 01', 'SP'),
    (2, 2, '87654321', 'Avenida São Paulo', '456', '', 'Bairro Sete', 'Cidade Teste', 'SP'),
    (3, 3, '13525000', 'Rua Principal', '789', 'Loja 1', 'Centro', 'Água de São Pedro', 'SP'),
    (4, 3, '12530000', 'Rua Pereira Silva', '790', 'Loja 1', 'Centro', 'Cunha', 'SP'),
    (4, 4, '18160000', 'Rua Paraná', '102', '', 'Jardim 2', 'Salto de Pirapora', 'SP');

INSERT INTO Usuario (id_usuario, id_pessoa, senha_hash, confirmar_senha_hash, tp_usuario, nome_de_usuario)
VALUES 
    (1, 1, 'e10adc3949ba59abbe56e057f20f883e', 'e10adc3949ba59abbe56e057f20f883e', 'Admin', 'admin123'),
    (1, 4, 'e10adc3949ba59abbe56e057f20f883e', 'e10adc3949ba59abbe56e057f20f883e', 'usuario', 'usuario01');

INSERT INTO Cliente (id_cliente, id_pessoa, id_usuario)
VALUES (1, 2, 4),

INSERT INTO Fornecedor (id_cliente, id_pessoa, id_usuario)
VALUES (1, 3, 4, 'Vidas Saudáveis', 'Vidas Saudáveis LTDA');,

INSERT INTO Categoria (id_categoria, id_usuario, nome_categoria, descricao_categoria)
VALUES 
    (1, 4, 'Analgésicos', 'Medicamentos para alívio da dor.'),
    (2, 4, 'Antibióticos', 'Medicamentos para combater infecções bacterianas.'),
    (3, 4, 'Vitaminas', 'Suplementos vitamínicos para promover a saúde.'),
    (4, 4, 'Teste', 'Teste de Categoria');

INSERT INTO Localizacao (id_localizacao, id_usuario, nome_localizacao, descricao_localizacao, capacidade_localizacao)
VALUES 
    (1, 1, 'Prateleira A', 'Prateleira próxima ao balcão de atendimento.', 100),
    (2, 1, 'Estoque Central', 'Armazém principal da loja.', 500),
    (3, 1, 'Freezer', 'Freezer para armazenar medicamentos termolábeis.', 50);

INSERT INTO Produto (id_produto, id_categoria, id_localizacao, id_usuario, nome_produto, descricao_produto, dt_cadastro)
VALUES 
    (1, 1, 1, 4, 'Dipirona 500mg', 'Analgésico para alívio de dores leves a moderadas.', '2024-04-13 14:00:00'),
    (2, 2, 2, 4, 'Amoxicilina 500mg', 'Antibiótico de amplo espectro para tratamento de infecções.', '2024-04-13 14:15:00');

INSERT INTO Pedido_Compra (id_compra, id_fornecedor, nt_fiscal, vl_total_compra, dt_compra)
VALUES 
    (1, 1, 'NF123477', 1500.00, '2024-04-13 15:30:00');

INSERT INTO Item_Compra (id_item_compra, id_compra, id_produto, qt_produto, vl_total_item, vl_unitario_item)
VALUES 
    (1, 1, 2, 50, 1500.00, 30.00);

INSERT INTO Pedido_Cliente (id_pedido, id_cliente, nt_fiscal, vl_total, dt_pedido)
VALUES 
    (1, 1, 'NF123456', 200.00, '2024-04-13 15:30:00');

INSERT INTO Item_Pedido (id_item_pedido, id_pedido, id_produto, qt_produto, vl_total_item, vl_unitario_item)
VALUES 
    (1, 1, 2, 5, 200.00, 40.00);
    
INSERT INTO Movimentacao_Estoque (id_movimentacao, id_item_compra, id_item_pedido, tp_movimentacao, qt_produto, dt_movimentacao)
VALUES 
    (1, 1, NULL, 'Entrada', 50, '2024-04-13'),
    (2, NULL, 1, 'Saída', 5, '2024-04-13');

/* Deletando uma categoria */
DELETE FROM Categoria WHERE id_categoria = 4;

/*Atualizando nome do usuario*/
UPDATE Pessoa
SET nome_completo = 'Usuario'
WHERE id_pessoa = 4;


SELECT *
FROM Cliente;

SELECT *
FROM Fornecedor;

SELECT *
FROM Usuario;

SELECT *
FROM Produto;

SELECT *
FROM Categoria;

SELECT *
FROM Localizacao;

/* Retornar os dados de pessoa e endereço */

SELECT *
FROM Pessoa p
INNER JOIN Endereco ON p.id_pessoa = e.id_pessoa;