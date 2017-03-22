ALTER TABLE Employee
ADD Email Varchar(250)

ALTER TABLE Employee
ADD Phone Varchar(15)

ALTER TABLE Employee
ADD UserName Varchar(250)

ALTER TABLE Employee
ADD UserName Varchar(250)


ALTER TABLE Employee ADD [LogoID] INT  NULL,
CONSTRAINT [FK_Employee_Documents] FOREIGN KEY ([DocumentID]) REFERENCES [Documents];
