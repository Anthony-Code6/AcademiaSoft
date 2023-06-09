USE master;
GO

IF DB_ID('Academia_Soft') IS NOT NULL --IF EXISTS (SELECT name FROM sys.databases WHERE name = 'Academia_Soft')
    DROP DATABASE Academia_Soft;
GO

CREATE DATABASE Academia_Soft;
GO

USE Academia_Soft;
GO

CREATE TABLE aula (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    codigo AS ('A' + RIGHT(CONVERT(VARCHAR, id), 100)),
    descripcion VARCHAR(200)
);
--Nota: AULA eliminado
CREATE TABLE curso (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    codigo AS ('C' + RIGHT(CONVERT(VARCHAR, id), 100)),
    descripcion VARCHAR(100)
);

CREATE TABLE periodo (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    codigo AS ('PR' + RIGHT(CONVERT(VARCHAR, id), 200)),
    fectrimestre1 DATE NOT NULL,
    fectrimestre2 DATE,
    fectrimestre3 DATE,
    fectrimestre4 DATE
);
--Nota: En un entorno real no debe haber bucles, se pueden crear otras bd para evitar los bucles y garantizar escalabilidad.
CREATE TABLE usuario (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    codigo AS ('US' + RIGHT(CONVERT(VARCHAR, id), 200)),
    email VARCHAR(200) NOT NULL,
    password VARCHAR(100) NOT NULL,
    tipo VARCHAR(20)
);

CREATE TABLE profesor (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    codigo AS ('PS' + RIGHT(CONVERT(VARCHAR, id), 200)),
    documento VARCHAR(20) NOT NULL,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    idusuario INT FOREIGN KEY REFERENCES usuario(id) ON UPDATE CASCADE ON DELETE SET NULL
);

CREATE TABLE alumno (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    codigo AS ('AL' + RIGHT(CONVERT(VARCHAR, id), 200)),
    documento VARCHAR(20) NOT NULL,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    idusuario INT FOREIGN KEY REFERENCES usuario(id) ON UPDATE CASCADE ON DELETE SET NULL
);
--Nota: IDPERIODO eliminado
CREATE TABLE matricula (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    codigo AS ('M' + RIGHT(CONVERT(VARCHAR, id), 100)),
    fecha DATE DEFAULT GETDATE(),
    idalumno INT NOT NULL FOREIGN KEY REFERENCES alumno(id) ON UPDATE CASCADE ON DELETE NO ACTION,
    idaula INT NOT NULL FOREIGN KEY REFERENCES aula(id) ON UPDATE CASCADE ON DELETE NO ACTION
);
--Nota: Renombrar CursoProfesor a CargoProfesor, se crearon otros ID ademas de IDCURSO e IDPROFESOR
CREATE TABLE cargo_profesor (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    idaula INT FOREIGN KEY REFERENCES aula(id) ON UPDATE CASCADE ON DELETE NO ACTION,
    idcurso INT NOT NULL FOREIGN KEY REFERENCES curso(id) ON UPDATE CASCADE ON DELETE NO ACTION,
    idprofesor INT NOT NULL FOREIGN KEY REFERENCES profesor(id) ON UPDATE CASCADE ON DELETE NO ACTION,
	idperiodo INT NOT NULL FOREIGN KEY REFERENCES periodo(id) ON UPDATE CASCADE ON DELETE NO ACTION
);
--Nota: Renombrar BoletaNotas a BoletaNota, se elimino IDPROFESOR, IDALUMNO y ESTADO, se agrego IDMATRICULA e IDCARGO
CREATE TABLE boleta_nota (
    id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    idmatricula INT NOT NULL FOREIGN KEY REFERENCES matricula(id),
    idcargo INT NOT NULL FOREIGN KEY REFERENCES cargo_profesor(id),
    nota1 DECIMAL(4,2) CHECK (nota1>=0 AND nota1<=20) DEFAULT 0.00,
    nota2 DECIMAL(4,2) CHECK (nota2>=0 AND nota2<=20) DEFAULT 0.00,
    nota3 DECIMAL(4,2) CHECK (nota3>=0 AND nota3<=20) DEFAULT 0.00,
    nota4 DECIMAL(4,2) CHECK (nota4>=0 AND nota4<=20) DEFAULT 0.00,
    promedio DECIMAL(4,2) DEFAULT 0.00
);
GO

