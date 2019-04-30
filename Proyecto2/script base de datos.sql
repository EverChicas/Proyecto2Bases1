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