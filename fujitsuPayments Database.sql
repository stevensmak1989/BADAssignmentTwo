--CREATE DATABASE fujitsuPayments    
--GO

--specify the db
using fujitsuPayments

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
	CappedHrs		DECIMAL(15,2)		NOT NULL,
	B48Rate			DECIMAL(3,2)		Not null,
	A48Rate			DECIMAL(3,2)		Not null,
	BHRate			DECIMAL(3,2)		Not null,

	--PK
	CONSTRAINT pkProjId PRIMARY KEY (ProjectID),
	--FK
	CONSTRAINT fkAccId	FOREIGN KEY (AccountID ) REFERENCES Account(AccountID),

	
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

-- project
   insert into Project (ProjectID, ProjDesc, AccountID, StartDate, Duration, CappedHrs, B48Rate, A48Rate, BHRate)
  values (1, 'Data Exchange', 10000, '05-02-2021', 100, 100.00, 1.00, 1.00,2.00), 
  (2, 'Small App Migra ', 10001, '05-01-2021', 200, 400.00, 1.00, 1.50,2.00),
  (3, 'Training Model', 10000, '05-12-2021', 500, 150.00, 1.00, 1.50,2.50),
  (4, 'Claim Hub ', 10003, '06-22-2021', 400, 240.00, 1.00, 2.00,3.00),
  (5, 'Cust Service', 10012, '05-24-2021', 320, 410.00, 1.00, 1.50,2.00),
  (6, 'Flight Tracker', 10006, '08-15-2021', 700, 500.00, 1.00, 2.00,4.00),
  (7, 'Click & Co', 10008, '05-03-2021', 420, 400.00, 1.00, 1.50,2.00),
  (8, 'Health Checker', 10021, '05-22-2021', 200, 100.00, 1.00, 1.50,2.00),
  (9, 'Cust Loyalty', 10009, '05-19-2021', 240, 130.00, 1.00, 1.50,2.00), 
  (10, 'Nectar System', 10013, '05-07-2021', 240, 410.00, 1.00, 1.70,2.50),
  (11, 'Mortgage Plat', 10004, '06-12-2021', 320, 200.00, 1.00, 1.50,2.50),
  (12, 'Land Manage', 10002, '07-29-2021', 500, 400.00, 1.00, 2.00,3.50),
  (13, 'Fleet Manage', 10002, '07-29-2021', 500, 410.00, 1.00, 2.00,3.50),
  (14, 'Leasing system', 10020, '05-17-2021', 200, 100.00, 1.00, 1.50,2.00),
  (15, 'Fleet Tracking', 10008, '06-04-2021', 300, 700.00, 1.00, 1.50,2.00),
  (16, 'Research Squad', 10021, '05-01-2021', 100, 300.00, 1.00, 1.50,2.00)