-- PROCEDIMIENTO DE ALUMNO
/*  => VALIDACION DE CORREO ELECTRONICO 
	VALIDAR EL CORREO CON UNA CONSULTA SI YA ESTA ASIGADO A OTRO PROFESOR O ALUMNO
	Y MOSTRAR UN MENSAJE SI ESTA O NO ESTA ASIGANDO A DICHOS USUARIOS,
	ALGO PARECIDO CON EL ELIMINAR DE PERIODO PERO EN EL CASO DE GUARDAR Y ACTUALIZAR
*/

CREATE PROCEDURE SP_REGISTRAR_ALUMNO
    @ID INT,
    @DOCUMENTO VARCHAR(20),
    @NOMBRE VARCHAR(50),
    @APELLIDO VARCHAR(50),
    @IDUSUARIO INT
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM ALUMNO WHERE ID = @ID)
    BEGIN
        IF (@IDUSUARIO IS NOT NULL)
            INSERT INTO ALUMNO (DOCUMENTO, NOMBRE, APELLIDO, IDUSUARIO) VALUES (@DOCUMENTO, @NOMBRE, @APELLIDO, @IDUSUARIO);
        ELSE
            INSERT INTO ALUMNO (DOCUMENTO, NOMBRE, APELLIDO) VALUES (@DOCUMENTO, @NOMBRE, @APELLIDO);
    END
END
GO

CREATE PROCEDURE SP_ACTUALIZAR_ALUMNO
    @ID INT,
    @DOCUMENTO VARCHAR(20),
    @NOMBRE VARCHAR(50),
    @APELLIDO VARCHAR(50),
    @IDUSUARIO INT
AS
BEGIN
    IF EXISTS (SELECT * FROM ALUMNO WHERE ID = @ID)
    BEGIN
        IF (@IDUSUARIO IS NOT NULL)
            UPDATE ALUMNO SET DOCUMENTO = @DOCUMENTO, NOMBRE = @NOMBRE, APELLIDO = @APELLIDO, IDUSUARIO = @IDUSUARIO WHERE ID = @ID;
        ELSE
            UPDATE ALUMNO SET DOCUMENTO = @DOCUMENTO, NOMBRE = @NOMBRE, APELLIDO = @APELLIDO WHERE ID = @ID;
    END
END
GO

CREATE PROCEDURE SP_LISTAR_ALUMNO
AS
BEGIN
    SELECT id, codigo, documento, nombre, apellido, idusuario
    FROM alumno
    ORDER BY apellido ASC;
END
GO

CREATE PROCEDURE SP_BUSCAR_ALUMNO
    @CODIGO INT
AS
BEGIN
    IF EXISTS (SELECT * FROM ALUMNO WHERE id = @CODIGO)
    BEGIN
        SELECT id, codigo, documento, nombre, apellido, idusuario
        FROM alumno
        WHERE id = @CODIGO;
    END
END
GO
-- Agregado delete de matricula.
CREATE PROCEDURE SP_BORRAR_ALUMNO
    @CODIGO VARCHAR(20)
AS
BEGIN
    IF EXISTS (SELECT * FROM ALUMNO WHERE CODIGO = @CODIGO)
    BEGIN
		DECLARE @idAl INT
		SET @idAl = (SELECT ID FROM ALUMNO WHERE CODIGO = @CODIGO)
		DELETE FROM MATRICULA WHERE IDALUMNO = @idAl;
        DELETE FROM ALUMNO WHERE CODIGO = @CODIGO;
    END
END
GO
/*EXEC SP_BORRAR_ALUMNO 'AL72';*/

-- PROCEDIMIENTO ALMACENADOS DE USUARIO (Probablemente solo se use validar)

CREATE PROCEDURE SP_REGISTRAR_USUARIO
    @ID INT,
    @EMAIL VARCHAR(200),
    @PASSWORD VARCHAR(100),
    @TIPO VARCHAR(20)
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM usuario WHERE ID = @ID)
    BEGIN
        INSERT INTO USUARIO (EMAIL, PASSWORD, TIPO) VALUES (@EMAIL, @PASSWORD, @TIPO);
    END
END
GO

CREATE PROCEDURE SP_ACTUALIZAR_USUARIO
    @ID INT,
    @EMAIL VARCHAR(200),
    @PASSWORD VARCHAR(100),
    @TIPO VARCHAR(20)
