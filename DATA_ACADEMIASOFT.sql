--Deberíamos borrar el id del procedimiento almacenado
--EL ID DEL PROCEDIMIENTO ALMACENADO ES PARA VALIDAR SI NO EXISTE
USE Academia_Soft
GO

EXEC SP_REGISTRAR_USUARIO 1, 'prueba4@gmail.com', '232323', 'Profesor';
EXEC SP_REGISTRAR_USUARIO 2, 'prueba8@gmail.com', '232323', 'Auxiliar';
EXEC SP_REGISTRAR_USUARIO 3, 'p1@gmail.com', '232323', 'Alumno';
EXEC SP_REGISTRAR_USUARIO 4, 'p2@gmail.com', '232323', 'Alumno';
EXEC SP_REGISTRAR_USUARIO 5, 'p3@gmail.com', '232323', 'Alumno';
EXEC SP_REGISTRAR_USUARIO 6, 'p4@gmail.com', '232323', 'Alumno';
EXEC SP_REGISTRAR_USUARIO 7, 'p5@gmail.com', '232323', 'Alumno';
EXEC SP_REGISTRAR_USUARIO 8, 'p6@gmail.com', '232323', 'Alumno';
EXEC SP_REGISTRAR_USUARIO 9, 'p7@gmail.com', '232323', 'Alumno';
EXEC SP_REGISTRAR_USUARIO 10, 'p8@gmail.com', '232323', 'Alumno';
GO

INSERT INTO periodo (fectrimestre1, fectrimestre2, fectrimestre3, fectrimestre4) VALUES
('2021-03-31', '2021-06-30', '2021-09-30', '2021-12-31'),
('2022-03-31', '2022-06-30', '2022-09-30', '2022-12-31'),
('2023-03-31', '2023-06-30', '2023-09-30', '2023-12-31');
GO

INSERT INTO aula (descripcion) VALUES
('1A'), ('1B'), ('1C'), ('1D'),
('2A'), ('2B'), ('2C'), ('2D'),
('3A'), ('3B'), ('3C'), ('3D'),
('4A'), ('4B'), ('4C'), ('4D'),
('5A'), ('5B'), ('5C'), ('5D'),
('6A'), ('6B'), ('6C'), ('6D');
GO

INSERT INTO profesor (documento, nombre, apellido, idusuario) VALUES
('00000000', 'Carlos', 'Torres', 1),
('00000000', 'Miguel', 'Jose', 2);
GO

