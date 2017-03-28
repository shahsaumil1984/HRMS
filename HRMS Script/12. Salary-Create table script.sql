Create Table Salary
(
	SalaryID int identity(1,1) not null,
	EmployeeID int not null,
	MonthID int not null,
	[Basic] decimal(18,4) not null,
	HRA decimal(18,4) not null,
	ConveyanceAllowance decimal(18,4) not null,
	OtherAllowance decimal(18,4) not null,
	MedicalReimbursement decimal(18,4) not null,
	AdvanceSalary decimal(18,4) not null,
	Incentive decimal(18,4) not null,
	PLI decimal(18,4) not null,
	Exgratia decimal(18,4) not null,
	ReimbursementOfexp decimal(18,4) not null,

	TDS decimal(18,4) not null,
	EPF decimal(18,4) not null,
	ProfessionalTax decimal(18,4) not null,
	Leave decimal(18,4) not null,
	Advance decimal(18,4) not null,
	YTDS decimal(18,4) not null,
	
	CONSTRAINT PK_Salary PRIMARY KEY (SalaryID),
	CONSTRAINT FK_Salary_Employee FOREIGN KEY (EmployeeID)
    REFERENCES Employee(EmployeeID),
	CONSTRAINT FK_Salary_Month FOREIGN KEY (MonthID)
    REFERENCES [Month](MonthID)	
)




