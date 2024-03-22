-- TABLA Cargo-- TABLA Cargo
CREATE DATABASE Caez
USE Caez

-- TABLA Direccion
CREATE TABLE Direccion(
    Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    Nombre VARCHAR(200) NOT NULL
);
GO
-- TABLA Turno
CREATE TABLE Turno(
    Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    Nombre VARCHAR(80) NOT NULL
);
GO
-- TABLA Grado
CREATE TABLE Grado(
    Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    Nombre VARCHAR(50) NOT NULL
);
GO
-- TABLA TipoDocumento
CREATE TABLE TipoDocumento(
    Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    Nombre VARCHAR(80) NOT NULL
);
GO
-- TABLA TipoPago
CREATE TABLE TipoPago(
    Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    Nombre VARCHAR(80) NOT NULL
);
GO
-- TABLA Parentezco
CREATE TABLE Parentezco(
    Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    Nombre VARCHAR(50) NOT NULL
);
GO
-- TABLA Mes
CREATE TABLE Mes(
    Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    Nombre VARCHAR(50) NOT NULL
);
GO
--***actualización de la base de datos**--
create table [Role](
Id int not null identity(1,1),
[Name] nvarchar(30) not null,
primary key(Id)
);
go

create table [User](
Id int not null identity(1,1),
IdRole int not null,
[Name] nvarchar(30) not null,
LastName nvarchar(30) not null,
[Login] nvarchar(25) not null,
[Password] nvarchar(100) not null,
[Status] tinyint not null,
RegistrationDate datetime not null,
primary key(Id),
foreign key(IdRole) references [Role](Id)
);
go

-- TABLA AdministradorEncargado
CREATE TABLE Encargado(
    Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    IdTipoDoc INT NOT NULL FOREIGN KEY REFERENCES TipoDocumento(Id),
    NumeroDocumento VARCHAR(50) NOT NULL,
    Telefono VARCHAR(50) NOT NULL,
    IdDireccion INT NOT NULL FOREIGN KEY REFERENCES Direccion(Id),
    IdParentezco INT NOT NULL FOREIGN KEY REFERENCES Parentezco(Id),
    IdAdministrador INT NOT NULL FOREIGN KEY REFERENCES [User](Id),
	FechaRegistro datetime not null,
);
GO
-- TABLA Alumno
CREATE TABLE Alumno(
    Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(50) NOT NULL,
    IdGrado INT NOT NULL FOREIGN KEY REFERENCES Grado(Id),
    IdTipoDoc INT NOT NULL FOREIGN KEY REFERENCES TipoDocumento(Id),
    NumeroDocumento VARCHAR(50) NOT NULL,
    IdEncargado INT NOT NULL FOREIGN KEY REFERENCES Encargado(Id),
    IdTurno INT NOT NULL FOREIGN KEY REFERENCES Turno(Id),
    IdAdministrador INT NOT NULL FOREIGN KEY REFERENCES  [User](Id),
	FechaRegistro datetime not null,
);
GO
-- TABLA Pago
CREATE TABLE Pago (
    Id INT NOT NULL PRIMARY KEY IDENTITY (1, 1),
    IdAlumno INT NOT NULL FOREIGN KEY REFERENCES Alumno(Id),
    IdEncargado INT NOT NULL,
    MontoPagar DECIMAL(10, 2) NOT NULL,
    Multa DECIMAL(10, 2) NOT NULL DEFAULT 0,
    TotalPagado DECIMAL(10, 2) NOT NULL DEFAULT 0,
    FechaRegistro DATETIME NOT NULL,
    IdAdministrador INT NOT NULL FOREIGN KEY REFERENCES  [User](Id),
    IdMes INT NOT NULL FOREIGN KEY REFERENCES Mes(Id)
);
GO


CREATE TABLE Factura(
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    NumeroFactura INT NOT NULL,
    IdPago INT NOT NULL FOREIGN KEY REFERENCES Pago(Id),
    FechaDescarga DATETIME NOT NULL -- Fecha y hora de descarga de la factura
);
GO
-----TABLA FONDO
CREATE TABLE FONDO(
    Id INT NOT NULL PRIMARY KEY IDENTITY (1,1),
    MontoTotal DECIMAL(10, 2) NOT NULL DEFAULT 0 -- Monto total acumulado
);
GO
