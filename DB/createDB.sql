IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TiendaRopaDb')
BEGIN
    CREATE DATABASE TiendaRopaDb;
END
GO

USE TiendaRopaDb;
GO

DROP TABLE IF EXISTS Envios;
DROP TABLE IF EXISTS LineasPedido;
DROP TABLE IF EXISTS Pedidos;
DROP TABLE IF EXISTS Prendas;
DROP TABLE IF EXISTS Clientes;
GO

DROP TABLE IF EXISTS Envios;
DROP TABLE IF EXISTS LineasPedido;
DROP TABLE IF EXISTS Pedidos;
DROP TABLE IF EXISTS Prendas;
DROP TABLE IF EXISTS Clientes;
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
GO

INSERT INTO Clientes (Nombre, Email, EsSocioClub)
VALUES 
('Carlos Montañero', 'carlos@email.com', 1),
('Ana Escaladora', 'ana@email.com', 0),
('David Alpinista', 'david@email.com', 1);

INSERT INTO Prendas (Nombre, Categoria, Precio, Stock, EsImpermeable)
VALUES 
('Chaqueta Gore-Tex Pro', 'Chaquetas', 299.99, 15, 1),
('Pantalón Trekking Dry', 'Pantalones', 89.50, 30, 0),
('Botas Alpinismo Extreme', 'Calzado', 220.00, 8, 1);

INSERT INTO Pedidos (Codigo, Fecha, Total, Pagado, ClienteId)
VALUES 
('PED-2026-001', '2026-11-20 10:30:00', 299.99, 1, 1),
('PED-2026-002', '2026-11-22 15:45:00', 89.50, 0, 2),
('PED-2026-003', '2026-11-25 18:20:00', 220.00, 1, 3);

INSERT INTO LineasPedido (Cantidad, PrecioUnitario, PedidoId, PrendaId)
VALUES 
(1, 299.99, 1, 1),
(1, 89.50, 2, 2),
(1, 220.00, 3, 3);

INSERT INTO Envios (Empresa, FechaEnvio, Coste, Entregado, PedidoId)
VALUES 
('SEUR Express', '2026-11-21 09:00:00', 5.95, 1, 1),
('Correos Express', '2026-11-23 11:15:00', 4.50, 0, 2),
('DHL Freight', '2026-11-26 08:30:00', 6.50, 0, 3);
GO
