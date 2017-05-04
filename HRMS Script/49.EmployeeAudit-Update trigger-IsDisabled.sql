


delete from Employee_Audit
GO
Alter table [dbo].[Employee_Audit] Add IsDisabled bit not null
GO

USE [HRMS]
GO

/****** Object:  Trigger [dbo].[trg_Update_Employee]    Script Date: 4/24/2017 3:12:27 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

--Employee Update Trigger change
ALTER TRIGGER [dbo].[trg_Update_Employee] On [dbo].[Employee]
AFTER Update
as
BEGIN
Insert into [dbo].[Employee_Audit]
(	
	 EmployeeID
	,FirstName
	,LastName
	,FullName
	,PermanentAddressLine1
	,PermanentAddressLine2
	,PermanentAddressLine3
	,PermanentAddressState
	,PermanentAddressCountry
	,PermanentAddressZip
	,AddressLine1
	,AddressLine2
	,AddressLine3
	,AddressState
	,AddressCountry
	,AddressZip
	,DateOfBirth
	,DateOfjoining
	,ProbationPeriodEndDate
	,HasResigned
	,DateOfResignation
	,LastWorkingDay
	,PAN
	,IDCardNumber
	,IDCardType
	,SalaryAccountNumber
	,SalaryAccountBank
	,SalaryAccountBankAddress
	,SalaryAccountIFSCCode
	,Email
	,Phone
	,UserName
	,PermanentAddressCity
	,AddressCity
	,DesignationID
	,EmployeePhoto
	,EmployeeCode
	,EmployeeStatusID
	,CreatedBy
	,CreatedDate
	,ModifiedBy
	,ModifiedDate
	,AlternatePhone,
	IsDisabled
)

SELECT 
 d.EmployeeID
,d.FirstName
,d.LastName
,d.FullName
,d.PermanentAddressLine1
,d.PermanentAddressLine2
,d.PermanentAddressLine3
,d.PermanentAddressState
,d.PermanentAddressCountry
,d.PermanentAddressZip
,d.AddressLine1
,d.AddressLine2
,d.AddressLine3
,d.AddressState
,d.AddressCountry
,d.AddressZip
,d.DateOfBirth
,d.DateOfjoining
,d.ProbationPeriodEndDate
,d.HasResigned
,d.DateOfResignation
,d.LastWorkingDay
,d.PAN
,d.IDCardNumber
,d.IDCardType
,d.SalaryAccountNumber
,d.SalaryAccountBank
,d.SalaryAccountBankAddress
,d.SalaryAccountIFSCCode
,d.Email
,d.Phone
,d.UserName
,d.PermanentAddressCity
,d.AddressCity
,d.DesignationID
,d.EmployeePhoto
,d.EmployeeCode
,d.EmployeeStatusID
,d.CreatedBy
,d.CreatedDate
,d.ModifiedBy
,d.ModifiedDate
,d.AlternatePhone
,d.IsDisabled
from inserted i
Join deleted d on i.EmployeeID = d.EmployeeID 
where 
   ISNULL(d.EmployeeID,0)						<> ISNULL(i.EmployeeID, 0) 
OR ISNULL(d.FirstName,'')						<> ISNULL(i.FirstName, '') 
OR ISNULL(d.LastName,'')						<> ISNULL(i.LastName, '') 
OR ISNULL(d.FullName,'')						<> ISNULL(i.FullName,'')			    
OR ISNULL(d.PermanentAddressLine1,'')			<> ISNULL(i.PermanentAddressLine1,'')   
OR ISNULL(d.PermanentAddressLine2,'')			<> ISNULL(i.PermanentAddressLine2,'')   
OR ISNULL(d.PermanentAddressLine3,'')			<> ISNULL(i.PermanentAddressLine3,'')   
OR ISNULL(d.PermanentAddressState,'')			<> ISNULL(i.PermanentAddressState,'')   
OR ISNULL(d.PermanentAddressCountry,'')			<> ISNULL(i.PermanentAddressCountry,'') 
OR ISNULL(d.PermanentAddressZip,'')				<> ISNULL(i.PermanentAddressZip,'')		
OR ISNULL(d.AddressLine1,'')					<> ISNULL(i.AddressLine1,'')		
OR ISNULL(d.AddressLine2,'')					<> ISNULL(i.AddressLine2,'')		
OR ISNULL(d.AddressLine3,'')					<> ISNULL(i.AddressLine3,'')		
OR ISNULL(d.AddressState,'')					<> ISNULL(i.AddressState,'')		
OR ISNULL(d.AddressCountry,'')					<> ISNULL(i.AddressCountry,'')		
OR ISNULL(d.AddressZip,'')						<> ISNULL(i.AddressZip,'')			
OR ISNULL(d.DateOfBirth,'1900-1-1')				<> ISNULL(i.DateOfBirth,'1900-1-1')					
OR ISNULL(d.DateOfjoining,'1900-1-1')			<> ISNULL(i.DateOfjoining,'1900-1-1')				
OR ISNULL(d.ProbationPeriodEndDate,'1900-1-1')	<> ISNULL(i.ProbationPeriodEndDate,'1900-1-1')		
OR ISNULL(d.HasResigned,'')						<> ISNULL(i.HasResigned,'')					
OR ISNULL(d.DateOfResignation,'1900-1-1')		<> ISNULL(i.DateOfResignation,'1900-1-1')			
OR ISNULL(d.LastWorkingDay,'1900-1-1')			<> ISNULL(i.LastWorkingDay,'1900-1-1')			
OR ISNULL(d.PAN,'')								<> ISNULL(i.PAN,'')		
OR ISNULL(d.IDCardNumber,'')					<> ISNULL(i.IDCardNumber,'')				
OR ISNULL(d.IDCardType,'')						<> ISNULL(i.IDCardType,'')					
OR ISNULL(d.SalaryAccountNumber,'')				<> ISNULL(i.SalaryAccountNumber,'')			
OR ISNULL(d.SalaryAccountBank,'')				<> ISNULL(i.SalaryAccountBank,'')			
OR ISNULL(d.SalaryAccountBankAddress,'')		<> ISNULL(i.SalaryAccountBankAddress,'')	
OR ISNULL(d.SalaryAccountIFSCCode,'')			<> ISNULL(i.SalaryAccountIFSCCode,'')	
OR ISNULL(d.Email,'')							<> ISNULL(i.Email,'')					
OR ISNULL(d.Phone,'')							<> ISNULL(i.Phone,'')					
OR ISNULL(d.UserName,'')						<> ISNULL(i.UserName,'')				
OR ISNULL(d.PermanentAddressCity,'')			<> ISNULL(i.PermanentAddressCity,'')	
OR ISNULL(d.AddressCity,'')						<> ISNULL(i.AddressCity,'')				
OR ISNULL(d.DesignationID,0)					<> ISNULL(i.DesignationID,0)			
OR ISNULL(d.EmployeePhoto,0)					<> ISNULL(i.EmployeePhoto,0)			
OR ISNULL(d.EmployeeCode,'')					<> ISNULL(i.EmployeeCode,'')			
OR ISNULL(d.EmployeeStatusID,0)					<> ISNULL(i.EmployeeStatusID,0)		
OR ISNULL(d.AlternatePhone,0)					<> ISNULL(i.AlternatePhone,0)	
OR ISNULL(d.IsDisabled,'')						<> ISNULL(i.IsDisabled,'')			
END
GO


