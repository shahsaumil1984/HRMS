USE [master]
GO
/****** Object:  Database [HRMS]    Script Date: 05-04-2017 12.53.36 PM ******/
CREATE DATABASE [HRMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'alepthrdb', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\alepthrdb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'alepthrdb_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\alepthrdb_log.ldf' , SIZE = 3456KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HRMS] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HRMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HRMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HRMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HRMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HRMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HRMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [HRMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HRMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HRMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HRMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HRMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HRMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HRMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HRMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HRMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HRMS] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HRMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HRMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HRMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HRMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HRMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HRMS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HRMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HRMS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HRMS] SET  MULTI_USER 
GO
ALTER DATABASE [HRMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HRMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HRMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HRMS] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [HRMS] SET DELAYED_DURABILITY = DISABLED 
GO
USE [HRMS]
GO
/****** Object:  Schema [aspnet_Membership_BasicAccess]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE SCHEMA [aspnet_Membership_BasicAccess]
GO
/****** Object:  Schema [aspnet_Membership_FullAccess]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE SCHEMA [aspnet_Membership_FullAccess]
GO
/****** Object:  Schema [aspnet_Membership_ReportingAccess]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE SCHEMA [aspnet_Membership_ReportingAccess]
GO
/****** Object:  Schema [aspnet_Personalization_BasicAccess]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE SCHEMA [aspnet_Personalization_BasicAccess]
GO
/****** Object:  Schema [aspnet_Personalization_FullAccess]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE SCHEMA [aspnet_Personalization_FullAccess]
GO
/****** Object:  Schema [aspnet_Personalization_ReportingAccess]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE SCHEMA [aspnet_Personalization_ReportingAccess]
GO
/****** Object:  Schema [aspnet_Profile_BasicAccess]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE SCHEMA [aspnet_Profile_BasicAccess]
GO
/****** Object:  Schema [aspnet_Profile_FullAccess]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE SCHEMA [aspnet_Profile_FullAccess]
GO
/****** Object:  Schema [aspnet_Profile_ReportingAccess]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE SCHEMA [aspnet_Profile_ReportingAccess]
GO
/****** Object:  Schema [aspnet_Roles_BasicAccess]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE SCHEMA [aspnet_Roles_BasicAccess]
GO
/****** Object:  Schema [aspnet_Roles_FullAccess]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE SCHEMA [aspnet_Roles_FullAccess]
GO
/****** Object:  Schema [aspnet_Roles_ReportingAccess]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE SCHEMA [aspnet_Roles_ReportingAccess]
GO
/****** Object:  Schema [aspnet_WebEvent_FullAccess]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE SCHEMA [aspnet_WebEvent_FullAccess]
GO
/****** Object:  FullTextCatalog [alepthrdb]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE FULLTEXT CATALOG [alepthrdb]WITH ACCENT_SENSITIVITY = ON
AS DEFAULT

GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC,
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](128) NOT NULL,
	[RoleId] [nvarchar](128) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](128) NOT NULL,
	[FirstName] [nvarchar](max) NULL,
	[LastName] [nvarchar](max) NULL,
	[EmployeeId] [int] NOT NULL,
	[Email] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEndDateUtc] [datetime] NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
	[UserName] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_dbo.AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Designation]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
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

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Document]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Document](
	[DocumentID] [bigint] IDENTITY(1,1) NOT NULL,
	[DocumentContent] [varbinary](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
SET ANSI_PADDING OFF
ALTER TABLE [dbo].[Document] ADD [DocumentName] [varchar](250) NULL
ALTER TABLE [dbo].[Document] ADD [CreatedBy] [varchar](250) NULL
ALTER TABLE [dbo].[Document] ADD [ModifiedDate] [datetime] NULL
ALTER TABLE [dbo].[Document] ADD [ModifiedBy] [varchar](250) NULL
ALTER TABLE [dbo].[Document] ADD [CreatedDate] [datetime] NULL
 CONSTRAINT [PK_Document] PRIMARY KEY CLUSTERED 
(
	[DocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DocumentType]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DocumentType](
	[DocumentTypeID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](100) NULL,
	[CreatedBy] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED 
(
	[DocumentTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_EmployeeCode] UNIQUE NONCLUSTERED 
(
	[EmployeeCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeDocument]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
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
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_EmployeeDocument] PRIMARY KEY CLUSTERED 
(
	[EmployeeDocumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EmployeeStatus]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EmployeeStatus](
	[EmployeeStatusID] [int] IDENTITY(1,1) NOT NULL,
	[StatusName] [varchar](50) NOT NULL,
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
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HolidayCalendar]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HolidayCalendar](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[HolidayDate] [datetime] NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedBy] [varchar](250) NULL,
	[ModifiedBy] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_HolidayCalendar] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LeaveMaster]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LeaveMaster](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NULL,
	[LeaveTypeId] [int] NULL,
	[LeavesAdded] [numeric](18, 4) NULL,
	[LeaveValueDate] [datetime] NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedBy] [varchar](250) NULL,
	[ModifiedBy] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_LeaveMaster] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LeaveTaken]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LeaveTaken](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[LeaveDate] [datetime] NOT NULL,
	[Description] [nvarchar](500) NULL,
	[LeaveValue] [numeric](18, 4) NOT NULL,
	[IsHalfDay] [bit] NOT NULL,
	[LeaveTypeId] [int] NULL,
	[CreatedBy] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_LeaveData] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LeaveType]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LeaveType](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Symbol] [nvarchar](5) NULL,
	[CreatedBy] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_LeaveType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Month]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Month](
	[MonthID] [int] IDENTITY(1,1) NOT NULL,
	[Month] [varchar](20) NOT NULL,
	[Year] [varchar](4) NOT NULL,
	[CreatedBy] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Month] PRIMARY KEY CLUSTERED 
(
	[MonthID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Salary]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Salary](
	[SalaryID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[MonthID] [int] NOT NULL,
	[Basic] [decimal](18, 4) NOT NULL,
	[HRA] [decimal](18, 4) NOT NULL,
	[ConveyanceAllowance] [decimal](18, 4) NOT NULL,
	[OtherAllowance] [decimal](18, 4) NOT NULL,
	[MedicalReimbursement] [decimal](18, 4) NOT NULL,
	[AdvanceSalary] [decimal](18, 4) NOT NULL,
	[Incentive] [decimal](18, 4) NOT NULL,
	[PLI] [decimal](18, 4) NOT NULL,
	[Exgratia] [decimal](18, 4) NOT NULL,
	[ReimbursementOfexp] [decimal](18, 4) NOT NULL,
	[TDS] [decimal](18, 4) NOT NULL,
	[EPF] [decimal](18, 4) NOT NULL,
	[ProfessionalTax] [decimal](18, 4) NOT NULL,
	[Leave] [decimal](18, 4) NOT NULL,
	[Advance] [decimal](18, 4) NOT NULL,
	[YTDS] [decimal](18, 4) NOT NULL,
	[Note] [nvarchar](500) NULL,
	[Salary] [decimal](18, 4) NOT NULL,
	[Total] [decimal](18, 4) NULL,
	[TotalPayment] [decimal](18, 4) NULL,
	[Days] [int] NOT NULL,
	[AccountNumber] [varchar](50) NOT NULL,
	[BankName] [varchar](100) NOT NULL,
	[SalaryStatus] [varchar](50) NOT NULL,
	[CreatedBy] [varchar](250) NULL,
	[ModifiedBy] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_Salary] PRIMARY KEY CLUSTERED 
(
	[SalaryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SettingTable]    Script Date: 05-04-2017 12.53.37 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SettingTable](
	[ID] [int] NOT NULL,
	[LeavesPerMonth] [numeric](18, 4) NOT NULL,
	[LeavesToBeCarriedForward] [numeric](18, 4) NOT NULL,
	[CreatedBy] [varchar](250) NULL,
	[CreatedDate] [datetime] NULL,
	[ModifiedBy] [varchar](250) NULL,
	[ModifiedDate] [datetime] NULL,
 CONSTRAINT [PK_SettingTable] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[ActiveEmployees]    Script Date: 05-04-2017 12.53.37 PM ******/
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
/****** Object:  View [dbo].[EmployeeLeaveBalanceView]    Script Date: 05-04-2017 12.53.37 PM ******/
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
/****** Object:  View [dbo].[EmployeeLeaveTakenView]    Script Date: 05-04-2017 12.53.37 PM ******/
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
SET ANSI_PADDING ON

