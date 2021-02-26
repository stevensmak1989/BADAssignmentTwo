CREATE DATABASE fujitsuPayments    
GO

--Creates the Grade table
CREATE TABLE Grade 
(
	Grade			varchar(5)		NOT NULL,
	GradeDesc		varchar(15)		NOT NULL,
	StartSal		DECIMAL(10,2)	Not NULL,
	EndSal			DECIMAL(10,2)	Not NULL
	--PK
	CONSTRAINT pkGrade PRIMARY KEY (Grade),
	CONSTRAINT unqMethodDesc UNIQUE (GradeDesc),
	CONSTRAINT ckStartSal CHECK (StartSal > 0),
	CONSTRAINT ckEndSal CHECK (EndSal > 0)
)

--employee
CREATE TABLE Employee
(
	EmployeeID 		int					NOT NULL,
	Title			varchar(4)			NOT NULL,
	Surname			varchar(20)			NOT NULL,
	Forename		varchar(20)			NOT NULL,
	Street			varchar(30)			NOT NULL,
	Town			varchar(30)			NOT NULL,
	County			varchar(30)			NOT NULL,
	PostCode		varchar(8)			NOT NULL,
	TelNo			varchar(11)			NOT NULL,
	DOB				date				NOT NULL,
	ManagerID		int					NOT NULL,
	Grade			varchar(5)			NOT NULL,
	Salary			DECIMAL(10,2)		Not NULL,

	--PK
	CONSTRAINT pkEmpID PRIMARY KEY (EmployeeID),
	--FK
	CONSTRAINT fkGrade	FOREIGN KEY (Grade) REFERENCES Grade (Grade),

	CONSTRAINT ckTitle CHECK (Title IN ('Mr','Mrs','Miss','Ms')),
	CONSTRAINT ckPostcode CHECK (Postcode LIKE '[A-Z][A-Z][0-9][0-9] [0-9][A-Z][A-Z]'),
	CONSTRAINT ckTelNo CHECK (TelNo LIKE REPLICATE('[0-9]', 11)),
	

)


CREATE TABLE Account
(
	AccountID 		int					NOT NULL,
	ClientName		varchar(30)			NOT NULL,
	Street			varchar(30)			NOT NULL,
	Town			varchar(30)			NOT NULL,
	County			varchar(30)			NOT NULL,
	PostCode		varchar(8)			NOT NULL,
	TelNo			varchar(11)			NOT NULL,
	Email           varchar(30)			NOT NULL,

	--PK
	CONSTRAINT pkAccID PRIMARY KEY (AccountID),
	CONSTRAINT ckAccPostcode CHECK (Postcode LIKE '[A-Z][A-Z][0-9][0-9] [0-9][A-Z][A-Z]'),
	CONSTRAINT ckAccTelNo CHECK (TelNo LIKE REPLICATE('[0-9]', 11))

)



CREATE TABLE OfficeLocation
(
	LocationID 		varchar(5)			NOT NULL,
	LocationName    varchar(30)			NOT NULL,
	Street			varchar(30)			NOT NULL,
	Town			varchar(30)			NOT NULL,
	County			varchar(30)			NOT NULL,
	PostCode		varchar(8)			NOT NULL,
	TelNo			varchar(11)			NOT NULL,

	--PK
	CONSTRAINT pkLocID PRIMARY KEY (LocationID),
	CONSTRAINT ckLocPostcode CHECK (Postcode LIKE '[A-Z][A-Z][0-9][0-9] [0-9][A-Z][A-Z]'),
	CONSTRAINT ckLocTelNo CHECK (TelNo LIKE REPLICATE('[0-9]', 11))
	

)


