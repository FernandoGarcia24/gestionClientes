
-- Creación de la tabla Clientes con Primary Key, valores únicos y valores por defecto
CREATE TABLE Clientes (
    ClienteID INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(255) NOT NULL,
    Correo VARCHAR(255) UNIQUE NOT NULL,
    Telefono VARCHAR(20),
    FechaRegistro DATE DEFAULT CURRENT_TIMESTAMP
);

-- Creación de la tabla Pedidos con Foreign Key hacia Clientes
CREATE TABLE Pedidos (
    PedidoID INT PRIMARY KEY,
    FechaPedido DATE DEFAULT CURRENT_TIMESTAMP,
    Total DECIMAL(10, 2),
    ClienteID INT,
    CONSTRAINT fk_cliente FOREIGN KEY (ClienteID) REFERENCES Clientes(ClienteID)
);

-- Creación de la tabla Productos
CREATE TABLE Productos (
    ProductoID INT PRIMARY KEY,
    NombreProducto VARCHAR(255) UNIQUE NOT NULL,
    Precio DECIMAL(10, 2) NOT NULL
);

-- Creación de la tabla ProductosPedidos para la relación muchos a muchos entre Pedidos y Productos
CREATE TABLE ProductosPedidos (
    PedidoID INT,
    ProductoID INT,
    Cantidad INT,
    CONSTRAINT pk_productos_pedidos PRIMARY KEY (PedidoID, ProductoID),
    CONSTRAINT fk_pedido FOREIGN KEY (PedidoID) REFERENCES Pedidos(PedidoID),
    CONSTRAINT fk_producto FOREIGN KEY (ProductoID) REFERENCES Productos(ProductoID)
);

-- Consulta con INNER JOIN y LEFT JOIN para obtener los pedidos y productos de cada cliente
SELECT C.Nombre, P.FechaPedido, PP.Cantidad
FROM Clientes C
INNER JOIN Pedidos P ON C.ClienteID = P.ClienteID
LEFT JOIN ProductosPedidos PP ON P.PedidoID = PP.PedidoID;

-- Consulta con CASE para categorizar productos según su precio y UNION para combinar con un producto adicional
SELECT NombreProducto, Precio,
    CASE 
        WHEN Precio < 100 THEN 'Barato'
        WHEN Precio >= 100 AND Precio <= 150 THEN 'Medio'
        ELSE 'Caro'
    END AS Categoria
FROM Productos
UNION
SELECT 'Producto Extra', 500, 'Exclusivo';

-- Inserción de registros en la tabla Clientes
INSERT INTO Clientes ( Nombre, Correo, Telefono) VALUES
('Luis Pérez', 'luisperez@gmail.com', '3023455465'),
('Ana Gómez', 'anagomez@gmail.com', '3109875643'),
('Juan López', 'juanlopez@gmail.com', '3023243445'),
('Carla Ruiz', 'carlariuz@gmail.com', '301345455i'),
('Diego Martínez', 'diegomartinez@gmail.com', '3009875467');

-- Inserción de registros en la tabla Productos
INSERT INTO Productos (ProductoID, NombreProducto, Precio) VALUES
(1, 'Producto A', 50.00),
(2, 'Producto B', 75.00),
(3, 'Producto C', 100.00),
(4, 'Producto D', 150.00),
(5, 'Producto E', 200.00);

-- Inserción de registros en la tabla Pedidos
INSERT INTO Pedidos (PedidoID, FechaPedido, Total, ClienteID) VALUES
(1, '2024-01-01', 300.00, 1),
(2, '2024-01-02', 450.00, 2),
(3, '2024-01-03', 120.00, 3);

-- Inserción de registros en la tabla ProductosPedidos
INSERT INTO ProductosPedidos (PedidoID, ProductoID, Cantidad) VALUES
(1, 1, 2),
(1, 2, 1),
(2, 3, 3),
(2, 4, 1),
(3, 5, 2);