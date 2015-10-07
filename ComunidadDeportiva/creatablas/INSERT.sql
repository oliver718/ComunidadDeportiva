
/********tabla liga*******/
insert into liga values('LigaBBVA');

/***********tabla equipos**********/
/*equipos*/
insert into equipo values('Real Madrid',1,0);
insert into equipo values('Barcelona',1,0);
insert into equipo values('Valencia',1,0);
insert into equipo values('Villarreal',1,0);
insert into equipo values('Sevilla',1,0);
insert into equipo values('Athletic de Bilbao',1,0);
insert into equipo values('Atlético de Madrid',1,0);
insert into equipo values('Espanyol',1,0);
insert into equipo values('Osasuna',1,0);
insert into equipo values('Sporting de Gijón',1,0);
insert into equipo values('Málaga',1,0);
insert into equipo values('Racing de Santander',1,0);
insert into equipo values('Zaragoza',1,0);
insert into equipo values('Levante',1,0);
insert into equipo values('Real Sociedad',1,0);
insert into equipo values('Getafe',1,0);
insert into equipo values('Mallorca',1,0);
insert into equipo values('Betis',1,0);
insert into equipo values('Rayo Vallecano',1,0);
insert into equipo values('Granada',1,0);
/*selecciones*/
insert into equipo values('Selección Española',null,1);
insert into equipo values('Selección Portuguesa',null,1);
insert into equipo values('Selección Inglesa',null,1);
insert into equipo values('Selección Alemana',null,1);

/********tabla usuario*******/
insert into usuario values('eag','eag','oli_y_chibi@hotmail.com',1,21,0);
insert into usuario values('admin','admin','admin@hotmail.com',1,21,1);

/********tabla noticias*******/

insert into noticias values(2,'Noticia de prueba 1','Texto de prueba<br>Texto de prueba',convert(date,'21/05/2011',103));
insert into noticias values(2,'Noticia de prueba 2','Texto de prueba<br>Texto de prueba',convert(date,'22/05/2011',103));
insert into noticias values(2,'Noticia de prueba 3','Texto de prueba<br>Texto de prueba',convert(date,'23/05/2011',103));
insert into noticias values(2,'Noticia de prueba 4','Texto de prueba<br>Texto de prueba',convert(date,'24/05/2011',103));
insert into noticias values(2,'Noticia de prueba 5','Texto de prueba<br>Texto de prueba',convert(date,'25/05/2011',103));

/************tabla jugador************/
/*select CONVERT(VARCHAR(10),fechaNac, 103) as fecha from jugador ---- para sacar jugadores*/
/*REAL MADRID--1*/
insert into jugador values('Íker Casillas',1,'España',convert(date,'20/05/1981',103),21,60000000,60000,7,'portero','casillas.jpg');
insert into jugador values('Adán',1,'España',convert(date,'13/05/1987',103),null,7000000,7000,8,'portero','adan.jpg');
insert into jugador values('Carvalho',1,'Portugal',convert(date,'18/05/1978',103),null,10000000,10000,5,'defensa','carvalho.jpg');
insert into jugador values('Pepe',1,'Brasil',convert(date,'26/02/1983',103),22,30000000,30000,3,'defensa','pepe.jpg');
insert into jugador values('Sergio Ramos',1,'España',convert(date,'30/03/1986',103),21,50000000,50000,8,'defensa','sergioramos.jpg');
insert into jugador values('Marcelo',1,'Brasil',convert(date,'12/05/1988',103),null,35000000,35000,7,'defensa','marcelo.jpg');
insert into jugador values('Álvaro Arbeloa',1,'España',convert(date,'17/01/1983',103),21,20000000,20000,3,'defensa','alvaroarbeloa.jpg');
insert into jugador values('Raúl Albiol',1,'España',convert(date,'04/09/1985',103),21,25000000,25000,2,'defensa','raulalbiol.jpg');
insert into jugador values('Kaká',1,'Brasil',convert(date,'22/04/1982',103),null,50000000,50000,9,'centrocampista','kaka.jpg');
insert into jugador values('Granero',1,'España',convert(date,'02/07/1987',103),null,15000000,15000,0,'centrocampista','granero.jpg');
insert into jugador values('Xabi Alonso',1,'España',convert(date,'25/11/1981',103),21,35000000,35000,6,'centrocampista','xabialonso.jpg');
insert into jugador values('Di María',1,'Argentina',convert(date,'14/02/1988',103),null,55000000,55000,6,'centrocampista','dimaria.jpg');
insert into jugador values('Özil',1,'Alemania',convert(date,'15/10/1988',103),24,55000000,55000,9,'centrocampista','ozil.jpg');
insert into jugador values('Khedira',1,'Alemania',convert(date,'04/04/1987',103),24,25000000,25000,9,'centrocampista','khedira.jpg');
insert into jugador values('Cristiano Ronaldo',1,'Portugal',convert(date,'05/02/1985',103),22,90000000,90000,9,'delantero','cristianoronaldo.jpg');
insert into jugador values('Benzema',1,'Francia',convert(date,'19/12/1987',103),null,40000000,40000,4,'delantero','benzema.jpg');
insert into jugador values('Higuaín',1,'Francia',convert(date,'12/12/1987',103),null,45000000,45000,0,'delantero','higuain.jpg');

