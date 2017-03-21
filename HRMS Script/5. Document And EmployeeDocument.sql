
CREATE TABLE [dbo].[Document](
	[DocumentID] [bigint] IDENTITY(1,1) NOT NULL,
	[DocumentContent] [varbinary](max) NULL,
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[DocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO



CREATE TABLE [dbo].[EmployeeDocument](
	[EmployeeDocumentID] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[DocumentID] [bigint] NOT NULL,
	[DocumentTypeID] [int] NOT NULL,
	[DocumentName] [varchar](250) NOT NULL,
	[CreatedBy] [varchar](250) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[ModifiedBy] [varchar](250) NULL,
	[ModifiedDate] [varchar](250) NULL,
 CONSTRAINT [PK_EmployeeDocument] PRIMARY KEY CLUSTERED 
(
	[EmployeeDocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[EmployeeDocument]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeDocument_Document] FOREIGN KEY([DocumentID])
REFERENCES [dbo].[Document] ([DocumentID])
GO

ALTER TABLE [dbo].[EmployeeDocument] CHECK CONSTRAINT [FK_EmployeeDocument_Document]
GO

ALTER TABLE [dbo].[EmployeeDocument]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeDocument_DocumentType] FOREIGN KEY([DocumentTypeID])
REFERENCES [dbo].[DocumentType] ([DocumentTypeID])
GO

ALTER TABLE [dbo].[EmployeeDocument] CHECK CONSTRAINT [FK_EmployeeDocument_DocumentType]
GO

ALTER TABLE [dbo].[EmployeeDocument]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeDocument_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO

ALTER TABLE [dbo].[EmployeeDocument] CHECK CONSTRAINT [FK_EmployeeDocument_Employee]
GO


