USE [alepthrdb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET MAXDOP = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET LEGACY_CARDINALITY_ESTIMATION = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET PARAMETER_SNIFFING = PRIMARY;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION FOR SECONDARY SET QUERY_OPTIMIZER_HOTFIXES = PRIMARY;
GO
USE [alepthrdb]
GO
/****** Object:  User [alepthrdb]    Script Date: 20-03-2017 16:07:38 ******/
CREATE USER [alepthrdb] WITHOUT LOGIN WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  DatabaseRole [gd_execprocs]    Script Date: 20-03-2017 16:07:38 ******/
CREATE ROLE [gd_execprocs]
GO
/****** Object:  DatabaseRole [aspnet_WebEvent_FullAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE ROLE [aspnet_WebEvent_FullAccess]
GO
/****** Object:  DatabaseRole [aspnet_Roles_ReportingAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE ROLE [aspnet_Roles_ReportingAccess]
GO
/****** Object:  DatabaseRole [aspnet_Roles_FullAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE ROLE [aspnet_Roles_FullAccess]
GO
/****** Object:  DatabaseRole [aspnet_Roles_BasicAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE ROLE [aspnet_Roles_BasicAccess]
GO
/****** Object:  DatabaseRole [aspnet_Profile_ReportingAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE ROLE [aspnet_Profile_ReportingAccess]
GO
/****** Object:  DatabaseRole [aspnet_Profile_FullAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE ROLE [aspnet_Profile_FullAccess]
GO
/****** Object:  DatabaseRole [aspnet_Profile_BasicAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE ROLE [aspnet_Profile_BasicAccess]
GO
/****** Object:  DatabaseRole [aspnet_Personalization_ReportingAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE ROLE [aspnet_Personalization_ReportingAccess]
GO
/****** Object:  DatabaseRole [aspnet_Personalization_FullAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE ROLE [aspnet_Personalization_FullAccess]
GO
/****** Object:  DatabaseRole [aspnet_Personalization_BasicAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE ROLE [aspnet_Personalization_BasicAccess]
GO
/****** Object:  DatabaseRole [aspnet_Membership_ReportingAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE ROLE [aspnet_Membership_ReportingAccess]
GO
/****** Object:  DatabaseRole [aspnet_Membership_FullAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE ROLE [aspnet_Membership_FullAccess]
GO
/****** Object:  DatabaseRole [aspnet_Membership_BasicAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE ROLE [aspnet_Membership_BasicAccess]
GO
ALTER ROLE [db_securityadmin] ADD MEMBER [alepthrdb]
GO
ALTER ROLE [db_ddladmin] ADD MEMBER [alepthrdb]
GO
ALTER ROLE [db_datareader] ADD MEMBER [alepthrdb]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [alepthrdb]
GO
ALTER ROLE [aspnet_Roles_BasicAccess] ADD MEMBER [aspnet_Roles_FullAccess]
GO
ALTER ROLE [aspnet_Roles_ReportingAccess] ADD MEMBER [aspnet_Roles_FullAccess]
GO
ALTER ROLE [aspnet_Profile_BasicAccess] ADD MEMBER [aspnet_Profile_FullAccess]
GO
ALTER ROLE [aspnet_Profile_ReportingAccess] ADD MEMBER [aspnet_Profile_FullAccess]
GO
ALTER ROLE [aspnet_Personalization_BasicAccess] ADD MEMBER [aspnet_Personalization_FullAccess]
GO
ALTER ROLE [aspnet_Personalization_ReportingAccess] ADD MEMBER [aspnet_Personalization_FullAccess]
GO
ALTER ROLE [aspnet_Membership_BasicAccess] ADD MEMBER [aspnet_Membership_FullAccess]
GO
ALTER ROLE [aspnet_Membership_ReportingAccess] ADD MEMBER [aspnet_Membership_FullAccess]
GO
/****** Object:  Schema [aspnet_Membership_BasicAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE SCHEMA [aspnet_Membership_BasicAccess]
GO
/****** Object:  Schema [aspnet_Membership_FullAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE SCHEMA [aspnet_Membership_FullAccess]
GO
/****** Object:  Schema [aspnet_Membership_ReportingAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE SCHEMA [aspnet_Membership_ReportingAccess]
GO
/****** Object:  Schema [aspnet_Personalization_BasicAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE SCHEMA [aspnet_Personalization_BasicAccess]
GO
/****** Object:  Schema [aspnet_Personalization_FullAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE SCHEMA [aspnet_Personalization_FullAccess]
GO
/****** Object:  Schema [aspnet_Personalization_ReportingAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE SCHEMA [aspnet_Personalization_ReportingAccess]
GO
/****** Object:  Schema [aspnet_Profile_BasicAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE SCHEMA [aspnet_Profile_BasicAccess]
GO
/****** Object:  Schema [aspnet_Profile_FullAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE SCHEMA [aspnet_Profile_FullAccess]
GO
/****** Object:  Schema [aspnet_Profile_ReportingAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE SCHEMA [aspnet_Profile_ReportingAccess]
GO
/****** Object:  Schema [aspnet_Roles_BasicAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE SCHEMA [aspnet_Roles_BasicAccess]
GO
/****** Object:  Schema [aspnet_Roles_FullAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE SCHEMA [aspnet_Roles_FullAccess]
GO
/****** Object:  Schema [aspnet_Roles_ReportingAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE SCHEMA [aspnet_Roles_ReportingAccess]
GO
/****** Object:  Schema [aspnet_WebEvent_FullAccess]    Script Date: 20-03-2017 16:07:38 ******/
CREATE SCHEMA [aspnet_WebEvent_FullAccess]
GO
/****** Object:  FullTextCatalog [alepthrdb]    Script Date: 20-03-2017 16:07:38 ******/
CREATE FULLTEXT CATALOG [alepthrdb]WITH ACCENT_SENSITIVITY = ON
AS DEFAULT

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 20-03-2017 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeID] [int] NOT NULL,
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
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[ActiveEmployees]    Script Date: 20-03-2017 16:07:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ActiveEmployees]
AS
SELECT        EmployeeID, FirstName, LastName, FullName, PermanentAddressLine1, PermanentAddressLine2, PermanentAddressLine3, PermanentAddressState, PermanentAddressCountry, PermanentAddressZip, 
                         AddressLine1, AddressLine2, AddressLine3, AddressState, AddressCountry, AddressZip, DateOfBirth, DateOfjoining, ProbationPeriodEndDate, HasResigned, DateOfResignation, LastWorkingDay, PAN, 
                         IDCardNumber, IDCardType, SalaryAccountNumber, SalaryAccountBank, SalaryAccountBankAddress, SalaryAccountIFSCCode
