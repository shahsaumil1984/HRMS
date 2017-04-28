USE [HRMS]
GO

/****** Object:  Trigger [dbo].[trg_Update_Salary]    Script Date: 4/28/2017 6:16:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[trg_TaxComputation_Salary] On [dbo].[TaxComputation]
AFTER Update
as
BEGIN
Insert into [dbo].[TaxComputation_Audit]
(	
			[Basic3mAprilToJune]
           ,[BasicFromApril]
           ,[BasicFromJuly]
           ,[Basic9mJulyToMarch]
           ,[Basic12Month]
           ,[HRA3mAprilToJune]
           ,[HRAFromApril]
           ,[HRAFromJuly]
           ,[HRA9mJulyToMarch]
           ,[HRA12Month]
           ,[ConveyanceAllowance3mAprilToJune]
           ,[ConveyanceAllowanceFromApril]
           ,[ConveyanceAllowanceFromJuly]
           ,[ConveyanceAllowance9mJulyToMarch]
           ,[ConveyanceAllowance12Month]
           ,[OtherAllowance3mAprilToJune]
           ,[OtherAllowanceFromApril]
           ,[OtherAllowanceFromJuly]
           ,[OtherAllowance9mJulyToMarch]
           ,[OtherAllowance12Month]
           ,[MedicalReimbursement3mAprilToJune]
           ,[MedicalReimbursementFromApril]
           ,[MedicalReimbursementFromJuly]
           ,[MedicalReimbursement9mFromJulyToMarch]
           ,[MedicalReimbursement12Month]
           ,[Incentive3mAprilToJune]
           ,[IncentiveFromApril]
           ,[IncentiveFromJuly]
           ,[Incentive9mJulyToMarch]
           ,[Incentive12Month]
           ,[Total3mAprilToJune]
           ,[TotalFromApril]
           ,[TotalFromJuly]
           ,[Total9mJulyToMarch]
           ,[Total12Month]
           ,[EPF]
           ,[EmployeeID]
           ,[LessConveyanceAllowancesAllowed]
           ,[LessHRA3Months]
           ,[FourtyPercentOfBasicAprilToJune]
           ,[ActualHRAReceivedAprilToJune]
           ,[RentPaidAprilToJune]
           ,[LessHRA9Months]
           ,[LessDeduction80C]
           ,[EmployeeContributionToPF]
           ,[PPF]
           ,[MutualFundOrUTI]
           ,[InsurancePremium]
           ,[FourtyPercentOfBasicFromJuly]
           ,[ActualHRAReceivedFromJuly]
           ,[RentPaidAprilFromJuly]
           ,[LessDedution80DDeclared]
           ,[LessMedicalReimbursementAllowanceDeclared]
           ,[LessProfessionalTax]
           ,[TotalTaxableIncome]
           ,[TaxDue]
           ,[LessAdd87A]
           ,[TaxDueAfter87A]
           ,[EducationCess]
           ,[TotalTaxPayable]
           ,[TaxTillFebuary]
           ,[LessDedution80DAllowed]
           ,[LessMedicalReimbursementAllowanceAllowed]
           ,[BalanceTaxPayableAfterFebuary]
           ,[TaxForMarch]
           ,[Refund]
           ,[TaxPaid]
           ,[Year]
           ,[CreatedDate]
           ,[CreatedBy]
           ,[ModifiedDate]
           ,[ModifiedBy]
)

SELECT 
			d.[Basic3mAprilToJune]
           ,d.[BasicFromApril]
           ,d.[BasicFromJuly]
           ,d.[Basic9mJulyToMarch]
           ,d.[Basic12Month]
           ,d.[HRA3mAprilToJune]
           ,d.[HRAFromApril]
           ,d.[HRAFromJuly]
           ,d.[HRA9mJulyToMarch]
           ,d.[HRA12Month]
           ,d.[ConveyanceAllowance3mAprilToJune]
           ,d.[ConveyanceAllowanceFromApril]
           ,d.[ConveyanceAllowanceFromJuly]
           ,d.[ConveyanceAllowance9mJulyToMarch]
           ,d.[ConveyanceAllowance12Month]
           ,d.[OtherAllowance3mAprilToJune]
           ,d.[OtherAllowanceFromApril]
           ,d.[OtherAllowanceFromJuly]
           ,d.[OtherAllowance9mJulyToMarch]
           ,d.[OtherAllowance12Month]
           ,d.[MedicalReimbursement3mAprilToJune]
           ,d.[MedicalReimbursementFromApril]
           ,d.[MedicalReimbursementFromJuly]
           ,d.[MedicalReimbursement9mFromJulyToMarch]
           ,d.[MedicalReimbursement12Month]
           ,d.[Incentive3mAprilToJune]
           ,d.[IncentiveFromApril]
           ,d.[IncentiveFromJuly]
           ,d.[Incentive9mJulyToMarch]
           ,d.[Incentive12Month]
           ,d.[Total3mAprilToJune]
           ,d.[TotalFromApril]
           ,d.[TotalFromJuly]
           ,d.[Total9mJulyToMarch]
           ,d.[Total12Month]
           ,d.[EPF]
           ,d.[EmployeeID]
           ,d.[LessConveyanceAllowancesAllowed]
           ,d.[LessHRA3Months]
           ,d.[FourtyPercentOfBasicAprilToJune]
           ,d.[ActualHRAReceivedAprilToJune]
           ,d.[RentPaidAprilToJune]
           ,d.[LessHRA9Months]
           ,d.[LessDeduction80C]
           ,d.[EmployeeContributionToPF]
           ,d.[PPF]
           ,d.[MutualFundOrUTI]
           ,d.[InsurancePremium]
           ,d.[FourtyPercentOfBasicFromJuly]
           ,d.[ActualHRAReceivedFromJuly]
           ,d.[RentPaidAprilFromJuly]
           ,d.[LessDedution80DDeclared]
           ,d.[LessMedicalReimbursementAllowanceDeclared]
           ,d.[LessProfessionalTax]
           ,d.[TotalTaxableIncome]
           ,d.[TaxDue]
           ,d.[LessAdd87A]
           ,d.[TaxDueAfter87A]
           ,d.[EducationCess]
           ,d.[TotalTaxPayable]
           ,d.[TaxTillFebuary]
           ,d.[LessDedution80DAllowed]
           ,d.[LessMedicalReimbursementAllowanceAllowed]
           ,d.[BalanceTaxPayableAfterFebuary]
           ,d.[TaxForMarch]
           ,d.[Refund]
           ,d.[TaxPaid]
           ,d.[Year]
           ,d.[CreatedDate]
           ,d.[CreatedBy]
           ,d.[ModifiedDate]
           ,d.[ModifiedBy]
from inserted i
Join deleted d on i.TaxComputationID = d.TaxComputationID			  
where 
   ISNULL(d.[Basic3mAprilToJune],0)		<> ISNULL(i.[Basic3mAprilToJune],0)			
OR ISNULL(d.[BasicFromApril],0)			<> ISNULL(i.[BasicFromApril],0)				
OR ISNULL(d.[BasicFromJuly],0)			<> ISNULL(i.[BasicFromJuly],0)				
OR ISNULL(d.[Basic9mJulyToMarch],0)		<> ISNULL(i.[Basic9mJulyToMarch],0)					
OR ISNULL(d.[Basic12Month],0)			<> ISNULL(i.[Basic12Month],0)	
OR ISNULL(d.[HRA3mAprilToJune],0)		<> ISNULL(i.[HRA3mAprilToJune],0)		
OR ISNULL(d.[HRAFromApril],0)		<> ISNULL(i.[HRAFromApril],0)	
OR ISNULL(d.[HRAFromJuly],0)			<> ISNULL(i.[HRAFromJuly],0)		
OR ISNULL(d.[HRA9mJulyToMarch],0)				<> ISNULL(i.[HRA9mJulyToMarch],0)			
OR ISNULL(d.[HRA12Month],0)						<> ISNULL(i.[HRA12Month],0)					
OR ISNULL(d.[ConveyanceAllowance3mAprilToJune],0)					<> ISNULL(i.[ConveyanceAllowance3mAprilToJune],0)				
OR ISNULL(d.[ConveyanceAllowanceFromApril],0)		<> ISNULL(i.[ConveyanceAllowanceFromApril],0)	
OR ISNULL(d.[ConveyanceAllowanceFromJuly],0)						<> ISNULL(i.[ConveyanceAllowanceFromJuly],0)					
OR ISNULL(d.[ConveyanceAllowance9mJulyToMarch],0)						<> ISNULL(i.EPF,0)					
OR ISNULL(d.[ConveyanceAllowance12Month],0)			<> ISNULL(i.[ConveyanceAllowance12Month],0)		
OR ISNULL(d.[OtherAllowance3mAprilToJune],0)					<> ISNULL(i.[OtherAllowance3mAprilToJune],0)				
OR ISNULL(d.[OtherAllowanceFromApril],0)					<> ISNULL(i.[OtherAllowanceFromApril],0)					
OR ISNULL(d.[OtherAllowanceFromJuly],0)						<> ISNULL(i.[OtherAllowanceFromJuly],0)						
OR ISNULL(d.[OtherAllowance9mJulyToMarch],'')					<> ISNULL(i.[OtherAllowance9mJulyToMarch],'')					
OR ISNULL(d.[OtherAllowance12Month],0)					<> ISNULL(i.[OtherAllowance12Month],0)				
OR ISNULL(d.[MedicalReimbursement3mAprilToJune],0)					<> ISNULL(i.[MedicalReimbursement3mAprilToJune],0)					
OR ISNULL(d.[MedicalReimbursementFromApril],0)				<> ISNULL(i.[MedicalReimbursementFromApril],0)			
OR ISNULL(d.[MedicalReimbursementFromJuly],0)					<> ISNULL(i.[MedicalReimbursementFromJuly],0)				
OR ISNULL(d.[MedicalReimbursement9mFromJulyToMarch],0)			<> ISNULL(i.[MedicalReimbursement9mFromJulyToMarch],0)		
OR ISNULL(d.[MedicalReimbursement12Month],'')				<> ISNULL(i.[MedicalReimbursement12Month],'')			
OR ISNULL(d.[Incentive3mAprilToJune],0)				<> ISNULL(i.[Incentive3mAprilToJune],0)	
OR ISNULL(d.[IncentiveFromApril],0)				<> ISNULL(i.[IncentiveFromApril],0)	
OR ISNULL(d.[IncentiveFromJuly],0)				<> ISNULL(i.[IncentiveFromJuly],0)	
OR ISNULL(d.[Incentive9mJulyToMarch],0)				<> ISNULL(i.[Incentive9mJulyToMarch],0)	
OR ISNULL(d.[Incentive12Month],0)				<> ISNULL(i.[Incentive12Month],0)	
OR ISNULL(d.[Total3mAprilToJune],0)				<> ISNULL(i.[Total3mAprilToJune],0)	
OR ISNULL(d.[TotalFromApril],0)				<> ISNULL(i.[TotalFromApril],0)	
OR ISNULL(d.[TotalFromJuly],0)				<> ISNULL(i.[TotalFromJuly],0)	

OR ISNULL(d.[Total9mJulyToMarch],0)				<> ISNULL(i.[Total9mJulyToMarch],0)	
OR ISNULL(d.[Total12Month],0)				<> ISNULL(i.[Total12Month],0)	
OR ISNULL(d.[EPF],0)				<> ISNULL(i.[EPF],0)	
OR ISNULL(d.[EmployeeID],0)				<> ISNULL(i.[EmployeeID],0)	
OR ISNULL(d.[LessConveyanceAllowancesAllowed],0)				<> ISNULL(i.[LessConveyanceAllowancesAllowed],0)	
OR ISNULL(d.[LessHRA3Months],0)				<> ISNULL(i.[LessHRA3Months],0)	
OR ISNULL(d.[FourtyPercentOfBasicAprilToJune],0)				<> ISNULL(i.[FourtyPercentOfBasicAprilToJune],0)	
OR ISNULL(d.[ActualHRAReceivedAprilToJune],0)				<> ISNULL(i.[ActualHRAReceivedAprilToJune],0)	
OR ISNULL(d.[RentPaidAprilToJune],0)				<> ISNULL(i.[RentPaidAprilToJune],0)	
OR ISNULL(d.[LessHRA9Months],0)				<> ISNULL(i.[LessHRA9Months],0)	
OR ISNULL(d.[LessDeduction80C],0)				<> ISNULL(i.[LessDeduction80C],0)	
OR ISNULL(d.[EmployeeContributionToPF],0)				<> ISNULL(i.[EmployeeContributionToPF],0)	
OR ISNULL(d.[PPF],0)				<> ISNULL(i.[PPF],0)	
OR ISNULL(d.[MutualFundOrUTI],0)				<> ISNULL(i.[MutualFundOrUTI],0)	
OR ISNULL(d.[InsurancePremium],0)				<> ISNULL(i.[InsurancePremium],0)	
OR ISNULL(d.[FourtyPercentOfBasicFromJuly],0)				<> ISNULL(i.[FourtyPercentOfBasicFromJuly],0)	
OR ISNULL(d.[ActualHRAReceivedFromJuly],0)				<> ISNULL(i.[ActualHRAReceivedFromJuly],0)	
OR ISNULL(d.[RentPaidAprilFromJuly],0)				<> ISNULL(i.[RentPaidAprilFromJuly],0)	
OR ISNULL(d.[LessDedution80DDeclared],0)				<> ISNULL(i.[LessDedution80DDeclared],0)	
OR ISNULL(d.[LessMedicalReimbursementAllowanceDeclared],0)				<> ISNULL(i.[LessMedicalReimbursementAllowanceDeclared],0)	
OR ISNULL(d.[LessProfessionalTax],0)				<> ISNULL(i.[LessProfessionalTax],0)	
OR ISNULL(d.[TotalTaxableIncome],0)				<> ISNULL(i.[TotalTaxableIncome],0)	
OR ISNULL(d.[TaxDue],0)				<> ISNULL(i.[TaxDue],0)	
OR ISNULL(d.[LessAdd87A],0)				<> ISNULL(i.[LessAdd87A],0)	
OR ISNULL(d.[TaxDueAfter87A],0)				<> ISNULL(i.[TaxDueAfter87A],0)	
OR ISNULL(d.[EducationCess],0)				<> ISNULL(i.[EducationCess],0)	
OR ISNULL(d.[TotalTaxPayable],0)				<> ISNULL(i.[TotalTaxPayable],0)	
OR ISNULL(d.[TaxTillFebuary],0)				<> ISNULL(i.[TaxTillFebuary],0)	
OR ISNULL(d.[LessDedution80DAllowed],0)				<> ISNULL(i.[LessDedution80DAllowed],0)	
OR ISNULL(d.[LessMedicalReimbursementAllowanceAllowed],0)				<> ISNULL(i.[LessMedicalReimbursementAllowanceAllowed],0)	
OR ISNULL(d.[BalanceTaxPayableAfterFebuary],0)				<> ISNULL(i.[BalanceTaxPayableAfterFebuary],0)	
OR ISNULL(d.[TaxForMarch],0)				<> ISNULL(i.[TaxForMarch],0)	
OR ISNULL(d.[Refund],0)				<> ISNULL(i.[Refund],0)	
OR ISNULL(d.[TaxPaid],0)				<> ISNULL(i.[TaxPaid],0)	
OR ISNULL(d.[Year],0)				<> ISNULL(i.[Year],0)	
OR ISNULL(d.[CreatedDate],0)				<> ISNULL(i.[CreatedDate],0)	
OR ISNULL(d.[CreatedBy],0)				<> ISNULL(i.[CreatedBy],0)	
OR ISNULL(d.[ModifiedDate],0)				<> ISNULL(i.[ModifiedDate],0)	
OR ISNULL(d.[ModifiedBy],0)				<> ISNULL(i.[ModifiedBy],0)	
END
GO


