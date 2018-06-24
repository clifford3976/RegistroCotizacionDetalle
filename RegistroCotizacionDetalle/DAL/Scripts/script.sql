CREATE DATABASE ArticulosDb
GO
USE ArticulosDb
GO
CREATE TABLE Articulos
(

  ArticuloId int primary key identity(1,1),
  FechaVencimiento datetime,
  Descripcion varchar(max),
  Precio int,
  CantidadCotizado int
  );
  