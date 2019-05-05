insert into Rol_Usuario(Rol_Usuario,Nombre) values(1,'Administrador');
insert into Rol_Usuario(Rol_Usuario,Nombre) values(2,'Vendedor');
insert into Rol_Usuario(Nombre) values('Contador');

select * from rol_usuario;



CALL AGREGAR_ROL_USUARIO('SECRETARIA');

-- USUARIO
insert into usuario(Usuario,Nombre,Direccion,Telefono,Correo,Password,Rol_Usuario)
values(1,'ever','guatemala','55421254','ever@admin.com','1234',1);

call LOGIN_USUARIO(1,1234);