GO
/****** Object:  Index [RoleNameIndex]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex] ON [dbo].[AspNetRoles]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserClaims]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserLogins]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_RoleId]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE NONCLUSTERED INDEX [IX_RoleId] ON [dbo].[AspNetUserRoles]
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_UserId]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[AspNetUserRoles]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [UserNameIndex]    Script Date: 05-04-2017 12.53.37 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [UserNameIndex] ON [dbo].[AspNetUsers]
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Salary] ADD  DEFAULT ('Pending') FOR [SalaryStatus]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Designation] FOREIGN KEY([DesignationID])
REFERENCES [dbo].[Designation] ([DesignationID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Designation]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_EmployeeStatus] FOREIGN KEY([EmployeeStatusID])
REFERENCES [dbo].[EmployeeStatus] ([EmployeeStatusID])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_EmployeeStatus]
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
ALTER TABLE [dbo].[Salary]  WITH CHECK ADD  CONSTRAINT [FK_Salary_Employee] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO
ALTER TABLE [dbo].[Salary] CHECK CONSTRAINT [FK_Salary_Employee]
GO
ALTER TABLE [dbo].[Salary]  WITH CHECK ADD  CONSTRAINT [FK_Salary_Month] FOREIGN KEY([MonthID])
REFERENCES [dbo].[Month] ([MonthID])
GO
ALTER TABLE [dbo].[Salary] CHECK CONSTRAINT [FK_Salary_Month]
GO
USE [master]
GO
ALTER DATABASE [HRMS] SET  READ_WRITE 
GO
