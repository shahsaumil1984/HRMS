USE [HRMS]


CREATE TABLE [dbo].[Employee_Audit](
	[Employee_Audit_Id]	INT	IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[EmployeeID] [int] ,
	[FirstName] [nvarchar](500) NOT NULL,
	[LastName] [nvarchar](500) NOT NULL,
	[FullName] [nvarchar](500) NOT NULL,
	[PermanentAddressLine1] [nvarchar](500) NULL,
	[PermanentAddressLine2] [nvarchar](500) NULL,
	[PermanentAddressLine3] [nvarchar](500) NULL,
	[PermanentAddressState] [nvarchar](50) NULL,
	[PermanentAddressCountry] [nvarchar](50) NULL,
	[PermanentAddressZip] [nvarchar](50) NULL,
	[AddressLine1] [nchar](100) NULL,
	[AddressLine2] [nchar](100) NULL,
	[AddressLine3] [nchar](100) NULL,
	[AddressState] [nchar](100) NULL,
	[AddressCountry] [nchar](10) NULL,
	[AddressZip] [nchar](10) NULL,
	[DateOfBirth] [datetime] NULL,
	[DateOfjoining] [datetime] NOT NULL,
	[ProbationPeriodEndDate] [datetime] NOT NULL,
	[HasResigned] [bit] NULL,
	[DateOfResignation] [datetime] NULL,
	[LastWorkingDay] [datetime] NULL,
	[PAN] [nvarchar](50) NULL,
	[IDCardNumber] [nvarchar](50) NULL,
	[IDCardType] [nvarchar](50) NULL,
	[SalaryAccountNumber] [nvarchar](50) NULL,
	[SalaryAccountBank] [nvarchar](50) NULL,
	[SalaryAccountBankAddress] [nvarchar](500) NULL,
	[SalaryAccountIFSCCode] [nvarchar](50) NULL,
	[Email] [varchar](250) NULL,
	[Phone] [varchar](15) NULL,
	[UserName] [varchar](250) NULL,
	[PermanentAddressCity] [nvarchar](50) NULL,
	[AddressCity] [nvarchar](50) NULL,
	[DesignationID] [int] NULL,
	[EmployeePhoto] [varbinary](max) NULL,
	[EmployeeCode] [varchar](20) NOT NULL DEFAULT ((0)),
	[EmployeeStatusID] [int] NULL,
	[CreatedBy] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[ModifiedDate] [datetime] NULL
	)

GO
