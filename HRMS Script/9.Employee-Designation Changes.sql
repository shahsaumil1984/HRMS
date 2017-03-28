CREATE TABLE [dbo].[Designation](
	[DesignationID] [int] IDENTITY(1,1) NOT NULL,
	[DesignationName] [varchar](100) NULL,
	[CreatedBy] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[ModifiedDate] [datetime] NULL,
   CONSTRAINT [PK_Designation] PRIMARY KEY CLUSTERED 
   (
	  [DesignationID] ASC
   )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

------------------------------------------------------------
GO
------------------------------------------------------------
insert into Designation(DesignationName) values ('Development Lead')
---------------------------------------------------------------------------
GO
---------------------------------------------------------------------------
insert into Designation(DesignationName) values ('Project Manager')
---------------------------------------------------------------------------
GO
---------------------------------------------------------------------------
insert into Designation(DesignationName) values ('Senior Developer')
---------------------------------------------------------------------------
GO
---------------------------------------------------------------------------
insert into Designation(DesignationName) values ('Designer')
---------------------------------------------------------------------------
GO
---------------------------------------------------------------------------
ALTER TABLE Employee
ADD PermanentAddressCity nvarchar(50)
------------------------------------------------------------
GO
------------------------------------------------------------
ALTER TABLE Employee
ADD AddressCity nvarchar(50)
------------------------------------------------------------
GO
------------------------------------------------------------
ALTER TABLE Employee
ADD DesignationID int
---------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Designation] FOREIGN KEY([DesignationID])
REFERENCES [dbo].[Designation] ([DesignationID ])

ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Designation]
---------------------------------------------------------------------------------
GO
---------------------------------------------------------------------------------


