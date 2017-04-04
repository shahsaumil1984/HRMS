ALTER TABLE HolidayCalendar
ALTER column CreatedBy varchar(250) NULL

ALTER TABLE HolidayCalendar
ADD CreatedDate datetime NULL

ALTER TABLE HolidayCalendar
ALTER column ModifiedBy varchar(250) NULL

ALTER TABLE HolidayCalendar
ADD	ModifiedDate datetime NULL

ALTER TABLE HolidayCalendar
DROP column Created

ALTER TABLE HolidayCalendar
DROP column Modified