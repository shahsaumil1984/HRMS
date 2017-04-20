

delete from EmployeeStatusHistory

DBCC CHECKIDENT ('EmployeeStatusHistory', RESEED, 0);

update Employee set EmployeeStatusID = null

delete from EmployeeStatus

DBCC CHECKIDENT ('EmployeeStatus', RESEED, 0);


--Insert data into EmployeeStatus table 
INSERT INTO [dbo].[EmployeeStatus]
           ([Status]
           ,[Description]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy]
           ,[ModifiedDate])
     VALUES
           ('Probation'
           ,'This is Probation Period'
           ,'jay.pithadiya@alept.com'
           ,'2017-04-19'
           ,'jay.pithadiya@alept.com'
           ,'2017-04-19')

INSERT INTO [dbo].[EmployeeStatus]
           ([Status]
           ,[Description]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy]
           ,[ModifiedDate])
     VALUES
           ('Active'
           ,'This is Active'
           ,'jay.pithadiya@alept.com'
           ,'2017-04-19'
           ,'jay.pithadiya@alept.com'
           ,'2017-04-19')

INSERT INTO [dbo].[EmployeeStatus]
           ([Status]
           ,[Description]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy]
           ,[ModifiedDate])
     VALUES
           ('Notice Period'
           ,'This is Notice Period'
           ,'jay.pithadiya@alept.com'
           ,'2017-04-19'
           ,'jay.pithadiya@alept.com'
           ,'2017-04-19')
INSERT INTO [dbo].[EmployeeStatus]
           ([Status]
           ,[Description]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy]
           ,[ModifiedDate])
     VALUES
           ('Disassociated'
           ,'This is Disassociated'
           ,'jay.pithadiya@alept.com'
           ,'2017-04-19'
           ,'jay.pithadiya@alept.com'
           ,'2017-04-19')
INSERT INTO [dbo].[EmployeeStatus]
           ([Status]
           ,[Description]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy]
           ,[ModifiedDate])
     VALUES
           ('Full and Final'
           ,'This is Full and Final'
           ,'jay.pithadiya@alept.com'
           ,'2017-04-19'
           ,'jay.pithadiya@alept.com'
           ,'2017-04-19')
INSERT INTO [dbo].[EmployeeStatus]
           ([Status]
           ,[Description]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy]
           ,[ModifiedDate])
     VALUES
           ('InActive'
           ,'This is InActive'
           ,'jay.pithadiya@alept.com'
           ,'2017-04-19'
           ,'jay.pithadiya@alept.com'
           ,'2017-04-19')

-- update Employee table to set Probation to all emplyee initially
update Employee set EmployeeStatusID = 1

-- Insert data in EmployeeStatusHistory table according to user
INSERT INTO [dbo].[EmployeeStatusHistory]
           ([EmployeeID]
           ,[NewStatusID]
           ,[StartDate]
           ,[EndDate]
           ,[StatusNote]
           ,[CreatedBy]
           ,[CreatedDate]
           ,[ModifiedBy]
           ,[ModifiedDate])
     VALUES
           (3
           ,1
           ,'2016-4-12'
           ,'2016-4-13'
           ,'This is Test Status'
           ,'jay.pithadiya@alept.com'
           ,'2017-04-19'
           ,'jay.pithadiya@alept.com'
           ,'2017-04-19')
GO



