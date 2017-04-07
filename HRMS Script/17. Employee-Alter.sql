DELETE FROM employeedocument
DELETE FROM employee

ALTER TABLE Employee
DROP COLUMN EmployeeStatus;

ALTER TABLE Employee
ADD EmployeeStatusID int not null

ALTER TABLE Employee
ADD CONSTRAINT FK_Employee_EmployeeStatus FOREIGN KEY (EmployeeStatusID) REFERENCES EmployeeStatus(EmployeeStatusID);




	



