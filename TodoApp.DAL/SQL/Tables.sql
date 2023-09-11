CREATE DATABASE MvcTodo;

use MvcTodo;

Create table Tarea(
	Id int primary key identity(1,1),
	Nombre varchar(50) not null,
	Descripcion varchar(100),
	FechaRegistro datetime default getdate(),
	Completada bit default 0
)

insert into Tarea(Nombre, Descripcion) values('Aprender Raizor', 'Aprende Raizor pasao a pasito mi rey')