INSERT INTO [alumno] (documento,nombre,apellido,idusuario)
VALUES
  ('63766508','Hadley Turner','Clark Snow',7),
  ('27376503','Tatum Ryan','Hanae Larsen',4),
  ('61223241','Harriet Ortega','Heather Herman',4),
  ('64728725','Robert Marsh','Emma Pickett',5),
  ('77168117','Janna Espinoza','Bernard Keith',8),
  ('01704122','Kirestin Rollins','Lilah Merrill',4),
  ('37193827','Rashad Snider','Seth Daugherty',3),
  ('94686287','Leilani Hyde','Duncan Price',6),
  ('63155073','Margaret Garner','Charlotte Bell',9),
  ('71848566','Marsden Velazquez','Herman Gould',6),
  ('66475568','Aurelia Salinas','Glenna Bridges',4),
  ('87361033','Ulysses Ball','Azalia Warner',7),
  ('17641939','Mark Shepard','Zephania Dickerson',4),
  ('72682727','Miriam Lindsay','Adam Ashley',9),
  ('64584412','Uta Lloyd','Omar Mcmahon',5),
  ('62766654','Chaney Mcintyre','Hunter Gomez',10),
  ('10288978','Karina Mcintosh','Yvette Byrd',5),
  ('54336300','Amethyst Mcconnell','Cassidy Green',7),
  ('31383932','Aidan Russo','Janna Bruce',9),
  ('50726186','Patricia Lee','Yolanda Wynn',3),
  ('99234606','Magee Mcleod','Moana Ryan',6),
  ('13563897','Kuame Morrow','Beatrice Ruiz',8),
  ('40434172','Elmo Fitzgerald','Eliana Robbins',5),
  ('43660112','Cyrus Burnett','Hedley Vaughn',5),
  ('84898746','Hilda Perez','Neville Cline',5),
  ('63534566','Gillian Allen','Ray Joseph',7),
  ('94686296','Chadwick Hodges','Willa Sanford',9),
  ('21369182','Amos Morse','Kyra Roth',5),
  ('66353321','Lillian Foley','Griffin Gilliam',6),
  ('27091778','Evan Knight','Kirk Jenkins',10),
  ('32285337','Gay Schwartz','Raymond Salazar',10),
  ('84207704','Oleg Morse','Xenos Medina',3),
  ('67734740','Calista Lewis','Ralph Bishop',3),
  ('63852218','Brody Anthony','Isaiah Robinson',8),
  ('37782531','Victoria Cochran','Murphy Calhoun',7),
  ('13714737','Adele Barton','Paloma Velazquez',4),
  ('75104968','Hayfa Whitney','Arthur Brown',9),
  ('47824884','Porter Padilla','Hammett Mckee',6),
  ('17210235','Mariam Vance','Phyllis Fields',6),
  ('77285953','Barclay Strickland','Sasha Hendrix',8),
  ('00164243','Avye Aguirre','Valentine Villarreal',7),
  ('71232555','Cora Alvarez','Lavinia Nguyen',4),
  ('98772486','Glenna Trujillo','Roanna Larson',9),
  ('89537474','Phyllis Shepherd','Roth Donovan',4),
  ('08014332','Kaye Bean','Isaac Crawford',3),
  ('80758482','Colin Burnett','Hadley Wilder',5),
  ('75571161','Shelby Herman','Lane Branch',7),
  ('09063812','Martin Solomon','Mohammad Howell',4),
  ('38326458','Nell Holcomb','Emmanuel Castaneda',10),
  ('29038171','Hall Mathews','Brennan Bean',6),
  ('18576779','Noble Bean','Indira Conley',3),
  ('95457219','Jakeem Kirby','Emily Walker',4),
  ('61673237','Hilel Solomon','Orson Hammond',6),
  ('57118348','Derek Bowen','Belle Horn',6),
  ('22356586','Kaitlin Calderon','Hasad Hamilton',5),
  ('39232182','MacKensie Harmon','Vance Sweeney',9),
  ('52324322','Amela Stephenson','Zia Barlow',8),
  ('10131808','Nyssa Powers','Claire Park',6),
  ('86061635','Isaiah Cameron','Palmer Goff',9),
  ('26658642','Price Marquez','Kareem Guerrero',7),
  ('36257214','Erin Carlson','Rahim Hamilton',4),
  ('44779595','Scarlet Kennedy','Moana Head',10),
  ('29188198','Nash Middleton','Simone Stokes',10),
  ('30557906','Burke Osborne','Cullen Shepherd',4),
  ('68480187','Zane Holden','Hilary Lott',9),
  ('59265027','Tana Coleman','Martin Parker',7),
  ('63843706','Quentin Miles','Bradley Dunlap',7),
  ('54376495','Odette Townsend','Paki Conner',3),
  ('54602452','Rebecca O''donnell','Mariam Johnson',3),
  ('52464063','Andrew Espinoza','Blaze Robbins',6),
  ('63943638','Emily Knapp','Yeo Fry',10),
  ('07301734','Hope Rodriquez','Petra Christian',7),
  ('26862986','Vladimir Ewing','Alan Ewing',4),
  ('30687941','Warren Roth','Hope Cruz',3),
  ('41954168','Lani Holmes','Troy Johnson',6),
  ('82047631','Wylie Baldwin','Ezekiel Atkinson',9),
  ('08183553','Wilma Morales','Slade Glass',4),
  ('47348103','Clio Fields','Jessamine Paul',5),
  ('11662402','Brock Owens','Cameron Franks',3),
  ('27842518','Beatrice Morrison','Noel Levine',8),
  ('83036560','Walter England','Brady Pace',7),
  ('75328487','Otto Davenport','David Wyatt',3),
  ('57657412','Kiona Young','Giacomo Randall',9),
  ('88053423','Price Nelson','Kirsten Weber',3),
  ('60373656','Ria Baxter','Quail Palmer',4),
  ('68867543','Geraldine Lane','Tashya Roberts',7),
  ('13686811','Charity Campbell','Chelsea Erickson',5),
  ('01678543','Lael Cruz','Moses Rich',3),
  ('13346190','Zenia Sharp','Buckminster Mcguire',7),
  ('37198510','David Jefferson','Kato Serrano',7),
  ('43435431','Whoopi Horne','Guinevere Raymond',5),
  ('21252013','Wyatt Moon','Riley Garrison',6),
  ('32161267','Quinn Riley','Kyle Foley',9),
  ('60674582','Akeem Charles','Kasper Lamb',7),
  ('28734548','Orli Humphrey','Shelby Britt',5),
  ('57637840','Tatyana Marshall','Keelie Harrington',10),
  ('61638521','Janna Cruz','Tatum Roth',7),
  ('83522435','Ursa Marks','Thane House',5),
  ('84360666','Hammett Ramirez','Xaviera Alexander',8),
  ('37704425','Ryan Ortega','Summer Kidd',6);
