USE [HRMS]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] IDENTITY(1,1) NOT NULL,
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
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeStatus](
	[StatusID] [int] IDENTITY(1,1) NOT NULL,
	[Status] [varchar](100) NULL,
	[Description] [varchar](max) NULL,
	[CreatedBy] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_EmployeeStatuss] PRIMARY KEY CLUSTERED 
(
	[StatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeeStatusHistory](
	[EmployeeStatusID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[OldStatusID] [int] NULL,
	[NewStatusID] [int] NULL,
	[StartDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[StatusNote] [varchar](500) NULL,
	[CreatedBy] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_EmployeeStatus] PRIMARY KEY CLUSTERED 
(
	[EmployeeStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [FullName], [PermanentAddressLine1], [PermanentAddressLine2], [PermanentAddressLine3], [PermanentAddressState], [PermanentAddressCountry], [PermanentAddressZip], [AddressLine1], [AddressLine2], [AddressLine3], [AddressState], [AddressCountry], [AddressZip], [DateOfBirth], [DateOfjoining], [ProbationPeriodEndDate], [HasResigned], [DateOfResignation], [LastWorkingDay], [PAN], [IDCardNumber], [IDCardType], [SalaryAccountNumber], [SalaryAccountBank], [SalaryAccountBankAddress], [SalaryAccountIFSCCode], [Email], [Phone], [UserName], [PermanentAddressCity], [AddressCity], [DesignationID], [EmployeePhoto], [EmployeeCode], [EmployeeStatusID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'Gargi', N'Mukherjee', N'Gargi Mukherjee', NULL, NULL, NULL, N'Select', NULL, NULL, NULL, NULL, NULL, N'Select                                                                                              ', NULL, NULL, CAST(N'1991-03-16 00:00:00.000' AS DateTime), CAST(N'2017-03-01 00:00:00.000' AS DateTime), CAST(N'2017-03-08 00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'gmukherjee@affirma.com', NULL, NULL, NULL, NULL, 2, NULL, N'111', 3, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [FullName], [PermanentAddressLine1], [PermanentAddressLine2], [PermanentAddressLine3], [PermanentAddressState], [PermanentAddressCountry], [PermanentAddressZip], [AddressLine1], [AddressLine2], [AddressLine3], [AddressState], [AddressCountry], [AddressZip], [DateOfBirth], [DateOfjoining], [ProbationPeriodEndDate], [HasResigned], [DateOfResignation], [LastWorkingDay], [PAN], [IDCardNumber], [IDCardType], [SalaryAccountNumber], [SalaryAccountBank], [SalaryAccountBankAddress], [SalaryAccountIFSCCode], [Email], [Phone], [UserName], [PermanentAddressCity], [AddressCity], [DesignationID], [EmployeePhoto], [EmployeeCode], [EmployeeStatusID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'dsd', N'sdsd', N'sdsd', NULL, NULL, NULL, N'Select', NULL, NULL, NULL, NULL, NULL, N'Select                                                                                              ', NULL, NULL, NULL, CAST(N'2017-04-11 00:00:00.000' AS DateTime), CAST(N'2017-04-21 00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'sas@sa.com', NULL, NULL, N'sasas', NULL, 3, NULL, N'112', 3, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [FullName], [PermanentAddressLine1], [PermanentAddressLine2], [PermanentAddressLine3], [PermanentAddressState], [PermanentAddressCountry], [PermanentAddressZip], [AddressLine1], [AddressLine2], [AddressLine3], [AddressState], [AddressCountry], [AddressZip], [DateOfBirth], [DateOfjoining], [ProbationPeriodEndDate], [HasResigned], [DateOfResignation], [LastWorkingDay], [PAN], [IDCardNumber], [IDCardType], [SalaryAccountNumber], [SalaryAccountBank], [SalaryAccountBankAddress], [SalaryAccountIFSCCode], [Email], [Phone], [UserName], [PermanentAddressCity], [AddressCity], [DesignationID], [EmployeePhoto], [EmployeeCode], [EmployeeStatusID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (5, N'sd', N'sd', N'ds', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2017-04-03 00:00:00.000' AS DateTime), CAST(N'2017-04-05 00:00:00.000' AS DateTime), CAST(N'2017-04-14 00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'sas@sa.com', NULL, NULL, NULL, NULL, 1, NULL, N'123', 4, NULL, NULL, NULL, NULL)
INSERT [dbo].[Employee] ([EmployeeID], [FirstName], [LastName], [FullName], [PermanentAddressLine1], [PermanentAddressLine2], [PermanentAddressLine3], [PermanentAddressState], [PermanentAddressCountry], [PermanentAddressZip], [AddressLine1], [AddressLine2], [AddressLine3], [AddressState], [AddressCountry], [AddressZip], [DateOfBirth], [DateOfjoining], [ProbationPeriodEndDate], [HasResigned], [DateOfResignation], [LastWorkingDay], [PAN], [IDCardNumber], [IDCardType], [SalaryAccountNumber], [SalaryAccountBank], [SalaryAccountBankAddress], [SalaryAccountIFSCCode], [Email], [Phone], [UserName], [PermanentAddressCity], [AddressCity], [DesignationID], [EmployeePhoto], [EmployeeCode], [EmployeeStatusID], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (7, N'ss', N'ds', N'da', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, CAST(N'2017-04-06 00:00:00.000' AS DateTime), CAST(N'2017-04-13 00:00:00.000' AS DateTime), NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'sas@sa.com', NULL, NULL, NULL, NULL, 2, NULL, N'116', 4, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Employee] OFF
SET IDENTITY_INSERT [dbo].[EmployeeStatus] ON 

INSERT [dbo].[EmployeeStatus] ([StatusID], [Status], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, N'Probation', N'This is Probation period for new employee', NULL, CAST(N'2017-04-05 00:00:00.000' AS DateTime), NULL, CAST(N'2017-04-06 00:00:00.000' AS DateTime))
INSERT [dbo].[EmployeeStatus] ([StatusID], [Status], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (3, N'Employee', N'This status is all permanent employee', NULL, CAST(N'2017-04-06 00:00:00.000' AS DateTime), N'gmukherjee@affirma.com', CAST(N'2017-04-06 11:52:11.593' AS DateTime))
INSERT [dbo].[EmployeeStatus] ([StatusID], [Status], [Description], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (4, N'Test', N'Test', N'gmukherjee@affirma.com', CAST(N'2017-04-06 00:00:00.000' AS DateTime), NULL, CAST(N'2017-04-06 00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[EmployeeStatus] OFF
SET IDENTITY_INSERT [dbo].[EmployeeStatusHistory] ON 

INSERT [dbo].[EmployeeStatusHistory] ([EmployeeStatusID], [EmployeeID], [OldStatusID], [NewStatusID], [StartDate], [EndDate], [StatusNote], [CreatedBy], [CreatedDate], [ModifiedBy], [ModifiedDate]) VALUES (1, 3, 1, 3, CAST(N'2017-06-20 00:00:00.000' AS DateTime), CAST(N'2017-08-20 00:00:00.000' AS DateTime), N'Status Changed', N'jpithadiya@affirma.com', CAST(N'2017-06-22 00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [dbo].[EmployeeStatusHistory] OFF
SET ANSI_PADDING ON

GO
ALTER TABLE [dbo].[Employee] ADD  CONSTRAINT [UK_EmployeeCode] UNIQUE NONCLUSTERED 
(
	[EmployeeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Designation] FOREIGN KEY([DesignationID])
REFERENCES [dbo].[Designation] ([DesignationID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Designation]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_EmployeeStatus] FOREIGN KEY([EmployeeStatusID])
REFERENCES [dbo].[EmployeeStatus] ([StatusID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_EmployeeStatus]
GO
ALTER TABLE [dbo].[EmployeeStatusHistory]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeStatusHistory_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[EmployeeStatusHistory] CHECK CONSTRAINT [FK_EmployeeStatusHistory_Employee]
GO
ALTER TABLE [dbo].[EmployeeStatusHistory]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeStatusHistory_EmployeeStatus] FOREIGN KEY([OldStatusID])
REFERENCES [dbo].[EmployeeStatus] ([StatusID])
GO
ALTER TABLE [dbo].[EmployeeStatusHistory] CHECK CONSTRAINT [FK_EmployeeStatusHistory_EmployeeStatus]
GO
ALTER TABLE [dbo].[EmployeeStatusHistory]  WITH CHECK ADD  CONSTRAINT [FK_EmployeeStatusHistory_EmployeeStatus1] FOREIGN KEY([NewStatusID])
REFERENCES [dbo].[EmployeeStatus] ([StatusID])
GO
ALTER TABLE [dbo].[EmployeeStatusHistory] CHECK CONSTRAINT [FK_EmployeeStatusHistory_EmployeeStatus1]
GO
