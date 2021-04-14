CREATE DATABASE fujitsuPayments    
GO

--Creates the Grade table
CREATE TABLE Grade 
(
	Grade			varchar(5)		NOT NULL,
	GradeDesc		varchar(30)		NOT NULL,
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
	 Manager bit not null

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
	ShiftID		int		NOT NULL,
	AccountID      	int         	NOT NULL,
	ProjectID 	int	     	NOT NULL,
	TaskID 		int	     	NOT NULL,
	StartDate       Date	    	NOT NULL,
	StartTime       Time(2) 	NOT NULL,
	EndTime		Time(2)       	NOT NULL,

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
CREATE TABLE ClaimType
(
	ClaimTypeID			int			NOT NULL,
	ClaimTypeDesc        varchar(30)     NOT NULL,

	--PK
	CONSTRAINT pkClaimType PRIMARY KEY (ClaimTypeID)

)

CREATE TABLE Timesheet
(
	TimesheetID			int			NOT NULL,
	EmployeeID      	int         NOT NULL,
	CostCentreID 		int	     	NOT NULL,
	WkBeginning 			Date	    NOT NULL,
	ApprovedBy			varchar(30) NOT NULL,
	

	--PK
	CONSTRAINT pkTimesheetID PRIMARY KEY (TimesheetID),	

	--FK
	CONSTRAINT fkEmpID FOREIGN KEY (EmployeeID) REFERENCES Employee (EmployeeID),
	CONSTRAINT fkCosteCentID FOREIGN KEY (CostCentreID) REFERENCES CostCentre (CostCentreID),


)

CREATE TABLE TimesheetDetails
(
    TimesheetID 		int	     	NOT NULL,
	WorkedDay 			Date	    NOT NULL,
	StartTime			time(2)		NOT NULL,
	EndTime				time(2)		NOT NULL,
	ClaimTypeID			int			NOT NULL,
	ProjectID		    int        	NOT NULL,
	TaskID				int        	NOT NULL

	--PK
	CONSTRAINT pkTimeDetails PRIMARY KEY (TimesheetID, WorkedDay, StartTime),

	--FK
	CONSTRAINT fkClaimType FOREIGN KEY (ClaimTypeID) REFERENCES ClaimType (ClaimTypeID),
	CONSTRAINT fkTProjID FOREIGN KEY (ProjectID) REFERENCES Project (ProjectID),
	CONSTRAINT fkTTaskID FOREIGN KEY (ProjectID,TaskID) REFERENCES ProjectTask (ProjectID,TaskID),	

)

  insert into ClaimType([ClaimTypeID]
      ,[ClaimTypeDesc])
	  values(1,'Basic Hours'),(2,'Overtime Hours'),(3,'OnCall Hours')
	  
	 


--Records 
--populating account
  INSERT INTO Account(AccountID,ClientName,Street,Town,County,PostCode,TelNo,Email) VALUES
(10000,'CITB','Nutts Corner Training Centre','17 Dundrod','Crumlin','BT48 0RU', '02871261548','info@citb.co.uk'),
(10001,'Post Office','3 Custom House','Derry','Derry','BT48 6AA', '02871261548','info@postoffice.com'),
(10002,'HS2','The Podium','1 Eversholt','London','NW11 2DN', '02871261548','info@hs2.co.uk'),
(10003,'Aviva Plc','139 W','Regent Street','Glasgow','GG21 2SG', '02871261548','info@avivaplc.co.uk'),
(10004,'Barclays','61 Bow St','Lisburn','Antrim','BT28 1DR', '02871261548','info@barclays.co.uk'),
(10005,'Diageo','3 Marshalls Rd','Castlereagh','Belfast','BT50 6SL', '02871261548','info@diageo.co.uk'),
(10006,'EasyJet','Airport Approach Rd','Luton','London','LU21 9PF', '02871261548','info@easyjet.co.uk'), 
(10007,'Royal Mail','6 Laurence Poutney','Hill','London','EC41 0EH', '02871261548','info@royalmail.co.uk'),
(10008,'Tesco','Cresent Link','Retail Park','Derry','BT47 5FX', '02871261548','info@tesco.co.uk'),
(10009,'Vivo Energy','5 the Peak','Pimlico','London','SW11 1AN', '02871261548','info@vivoenergy.co.uk'),
(10010,'Unilever','PO Box 69','Port Sunlight','Wirral','CH62 4ZD', '02871261548','info@unilever.co.uk'),
(10011,'Tate & Lyle','Knights Rd','Royal Docks','London','EE16 2AT', '02871261548','info@tate&lyle.co.uk'),
(10012,'Next','Crescent Road','Lisnagelvin Retail Park','Derry','BT47 2NQ', '02871261548','info@next.co.uk'),
(10013,'Sainsbury','200 Strand Road','Derry','Derry','BT48 7PU', '02871261548','info@sainsburys.co.uk'),
(10014,'GlaxoSmithKline','980 Great West Rd','London','London','TW81 9GS', '02871261548','info@glaxosmithkline.co.uk'),
(10015,'Dixons Carphone','Riverside Retail Park','Unit 8','Coleraine','BT51 3QC', '02871261548','info@dixonscarphone.co.uk'),
(10016,'FirstGroup','300 Stirling Rd','Camelon','Larbert','FK51 3NJ', '02871261548','info@firstgroup.co.uk'),
(10017,'Computacenter','Haston House','South Gyle','Edinburgh','EH12 9DQ', '02871261548','info@computacenter.co.uk'),
(10018,'Direct Line Insurance Group','14-18 Cadogan St','Glasgow','Glasgow','BT33 0RG', '02871261548','info@directlinegroup.co.uk'),
(10019,'Taylor Wimpey','1 Masterton Park','Fife','Dunfermline','KY11 8NX', '02871261548','info@taylorwimpey.co.uk'),
(10020,'Vertu Motors','390 Calder Rd','Edinburgh','Edinburgh','EH11 4AS', '02871261548','info@vertumotors.co.uk'),
(10021, 'Fujitsu Services','Strand Rd', 'Derry', 'Derry','BT48 4DF', '02872328547','info@fujitsu.com' )


--populating location
INSERT INTO OfficeLocation (LocationID, LocationName, Street, Town, County, PostCode, TelNo) VALUES
(1000, 'IRE24', 'Strand Rd', 'Derry', 'Derry','BT48 4DF', '02872328547'),
(1001, 'IRE11', 'Icl House', 'Hollywood Rd', 'Belfast','BT14 1NU', '02872328547'),
(1002, 'IRE09', 'Cunningham House', '429 Hollywood Rd', 'Belfast','BT41 1NU', '02872328547'),
(1003, 'IRE05', 'Central Library', 'Royal Avenue', 'Belfast','BT11 1EA', '02872328547'),
(1004, 'SOL20', 'Birmingham Business Park', '6000 Solihull', 'Birmingham','BB37 7YU', '02872328547'),
(1005, 'STE04', '14 Cavendish Rd', 'Stevenage', 'Stevenage','SG12 2DY', '02872328547'),
(1006, 'LON01', '22 Baker St', 'Marylebone', 'London','WU11 3BW', '02872328547'),
(1007, 'BAS03', '55 Jays Cl', 'Basingstoke', 'Basingstoke','RG22 4BY', '02872328547'),
(1008, 'BRA06', '22 Arrow Rd', 'Bracknell', 'Bracknell','RG12 8FB', '02872328547'),
(1009, 'MAL12', 'Infinity House', 'Mallard Way', 'Crewe','CW10 6ZQ', '02872328547'),
(1010, 'MAN10', 'One Central Park', 'Northampton', 'Manchester','MM40 5BP', '02872328547'),
(1011, 'EDN15', 'Wallace House', '1 Lochside Ave', 'Edinburgh','EH12 9DJ', '02872328547'),
(1012, 'INV20', '50 Seafield Rd', 'Inverness', 'Inverness','IV12 1SG', '02872328547')


--Populating CostCentre 
  INSERT INTO CostCentre (CostCentreID, CostCentreDesc, LocationID) VALUES
(3000, 'Derry Office', 1000),
(3001, 'Belfast Office', 1001),
(3002, 'Solihull Office', 1004),
(3003, 'Stevenage Office', 1005),
(3004, 'London Main Office', 1006),
(3005, 'Basignstoke Office', 1007),
(3006, 'Bracknell Office', 1008),
(3007, 'Manchester Office', 1010),
(3008, 'Edinburgh Office', 1011),
(3009, 'Inverness Office', 1012)


--Populating Grade
INSERT INTO Grade (Grade, GradeDesc, StartSal, EndSal) VALUES
('DEV01', 'Apprentice', 17500, 18500),
('DEV02', 'Junior Developer', 19000, 22500),
('DEV03', 'Graduate Developer', 23000, 25000),
('DEV04', 'Applications Developer', 25500, 28500),
('DEV05', 'Senior Applications Developer', 29000, 33500),
('DEV06', 'Software Architect', 34000, 44000),
('MAN01', 'Services Manager',29000, 35000),
('MAN02', 'Head of Applications', 35500, 55000)