GO

--A mi parecer se podria cambiar la forma de como almacenar los cursos
INSERT INTO curso (descripcion) VALUES
('Matemáticas I'), ('Matemáticas II'), ('Matemáticas III'), ('Matemáticas IV'), ('Matemáticas V'), 
('Lengua Castellana y Literatura'), ('Lengua Cooficial y Literatura'), ('Cultura Civica'), ('Persona, Familia y Relaciones Humanas'), 
('Computacion I'), ('Computacion II'), ('Ingles I'), ('Ingles II'),  ('Ingles III'), ('Ingles IV'), 
('Educación Física'), ('Religion'), ('Educación Artística'), ('Ciencias de la Naturaleza');
GO

INSERT INTO [matricula] (idalumno, idaula, fecha)
VALUES
(1, 1, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(2, 2, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(3, 3, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(4, 4, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(5, 5, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(1, 5, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(2, 5, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(3, 5, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(6, 5, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(6, 6, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(7, 7, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(8, 8, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(9, 9, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(10, 10, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(11, 11, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(12, 12, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(13, 13, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(14, 14, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(15, 15, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(16, 16, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(17, 17, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(18, 18, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(19, 19, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(20, 20, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(21, 21, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(22, 22, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(23, 23, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(24, 24, CONCAT(FORMAT(sysdatetime(),'yyyy') - 2,FORMAT(sysdatetime(),'-MM-dd'))),
(25, 1, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(26, 2, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(27, 3, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(28, 4, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(29, 5, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(30, 6, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(31, 7, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(32, 8, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(33, 9, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(34, 10, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(35, 11, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(36, 12, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(37, 13, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(38, 14, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(39, 15, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(40, 16, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(41, 17, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(42, 18, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(43, 19, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(44, 20, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(45, 21, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(46, 22, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(47, 23, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(48, 24, CONCAT(FORMAT(sysdatetime(),'yyyy') - 1,FORMAT(sysdatetime(),'-MM-dd'))),
(49, 1, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(50, 2, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(51, 3, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(52, 4, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(53, 5, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(54, 6, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(55, 7, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(56, 8, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(57, 9, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(58, 10, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(59, 11, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(60, 12, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(61, 13, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(62, 14, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(63, 15, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(64, 16, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(65, 17, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(66, 18, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(67, 19, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(68, 20, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(69, 21, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(70, 22, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(71, 23, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(72, 24, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(73, 1, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(74, 2, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(75, 3, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(76, 4, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(77, 5, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(78, 6, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(79, 7, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(80, 8, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(81, 9, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(82, 10, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(83, 11, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(84, 12, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(85, 13, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(86, 14, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(87, 15, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(88, 16, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(89, 17, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(90, 18, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(91, 19, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(92, 20, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(93, 21, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(94, 22, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(95, 23, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(96, 24, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(97, 1, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(98, 1, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(99, 1, FORMAT(sysdatetime(),'yyyy-MM-dd') ),
(100, 1, FORMAT(sysdatetime(),'yyyy-MM-dd') );
GO


INSERT INTO cargo_profesor (idaula,idcurso,idprofesor,idperiodo)
VALUES
(16,15,1,3), (12,16,1,1), (19,14,2,2), (16,17,1,3), (17,4,2,2), (14,14,2,1),
(12,13,2,2), (19,13,2,2), (16,16,2,3), (17,18,2,3), (7,16,1,2), (16,18,2,1),
(8,14,1,2), (14,11,1,1), (20,17,2,1), (21,2,1,1), (6,4,2,3), (6,1,2,2), (8,7,2,1),
(21,11,1,3), (9,3,2,2), (8,2,1,1), (11,8,2,3), (12,17,1,3), (10,13,1,3), (5,2,1,3),
(5,9,2,1), (6,10,2,1), (13,1,1,3), (22,12,2,3), (20,3,2,2), (20,10,1,3), (4,18,1,2),
(4,5,1,3), (3,16,1,2), (9,14,2,2), (10,17,2,2), (5,10,2,1), (24,8,1,2), (13,12,1,3),
(2,8,2,2), (14,9,2,3), (7,9,1,3), (12,11,2,2), (21,11,2,2), (5,7,1,3), (10,1,2,2),
(4,7,2,3), (13,15,2,2), (19,11,2,2), (9,2,1,2), (13,1,2,2), (9,15,1,3), (8,18,1,2),
(22,10,2,1), (15,9,1,2), (19,16,2,3), (11,1,1,2), (17,16,1,2), (1,3,1,3), (10,6,1,3),
(23,7,1,2), (13,16,2,2), (15,13,1,1), (19,17,1,3), (5,13,2,3), (8,7,1,3), (10,12,1,3),
(8,16,1,1), (17,13,1,2), (15,1,1,2), (15,2,1,2), (22,4,1,1), (24,10,2,2),
(2,17,1,1), (11,5,2,2), (12,10,1,2), (4,5,2,2), (22,3,1,2), (22,14,2,3), (21,13,2,3),
(5,12,1,1), (11,7,1,3), (19,14,2,3), (18,9,1,2), (4,1,1,1), (24,5,2,1), (21,15,2,2),
(2,9,1,2), (22,16,2,2), (10,17,2,1), (4,5,2,1), (5,10,1,2), (19,7,2,2), (19,17,2,2),
(17,2,1,2), (14,3,2,1), (16,11,2,2), (24,18,2,1);

--EXEC SP_CREAR_BOLETA_NOTA 46, 49;

insert into boleta_nota (idcargo, idmatricula) values
(46, 49), (26, 49), (66, 49), (46, 50), (26, 50), (66, 50), (46, 51),
(26, 51), (66, 51), (46, 52), (26, 52), (66, 52), (46, 53), (26, 53),
(66, 53), (46, 54), (26, 54), (66, 54), (46, 55), (26, 55), (66, 55),
(46, 56), (26, 56), (66, 56), (46, 57), (26, 17), (66, 57), (46, 58),
(26, 58), (66, 58), (46, 59), (26, 59), (66, 59), (46, 60), (26, 60),
(66, 60), (46, 61), (26, 61), (66, 61), (61, 62), (68, 62), (25, 62),
(61, 63), (68, 63), (25, 63), (61, 64), (68, 64), (25, 64), (61, 65),
(68, 65), (25, 65), (61, 66), (68, 66), (25, 66), (61, 67), (68, 67),
(25, 67), (61, 68), (68, 68), (25, 68), (61, 69), (68, 69), (25, 69),
(61, 70), (68, 70), (25, 70), (61, 71), (68, 71), (25, 71), (61, 72),
(68, 72), (25, 72), (61, 73), (68, 73), (25, 73), (61, 74), (68, 74),
(25, 74), (1, 75), (4, 75), (9, 75), (1, 76), (4, 76), (9, 76), (1, 77),
(4, 77), (9, 77), (1, 78), (4, 78), (9, 78), (1, 79), (4, 79), (9, 79),
(1, 80), (4, 80), (9, 80), (1, 81), (4, 81), (9, 81), (1, 82), (4, 82),
(9, 82), (1, 83), (4, 83), (9, 83), (1, 84), (4, 84), (9, 84), (1, 85),
(4, 85), (9, 85), (1, 86), (4, 86), (9, 86), (1, 87), (4, 87), (9, 87),
(84, 88), (65, 88), (57, 88), (84, 89), (65, 89), (57, 89), (84, 90),
(65, 90), (57, 90), (84, 91), (65, 91), (57, 91), (84, 92), (65, 92),
(57, 92), (84, 93), (65, 93), (57, 93), (84, 94), (65, 94), (57, 94),
(84, 95), (65, 95), (57, 95), (84, 96), (65, 96), (57, 96), (84, 97),
(65, 97), (57, 97), (84, 98), (65, 98), (57, 98), (84, 99), (65, 99),
(57, 99), (84, 100), (65, 100), (57, 100);
go

/*
select c.*, p.fectrimestre1 from cargo_profesor c inner join periodo p on p.id = c.idperiodo
where year(p.fectrimestre1) = 2023 order by c.idaula

select * from profesor
select * from curso
select * from cargo_profesor
select * from aula
select * from usuario
select * from alumno
select * from matricula
select * from periodo
select * from boleta_nota
*/
-- Ejemplos de uso de los procedimientos almacenados
/*EXEC SP_REGISTRAR_USUARIO 1, 'prueba4@gmail.com', '232323', 'Profesor';
EXEC SP_REGISTRAR_USUARIO 2, 'prueba8@gmail.com', '232323', 'Auxiliar';
EXEC SP_LISTAR_USUARIO;

EXEC SP_BORRAR_ALUMNO 'AL72';

DELETE FROM CURSO_PROFESOR WHERE idprofesor, idcurso, idperiodo
SELECT idprofesor, idcurso, idperiodo, count(*) as repeticiones FROM curso_profesor 
     GROUP BY idprofesor, idcurso, idperiodo 
     HAVING COUNT(*)>1;

*/