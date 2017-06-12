CREATE DATABASE Filmverwaltung;
USE Filmverwaltung;

CREATE TABLE Produzent(
	ID_Produzent	INT PRIMARY KEY IDENTITY(1,1),
	Vorname			VARCHAR(200) NOT NULL,
	Nachname		VARCHAR(200) NOT NULL,
	Firma			VARCHAR(200)
);

CREATE TABLE Film(
	ID_Film		INT	PRIMARY KEY IDENTITY(1,1),
	Name		VARCHAR(200) NOT NULL,
	Genre		VARCHAR(200) NOT NULL,
	Laenge		INT,	
	ProduzentId		INT FOREIGN KEY REFERENCES Produzent(ID_Produzent) NOT NULL
);

CREATE TABLE Schauspieler(
	ID_Schauspieler		INT PRIMARY KEY IDENTITY(1,1),
	Vorname				VARCHAR(200) NOT NULL,
	Name				VARCHAR(200) NOT NULL,
	VermittlungsAgentur	VARCHAR(200)
);

drop table Serie

CREATE TABLE Serie(
	ID_Serie		INT	PRIMARY KEY IDENTITY(1,1),
	Name			VARCHAR(200) NOT NULL,
	Genre			VARCHAR(200) NOT NULL,
	AnzStaffeln		INT NOT NULL,	
	AnzEpisoden		INT NOT NULL,	
	ProduzentId		INT FOREIGN KEY REFERENCES Produzent(ID_Produzent) NOT NULL
);

CREATE TABLE FilmSchauspieler(
	ID_FilmSchauspieler INT PRIMARY KEY IDENTITY(1,1),
	FilmId				INT FOREIGN KEY REFERENCES Film(ID_Film) NOT NULL,
	SchauspielerId		INT FOREIGN KEY REFERENCES Schauspieler(ID_Schauspieler) NOT NULL,
);

CREATE TABLE SerieSchauspieler(
	ID_SerieSchauspieler	INT PRIMARY KEY IDENTITY(1,1),
	SerieId					INT FOREIGN KEY REFERENCES Serie(ID_Serie) NOT NULL,
	SchauspielerId			INT FOREIGN KEY REFERENCES Schauspieler(ID_Schauspieler) NOT NULL,
);