AS
BEGIN
    IF EXISTS (SELECT * FROM usuario WHERE ID = @ID)
    BEGIN
        UPDATE USUARIO SET EMAIL=@EMAIL, PASSWORD=@PASSWORD, TIPO=@TIPO WHERE ID=@ID;
    END
END
GO

CREATE PROCEDURE SP_ELIMINAR_USUARIO
@CODIGO INT
AS
BEGIN
	IF EXISTS (SELECT * FROM USUARIO WHERE ID=@CODIGO)
		BEGIN
			DELETE FROM USUARIO WHERE ID=@CODIGO
		END
END
GO

CREATE PROCEDURE SP_BUSCAR_USUARIO
@CODIGO INT
AS
BEGIN
	IF EXISTS (SELECT * FROM USUARIO WHERE ID=@CODIGO)
		BEGIN
			SELECT ID,CODIGO,EMAIL,PASSWORD,TIPO FROM USUARIO WHERE ID=@CODIGO
		END
END
GO

CREATE PROCEDURE SP_LISTAR_USUARIO
AS
BEGIN
    SELECT id, codigo, email, password, tipo
    FROM USUARIO;
END
GO

-- PROCEDIMIENTOS ALMACENADOS PERIODO
CREATE PROCEDURE SP_LISTAR_PERIODO
AS
BEGIN
	SELECT id,codigo,fectrimestre1,fectrimestre2,fectrimestre3,fectrimestre4 FROM PERIODO;
END
GO

CREATE PROCEDURE SP_BUSCAR_PERIODO
@CODIGO INT
AS
BEGIN
	IF EXISTS (SELECT * FROM PERIODO WHERE ID=@CODIGO)
		BEGIN
			SELECT id,codigo,fectrimestre1,fectrimestre2,fectrimestre3,fectrimestre4 FROM PERIODO WHERE ID=@CODIGO;
		END
END
GO

CREATE PROCEDURE SP_REGISTRAR_PERIODO
@ID INT,
@TRIMESTRE1 DATE,
@TRIMESTRE2 DATE,
@TRIMESTRE3 DATE,
@TRIMESTRE4 DATE
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM PERIODO WHERE ID=@ID)
		BEGIN
			INSERT INTO PERIODO(fectrimestre1,fectrimestre2,fectrimestre3,fectrimestre4)VALUES(@TRIMESTRE1,@TRIMESTRE2,@TRIMESTRE3,@TRIMESTRE4);
		END
END
GO

CREATE PROCEDURE SP_ACTUALIZAR_PERIODO
@ID INT,
@TRIMESTRE1 DATE,
@TRIMESTRE2 DATE,
@TRIMESTRE3 DATE,
@TRIMESTRE4 DATE
AS
BEGIN
	IF EXISTS (SELECT * FROM PERIODO WHERE ID=@ID)
		BEGIN
			UPDATE PERIODO SET fectrimestre1=@TRIMESTRE1,fectrimestre2=@TRIMESTRE2,fectrimestre3=@TRIMESTRE3,fectrimestre4=@TRIMESTRE4 WHERE ID=@ID;
		END
END
GO

CREATE PROCEDURE SP_ELIMINAR_PERIODO
@CODIGO INT
AS
BEGIN
	DECLARE @MENSAJE VARCHAR(100);
	IF EXISTS (select * from periodo as p inner join cargo_profesor as c
					on c.idperiodo=p.id where p.id=@CODIGO)
		BEGIN
			SET @MENSAJE = 'Error el Periodo no se puede Eliminar, hay materias ya asignadas';		
		END
	ELSE
		BEGIN 
			DELETE FROM PERIODO WHERE ID=@CODIGO;
			SET @MENSAJE = 'Se Elimino Correctamente';	
		END
	select @MENSAJE as Error;
END
GO

-- PROCEDIMIENTOS ALMACENADOS DE AULA
CREATE PROCEDURE SP_LISTAR_AULA
AS
BEGIN 
	SELECT id,codigo,descripcion FROM AULA;
END
GO


CREATE PROCEDURE SP_REGISTRAR_AULA
@ID INT,
@DESCRIPCION VARCHAR(200)
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM AULA WHERE ID=@ID)
		BEGIN
			INSERT INTO AULA(DESCRIPCION)VALUES(@DESCRIPCION);
		END
END
GO

