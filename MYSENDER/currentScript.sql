


--Scaffold-DbContext "Server=DESKTOP-0M7S8I3\SQLEXPRESS2012;Database=MYSENDER;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force
/****************************EMETTEUR*************************************/
ALTER TABLE HISTORIQUE DROP CONSTRAINT FK_CONTACT
ALTER TABLE HISTORIQUE DROP CONSTRAINT FK_EMETEUR
DROP TABLE  HISTORIQUE  
DROP TABLE EMETTEUR
DROP TABLE  CONTACT




IF NOT EXISTS (SELECT * FROM sysobjects WHERE name ='EMETTEUR' AND xtype='U')
	BEGIN
		CREATE TABLE EMETTEUR
		(
		 ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
		 NOM NVARCHAR(36),
		 PRENOM VARCHAR(36),
		 ACCESTOKEN VARCHAR(100),
		 TEL NVARCHAR(15)
		 )
	END
GO


/****************************DESTINATAIRE*************************************/
IF NOT EXISTS (SELECT * FROM sysobjects WHERE name ='CONTACT' AND xtype='U')
	BEGIN
		CREATE TABLE CONTACT
		(
		 ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
		 NOM NVARCHAR(36),
		 PRENOM VARCHAR(36),
		 TEL NVARCHAR(15)
		 )
	END
GO

--IF EXISTS (SELECT NAME FROM sysobjects WHERE type = 'P' AND NAME = 'SELECT_ALL_CONTACT' )
--DROP PROCEDURE [dbo].[SELECT_ALL_CONTACT]
--	GO
--CREATE PROCEDURE [SELECT_ALL_CONTACT]
--	AS 
--	BEGIN
--		SELECT * FROM CONTACT
--	END
--GO


--IF EXISTS (SELECT NAME FROM sysobjects WHERE type = 'P' AND NAME = 'INSERT_CONTACT' )
--DROP PROCEDURE [dbo].[INSERT_CONTACT]
--	GO
--CREATE PROCEDURE [INSERT_CONTACT]
--	 @nom nvarchar(30),
--	 @prenom nvarchar(15),
--	 @tel int
--	AS 
--	BEGIN
--		INSERT INTO [CONTACT] 
--		(
--			NOM,
--			PRENOM,
--			TEL
--		)
--		VALUES 
--		(
--		 @nom,
--		 @prenom,
--		 @tel
--		 )
--	END
--GO

/****************************HISTORISATION*************************************/

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name ='HISTORIQUE' AND xtype='U')
	BEGIN
		CREATE TABLE HISTORIQUE
		(
		 ID INT PRIMARY KEY NOT NULL IDENTITY(1,1),
		 ID_EMETTEUR INT,
		 SMSTEXT NVARCHAR(160),
		 ID_CONTACT INT,
		 DATE_ENVOI DATETIME,
		 STATUT INT,
		 CONSTRAINT FK_EMETEUR FOREIGN KEY (ID_EMETTEUR) REFERENCES EMETTEUR(ID),
		 CONSTRAINT FK_CONTACT FOREIGN KEY (ID_CONTACT) REFERENCES CONTACT(ID)
		 )
	END
GO
--IF EXISTS (SELECT NAME FROM sysobjects WHERE type = 'P' AND NAME = 'INSERT_HISTORIQUE' )
--DROP PROCEDURE [dbo].[INSERT_HISTORIQUE]
--	GO
--CREATE PROCEDURE [INSERT_HISTORIQUE]
--	 @smstext nvarchar(30),
--	 @destinataire nvarchar(15),
--	 @idemetteur int,
--	 @dateenvoi int,
--	 @statut int
--	AS 
--	BEGIN
--		INSERT INTO [HISTORIQUE] 
--		(
--			ID_EMETTEUR,
--			SMSTEXT,
--			ID_CONTACT, 
--			DATE_ENVOI, 
--			STATUT
--		)
--		VALUES 
--		(
--		 @idemetteur,
--		 @smstext,
--		 @destinataire,
--		 @dateenvoi,
--		 @statut
--		 )
--	END
--GO
--IF EXISTS (SELECT NAME FROM sysobjects WHERE type = 'P' AND NAME = 'SELECT_ALL_HISTORIQUE' )
--DROP PROCEDURE [dbo].[SELECT_ALL_HISTORIQUE]
--	GO
--CREATE PROCEDURE [SELECT_ALL_HISTORIQUE]
--	AS 
--	BEGIN
--		SELECT 
--			ID_EMETTEUR,
--			SMSTEXT,
--			DESTINATAIRE,
--			DATE_ENVOI,
--			STATUT
--			FROM HISTORIQUE
--	END

USE [MYSENDER]
GO

INSERT INTO [dbo].[EMETTEUR]
           ([NOM]
           ,[PRENOM]
           ,[ACCESTOKEN]
           ,[TEL])
     VALUES
           ('ADMIN', 'ADMIN'
           ,'ZjJrj36bCrAUmxnXwKTLxRPR0xkP1f1w'
           ,36034)

		   
INSERT INTO [dbo].[CONTACT]
           ([NOM]
           ,[PRENOM]           
           ,[TEL])
     VALUES
           ('CONTACT1', 'CONTACT1'        
           ,'0612345678')
GO



select * from CONTACT


select * from EMETTEUR

select * from HISTORIQUE
