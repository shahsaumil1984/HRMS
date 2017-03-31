--Create Table
CREATE Table EmployeeStatus
(
	EmployeeStatusID int identity(1,1) not null,
	StatusName varchar(50) not null

	CONSTRAINT PK_EmployeeStatus PRIMARY KEY (EmployeeStatusID)	
)

-----------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------
--Data
INSERT into EmployeeStatus
values('Active'),
('Probation'),
('Notice Period'),
('In Active')