--Project Task
 insert into ProjectTask (ProjectID,TaskID,  TaskDesc)
  values (1,1, 'Developer'), (1,2,'Senior Dev') , (1,3,'Architect'), (1,4, 'Tester'), (1,5,'Scrum Master'),
  (2,1, 'Developer'), (2,2,'Senior Dev') , (2,3,'Architect'), (2,4, 'Tester'), (2,5,'Scrum Master'),
  (3,1, 'Developer'), (3,2,'Senior Dev') , (3,3,'Architect'), (3,4, 'Tester'), (3,5,'Scrum Master'),
  (4,1, 'Developer'), (4,2,'Senior Dev') , (4,3,'Architect'), (4,4, 'Tester'), (4,5,'Scrum Master'),
  (5,1, 'Developer'), (5,2,'Senior Dev') , (5,3,'Architect'), (5,4, 'Tester'), (5,5,'Scrum Master'),
  (6,1, 'Developer'), (6,2,'Senior Dev') , (6,3,'Architect'), (6,4, 'Tester'), (6,5,'Scrum Master'),
  (7,1, 'Developer'), (7,2,'Senior Dev') , (7,3,'Architect'), (7,4, 'Tester'), (7,5,'Scrum Master'),
  (8,1, 'Developer'), (8,2,'Senior Dev') , (8,3,'Architect'), (8,4, 'Tester'), (8,5,'Scrum Master'),
  (9,1, 'Developer'), (9,2,'Senior Dev') , (9,3,'Architect'), (9,4, 'Tester'), (9,5,'Scrum Master'),
  (10,1, 'Developer'), (10,2,'Senior Dev') , (10,3,'Architect'), (10,4, 'Tester'), (10,5,'Scrum Master'),
  (11,1, 'Developer'), (11,2,'Senior Dev') , (11,3,'Architect'), (11,4, 'Tester'), (11,5,'Scrum Master'),
  (12,1, 'Developer'), (12,2,'Senior Dev') , (12,3,'Architect'), (12,4, 'Tester'), (12,5,'Scrum Master'),
  (13,1, 'Developer'), (13,2,'Senior Dev') , (13,3,'Architect'), (13,4, 'Tester'), (13,5,'Scrum Master'),
  (14,1, 'Developer'), (14,2,'Senior Dev') , (14,3,'Architect'), (14,4, 'Tester'), (14,5,'Scrum Master'),
  (15,1, 'Developer'), (15,2,'Senior Dev') , (15,3,'Architect'), (15,4, 'Tester'), (15,5,'Scrum Master'),
  (16,1, 'Developer'), (16,2,'Senior Dev') , (16,3,'Architect'), (16,4, 'Tester'), (16,5,'Scrum Master')
  
 --Employees
  insert into Employee (EmployeeID, Title, Surname,Forename, Street, Town, County,PostCode, TelNo, DOB, ManagerID, Grade, Salary, Manager) 
	  values (1000, 'Mr', 'Thompson', 'Glynn', '123 Fake Name', 'Derry', 'Derry', 'BT48 7YT', '07872311915', '07-07-1967' ,1000, 'MAN02', 54000.00, 1),
	  (1001, 'Mr', 'Collins', 'Jack', '74 Main Street', 'Derry', 'Derry', 'BT48 8JT', '07872311916', '05-27-1996' ,1000, 'DEV01', 18500.00, 0),
	  (1002, 'Mr', 'McCready', 'Steven', '41 Kilea', 'Derry', 'Derry', 'BT74 6PO', '07841214785', '01-05-1989' ,1000, 'DEV01', 18500.00, 0),
	  (1003, 'Mr', 'McIlroy', 'Billy', '22 Belfast Av', 'Belfast', 'Belfast', 'BT14 1YY', '07841214714', '05-19-1942' ,1000, 'MAN01', 35000.00, 1),
	  (1004, 'Miss', 'Martin', 'Gemma', '188 Eglinton', 'Derry', 'Derry', 'BT74 7KJ', '07741464717', '12-12-1992' ,1003, 'DEV04', 25500.00, 0),
	  (1005, 'Ms', 'Maguire', 'Megan', '1 Dungiven', 'Derry', 'Derry', 'BT88 2SR', '07732487621', '11-18-1987' ,1003, 'DEV05', 33500.00, 0),
	  (1006, 'Mr', 'Rodgers', 'Hamish', '74 Edingburgh', 'Scotland', 'Scotland', 'ED74 7GL', '07732484619', '05-11-1975' ,1000, 'MAN01', 34000.00, 1),
	  (1007, 'Mrs', 'Nash', 'Joanne', '42 City Centre', 'Derry', 'Derry', 'BT48 8LQ', '07832684674', '02-19-1971' ,1000, 'DEV06', 44000.00, 0),
	  (1008, 'Mr', 'Rocker', 'Gregg', '22 Leeds Town', 'Leeds', 'Leeds', 'LE35 7PT', '07964231784', '03-22-1976' ,1006, 'DEV06', 44000.00, 0),
	  (1009, 'Miss', 'McMullan', 'Marisa', '8 Dungannon Street', 'Derry', 'Derry', 'BT49 1YY', '07457215478', '04-17-1986' ,1003, 'DEV04', 28500.00, 0),
	  (1011, 'Mr', 'Wilson', 'Stephen', '59 Creggan', 'Derry', 'Derry', 'BT48 7OX', '07541214785', '11-05-1969' ,1003, 'DEV05', 32000.00, 0),
	  (1012, 'Ms', 'Wood', 'Mikayla', '24 Maydown', 'Derry', 'Derry', 'BT47 5KA', '07871457893', '08-29-1973' ,1006, 'DEV01', 17500.00, 0),
	  (1013, 'Mr', 'Biddle', 'Mark', '78 Limavady', 'Limavady', 'Derry', 'BT87 5II', '07612478942', '06-09-1998' ,1006, 'DEV01', 18500.00, 0),
	  (1014, 'Mr', 'Anderson', 'Mark', '154 Waterside Av', 'Derry', 'Derry', 'BT48 7QW', '07896541231', '12-23-1985' ,1000, 'DEV03', 23000.00, 0),
	  (1015, 'Ms', 'Deeney', 'Tereasa', '18 The Country', 'Derry', 'Derry', 'BT63 0IT', '07872311915', '05-05-1979' ,1000, 'MAN02', 55000.00, 0),
	  (1016, 'Ms', 'Smith', 'Rachel', '187 Waterside St', 'Derry', 'Derry', 'BT74 4RQ', '07865421324', '01-01-1977' ,1015, 'DEV04', 28500.00, 0),
	  (1017, 'Mr', 'McClintock', 'Adam', '77 Shantallow', 'Derry', 'Derry', 'BT48 9LK', '07872314787', '07-30-1989' ,1015, 'DEV01', 18000.00,0),
	  (1018, 'Mrs', 'Ennis', 'Mary', '17 Claudy', 'Derry', 'Derry', 'BT88 9SD', '07875314784', '09-29-1969' ,1003, 'DEV06', 43000.00, 1),
	  (1019, 'Ms', 'Porter', 'Lisa', '78 Waterside RD', 'Dublin', 'Dublin', 'DB47 7LP', '07872314879', '02-28-1985' ,1000, 'MAN01', 29000.00, 1),
	  (1020, 'Mr', 'Mulholand', 'Ryan', '36 Maghera', 'Tyrone', 'Tyrone', 'BT12 3KI', '07875412148', '07-01-1999' ,1000, 'DEV01', 17500.00, 0)


	--ProjectTaskEmployee
	 insert into ProjectTaskEmployee (ProjectID, TaskID, EmployeeID)
	 values(1,1,1001),(1,2,1004),(1,3,1008),(1,4, 1009), (1,5, 1019)
	 (2,1,1002),(2,2,1005),(2,3,1011),(2,4, 1017), (2,5, 1005),
	 (3,1,1017),(3,2,1014),(3,3,1007),(3,4, 1000), (3,5, 1019),
	 (4,1,1020),(4,2,1018),(4,3,1015),(4,4, 1002), (4,5, 1000),
	 (5,1,1013),(5,2,1016),(5,3,1000),(5,4, 1018), (5,5, 1003),
	 (6,1,1012),(6,2,1004),(6,3,1003),(6,4, 1009), (6,5, 1006),
	 (7,1,1001),(7,2,1005),(7,3,1011),(7,4, 1017), (7,5, 1019),
	 (8,1,1002),(8,2,1018),(8,3,1008),(8,4, 1018), (8,5, 1003),
	 (9,1,1017),(9,2,1005),(9,3,1007),(9,4, 1002), (9,5, 1005),
	 (10,1,1020),(10,2,1016),(10,3,1015),(10,4, 1000), (10,5, 1006),
	 (11,1,1013),(11,2,1014),(11,3,1011),(11,4, 1009), (11,5, 1000),
	 (12,1,1012),(12,2,1018),(12,3,1003),(12,4, 1017), (12,5, 1019),
	 (13,1,1001),(13,2,1005),(13,3,1008),(13,4, 1002), (13,5, 1005),
	 (14,1,1002),(14,2,1004),(14,3,1007),(14,4, 1009), (14,5, 1003),
	 (15,1,1017),(15,2,1016),(15,3,1000),(15,4, 1018), (15,5, 1019),
	 (16,1,1020),(16,2,1018),(16,3,1003),(16,4, 1002), (16,5, 1000)

	 insert into Timesheet (TimesheetID, EmployeeID, CostCentreID, WKBeginning,ApprovedBy)
	 values--(1000, 1000,3000,'04-19-2021', 1000),
	 (1001, 1001,3000,'04-19-2021', 1000)


	 insert into TimesheetDetails(TimesheetID, WorkedDAy,StartTime, EndTime, ClaimTypeID, ProjectID, TaskID)
	 Values --(1000, '04-19-2021', '08:00', '16:00',1,10,4), (1000, '04-20-2021', '08:00', '16:00',1,10,4) , (1000, '04-21-2021', '08:00', '16:00',1,10,4) ,(1000, '04-22-2021', '08:00', '16:00',1,10,4) ,(1000, '04-23-2021', '08:00', '16:00',1,10,4),
	 (1001, '04-19-2021', '08:00', '16:00',1,10,4), (1001, '04-20-2021', '08:00', '16:00',1,10,4) , (1001, '04-21-2021', '08:00', '16:00',1,10,4) ,(1001, '04-22-2021', '08:00', '16:00',1,10,4) ,(1001, '04-23-2021', '08:00', '16:00',1,10,4)