CREATE PROCEDURE SP_ACTUALIZAR_AULA
@ID INT,
@DESCRIPCION VARCHAR(200)
AS
BEGIN
	IF EXISTS (SELECT * FROM AULA WHERE ID=@ID)
		BEGIN
			UPDATE AULA SET DESCRIPCION=@DESCRIPCION WHERE ID=@ID;
		END
END
GO

CREATE PROCEDURE SP_BUSCAR_AULA
@CODIGO INT
AS
BEGIN
	IF EXISTS (SELECT * FROM AULA WHERE ID=@CODIGO)
		BEGIN
			SELECT ID,CODIGO,DESCRIPCION FROM AULA WHERE ID=@CODIGO;
		END
END
GO

create PROCEDURE SP_ELIMINAR_AULA
@ID INT
AS
BEGIN
	DECLARE @MENSAJE VARCHAR(200);
	IF EXISTS (SELECT A.ID,A.CODIGO,A.DESCRIPCION FROM AULA AS A INNER JOIN MATRICULA AS M 
				ON A.ID=M.IDAULA INNER JOIN CARGO_PROFESOR AS C
				ON A.ID=C.IDAULA
				WHERE A.ID=@ID) 
		BEGIN
			SET @MENSAJE = 'Error el Aula esta asignada a una Matricula o aun Cargo de un Profesor';
		END
	ELSE
		BEGIN
			DELETE FROM AULA WHERE ID=@ID;
			SET @MENSAJE ='Se Elimino Correctamente';
		END

	SELECT @MENSAJE AS MENSAJE;
END
GO


--
CREATE PROCEDURE SP_LISTAR_MATRICULA
AS
BEGIN
	SELECT ID,CODIGO,IDALUMNO,IDAULA,FECHA FROM MATRICULA;
END
GO


--
CREATE PROCEDURE SP_LISTAR_CURSO
AS
BEGIN
	SELECT id,codigo,descripcion FROM CURSO;
END
GO


--
CREATE PROCEDURE SP_LISTAR_PROFESOR
AS
BEGIN
    SELECT id, codigo, documento, nombre, apellido, idusuario
    FROM profesor;
END
GO

--
CREATE PROCEDURE SP_LISTAR_CARGO_PROFESOR
AS
BEGIN
	SELECT ID,IDAULA,IDCURSO,IDPROFESOR,IDPERIODO FROM cargo_profesor;
END
GO

/* PROCEDIMIENTO ALMACENADO BOLETA NOTAS */

--EXEC SP_BUSCAR_ALUMNOS_MATRICULADO_BOLETA 2698

CREATE procedure SP_BUSCAR_ALUMNOS_MATRICULADO_BOLETA
@CODIGO int
as
begin
declare @MENSAJE varchar(200)
	if exists (select * from boleta_nota where id=@CODIGO)
		begin 
		declare @cargo int = (select idcargo from boleta_nota where id=@CODIGO)
		declare @curso int = (select c.id from boleta_nota as b inner join cargo_profesor as cp
							on cp.id=b.idcargo inner join curso as c
							on c.id=cp.idcurso
							where b.idcargo=@cargo
							group by c.id)
		declare @aula int = (select a.id from boleta_nota as b inner join cargo_profesor as cp
							on cp.id=b.idcargo inner join aula as a
							on a.id=cp.idaula
							where b.idcargo=@cargo
							group by a.id) 
	    declare @profesor int = (select p.id from boleta_nota as b inner join cargo_profesor as cp
							on cp.id=b.idcargo inner join profesor as p
							on p.id=cp.idprofesor
							where b.idcargo=@cargo
							group by p.id)

		declare @fecha_perido varchar(4) = (select year(pr.fectrimestre1) from boleta_nota as b inner join cargo_profesor as cp
							on cp.id=b.idcargo inner join periodo as pr
							on pr.id=cp.idperiodo
							where b.idcargo=@cargo and year(pr.fectrimestre1)=year(getdate()) and year(pr.fectrimestre2)=year(getdate()) and year(pr.fectrimestre3)=year(getdate()) and year(pr.fectrimestre4)=year(getdate())
							group by year(pr.fectrimestre1))

		if (@fecha_perido is not null)
			begin
				if exists (select * from cargo_profesor where id=@cargo) and exists (select * from boleta_nota where idcargo=@cargo)
					begin
						select b.id,b.idmatricula,b.idcargo,b.nota1,b.nota2,b.nota3,b.nota4,b.promedio
						from matricula as m inner join alumno as al
						on m.idalumno = al.id left join boleta_nota as b
						on b.idmatricula=m.id inner join aula as a
						on a.id=m.idaula inner join cargo_profesor as cp
						on cp.idaula = a.id inner join curso as c
						on c.id=cp.idcurso inner join periodo as p
						on p.id=cp.idperiodo inner join profesor as pf
						on pf.id=cp.idprofesor
						where m.idaula=@aula and pf.id=@profesor and c.id=@curso and b.id is not null and b.idcargo=@cargo and year(p.fectrimestre4)=year(getdate())
						group by b.id,b.idmatricula,b.idcargo,b.nota1,b.nota2,b.nota3,b.nota4,b.promedio
						order by b.id asc
					end
				else
					begin
						set @MENSAJE = 'No Existe el un Cargo asignado a la boleta'
					end
			end
		else
			begin
				set @MENSAJE = 'Error no Existe una boleta en el periodo '
			end
		end
	else
		begin 
			set @MENSAJE = 'La Boleta no Existe en el Sistema'
		end

	if (@mensaje is not null)
		begin 
			select @MENSAJE as Mensaje;
		end
