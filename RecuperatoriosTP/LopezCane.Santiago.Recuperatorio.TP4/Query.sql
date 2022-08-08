CREATE DATABASE KIOSCO_DB;

GO

USE KIOSCO_DB;

CREATE TABLE kioscos(
id int primary key not null,
nombre varchar(128) not null,
registradora int not null,
)

CREATE TABLE productos(
id int NOT NULL IDENTITY(1, 1),
nombre varchar(128) not null,
descripcion varchar(128),
precio int not null,
tamanio int,
id_kiosco int not null,
PRIMARY KEY (id),
FOREIGN KEY (id_kiosco) REFERENCES kioscos(id)
)

INSERT INTO kioscos(id, nombre, registradora)
VALUES
(1, 'Lo de Sergio', 9800),
(2, 'Open 25', 78000)

INSERT INTO productos(nombre, descripcion, precio, tamanio, id_kiosco)
VALUES
('Coca Cola', 'Zero', 90, 2, 1),
('Coca Cola', 'Zero', 90, 1, 1),
('Coca Cola', 'Light', 90, 2, 1),
('Coca Cola', null, 85, 2, 1),
('Chupetin pop', 'con chicle', 22, null, 1),
('Chupetin pop', null, 18, null, 1),
('Alfajor Fantoche', 'triple', 100, null, 1)