alter table Document
add CreatedBy varchar(250),
ModifiedDate datetime,
ModifiedBy varchar(250)


alter table EmployeeDocument
alter column ModifiedDate datetime