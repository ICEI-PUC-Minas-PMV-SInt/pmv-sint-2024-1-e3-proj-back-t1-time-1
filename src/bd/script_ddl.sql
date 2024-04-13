CREATE TABLE Pessoa (
    id_pessoa INT PRIMARY KEY,
    cpf_cnpj VARCHAR(14),
    dt_nascimento DATE,
    nome_completo VARCHAR(255),
    genero CHAR(1) CHECK (genero IN ('M', 'F')),
    email VARCHAR(255),
    dtcadastro DATETIME,
    ddd_telefone VARCHAR(3),
    nr_telefone VARCHAR(8),
    ddd_celular VARCHAR(3),
    nr_celular VARCHAR(9)
);

CREATE TABLE Endereco (
    id_endereco INT PRIMARY KEY,
    id_pessoa INT,
    cep VARCHAR(8),
    logradouro VARCHAR(255),
    numero VARCHAR(10),
    complemento VARCHAR(100),
    bairro VARCHAR(255),
    cidade VARCHAR(255),
    uf CHAR(2),
    FOREIGN KEY (id_pessoa) REFERENCES Pessoa(id_pessoa)
);

CREATE TABLE Usuario (
    id_usuario INT PRIMARY KEY,
    id_pessoa INT,
    senha_hash VARCHAR(255),
    confirmar_senha_hash VARCHAR(255),
    tp_usuario VARCHAR(20),
    nome_de_usuario VARCHAR(50),
    FOREIGN KEY (id_pessoa) REFERENCES Pessoa(id_pessoa)
);

CREATE TABLE Cliente (
    id_cliente INT PRIMARY KEY,
    id_pessoa INT,
    id_usuario INT,
    FOREIGN KEY (id_pessoa) REFERENCES Pessoa(id_pessoa),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

CREATE TABLE Fornecedor (
    id_fornecedor INT PRIMARY KEY,
    id_pessoa INT,
    id_usuario INT,
    nome_fantasia VARCHAR(255),
    razão_social VARCHAR(255),
    FOREIGN KEY (id_pessoa) REFERENCES Pessoa(id_pessoa),
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

CREATE TABLE Categoria (
    id_categoria INT PRIMARY KEY,
    id_usuario INT,
    nome_categoria VARCHAR(100),
    descricao_categoria VARCHAR(1000)
);

CREATE TABLE Localizacao (
    id_localizacao INT PRIMARY KEY,
    id_usuario INT,
    nome_localizacao VARCHAR(100),
    descricao_localizacao VARCHAR(1000),
    capacidade_localizacao INT,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
);

CREATE TABLE Produto (
    id_produto INT PRIMARY KEY,
    id_categoria INT,
    id_localizacao INT,
    id_usuario INT,
    nome_produto VARCHAR(255),
    descricao_produto VARCHAR(255),
    dt_cadastro DATETIME,
    FOREIGN KEY (id_usuario) REFERENCES Usuario(id_usuario)
    FOREIGN KEY (id_categoria) REFERENCES Categoria(id_categoria)
    FOREIGN KEY (id_localizacao) REFERENCES Localizacao(id_localizacao)
);

CREATE TABLE Pedido_Cliente (
    id_pedido INT PRIMARY KEY,
    id_cliente INT,
    nt_fiscal VARCHAR(20),
    vl_total DECIMAL(10,2),
    dt_pedido DATETIME,
    FOREIGN KEY (id_cliente) REFERENCES Cliente(id_cliente),
);

CREATE TABLE Item_Pedido (
    id_item_pedido INT PRIMARY KEY,
    id_pedido INT,
    id_produto INT,
    qt_produto INT,
    vl_total_item DECIMAL(10,2),
    vl_unitario_item DECIMAL(10,2),
    FOREIGN KEY (id_pedido) REFERENCES Pedido_Cliente(id_pedido),
    FOREIGN KEY (id_produto) REFERENCES Produto(id_produto)
);

CREATE TABLE Pedido_Compra (
    id_compra INT PRIMARY KEY,
    id_fornecedor INT,
    nt_fiscal VARCHAR(20),
    vl_total_compra DECIMAL(10,2),
    dt_compra DATETIME,
    FOREIGN KEY (id_fornecedor) REFERENCES Fornecedor(id_fornecedor),
);

CREATE TABLE Item_Compra (
    id_item_compra INT PRIMARY KEY,
    id_compra INT,
    id_produto INT,
    qt_produto INT,
    vl_total_item DECIMAL(10,2),
    vl_unitario_item DECIMAL(10,2),
    FOREIGN KEY (id_compra) REFERENCES Pedido_Compra(id_compra),
    FOREIGN KEY (id_produto) REFERENCES Produto(id_produto)
);

CREATE TABLE Movimentacao_Estoque (
    id_movimentacao INT PRIMARY KEY,
    id_item_compra INT,
    id_item_pedido INT,
    tp_movimentacao VARCHAR(7),
    qt_produto INT,
    dt_movimentacao DATE,
    FOREIGN KEY (id_item_compra) REFERENCES Item_Compra(id_item_compra),
    FOREIGN KEY (id_item_pedido) REFERENCES Item_Pedido(id_item_pedido),
);

ALTER TABLE Movimentacao_Estoque
DROP COLUMN qt_produto;

ALTER TABLE Movimentacao_Estoque
MODIFY COLUMN dt_movimentacao DATETIME;