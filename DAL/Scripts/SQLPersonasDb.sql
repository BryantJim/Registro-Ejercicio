Create DataBase PersonasDb
go
use PersonasDb
go
create table Persona
(
ID int primary key identity,
Nombre varchar(50),
Apellido varchar(50),
Telefono varchar(25),
Cedula varchar(25),
Direccion varchar(max)
);