CREATE TABLE Project
(
	ProjectID 		int					NOT NULL,
	ProjDesc		varchar(15)			NOT NULL,
	AccountID       int                 NOT NULL,
	StartDate		date				NOT NULL,
	Duration		int					NOT NULL,
	CappedHrs		DECIMAL(5,2)		NOT NULL,
	B48Rate			DECIMAL(2,2)		Not null,
	A48Rate			DECIMAL(2,2)		Not null,
	BHRate			DECIMAL(2,2)		Not null,

	--PK
	CONSTRAINT pkProjId PRIMARY KEY (ProjectID),
	--FK
	CONSTRAINT fkAccId	FOREIGN KEY (AccountID ) REFERENCES Account(AccountID),

	CONSTRAINT ckB48Rate CHECK (B48Rate > 0),
	CONSTRAINT ckA48Rate CHECK (A48Rate > 0),
	CONSTRAINT ckBHRate CHECK (BHRate > 0)
)


CREATE TABLE CostCentre
(
	CostCentreID 		int					NOT NULL, 
	CostCentreDesc      varchar(40)         NOT NULL,
	LocationID 		    varchar(5)			NOT NULL,

	--PK
	CONSTRAINT pkCostCId PRIMARY KEY (CostCentreID),

	--FK
	CONSTRAINT fkLocId   FOREIGN KEY (LocationID) REFERENCES OfficeLocation(LocationID)

)

CREATE TABLE ProjectTask
(
	ProjectID 		int	     		NOT NULL,
	TaskID          int             NOT NULL,
	TaskDesc        varchar(30)     NOT NULL,

	--PK
	CONSTRAINT pkProjTask  PRIMARY KEY (ProjectID, TaskID),

	--FK
	CONSTRAINT fkProjId FOREIGN KEY (ProjectID) REFERENCES Project (ProjectID)
	
)


CREATE TABLE ProjectTaskEmployee
(
    ProjectID 		int	     		NOT NULL,
	TaskID 			int	     		NOT NULL,
	EmployeeID      int            	NOT NULL,

	--PK
	CONSTRAINT pkProjTaskEmp PRIMARY KEY (ProjectID, TaskID, EmployeeID),

	--FK
	CONSTRAINT fkProjId2 FOREIGN KEY (ProjectID) REFERENCES Project (ProjectID),
	CONSTRAINT fkTaskId FOREIGN KEY (ProjectID,TaskID) REFERENCES ProjectTask (ProjectID,TaskID),
	CONSTRAINT fkEmployeeId FOREIGN KEY (EmployeeID) REFERENCES Employee (EmployeeID)

)



CREATE TABLE EmployeeShift
(
	ShiftID			int			NOT NULL,
	AccountID      	int         NOT NULL,
	ProjectID 		int	     	NOT NULL,
	TaskID 			int	     	NOT NULL,
	StartDate       Date	    NOT NULL,
	StartTime       Time 	    NOT NULL,
	SlotCount       int			NOT NULL,

	--PK
	CONSTRAINT pkShift PRIMARY KEY (ShiftID),	

	--FK
	CONSTRAINT fkAccId2 FOREIGN KEY (AccountID) REFERENCES Account (AccountID),
	CONSTRAINT fkProjId3 FOREIGN KEY (ProjectID) REFERENCES Project (ProjectID),
	CONSTRAINT fkTaskId2 FOREIGN KEY (ProjectID,TaskID) REFERENCES ProjectTask (ProjectID,TaskID)

	--CONSTRAINT chkStartD CHECK (StartDate >= getDate())


)



CREATE TABLE EmployeeShiftDetails
(
	ShiftID				int					NOT NULL,
	EmployeeID     		int             	NOT NULL,

	--PK
	CONSTRAINT pkShiftDet PRIMARY KEY (ShiftID, EmployeeID),

	--FK
	CONSTRAINT fkShiftID FOREIGN KEY (ShiftID) REFERENCES EmployeeShift (ShiftID),
	CONSTRAINT fkEmployeeID2 FOREIGN KEY (EmployeeID) REFERENCES Employee (EmployeeID)

	
)
