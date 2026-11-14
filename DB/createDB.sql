CREATE DATABASE TiendaRopaDb;
GO

USE TiendaRopaDb;
GO

CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Email NVARCHAR(150) NOT NULL,
    EsSocioClub BIT NOT NULL DEFAULT 0
);

CREATE TABLE Prendas (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Categoria NVARCHAR(50) NOT NULL,
    Precio DECIMAL(10,2) NOT NULL CHECK (Precio >= 0),
    Stock INT NOT NULL DEFAULT 0 CHECK (Stock >= 0),
    EsImpermeable BIT NOT NULL DEFAULT 0
);

CREATE TABLE Pedidos (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Codigo NVARCHAR(50) NOT NULL,
    Fecha DATETIME2 NOT NULL DEFAULT GETDATE(),
    Total DECIMAL(10,2) NOT NULL DEFAULT 0,
    Pagado BIT NOT NULL DEFAULT 0,
    ClienteId INT NOT NULL,
    FOREIGN KEY (ClienteId) REFERENCES Clientes(Id)
);

CREATE TABLE LineasPedido (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Cantidad INT NOT NULL CHECK (Cantidad > 0),
    PrecioUnitario DECIMAL(10,2) NOT NULL CHECK (PrecioUnitario >= 0),
    PedidoId INT NOT NULL,
    PrendaId INT NOT NULL,
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id),
    FOREIGN KEY (PrendaId) REFERENCES Prendas(Id)
);

CREATE TABLE Envios (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Empresa NVARCHAR(50) NOT NULL,
    FechaEnvio DATETIME2 NOT NULL DEFAULT GETDATE(),
    Coste DECIMAL(10,2) NOT NULL DEFAULT 0,
    Entregado BIT NOT NULL DEFAULT 0,
    PedidoId INT NOT NULL,
    FOREIGN KEY (PedidoId) REFERENCES Pedidos(Id)
);

INSERT INTO Clientes (Nombre, Email, EsSocioClub)
VALUES 
('Carlos Montañero', 'carlos@email.com', 1),
('Ana Escaladora', 'ana@email.com', 0);

INSERT INTO Prendas (Nombre, Categoria, Precio, Stock, EsImpermeable)
VALUES 
('Chaqueta Gore-Tex Pro', 'Chaquetas', 299.99, 15, 1),
('Pantalón Trekking Dry', 'Pantalones', 89.50, 30, 0),
('Botas Alpinismo Extreme', 'Calzado', 220.00, 8, 1);
