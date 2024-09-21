use master
create database DBTarefa
use DBTarefa
create table Tb_Usuario (
    IDUsu int identity(1,1) primary key,
	Nome varchar(1000) not null,
	Senha varchar(150) not null,
);
create table TB_Tarefa (
    IDTarefa int identity(1,1) primary key,
	Descricao varchar(1000) not null,
	DataTarefa datetime not null,
	IDUSU int foreign key references TB_Usuario(IDUsu)
);
