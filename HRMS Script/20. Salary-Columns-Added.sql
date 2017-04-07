ALTER TABLE Salary
ADD AccountNumber varchar(50) not null

ALTER TABLE Salary
ADD BankName varchar(100) not null

ALTER TABLE Salary
ADD SalaryStatus varchar(50) not null default 'Pending'

ALTER TABLE Salary
ADD CreatedBy varchar(250) NULL

ALTER TABLE Salary
ADD CreatedDate datetime NULL

ALTER TABLE Salary
ADD	ModifiedBy varchar(250) NULL

ALTER TABLE Salary
ADD	ModifiedDate datetime NULL