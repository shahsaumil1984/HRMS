ALTER TABLE Salary
DROP CONSTRAINT [DF__Salary__SalarySt__59FA5E80]

ALTER TABLE Salary
ALTER column SalaryStatus int not null

ALTER TABLE Salary
ADD CONSTRAINT FK_SalaryStatus
FOREIGN KEY (SalaryStatus) REFERENCES SalaryStatus(SalaryStatusID);