/*LEVANTE---14*/

insert into jugador values('Manolo Reina',14,'España',convert(date,'01/04/1985',103),null,500000,500,5,'portero','manoloreina.jpg');
insert into jugador values('Munúa',14,'Uruguay',convert(date,'27/01/1978',103),null,700000,700,5,'portero','munua.jpg');
insert into jugador values('Cerra',14,'España',convert(date,'04/06/1983',103),null,400000,400,5,'defensa','cerra.jpg');
insert into jugador values('Nano',14,'España',convert(date,'07/07/1980',103),null,400000,400,7,'defensa','nano.jpg');
insert into jugador values('Rodas',14,'España',convert(date,'07/03/1988',103),null,800000,800,3,'defensa','rodas.jpg');
insert into jugador values('Robusté',14,'España',convert(date,'20/05/1985',103),null,500000,500,2,'defensa','robuste.jpg');
insert into jugador values('Juanfran',14,'España',convert(date,'15/07/1976',103),null,400000,400,6,'defensa','juanfran.jpg');
insert into jugador values('Del Horno',14,'España',convert(date,'19/01/1981',103),null,900000,900,8,'defensa','delhorno.jpg');
insert into jugador values('Javi Venta',14,'España',convert(date,'13/12/1975',103),null,500000,500,4,'defensa','javiventa.jpg');
insert into jugador values('Ballesteros',14,'España',convert(date,'04/09/1975',103),null,450000,450,3,'defensa','ballesteros.jpg');
insert into jugador values('Pallardó',14,'España',convert(date,'05/09/1986',103),null,900000,900,4,'centrocampista','pallardo.jpg');
insert into jugador values('Larrea',14,'España',convert(date,'07/04/1984',103),null,400000,400,8,'centrocampista','larrea.jpg');
insert into jugador values('Iborra',14,'España',convert(date,'16/01/1988',103),null,700000,700,5,'centrocampista','iborra.jpg');
insert into jugador values('Xavi Torres',14,'España',convert(date,'27/11/1986',103),null,900000,900,5,'centrocampista','xavitorres.jpg');
insert into jugador values('Juanlu',14,'España',convert(date,'18/05/1980',103),null,800000,800,5,'centrocampista','juanlu.jpg');
insert into jugador values('Valdo',14,'España',convert(date,'23/04/1981',103),null,900000,900,7,'centrocampista','valdo.jpg');
insert into jugador values('Xisco Nadal',14,'España',convert(date,'27/06/1986',103),null,900000,900,0,'delantero','xisconadal.jpg');
insert into jugador values('Rafa',14,'España',convert(date,'01/01/1984',103),null,600000,600,0,'delantero','rafa.jpg');
insert into jugador values('Stuani',14,'Uruguay',convert(date,'12/12/1986',103),null,1000000,1000,0,'delantero','stuani.jpg');
insert into jugador values('Caicedo',14,'Ecuador',convert(date,'05/09/1988',103),null,1500000,1500,2,'delantero','caicedo.jpg');

/*Athletic de Bilbao---6*/
insert into jugador values('Iraizoz',6,'España',convert(date,'06/03/1981',103),null,1500000,1500,4,'portero','iraizoz.jpg');
insert into jugador values('Raúl Fernández',6,'España',convert(date,'13/03/1988',103),null,1000000,1000,5,'portero','raulfernandez.jpg');
insert into jugador values('Koikili',6,'España',convert(date,'23/12/1980',103),null,1900000,1900,6,'defensa','koikili.jpg');
insert into jugador values('Xabier Castillo',6,'España',convert(date,'29/03/1986',103),null,1400000,1400,7,'centrocampista','xabiercastillo.jpg');
insert into jugador values('Susaeta',6,'España',convert(date,'14/12/1987',103),null,1800000,1800,8,'delantero','susaeta.jpg');
insert into jugador values('Gabilondo',6,'España',convert(date,'10/02/1979',103),null,1500000,1500,2,'centrocampista','gabilondo.jpg');
insert into jugador values('Llorente',6,'España',convert(date,'26/02/1985',103),21,20000000,20000,9,'delantero','llorente.jpg');

/******tabla fotoEquipo******/

insert into fotoEquipo values('realmadrid0.jpg',1,'Estadio Santiago Bernabéu');
insert into fotoEquipo values('realmadrid1.jpg',1,'Novena Copa de Europa');
insert into fotoEquipo values('levante0.jpg',14,'Estadio Ciudad de Valencia');
insert into fotoEquipo values('levante1.jpg',14,'Ascenso a primera división');




