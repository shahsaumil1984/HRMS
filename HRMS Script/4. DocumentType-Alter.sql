/*
   Tuesday, March 21, 20172:56:50 PM
   User: sa
   Server: NAMRATA\SQLEXPRESS
   Database: HRMS
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_DocumentType
	(
	DocumentTypeID int NOT NULL IDENTITY (1, 1),
	Description varchar(100) NULL,
	CreatedBy varchar(250) NULL,
	CreatedDate datetime NULL,
	ModifiedBy varchar(250) NULL,
	ModifiedDate datetime NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_DocumentType SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_DocumentType ON
GO
IF EXISTS(SELECT * FROM dbo.DocumentType)
	 EXEC('INSERT INTO dbo.Tmp_DocumentType (DocumentTypeID, Description, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate)
		SELECT DocumentTypeID, Description, CreatedBy, CreatedDate, ModifiedBy, ModifiedDate FROM dbo.DocumentType WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_DocumentType OFF
GO
DROP TABLE dbo.DocumentType
GO
EXECUTE sp_rename N'dbo.Tmp_DocumentType', N'DocumentType', 'OBJECT' 
GO
ALTER TABLE dbo.DocumentType ADD CONSTRAINT
	PK_DocumentType PRIMARY KEY CLUSTERED 
	(
	DocumentTypeID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.DocumentType', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DocumentType', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DocumentType', 'Object', 'CONTROL') as Contr_Per 