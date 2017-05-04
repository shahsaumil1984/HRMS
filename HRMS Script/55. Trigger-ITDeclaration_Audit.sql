USE [HRMS]
GO

/****** Object:  Trigger [dbo].[trg_Update_ItDeclarationForm]    Script Date: 5/1/2017 10:45:34 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[trg_Update_ItDeclarationForm] On [dbo].[ItDeclarationForm]
AFTER Update
as
BEGIN
Insert into ItDeclarationForm_Audit
(	
			[EmployeeID]
           ,[ItDeclarationYear]
           ,[Date]
           ,[PanNo]
           ,[AddressLine1]
           ,[AddressLine2]
           ,[AddressLine3]
           ,[AddressState]
           ,[AddressCountry]
           ,[AddressZip]
           ,[PurchaseOfNSC]
           ,[InsurancePremium]
           ,[PPF]
           ,[HousingLoan]
           ,[ChildrenTutionFee]
           ,[MutualfundOrUti]
           ,[BondsOfNabard]
           ,[InterestOnNSC]
           ,[FDR]
           ,[ULIPofUTI]
           ,[PF]
           ,[MediclaimPremium]
           ,[HomeLoan]
           ,[HLAddressLine1]
           ,[HLAddressLine2]
           ,[HLAddressLine3]
           ,[HLAddressState]
           ,[HLAddressCountry]
           ,[HLAddressZip]
           ,[HomeRent]
           ,[HRAddressLine11]
           ,[HRAddressLine21]
           ,[HRAddressLine31]
           ,[HRAddressState1]
           ,[HRAddressCountry1]
           ,[HRAddressZip1]
           ,[CreatedDate]
           ,[CreatedBy]
           ,[ModifiedDate]
           ,[ModifiedBy]
)

SELECT 
			d.[EmployeeID]
           ,d.[ItDeclarationYear]
           ,d.[Date]
           ,d.[PanNo]
           ,d.[AddressLine1]
           ,d.[AddressLine2]
           ,d.[AddressLine3]
           ,d.[AddressState]
           ,d.[AddressCountry]
           ,d.[AddressZip]
           ,d.[PurchaseOfNSC]
           ,d.[InsurancePremium]
           ,d.[PPF]
           ,d.[HousingLoan]
           ,d.[ChildrenTutionFee]
           ,d.[MutualfundOrUti]
           ,d.[BondsOfNabard]
           ,d.[InterestOnNSC]
           ,d.[FDR]
           ,d.[ULIPofUTI]
           ,d.[PF]
           ,d.[MediclaimPremium]
           ,d.[HomeLoan]
           ,d.[HLAddressLine1]
           ,d.[HLAddressLine2]
           ,d.[HLAddressLine3]
           ,d.[HLAddressState]
           ,d.[HLAddressCountry]
           ,d.[HLAddressZip]
           ,d.[HomeRent]
           ,d.[HRAddressLine11]
           ,d.[HRAddressLine21]
           ,d.[HRAddressLine31]
           ,d.[HRAddressState1]
           ,d.[HRAddressCountry1]
           ,d.[HRAddressZip1]
           ,d.[CreatedDate]
           ,d.[CreatedBy]
           ,d.[ModifiedDate]
           ,d.[ModifiedBy]
from inserted i
Join deleted d on i.ItDeclarationID = d.ItDeclarationID
where 
   ISNULL(d.EmployeeID,0)				<> ISNULL(i.EmployeeID,0)			
OR ISNULL(d.ItDeclarationYear,0)					<> ISNULL(i.ItDeclarationYear,0)				
OR ISNULL(d.Date,0)					<> ISNULL(i.Date,0)				
OR ISNULL(d.PanNo,0)						<> ISNULL(i.PanNo,0)					
OR ISNULL(d.AddressLine1,'')		<> ISNULL(i.AddressLine1,'')	
OR ISNULL(d.AddressLine2,'')			<> ISNULL(i.AddressLine2,'')		
OR ISNULL(d.AddressLine3,'')		<> ISNULL(i.AddressLine3,'')	
OR ISNULL(d.AddressState,0)			<> ISNULL(i.AddressState,0)		
OR ISNULL(d.AddressCountry,'')				<> ISNULL(i.AddressCountry,'')			
OR ISNULL(d.AddressZip,'')						<> ISNULL(i.AddressZip,'')					
OR ISNULL(d.PurchaseOfNSC,0)					<> ISNULL(i.PurchaseOfNSC,0)				
OR ISNULL(d.InsurancePremium,0)		<> ISNULL(i.InsurancePremium,0)	
OR ISNULL(d.PPF,0)						<> ISNULL(i.PPF,0)					
OR ISNULL(d.HousingLoan,0)						<> ISNULL(i.HousingLoan,0)					
OR ISNULL(d.ChildrenTutionFee,0)			<> ISNULL(i.ChildrenTutionFee,0)		
OR ISNULL(d.MutualfundOrUti,0)					<> ISNULL(i.MutualfundOrUti,0)				
OR ISNULL(d.BondsOfNabard,0)					<> ISNULL(i.BondsOfNabard,0)					
OR ISNULL(d.InterestOnNSC,0)						<> ISNULL(i.InterestOnNSC,0)						
OR ISNULL(d.FDR,0)					<> ISNULL(i.FDR,0)					
OR ISNULL(d.ULIPofUTI,0)					<> ISNULL(i.ULIPofUTI,0)				
OR ISNULL(d.PF,0)					<> ISNULL(i.PF,0)					
OR ISNULL(d.MediclaimPremium,0)				<> ISNULL(i.MediclaimPremium,0)			
OR ISNULL(d.HomeLoan,0)					<> ISNULL(i.HomeLoan,0)				
OR ISNULL(d.HLAddressLine1,'')			<> ISNULL(i.HLAddressLine1,'')		
OR ISNULL(d.HLAddressLine2,'')				<> ISNULL(i.HLAddressLine2,'')			
OR ISNULL(d.HLAddressLine3,'')				<> ISNULL(i.HLAddressLine3,'')	
OR ISNULL(d.HLAddressState,0)				<> ISNULL(i.HLAddressState,0)	
OR ISNULL(d.HLAddressCountry,'')				<> ISNULL(i.HLAddressCountry,'')	
OR ISNULL(d.HLAddressZip,'')				<> ISNULL(i.HLAddressZip,'')	
OR ISNULL(d.HomeRent,0)				<> ISNULL(i.HomeRent,0)	

OR ISNULL(d.HRAddressLine11,'')				<> ISNULL(i.HRAddressLine11,'')	
OR ISNULL(d.HRAddressLine21,'')				<> ISNULL(i.HRAddressLine21,'')	
OR ISNULL(d.HRAddressLine31,'')				<> ISNULL(i.HRAddressLine31,'')	
OR ISNULL(d.HRAddressState1,'')				<> ISNULL(i.HRAddressState1,'')	
OR ISNULL(d.HRAddressCountry1,'')				<> ISNULL(i.HRAddressCountry1,'')	
OR ISNULL(d.HRAddressZip1,'')				<> ISNULL(i.HRAddressZip1,'')	
OR ISNULL(d.CreatedDate,'')				<> ISNULL(i.CreatedDate,'')	
OR ISNULL(d.CreatedBy,'')				<> ISNULL(i.CreatedBy,'')	
OR ISNULL(d.ModifiedDate,'')				<> ISNULL(i.ModifiedDate,'')	
OR ISNULL(d.ModifiedBy,'')				<> ISNULL(i.ModifiedBy,'')	
END

GO


