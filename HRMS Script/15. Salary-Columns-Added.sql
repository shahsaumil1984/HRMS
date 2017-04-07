ALTER TABLE Salary
ADD Note nvarchar(500) null

ALTER TABLE Salary
ADD Salary decimal(18,4) not null

ALTER TABLE Salary
ADD Total decimal(18,4) null

ALTER TABLE Salary
ADD TotalPayment decimal(18,4) null

ALTER TABLE Salary
ADD [Days] int not null