end
go




CREATE PROCEDURE SP_LISTAR_CURSOS_BOLETA
@FECHA DATE
AS
BEGIN
	IF (@FECHA IS NOT NULL)
		BEGIN
			select b.idcargo,a.codigo,c.descripcion,p.fectrimestre1 as inicio,p.fectrimestre4 as final,count(al.id) as total,m.fecha as matricula
			from boleta_nota as b inner join cargo_profesor as cp
			on cp.id=b.idcargo inner join aula as a 
			on a.id=cp.idaula inner join profesor as pf
			on pf.id=cp.idprofesor inner join curso as c
			on c.id=cp.idcurso inner join periodo as p
			on p.id=cp.idperiodo inner join matricula as m
			on m.id=b.idmatricula inner join alumno as al
			on al.id=m.idalumno
			where year(m.fecha)=year(@FECHA)
			group by b.idcargo,a.codigo,c.descripcion,p.fectrimestre1,p.fectrimestre4,m.fecha
		END
	ELSE
		BEGIN
			select b.idcargo,a.codigo,c.descripcion,p.fectrimestre1 as inicio,p.fectrimestre4 as final,count(al.id) as total,m.fecha as matricula
			from boleta_nota as b inner join cargo_profesor as cp
			on cp.id=b.idcargo inner join aula as a 
			on a.id=cp.idaula inner join profesor as pf
			on pf.id=cp.idprofesor inner join curso as c
			on c.id=cp.idcurso inner join periodo as p
			on p.id=cp.idperiodo inner join matricula as m
			on m.id=b.idmatricula inner join alumno as al
			on al.id=m.idalumno
			where year(m.fecha)=year(getdate())
			group by b.idcargo,a.codigo,c.descripcion,p.fectrimestre1,p.fectrimestre4,m.fecha
		END
END
GO

/*
PROCEDIMIENTO ALMACENADO PARA LISTAR LOS CURSOS EN LA VISTA 'BOLETANOTAS'
*/
EXEC SP_LISTAR_CURSO 0,''

CREATE PROCEDURE SP_LISTAR_CURSOS_MATRICULA
    @IDPROFESOR INT,
	@FECHA DATE
AS
BEGIN
	IF (@IDPROFESOR=0) AND (@FECHA='')
		BEGIN
			SELECT C.id, C.IDAULA, C.IDCURSO,C.IDPROFESOR, C.IDPERIODO,CONCAT(A.descripcion, ' - ', CU.DESCRIPCION) AS DESCRIPCION, year(p.fectrimestre1) AS ANIO
			FROM CARGO_PROFESOR AS C
			INNER JOIN AULA AS A ON C.idaula = A.id
			INNER JOIN CURSO AS CU ON CU.ID = C.idcurso
			INNER JOIN PERIODO AS P ON C.idperiodo = P.id
			ORDER BY DESCRIPCION;
		END
	ELSE
		BEGIN
			SELECT C.id, C.IDAULA, C.IDCURSO,C.IDPROFESOR, C.IDPERIODO,CONCAT(A.descripcion, ' - ', CU.DESCRIPCION) AS DESCRIPCION, year(p.fectrimestre1) AS ANIO
			FROM CARGO_PROFESOR AS C
			INNER JOIN AULA AS A ON C.idaula = A.id
			INNER JOIN CURSO AS CU ON CU.ID = C.idcurso
			INNER JOIN PERIODO AS P ON C.idperiodo = P.id
			WHERE YEAR(P.fectrimestre1) = YEAR(GETDATE()) AND C.IDPROFESOR = @IDPROFESOR
			ORDER BY DESCRIPCION;
		END
	
