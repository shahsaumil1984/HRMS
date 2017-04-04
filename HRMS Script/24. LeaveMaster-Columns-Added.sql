ALTER TABLE LeaveMaster
ALTER column CreatedBy varchar(250) NULL

ALTER TABLE LeaveMaster
ADD CreatedDate datetime NULL

ALTER TABLE LeaveMaster
ALTER column ModifiedBy varchar(250) NULL

ALTER TABLE LeaveMaster
ADD	ModifiedDate datetime NULL

ALTER TABLE LeaveMaster
DROP column Created

ALTER TABLE LeaveMaster
DROP column Modified