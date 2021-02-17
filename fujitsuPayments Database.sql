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
	CONSTRAINT ckSal CHECK (Salary > 0),
	CONSTRAINT ckDOB CHECK (DOB >= dateAdd(Year, -17, getDate()))
)


CREATE TABLE Account
(
	AccountID 		int				NOT NULL,
	ClientName		varchar(20)			NOT NULL,
	Street			varchar(30)			NOT NULL,
	Town			varchar(30)			NOT NULL,
	County			varchar(30)			NOT NULL,
	PostCode		varchar(8)			NOT NULL,
	TelNo			varchar(11)			NOT NULL,
	Email                   varchar(20)			NOT NULL,

	--PK
	CONSTRAINT pkAccID PRIMARY KEY (AccountID),
	CONSTRAINT ckAccPostcode CHECK (Postcode LIKE '[A-Z][A-Z][0-9][0-9] [0-9][A-Z][A-Z]'),
	CONSTRAINT ckAccTelNo CHECK (TelNo LIKE REPLICATE('[0-9]', 11))

)



CREATE TABLE OfficeLocation
(
	LocationID 		varchar(5)			NOT NULL,
	LocationName            varchar(20)			NOT NULL,
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