END
GO


CREATE PROCEDURE SP_CREAR_BOLETA_NOTA
    @IDMATRICULA INT,
    @IDCARGO INT
AS
BEGIN
	IF NOT EXISTS (SELECT * FROM BOLETA_NOTA WHERE IDMATRICULA = @IDMATRICULA AND IDCARGO = @IDCARGO)
    BEGIN

		DECLARE @FECHA_PERIODO INT = (SELECT year(p.fectrimestre1) FROM PERIODO AS P INNER JOIN CARGO_PROFESOR C ON C.idperiodo = P.id WHERE C.id =@IDMATRICULA);
		DECLARE @FECHA_MATRICULA INT =(SELECT year(fecha) FROM MATRICULA WHERE id = @IDCARGO);

		IF (@FECHA_PERIODO = @FECHA_MATRICULA)
        BEGIN
			INSERT INTO BOLETA_NOTA (IDMATRICULA, IDCARGO) VALUES (@IDMATRICULA, @IDCARGO)
		END
    END
END
GO

--Actualizar nota
CREATE PROCEDURE SP_ACTUALIZAR_NOTA
	@ID INT,
    @NOTA1 DECIMAL(4,2),
    @NOTA2 DECIMAL(4,2),
    @NOTA3 DECIMAL(4,2),
    @NOTA4 DECIMAL(4,2),
	@FECHA_ACTUAL DATETIME
AS
BEGIN
	IF EXISTS (SELECT * FROM BOLETA_NOTA WHERE ID = @ID)
    BEGIN
		DECLARE @FECHA_PERIODO1 DATETIME = (SELECT p.fectrimestre1
											FROM BOLETA_NOTA AS B
											INNER JOIN CARGO_PROFESOR C ON C.id = B.idcargo
											INNER JOIN PERIODO P ON P.id = C.idperiodo
											WHERE B.id =@ID);
		DECLARE @FECHA_PERIODO2 DATETIME = (SELECT p.fectrimestre2
											FROM BOLETA_NOTA AS B
											INNER JOIN CARGO_PROFESOR C ON C.id = B.idcargo
											INNER JOIN PERIODO P ON P.id = C.idperiodo
											WHERE B.id =@ID);
		DECLARE @FECHA_PERIODO3 DATETIME = (SELECT p.fectrimestre3
											FROM BOLETA_NOTA AS B
											INNER JOIN CARGO_PROFESOR C ON C.id = B.idcargo
											INNER JOIN PERIODO P ON P.id = C.idperiodo
											WHERE B.id =@ID);
		DECLARE @FECHA_PERIODO4 DATETIME = (SELECT p.fectrimestre4
											FROM BOLETA_NOTA AS B
											INNER JOIN CARGO_PROFESOR C ON C.id = B.idcargo
											INNER JOIN PERIODO P ON P.id = C.idperiodo
											WHERE B.id =@ID);
		IF (@FECHA_ACTUAL < @FECHA_PERIODO1)
        BEGIN
			UPDATE BOLETA_NOTA SET NOTA1=@NOTA1 WHERE ID=@ID;
		END
		IF (@FECHA_ACTUAL < @FECHA_PERIODO2)
        BEGIN
			UPDATE BOLETA_NOTA SET NOTA2=@NOTA2 WHERE ID=@ID;
		END
		IF (@FECHA_ACTUAL < @FECHA_PERIODO3)
        BEGIN
			UPDATE BOLETA_NOTA SET NOTA3=@NOTA3 WHERE ID=@ID;
		END
		IF (@FECHA_ACTUAL < @FECHA_PERIODO4)
        BEGIN
			UPDATE BOLETA_NOTA SET NOTA4=@NOTA4 WHERE ID=@ID;
		END

		DECLARE @PROMEDIO DECIMAL = (SELECT (NOTA1+NOTA2+NOTA3+NOTA4)/4 FROM BOLETA_NOTA WHERE ID = @ID);
		UPDATE BOLETA_NOTA SET PROMEDIO = @PROMEDIO WHERE ID=@ID;

		SELECT * from boleta_nota where id = @ID;
    END
END
GO
