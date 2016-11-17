USE [domy59]
GO
/*------------------------------------------------------------
*        Scripts Création tables SQLSERVER 
------------------------------------------------------------*/
CREATE TABLE employe(
	loginE	   NVARCHAR (25) NOT NULL ,
	prenom     NVARCHAR (20) NOT NULL ,
	nom        NVARCHAR (30) NOT NULL ,
	groupe NVARCHAR (25) NOT NULL ,
	CONSTRAINT prk_constraint_employe PRIMARY KEY NONCLUSTERED (loginE)
);

CREATE TABLE materiel(
	idMateriel   INT IDENTITY (1,1) NOT NULL ,
	typeMateriel NVARCHAR (100) NOT NULL ,
	numeroSerie	 NVARCHAR (50) NOT NULL ,
	numeroTel    NVARCHAR (12) ,
	imei         NVARCHAR (17) ,
	idGoogle     TEXT   ,
	dateEnregistrement DATETIME NOT NULL,
	dateAffectation  DATETIME  ,
	fkLoginE       NVARCHAR (25) ,
	etatMateriel NVARCHAR(15) CHECK (etatMateriel IN ('stock','enService','enPanne','vol','declasse','perdu'))
	CONSTRAINT prk_constraint_materiel PRIMARY KEY NONCLUSTERED (idMateriel),
	CONSTRAINT FK_materiel_loginE FOREIGN KEY (fkLoginE) REFERENCES employe(loginE) ON DELETE SET NULL,
	CONSTRAINT unicite_numero_serie UNIQUE (numeroSerie)
);



CREATE TABLE technicien(
	loginT    NVARCHAR (25) NOT NULL ,
	prenom    NVARCHAR (20) NOT NULL ,
	nom       NVARCHAR (30) NOT NULL ,
	passwdT   NVARCHAR(32) ,
	fkIdMateriel INT NULL,
	CONSTRAINT prk_constraint_technicien PRIMARY KEY NONCLUSTERED (loginT),
	CONSTRAINT FK_technicien_idMateriel FOREIGN KEY (fkIdMateriel) REFERENCES materiel(idMateriel)
);

CREATE TABLE client(
	idClient   INT IDENTITY (1,1) NOT NULL ,
	entreprise NVARCHAR (75),
	civilite   NVARCHAR(3) CHECK (civilite IN ('Mme','Mr')) ,
	prenom     NVARCHAR (20) NOT NULL ,
	nom        NVARCHAR (30) NOT NULL ,
	adresse    NVARCHAR (75) NOT NULL ,
	compAdresse NVARCHAR (75) ,
	codePostal NVARCHAR (10) NOT NULL ,
	ville      NVARCHAR (30) NOT NULL ,
	numeroTel  NVARCHAR (12) NOT NULL ,
	email	   NVARCHAR (30),
	photoent   VARBINARY(MAX),
	latitude   NVARCHAR (20)  ,
	longitude  NVARCHAR (20)  ,
	dateCreation DATETIME  NOT NULL ,
	dateModification DATETIME ,
	etatClient NVARCHAR(15) CHECK (etatClient IN ('valide','impayé','aSupprimer')) ,
	fkLoginE     NVARCHAR (25),
	CONSTRAINT prk_constraint_client PRIMARY KEY NONCLUSTERED (idClient),
	CONSTRAINT FK_client_loginE FOREIGN KEY (fkLoginE) REFERENCES employe(loginE) ON DELETE SET NULL,
	CONSTRAINT unicite_prenom_nom UNIQUE (prenom,nom)
);

CREATE TABLE intervention(
	idIntervention INT IDENTITY (1,1) NOT NULL ,
	compteRendu    TEXT ,
	debutIntervention DATETIME  NOT NULL ,
	finIntervention   DATETIME  NOT NULL ,
	objectifVisite TEXT  NOT NULL ,
	photoLieu   VARBINARY(MAX),
	nomContact      NVARCHAR (30)  ,
	prenomContact   NVARCHAR (20)  ,
	telContact      NVARCHAR (12)  ,
	etatVisite      NVARCHAR (25) CHECK (etatVisite IN ('planifiée','effectuée','absence','aRenouveler')) ,
	fkLoginE        NVARCHAR (25) ,
	fkIdClient      INT  NOT NULL ,
	fkLoginT        NVARCHAR (25) ,
	CONSTRAINT prk_constraint_intervention PRIMARY KEY NONCLUSTERED (idIntervention),
    CONSTRAINT FK_intervention_loginE FOREIGN KEY (fkLoginE) REFERENCES employe(loginE) ON DELETE SET NULL,
	CONSTRAINT FK_intervention_idClient FOREIGN KEY (fkIdClient) REFERENCES client(idClient),
	CONSTRAINT FK_intervention_loginT FOREIGN KEY (fkLoginT) REFERENCES technicien(loginT) ON DELETE SET NULL
);

CREATE TABLE notification(
	idNotification INT IDENTITY (1,1) NOT NULL ,
	dateEnvoi      DATETIME  NOT NULL ,
	contenu        NVARCHAR (50) NOT NULL ,
	fkLoginT       NVARCHAR (25) ,
	fkLoginE       NVARCHAR (25),
	CONSTRAINT prk_constraint_notification PRIMARY KEY NONCLUSTERED (idNotification),
	CONSTRAINT FK_notification_loginT FOREIGN KEY (fkLoginT) REFERENCES technicien(loginT) ON DELETE SET NULL,
	CONSTRAINT FK_notification_loginE FOREIGN KEY (fkLoginE) REFERENCES employe(loginE) ON DELETE SET NULL
);
CREATE TABLE sessionTechnicien(
     idSession [int] IDENTITY(1,1) NOT NULL ,
     jeton NVARCHAR(255) ,
     dateDerniereRequete DATETIME ,
	 fkLoginT  NVARCHAR (25) NOT NULL ,
     CONSTRAINT prk_constraint_sessionTechnicien PRIMARY KEY NONCLUSTERED (idSession),
	 CONSTRAINT FK_session_technicien_loginT FOREIGN KEY (fkLoginT) REFERENCES technicien(loginT)
);

CREATE TABLE positionTechnicien(
	idPos     INT IDENTITY (1,1) NOT NULL ,
	latitude  NVARCHAR (15) NOT NULL ,
	longitude NVARCHAR (15) NOT NULL ,
	datepos   DATETIME  NOT NULL ,
	fkLoginT  NVARCHAR (25) NOT NULL ,
	CONSTRAINT prk_constraint_positionTechnicien PRIMARY KEY NONCLUSTERED (idPos),
	CONSTRAINT FK_positionTechnicien_loginT FOREIGN KEY (fkLoginT) REFERENCES technicien(loginT)
);
