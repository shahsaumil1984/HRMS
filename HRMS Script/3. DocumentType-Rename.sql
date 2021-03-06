/*
   Tuesday, March 21, 201712:59:06 PM
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
EXECUTE sp_rename N'dbo.DocumentType.ID', N'Tmp_DocumentTypeID', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.DocumentType.Tmp_DocumentTypeID', N'DocumentTypeID', 'COLUMN' 
GO
ALTER TABLE dbo.DocumentType SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.DocumentType', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.DocumentType', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.DocumentType', 'Object', 'CONTROL') as Contr_Per 