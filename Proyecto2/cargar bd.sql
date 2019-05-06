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


--LOGIN USUARIO
DELIMITER //
CREATE PROCEDURE LOGIN_USUARIO(IN USER INTEGER, IN PASS VARCHAR(50))
BEGIN
SELECT *FROM usuario 
WHERE Usuario = USER
and Password = PASS;
END//
call LOGIN_USUARIO(100, '123');


