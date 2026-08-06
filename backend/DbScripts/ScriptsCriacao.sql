--Criar banco
CREATE DATABASE backend;

--Usar banco
USE backend;

--Criar tabela
CREATE TABLE usuario(
    id int NOT NULL AUTO_INCREMENT,
    nome VARCHAR(50) NOT NULL,
    sobrenome VARCHAR(50) NOT NULL,
    telefone VARCHAR(15) NOT NULL,
    email VARCHAR(50) NOT NULL,
    genero VARCHAR(20) NOT NULL,
    senha VARCHAR(30) NOT NULL,
    PRIMARY KEY (id)
);

--Edita tabela 
alter tabela endereco add usuario_id int not null;

--Add chave estrangeira 
alter table endereco add constraint FK_usuario foreign key (usuario_id) references usuario(id);

--Add usuario
insert into usuario(nome, sobrenome, telefone, email, genero, senha) values 
('Murilo', 'yano', '(44)999558966', 'muril0yano150107@gmail.com', 'masculino', 'Teste123');

--Selecionar todos usuario
select * from usuario;

--Selecionar usuario especifico
select from usuario where email = '';
