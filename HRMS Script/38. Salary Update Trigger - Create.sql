CREATE TRIGGER trg_Update_Salary On Salary
AFTER Update
as
BEGIN
Insert into [dbo].[Salary_Audit]
(	
	 EmployeeID
	,MonthID
	,[Basic]
	,HRA
	,ConveyanceAllowance
	,OtherAllowance
	,MedicalReimbursement
	,AdvanceSalary
	,Incentive
	,PLI
	,Exgratia
	,ReimbursementOfexp
	,TDS
	,EPF
	,ProfessionalTax
	,Leave
	,Advance
	,YTDS
	,Note
	,Salary
	,Total
	,TotalPayment
	,[Days]
	,AccountNumber
	,BankName
	,SalaryStatus
	,CreatedBy
	,CreatedDate
	,ModifiedBy
	,ModifiedDate
)

SELECT 
 i.EmployeeID
,i.MonthID
,i.[Basic]
,i.HRA
,i.ConveyanceAllowance
,i.OtherAllowance
,i.MedicalReimbursement
,i.AdvanceSalary
,i.Incentive
,i.PLI
,i.Exgratia
,i.ReimbursementOfexp
,i.TDS
,i.EPF
,i.ProfessionalTax
,i.Leave
,i.Advance
,i.YTDS
,i.Note
,i.Salary
,i.Total
,i.TotalPayment
,i.[Days]
,i.AccountNumber
,i.BankName
,i.SalaryStatus
,i.CreatedBy
,i.CreatedDate
,i.ModifiedBy
,i.ModifiedDate
from inserted i
Join deleted d on i.EmployeeID = d.EmployeeID
			  and i.MonthID = d.MonthID
where 
   ISNULL(d.EmployeeID,0)				<> ISNULL(i.EmployeeID,0)			
OR ISNULL(d.MonthID,0)					<> ISNULL(i.MonthID,0)				
OR ISNULL(d.[Basic],0)					<> ISNULL(i.[Basic],0)				
OR ISNULL(d.HRA,0)						<> ISNULL(i.HRA,0)					
OR ISNULL(d.ConveyanceAllowance,0)		<> ISNULL(i.ConveyanceAllowance,0)	
OR ISNULL(d.OtherAllowance,0)			<> ISNULL(i.OtherAllowance,0)		
OR ISNULL(d.MedicalReimbursement,0)		<> ISNULL(i.MedicalReimbursement,0)	
OR ISNULL(d.AdvanceSalary,0)			<> ISNULL(i.AdvanceSalary,0)		
OR ISNULL(d.Incentive,0)				<> ISNULL(i.Incentive,0)			
OR ISNULL(d.PLI,0)						<> ISNULL(i.PLI,0)					
OR ISNULL(d.Exgratia,0)					<> ISNULL(i.Exgratia,0)				
OR ISNULL(d.ReimbursementOfexp,0)		<> ISNULL(i.ReimbursementOfexp,0)	
OR ISNULL(d.TDS,0)						<> ISNULL(i.TDS,0)					
OR ISNULL(d.EPF,0)						<> ISNULL(i.EPF,0)					
OR ISNULL(d.ProfessionalTax,0)			<> ISNULL(i.ProfessionalTax,0)		
OR ISNULL(d.Leave,0)					<> ISNULL(i.Leave,0)				
OR ISNULL(d.Advance,0)					<> ISNULL(i.Advance,0)					
OR ISNULL(d.YTDS,0)						<> ISNULL(i.YTDS,0)						
OR ISNULL(d.Note,'')					<> ISNULL(i.Note,'')					
OR ISNULL(d.Salary,0)					<> ISNULL(i.Salary,0)				
OR ISNULL(d.Total,0)					<> ISNULL(i.Total,0)					
OR ISNULL(d.TotalPayment,0)				<> ISNULL(i.TotalPayment,0)			
OR ISNULL(d.[Days],0)					<> ISNULL(i.[Days],0)				
OR ISNULL(d.AccountNumber,0)			<> ISNULL(i.AccountNumber,0)		
OR ISNULL(d.BankName,'')				<> ISNULL(i.BankName,'')			
OR ISNULL(d.SalaryStatus,0)				<> ISNULL(i.SalaryStatus,0)	
END