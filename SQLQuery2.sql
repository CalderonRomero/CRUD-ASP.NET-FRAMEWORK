USE master
GO
CREATE DATABASE DBprueba01
use DBprueba01

GO
CREATE TABLE TAgenda(
	IdAgenda int primary key,
	Apellidos varchar (50),
	Nombres varchar (50),
	Email varchar (50)
)
go
insert into TAgenda values(1, 'Calderon Romero','Jherzon','71827961@continental.edu.pe')
insert into TAgenda values(2, 'Navia Vargas','Carlos','71827961@continental.edu.pe')
insert into TAgenda values(3, 'Cuaresma Pinto','Gemma','71827961@continental.edu.pe')
insert into TAgenda values(4, 'Garcia Perez','Alan','71827961@continental.edu.pe')
GO
SELECT * FROM TAgenda