FROM            dbo.Employee
WHERE        (NOT (EmployeeID IN (5, 6))) AND (LastWorkingDay IS NULL OR
                         LastWorkingDay <= GETDATE())


GO
/****** Object:  Table [dbo].[LeaveMaster]    Script Date: 20-03-2017 16:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[LeaveTypeId] [int] NULL,
	[LeavesAdded] [numeric](18, 4) NULL,
	[LeaveValueDate] [datetime] NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[Created] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_LeaveMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeaveTaken]    Script Date: 20-03-2017 16:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveTaken](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[LeaveDate] [datetime] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[LeaveValue] [numeric](18, 4) NOT NULL,
	[IsHalfDay] [bit] NOT NULL,
	[LeaveTypeId] [int] NULL,
 CONSTRAINT [PK_LeaveData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[EmployeeLeaveBalanceView]    Script Date: 20-03-2017 16:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[EmployeeLeaveBalanceView]
AS

Select E.EmployeeId, E.FullName,(Select Sum(LeavesAdded) from LeaveMaster LM WHERE Lm.EmployeeId =  E.EmployeeID) as Leaves, Sum(LT.LeaveValue) as [LeaveTaken],
(Select Sum(LeavesAdded) from LeaveMaster LM WHERE Lm.EmployeeId =  E.EmployeeID) - Sum(LT.LeaveValue) as Balance 
 from LeaveTaken LT
LEFT OUTER JOIN EMPLOYEE E ON E.EmployeeID = LT.EmployeeId
Group By E.Employeeid, E.FullName



GO
/****** Object:  View [dbo].[EmployeeLeaveTakenView]    Script Date: 20-03-2017 16:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[EmployeeLeaveTakenView]
AS

Select E.EmployeeId, E.FullName, Sum(LT.LeaveValue) as [LeaveTaken] from LeaveTaken LT
JOIN EMPLOYEE E ON E.EmployeeID = LT.EmployeeId
Group By E.Employeeid, E.FullName


GO
/****** Object:  Table [dbo].[HolidayCalendar]    Script Date: 20-03-2017 16:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HolidayCalendar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HolidayDate] [datetime] NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedBy] [nvarchar](50) NULL,
	[Created] [datetime] NULL,
	[ModifiedBy] [nvarchar](50) NULL,
	[Modified] [datetime] NULL,
 CONSTRAINT [PK_HolidayCalendar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LeaveType]    Script Date: 20-03-2017 16:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LeaveType](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Symbol] [nvarchar](5) NULL,
 CONSTRAINT [PK_LeaveType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SettingTable]    Script Date: 20-03-2017 16:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SettingTable](
	[ID] [int] NOT NULL,
	[LeavesPerMonth] [numeric](18, 4) NOT NULL,
	[LeavesToBeCarriedForward] [numeric](18, 4) NOT NULL,
 CONSTRAINT [PK_SettingTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[LeaveMaster]  WITH CHECK ADD  CONSTRAINT [FK_LeaveMaster_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[LeaveMaster] CHECK CONSTRAINT [FK_LeaveMaster_Employee]
GO
ALTER TABLE [dbo].[LeaveMaster]  WITH CHECK ADD  CONSTRAINT [FK_LeaveMaster_LeaveType] FOREIGN KEY([LeaveTypeId])
REFERENCES [dbo].[LeaveType] ([ID])
GO
ALTER TABLE [dbo].[LeaveMaster] CHECK CONSTRAINT [FK_LeaveMaster_LeaveType]
GO
ALTER TABLE [dbo].[LeaveTaken]  WITH CHECK ADD  CONSTRAINT [FK_LeaveTaken_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[LeaveTaken] CHECK CONSTRAINT [FK_LeaveTaken_Employee]
GO
ALTER TABLE [dbo].[LeaveTaken]  WITH CHECK ADD  CONSTRAINT [FK_LeaveTaken_LeaveType] FOREIGN KEY([LeaveTypeId])
REFERENCES [dbo].[LeaveType] ([ID])
GO
ALTER TABLE [dbo].[LeaveTaken] CHECK CONSTRAINT [FK_LeaveTaken_LeaveType]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "Employee"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 271
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 30
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ActiveEmployees'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ActiveEmployees'
GO
USE [master]
GO
ALTER DATABASE [alepthrdb] SET  READ_WRITE 
GO
