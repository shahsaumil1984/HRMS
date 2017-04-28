USE [HRMS]
GO

/****** Object:  Table [dbo].[TaxComputation]    Script Date: 4/28/2017 6:13:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TaxComputation_Audit](
	[TaxComputationID] [int] IDENTITY(1,1) NOT NULL,
	[Basic3mAprilToJune] [int] NULL,
	[BasicFromApril] [int] NULL,
	[BasicFromJuly] [int] NULL,
	[Basic9mJulyToMarch] [int] NULL,
	[Basic12Month] [int] NULL,
	[HRA3mAprilToJune] [int] NULL,
	[HRAFromApril] [int] NULL,
	[HRAFromJuly] [int] NULL,
	[HRA9mJulyToMarch] [int] NULL,
	[HRA12Month] [int] NULL,
	[ConveyanceAllowance3mAprilToJune] [int] NULL,
	[ConveyanceAllowanceFromApril] [int] NULL,
	[ConveyanceAllowanceFromJuly] [int] NULL,
	[ConveyanceAllowance9mJulyToMarch] [int] NULL,
	[ConveyanceAllowance12Month] [int] NULL,
	[OtherAllowance3mAprilToJune] [int] NULL,
	[OtherAllowanceFromApril] [int] NULL,
	[OtherAllowanceFromJuly] [int] NULL,
	[OtherAllowance9mJulyToMarch] [int] NULL,
	[OtherAllowance12Month] [int] NULL,
	[MedicalReimbursement3mAprilToJune] [int] NULL,
	[MedicalReimbursementFromApril] [int] NULL,
	[MedicalReimbursementFromJuly] [int] NULL,
	[MedicalReimbursement9mFromJulyToMarch] [int] NULL,
	[MedicalReimbursement12Month] [int] NULL,
	[Incentive3mAprilToJune] [int] NULL,
	[IncentiveFromApril] [int] NULL,
	[IncentiveFromJuly] [int] NULL,
	[Incentive9mJulyToMarch] [int] NULL,
	[Incentive12Month] [int] NULL,
	[Total3mAprilToJune] [int] NULL,
	[TotalFromApril] [int] NULL,
	[TotalFromJuly] [int] NULL,
	[Total9mJulyToMarch] [int] NULL,
	[Total12Month] [int] NULL,
	[EPF] [int] NULL,
	[EmployeeID] [int] NOT NULL,
	[LessConveyanceAllowancesAllowed] [int] NULL,
	[LessHRA3Months] [int] NULL,
	[FourtyPercentOfBasicAprilToJune] [int] NULL,
	[ActualHRAReceivedAprilToJune] [int] NULL,
	[RentPaidAprilToJune] [int] NULL,
	[LessHRA9Months] [int] NULL,
	[LessDeduction80C] [int] NULL,
	[EmployeeContributionToPF] [int] NULL,
	[PPF] [int] NULL,
	[MutualFundOrUTI] [int] NULL,
	[InsurancePremium] [int] NULL,
	[FourtyPercentOfBasicFromJuly] [int] NULL,
	[ActualHRAReceivedFromJuly] [int] NULL,
	[RentPaidAprilFromJuly] [int] NULL,
	[LessDedution80DDeclared] [int] NULL,
	[LessMedicalReimbursementAllowanceDeclared] [int] NULL,
	[LessProfessionalTax] [int] NULL,
	[TotalTaxableIncome] [int] NULL,
	[TaxDue] [int] NULL,
	[LessAdd87A] [int] NULL,
	[TaxDueAfter87A] [int] NULL,
	[EducationCess] [int] NULL,
	[TotalTaxPayable] [int] NULL,
	[TaxTillFebuary] [int] NULL,
	[LessDedution80DAllowed] [int] NULL,
	[LessMedicalReimbursementAllowanceAllowed] [int] NULL,
	[BalanceTaxPayableAfterFebuary] [int] NULL,
	[TaxForMarch] [int] NULL,
	[Refund] [int] NULL,
	[TaxPaid] [int] NULL,
	[Year] [int] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreatedBy] [varchar](250) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [varchar](250) NULL,
 CONSTRAINT [PK_TaxComputation1] PRIMARY KEY CLUSTERED 
(
	[TaxComputationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TaxComputation]  WITH CHECK ADD  CONSTRAINT [FK_TaxComputation_Employee1] FOREIGN KEY([EmployeeID])
REFERENCES [dbo].[Employee] ([EmployeeID])
GO

ALTER TABLE [dbo].[TaxComputation] CHECK CONSTRAINT [FK_TaxComputation_Employee1]
GO


