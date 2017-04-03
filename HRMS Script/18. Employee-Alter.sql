ALTER TABLE Employee
ADD CONSTRAINT UK_EmployeeCode UNIQUE(EmployeeCode)

ALTER TABLE Employee
ALTER column EmployeeStatusID int null