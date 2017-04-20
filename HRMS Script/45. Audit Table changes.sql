--Salary Audit Table change
ALTER TABLE [dbo].[Salary_Audit]
ADD isFullAndFinal BIT NULL DEFAULT(0)

--Employee Audit Table change
ALTER TABLE [Employee_Audit]
ADD AlternatePhone varchar(15) null

