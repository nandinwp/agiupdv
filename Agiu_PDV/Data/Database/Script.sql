CREATE DATABASE AgiuPDV;



CREATE TABLE clientes (
    cliente_id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    endereco VARCHAR(150),
    telefone VARCHAR(15),
    email VARCHAR(100) UNIQUE
);

CREATE TABLE produtos (
    produto_id SERIAL PRIMARY KEY,
    nome VARCHAR(100) NOT NULL,
    descricao TEXT,
    preco NUMERIC(10, 2) NOT NULL CHECK (preco >= 0),
    estoque INT NOT NULL CHECK (estoque >= 0)
);

CREATE TABLE vendas (
    venda_id SERIAL PRIMARY KEY,
    cliente_id INT NOT NULL,
    data_venda TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    valor_total NUMERIC(10, 2) NOT NULL CHECK (valor_total >= 0),
    FOREIGN KEY (cliente_id) REFERENCES clientes(cliente_id)
);

CREATE TABLE venda_itens (
    venda_item_id SERIAL PRIMARY KEY,
    venda_id INT NOT NULL,
    produto_id INT NOT NULL,
    quantidade INT NOT NULL CHECK (quantidade > 0),
    preco_unitario NUMERIC(10, 2) NOT NULL CHECK (preco_unitario >= 0),
    FOREIGN KEY (venda_id) REFERENCES vendas(venda_id) ON DELETE CASCADE,
    FOREIGN KEY (produto_id) REFERENCES produtos(produto_id),
    UNIQUE (venda_id, produto_id)
);


CREATE INDEX idx_clientes_email ON clientes(email);
CREATE INDEX idx_produtos_nome ON produtos(nome);
CREATE INDEX idx_vendas_cliente_id ON vendas(cliente_id);
CREATE INDEX idx_venda_itens_venda_id ON venda_itens(venda_id);
CREATE INDEX idx_venda_itens_produto_id ON venda_itens(produto_id);

-- Dados para testes
INSERT INTO clientes (nome, endereco, telefone, email)
VALUES 
    ('Gandalf Olórin', 'tolkienano', '1000-6000', 'Gandalf@ring.com'),
    ('Dexter Morgan', 'Harry', '1979-5555', 'Dexter@Dexter.com');

INSERT INTO produtos (nome, descricao, preco, estoque)
VALUES 
    ('Cajado mágico', 'Cajado para invocação de feitiços', 250.00, 100),
    ('Garrafa florecente', 'Garrafa térmica fluorescente', 150.00, 200);

INSERT INTO vendas (cliente_id, valor_total)
VALUES (1, 200.00);

INSERT INTO venda_itens (venda_id, produto_id, quantidade, preco_unitario)
VALUES 
    (1, 1, 2, 50.00),
    (1, 2, 1, 150.00);
