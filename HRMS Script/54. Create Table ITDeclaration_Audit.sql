USE [HRMS]
GO

/****** Object:  Table [dbo].[ItDeclarationForm_Audit]    Script Date: 5/1/2017 10:44:42 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ItDeclarationForm_Audit](
	[ItDeclarationID] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeID] [int] NOT NULL,
	[ItDeclarationYear] [nvarchar](50) NOT NULL,
	[Date] [datetime] NULL,
	[PanNo] [varchar](10) NULL,
	[AddressLine1] [nvarchar](500) NULL,
	[AddressLine2] [nvarchar](500) NULL,
	[AddressLine3] [nvarchar](500) NULL,
	[AddressState] [varchar](100) NOT NULL,
	[AddressCountry] [varchar](100) NULL,
	[AddressZip] [varchar](6) NULL,
	[PurchaseOfNSC] [int] NULL,
	[InsurancePremium] [int] NULL,
	[PPF] [int] NULL,
	[HousingLoan] [int] NULL,
	[ChildrenTutionFee] [nchar](10) NULL,
	[MutualfundOrUti] [int] NULL,
	[BondsOfNabard] [int] NULL,
	[InterestOnNSC] [int] NULL,
	[FDR] [int] NULL,
	[ULIPofUTI] [int] NULL,
	[PF] [int] NULL,
	[MediclaimPremium] [int] NULL,
	[HomeLoan] [int] NULL,
	[HLAddressLine1] [nvarchar](100) NULL,
	[HLAddressLine2] [nvarchar](100) NULL,
	[HLAddressLine3] [nvarchar](100) NULL,
	[HLAddressState] [nvarchar](100) NULL,
	[HLAddressCountry] [nvarchar](100) NULL,
	[HLAddressZip] [nvarchar](100) NULL,
	[HomeRent] [int] NULL,
	[HRAddressLine11] [nvarchar](100) NULL,
	[HRAddressLine21] [nvarchar](100) NULL,
	[HRAddressLine31] [nvarchar](100) NULL,
	[HRAddressState1] [nvarchar](100) NULL,
	[HRAddressCountry1] [nvarchar](100) NULL,
	[HRAddressZip1] [nvarchar](100) NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](100) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](100) NULL,
 CONSTRAINT [PK_ItDeclarationForm1] PRIMARY KEY CLUSTERED 
(
	[ItDeclarationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


