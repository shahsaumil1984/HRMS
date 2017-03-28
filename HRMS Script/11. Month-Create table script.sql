Create Table [Month]
(
	MonthID int identity(1,1) not null,
	[Month] varchar(20) not null,
	[Year] varchar(4) not null,

	CONSTRAINT PK_Month PRIMARY KEY (MonthID)
)




