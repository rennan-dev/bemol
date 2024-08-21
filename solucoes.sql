select version();

create table clientes (
	id serial primary key,
	nome varchar(100),
	email varchar(100),
	dataNascimento date,
	cidade varchar(100)
);

create table pedidos (
	pedidoId serial primary key,
	dataPedido date,
	valorTotal decimal,
	clienteId integer,
	foreign key(clienteId) references clientes(id)
);

insert into clientes(nome, email, dataNascimento, cidade) values('Rennan Alves', 'rennanalves@bemol.com.br', '2000-09-19', 'Manaus');
insert into clientes(nome, email, dataNascimento, cidade) values('João Alves', 'joao@gmail.com.br', '1998-06-05', 'Parintins');
insert into clientes(nome, email, dataNascimento, cidade) values('Silvana Melo', 'silvana@hotmail.com.br', '1980-03-12', 'Parintins');

insert into pedidos(dataPedido, valorTotal, clienteId) values('2024-08-21', 2499.99, 1);
insert into pedidos(dataPedido, valorTotal, clienteId) values('2024-05-14', 999.99, 1);
insert into pedidos(dataPedido, valorTotal, clienteId) values('2024-12-01', 149.99, 3);

select * from clientes;
select * from pedidos;
select nome, email from clientes;

update clientes set email = 'joaoalves@gmail.com' where nome = 'João Alves';
update pedidos set valorTotal = 9.99 where pedidoId = 2;
delete from pedidos where pedidoId = 3;

select * from clientes where cidade='Parintins';
select * from pedidos where valorTotal > 100;

select * from clientes order by nome;
select * from pedidos order by valorTotal desc;

select nome, pedidos.valorTotal from clientes inner join pedidos on pedidos.clienteId = id;
select nome, pedidos.pedidoId, pedidos.valorTotal from clientes left join pedidos on clientes.id = pedidos.clienteId; 