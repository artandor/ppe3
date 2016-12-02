
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------
-- DEBUT SECTION PROCEDURES STOCKEES
----------------------------------------------------------------------------------------
----------------------------------------------------------------------------------------


----------------------------------------------------------------------------------------
-- Procédures liées à la table employé
----------------------------------------------------------------------------------------
------------- SUPPRIMER UN EMPLOYE (utiliser avec précaution) --------------------------
USE [domy59]
GO
CREATE PROC [dbo].[spEmployeDelete] 
    @pLoginE NVARCHAR (25) 
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
		DELETE
		FROM   [dbo].[employe]
		WHERE  [loginE] =  @pLoginE
	COMMIT
GO

------------- INSERER ou METTRE A JOUR UN EMPLOYE --------------------------------------
USE [domy59]
GO
CREATE PROCEDURE [dbo].[spInsUpdateEmploye]
@pLoginE NVARCHAR (25),
@pPrenom NVARCHAR(20),
@pNom NVARCHAR(30),
@pGroupe NVARCHAR (25)

AS
	SET NOCOUNT ON 
	SET XACT_ABORT ON 
	BEGIN TRAN 
		IF NOT EXISTS (SELECT loginE FROM [dbo].[employe] 
		WHERE loginE = @pLoginE) 
			BEGIN
				INSERT INTO [employe] (
					[loginE],[prenom],[nom],[groupe]
				) VALUES ( 
					@pLoginE,@pPrenom,@pNom,@pGroupe) 
			END
    	ELSE
			BEGIN
				UPDATE  [employe]
				SET     prenom = @pPrenom,nom = @pNom,groupe=@pGroupe
				WHERE   loginE = @pLoginE	
			END
	COMMIT
GO
------------- RECUPERER UN EMPLOYE --------------------------------------------------------
-- On récupère un employe soit avec son loginE soit si on connait à la fois son prenom et son nom
USE [domy59]
GO
CREATE PROCEDURE [dbo].[spGetEmploye]
@pLoginE NVARCHAR (25),
@pPrenom NVARCHAR(20),
@pNom NVARCHAR(30)

AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN
		SELECT [loginE], [prenom],[nom],[groupe]
		FROM   [dbo].[employe] 
		WHERE  (([loginE] = @pLoginE OR @pLoginE IS NULL) OR
		(([nom]=@pNom OR @pNom IS NULL)AND([prenom]=@pPrenom OR @pPrenom IS NULL))
		)	
	COMMIT
GO
	
----------------------------------------------------------------------------------------
-- Procédures liées à la table client
----------------------------------------------------------------------------------------

------------- CREER OU MODIFIER UN CLIENT ----------------------------------------------
USE [domy59]
GO
CREATE PROCEDURE [dbo].[spInsUpdateClient] 
@pIdClient int,
@pEntreprise NVARCHAR(75),
@pCivilite   NVARCHAR(3),
@pPrenom NVARCHAR(20),
@pNom NVARCHAR(30),
@pAdresse NVARCHAR(75),
@pCompAdresse NVARCHAR (75)= NULL,
@pCodepostal NVARCHAR(10), 
@pVille NVARCHAR(30),
@pNumeroTel NVARCHAR(12),
@pEmail NVARCHAR(30),
@pPhotoent VARBINARY(MAX) = NULL,
@pLatitude NVARCHAR(20) = NULL,
@pLongitude NVARCHAR(20) = NULL,
@pEtatClient NVARCHAR(15) ,
@pLoginE NVARCHAR (25) 

AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  
	
	BEGIN TRAN
	IF NOT EXISTS (SELECT idClient FROM [dbo].[client]	WHERE prenom = @pPrenom AND nom = @pNom)
			BEGIN
			INSERT INTO [dbo].[client]
				([entreprise],[civilite],[prenom],[nom],[adresse],[compAdresse],[codePostal],[ville],
				[numeroTel],[email],[photoent],[latitude],[longitude],[dateCreation],[etatClient],[fkLoginE])
				SELECT @pEntreprise,@pCivilite,@pPrenom,@pNom,@pAdresse,@pCompAdresse,@pCodepostal,@pVille,
				@pNumeroTel,@pEmail,@pPhotoent,@pLatitude,@pLongitude,GETDATE(),@pEtatClient,@pLoginE		
			END
	ELSE
		UPDATE [dbo].[client]
			SET [entreprise] = @pEntreprise, [civilite]=@pCivilite,[prenom] = @pPrenom, [nom] = @pNom, 
				[adresse] = @pAdresse,[compAdresse] = @pCompAdresse, [codePostal] = @pCodePostal,
				[ville]=@pVille, [numeroTel] = @pNumeroTel,[email]=@pEmail, [photoent] = @pPhotoent , 
				[latitude] = @pLatitude, [longitude] = @pLongitude,[dateModification]=GETDATE(),[etatClient]=@pEtatClient,[fKLoginE]=@pLoginE
			WHERE  [idClient] = @pIdClient
	
		-- Begin Return Select 
	SELECT [idClient], [entreprise],[civilite],[prenom],[nom],[adresse],[compAdresse],[codePostal],[ville],
		[numeroTel],[email],[photoent],[latitude],[longitude],[dateCreation],[dateModification],[etatClient],[fkLoginE]
		FROM   [dbo].[client] 
		WHERE  [idClient] = @pIdClient	
		-- End Return Select 
	COMMIT
GO

------------- RECUPERER UN CLIENT --------------------------------------------------------
-- On récupère un client soit avec son id soit si on connait à la fois son prenom et son nom
USE [domy59]
GO
CREATE PROCEDURE [dbo].[spGetClient]
@pIdClient int,
@pPrenom NVARCHAR(20),
@pNom NVARCHAR(30)
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  

	BEGIN TRAN
		SELECT [idClient], [entreprise],[civilite],[prenom],[nom],[adresse],[compAdresse],[codePostal],[ville],[numeroTel],[email],[photoent],[latitude],[longitude],[dateCreation],[dateModification],[etatClient],[fkLoginE]
		FROM   [dbo].[client] 
		WHERE  (([idClient] = @pIdClient OR @pIdClient IS NULL) OR
		(([nom]=@pNom OR @pNom IS NULL)AND([prenom]=@pPrenom OR @pPrenom IS NULL))
		)	
	COMMIT
GO

------------- SUPPRIMER UN CLIENT --------------------------------------------------------
USE [domy59]
GO
CREATE PROC [dbo].[spClientDelete] 
    @pIdClient int
AS 
	SET NOCOUNT ON 
	SET XACT_ABORT ON  	
	BEGIN TRAN
		DELETE
		FROM   [dbo].[Client]
		WHERE  [idClient] =  @pIdClient
	COMMIT
GO
