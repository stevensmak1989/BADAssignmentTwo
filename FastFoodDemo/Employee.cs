using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujitsuPayments
{
	class Employee
	{
		private int employeeId, managerId;
		private String title, surname, forename, street, town, county, country,  postcode, telNo, grade;
		private DateTime DOB;
		private float salary;


		public Employee()
		{
			employeeId = 0; managerId = 0;
			title = ""; surname = ""; forename = ""; street = ""; town = ""; county = ""; country = ""; postcode = ""; telNo = ""; grade = "";
			DOB = new DateTime(1999, 01, 01);
			salary = 0;
		}

		public Employee(int employeeId, int managerId, String title, String surname, String forename, String street, String town, String county, 
			String country, String postcode, String telNo, String grade, DateTime DOB, float salary)
		{
			this.employeeId = employeeId; this.managerId = managerId;
			this.title = title; this.surname = surname; this.forename = forename; this.street = street; this.town = town; this.county = county; this.country = country; this.postcode = postcode; this.telNo = telNo; this.grade = grade;
			this.DOB = DOB;
			this.salary = salary;
		}

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

        public string Surname
        {
            get { return surname; }
            set
            {
                if (MyValidation.validLength(value, 2, 15) && MyValidation.validSurname(value))
                {
                    surname = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Surname must be 2-15 letters.");
            }
        }

        public string Forename
        {
            get { return forename; }
            set
            {
                if (MyValidation.validLength(value, 2, 25) && MyValidation.validForename(value))
                {
                    forename = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Forename must be 2-15 letters.");
            }
        }

        public string Street
        {
            get { return street; }
            set
            {
                if (MyValidation.validLength(value, 5, 40) && MyValidation.validLetterNumberWhiteSpace(value))
                {
                    street = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Street must be 5-40 letters.");
            }
        }

        public string Town
        {
            get { return town; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validLetterWhiteSpace(value))
                {
                    town = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Town must be 2-20 letters.");
            }
        }

        public string County
        {
            get { return county; }
            set
            {
                if (MyValidation.validLength(value, 2, 20) && MyValidation.validLetter(value))
                {
                    county = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("County must be 2-20 letters.");
            }
        }

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

        public string Postcode
        {
            get { return postcode; }
            set
            {
                if (MyValidation.validLength(value, 7, 8) && MyValidation.validLetterNumberWhiteSpace(value))
                {
                    postcode = MyValidation.EachLetterToUpper(value);
                }
                else
                    throw new MyException("Postcode must be 7-8 letters.");
            }
        }

        public string TelNo
        {
            get { return telNo; }
            set
            {
                if (MyValidation.validLength(value, 11, 15) && MyValidation.validNumber(value))
                {
                    telNo = value;
                }
                else
                    throw new MyException("Telephone number must be 11-15 digits.");
            }
        }

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
                if (MyValidation.validLength(value, 1, 5))
                {
                    grade = value;
                }
                else
                    throw new MyException("Grade must be a combination of 5 characters and numbers.");
            }
        }

        public float Salary
        {
            get { return salary; }
            set
            {
                if (salary < 0)
                {
                    salary = salary;
                }
                else
                    throw new MyException("Salary muust be greater than £0.");
            }
        }

    }











	
}
