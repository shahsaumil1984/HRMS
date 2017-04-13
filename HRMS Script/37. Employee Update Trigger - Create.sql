CREATE TRIGGER trg_Update_Employee On Employee
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
)

SELECT 
 i.EmployeeID
,i.FirstName
,i.LastName
,i.FullName
,i.PermanentAddressLine1
,i.PermanentAddressLine2
,i.PermanentAddressLine3
,i.PermanentAddressState
,i.PermanentAddressCountry
,i.PermanentAddressZip
,i.AddressLine1
,i.AddressLine2
,i.AddressLine3
,i.AddressState
,i.AddressCountry
,i.AddressZip
,i.DateOfBirth
,i.DateOfjoining
,i.ProbationPeriodEndDate
,i.HasResigned
,i.DateOfResignation
,i.LastWorkingDay
,i.PAN
,i.IDCardNumber
,i.IDCardType
,i.SalaryAccountNumber
,i.SalaryAccountBank
,i.SalaryAccountBankAddress
,i.SalaryAccountIFSCCode
,i.Email
,i.Phone
,i.UserName
,i.PermanentAddressCity
,i.AddressCity
,i.DesignationID
,i.EmployeePhoto
,i.EmployeeCode
,i.EmployeeStatusID
,i.CreatedBy
,i.CreatedDate
,i.ModifiedBy
,i.ModifiedDate
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
END