/*Nombre de la base de datos: ComunidadDeportiva*/

CREATE TABLE liga
(
	id int IDENTITY PRIMARY KEY,
	nombre nvarchar(50) UNIQUE NOT NULL
);

CREATE TABLE equipo
(
	id int IDENTITY PRIMARY KEY,
	nombre nvarchar(50) UNIQUE NOT NULL,
	idLiga	int REFERENCES liga(id) ON UPDATE CASCADE ON DELETE CASCADE,
	seleccion int NOT NULL
);

CREATE TABLE fotoEquipo
(
	nombre nvarchar(50) PRIMARY KEY,
	idEquipo int NOT NULL REFERENCES equipo(id) ON UPDATE CASCADE ON DELETE CASCADE,
	descripcion nvarchar(200) NOT NULL
);

CREATE TABLE usuario
(
	id int IDENTITY PRIMARY KEY,
	nombre nvarchar(50) UNIQUE NOT NULL,
	contrasenia nvarchar(50) NOT NULL,
	email nvarchar(100) NOT NULL,
	idEquipo int REFERENCES equipo(id),
	idSeleccion int REFERENCES equipo(id),
	administrador int NOT NULL
);

CREATE TABLE temaForo
(
	id int IDENTITY PRIMARY KEY,
	nombre nvarchar(100) NOT NULL,
	idEquipo int NOT NULL REFERENCES equipo(id) ON UPDATE CASCADE ON DELETE CASCADE,
	idUsuario int NOT NULL REFERENCES usuario(id) ON UPDATE CASCADE ON DELETE CASCADE,
	fechaCreacion datetime NOT NULL
	
);

CREATE TABLE comentarioForo
(
	id int IDENTITY PRIMARY KEY,
	idTema int NOT NULL REFERENCES temaForo(id) ON UPDATE CASCADE ON DELETE CASCADE,
	idUsuario int NOT NULL REFERENCES usuario(id),
	fechaCreacion datetime NOT NULL,
	comentario nvarchar(1000) NOT NULL
);

CREATE TABLE jugador
(
	id int IDENTITY PRIMARY KEY,
	nombre nvarchar(50) NOT NULL,
	idEquipo int REFERENCES equipo(id),
	nacionalidad nvarchar(50) NOT NULL,
	fechaNac date NOT NULL,
	idSeleccion int REFERENCES equipo(id),
	precio int NOT NULL,
	salario int NOT NULL,
	puntuacionSemanal int,
	demarcacion nvarchar(20) NOT NULL,
	foto nvarchar(50) NOT NULL
);
	
CREATE TABLE equipoJuego
(
	id int IDENTITY PRIMARY KEY,
	nombre nvarchar(50) UNIQUE NOT NULL,
	idUsuario int NOT NULL REFERENCES usuario(id) ON UPDATE CASCADE ON DELETE CASCADE,
	fechaCreacion date NOT NULL,
	presupuesto int NOT NULL,
);

CREATE TABLE puntuacionEquipoJuego
(
	idEquipoJuego int NOT NULL REFERENCES equipoJuego(id) ON UPDATE CASCADE ON DELETE CASCADE,
	fecha date NOT NULL,
	puntuacionSemanal int NOT NULL,
	PRIMARY KEY(idEquipoJuego, fecha)
);
	

CREATE TABLE jugadorEquipoJuego
(
	idEquipoJuego int NOT NULL REFERENCES equipoJuego(id) ON UPDATE CASCADE ON DELETE CASCADE,
	idJugador int NOT NULL REFERENCES jugador(id) ON UPDATE CASCADE ON DELETE CASCADE,
	PRIMARY KEY(idEquipoJuego, idJugador)
);

CREATE TABLE noticias
(
	id int IDENTITY PRIMARY KEY,
	idAdmin int NOT NULL REFERENCES usuario(id) ON UPDATE CASCADE ON DELETE CASCADE,
	titulo nvarchar(50) NOT NULL,
	descripcion nvarchar(2000) NOT NULL,
	fecha date NOT NULL
);