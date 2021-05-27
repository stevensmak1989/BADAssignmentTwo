using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujitsuPayments
{
    class Employee
    {
        //vars for the Employee class
        private int employeeId, managerId, manager;
        private String title, surname, forename, street, town, county, country, postcode, telNo, grade, salary;
        private DateTime DOB;
       

        //blank constructor
        public Employee()
        {
            employeeId = 0; managerId = 0; manager = 0;
            title = ""; surname = ""; forename = ""; street = ""; town = ""; county = ""; country = ""; postcode = ""; telNo = ""; grade = "";
            DOB = new DateTime(1999, 01, 01);
            salary = "";
        }
        //constructor used to pass in values
        public Employee(int employeeId, int managerId,int manager, String title, String surname, String forename, String street, String town, String county,
            String country, String postcode, String telNo, String grade, DateTime DOB, String salary)
        {
            this.employeeId = employeeId; this.managerId = managerId; this.manager = manager; ;
            this.title = title; this.surname = surname; this.forename = forename; this.street = street; this.town = town; this.county = county; this.country = country; this.postcode = postcode; this.telNo = telNo; this.grade = grade;
            this.DOB = DOB;
            this.salary = salary;
        }
        //list of getters and setters
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

        public int ManagerId
        {
            get { return managerId; }
            set { managerId = value; }
        }
        public int Manager
        {
            get { return manager; }
            set { manager = value; }
        }
        //validates the title for the below values
        public string Title
        {
            get { return title; }
            set
            {
                if (value.ToUpper() != "MR" && value.ToUpper() != "MRS" && value.ToUpper() != "MISS" && value.ToUpper() != "MS")
                    throw new MyException("Title must be Mr,Mrs, Miss or Ms.");
                else
                    title = MyValidation.firstLetterEachWordToUpper(value);
            }
        }
        //validates surname to be valid letters between 2 and 20
        public string Surname
        {
            get { return surname; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validSurname(value))
                {
                    surname = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Surname must be 2-20 letters.");
            }
        }
        //validates forename to be valid letters between 2 and 20
        public string Forename
        {
            get { return forename; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validForename(value))
                {
                    forename = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Forename must be 2-20 letters.");
            }
        }
        //validates street to be valid letters between 5 and 30
        public string Street
        {
            get { return street; }
            set
            {
                if (MyValidation.validLength(value, 5, 30) && MyValidation.validLetterNumberWhiteSpace(value))
                {
                    street = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Street must be 5-30 letters.");
            }
        }
        //validates town to be valid letters between 2 and 30
        public string Town
        {
            get { return town; }
            set
            {
                if (MyValidation.validLength(value, 2, 30) && MyValidation.validLetterWhiteSpace(value))
                {
                    town = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Town must be 2-30 letters.");
            }
        }
        //validates county to be valid letters between 2 and 30
        public string County
        {
            get { return county; }
            set
            {
                if (MyValidation.validLength(value, 2, 30) && MyValidation.validLetter(value))
                {
                    county = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("County must be 2-30 letters.");
            }
        }
        //validates countru to be valid letters between 2 and 20
        public string Country
        {
            get { return country; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validLetter(value))
                {
                    country = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Country must be 2-20 letters.");
            }
        }
        //validates postcode to be valid letters and numbers between 7 and 8
        public string Postcode
        {
            get { return postcode; }
            set
            {
                if (MyValidation.validLength(value, 7, 8) && MyValidation.validLetterNumberWhiteSpace(value))
                {
                    if (MyValidation.validPCode(value))
                    {
                        postcode = MyValidation.EachLetterToUpper(value);
                    }
                    else
                        throw new MyException("Postcode must be 7-8 letters and numbers.");
                }
                else
                    throw new MyException("Postcode must be 7-8 letters and numbers.");
            }
        }
        //validates telno to be valid numbers for 11 digits
        public string TelNo
        {
            get { return telNo; }
            set
            {
                if (MyValidation.validLength(value, 11, 11) && MyValidation.validNumber(value))
                {
                    telNo = value;
                }
                else
                    throw new MyException("Telephone number must be 11 digits.");
            }
        }
        //validates dob to be older than 16
        public DateTime Dob
        {
            get { return DOB; }
            set
            {
                if (MyValidation.validDOB(Convert.ToString(value)))
                {
                    DOB = value;
                }
                else
                    throw new MyException("Employee age must be older than 16 years.");
            }
        }

        public string Grade
        {
            get { return grade; }
            set
            {
                grade = value;
            }
        }

        public string Salary
        {
            get { return salary; }
            set
            {
                if (MyValidation.validDigit(value))
                {
                    
                    salary = value;
                }
              

                
                else
                    throw new MyException("Salary must be greater than 0.0"); 
            }
        }

    }

}
