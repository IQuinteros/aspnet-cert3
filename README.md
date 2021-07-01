# aspnet-cert3
Certamen 3 - Programación Avanzada, INACAP

Ignacio Quinteros

# Script BD

```sql
CREATE DATABASE certame3;
USE certame3;

CREATE TABLE Empresa(
	Id INT PRIMARY KEY IDENTITY,
	Correo VARCHAR(20),
	Descripcion VARCHAR(100),
	Popularidad FLOAT,
	Fecha DATETIME
);

CREATE TABLE Persona(
	Rut VARCHAR(12) PRIMARY KEY,
	Nombres VARCHAR(20),
	Fecha SMALLDATETIME,
	Edad TINYINT
);

```
