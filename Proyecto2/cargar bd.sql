insert into Rol_Usuario(Rol_Usuario,Nombre) values(1,'Administrador');
insert into Rol_Usuario(Rol_Usuario,Nombre) values(2,'Vendedor');
insert into Rol_Usuario(Nombre) values('Contador');

select * from rol_usuario;

DELIMITER //
CREATE PROCEDURE AGREGAR_ROL_USUARIO(IN NOMBRE VARCHAR(45))
BEGIN
INSERT INTO Rol_Usuario(Nombre) values(NOMBRE);
END//
CALL AGREGAR_ROL_USUARIO('SECRETARIA');


--INSERTANDO ADMINISTRADOR
insert into usuario (Usuario, Nombre, Direccion, Telefono, Correo, Password, Rol_Usuario) values
(100, 'Jose Ramirez', 'Guatemala', '59339524', 'admin@gmail.com', '123', 1);

call CREAR_USUARIO('Bredly', 'Ciudad', '59339524', 'correo1@gmail.com', 5933, '123', 'Vendedor'); --PROCEDIMIENTO EN procedimientos.sql

CALL CREAR_CAJA(1,1000);
CALL CREAR_CAJA(2,1000);
CALL CREAR_CAJA(3,1000);
CALL CREAR_CAJA(4,1000);
CALL CREAR_CAJA(5,1000);

