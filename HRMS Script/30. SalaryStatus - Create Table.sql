--Create Table
CREATE Table SalaryStatus
(
	SalaryStatusID int identity(1,1) not null,
	SalaryStatusName varchar(50) not null

	CONSTRAINT PK_SalaryStatus PRIMARY KEY (SalaryStatusID)	
)

-----------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------
--Data
INSERT into SalaryStatus
values('Approved'),
('Pending')
