
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujitsuPayments
{
    class Project
    {
        //vars used for the project class
        private int projectId, accountID;
        private string projDesc, duration, cappedHrs, b48Rate, a48Rate, bHRate;
        private DateTime startDate;
        
        //constructor for the project
        public Project()
        {
            projectId = 0; accountID = 0; duration = ""; projDesc = "";
            startDate = new DateTime(); cappedHrs = ""; b48Rate = "";
            a48Rate = ""; bHRate = "";
        }

        //constructor for project values
        public Project(int projectId, int accountID, string duration, string projDesc, DateTime startDate,
            string cappedHrs, string b48Rate, string a48Rate, string bHRate)
        {
            this.projectId = projectId; this.accountID = accountID; this.duration = duration; this.projDesc = projDesc;
            this.startDate = startDate; this.cappedHrs = cappedHrs; this.b48Rate = b48Rate;
            this.a48Rate = a48Rate; this.bHRate = bHRate;
        }
        //sets the project id
        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }
        //sets the account id
        public int AccountID
        {
            get { return accountID; }
            set { accountID = value; }
        }

        //validates duration for a valid number and if it is greater than 0 and less than 601
        public string Duration
        {
            get { return duration; }
            set
            {
                if (MyValidation.validNumber(value))
                {
                    if (Convert.ToInt32(value) > 0 && Convert.ToInt32(value) < 601)
                    {
                        duration = value;
                    }
                    else
                        throw new MyException("Duration must be greater than 0 days and less than 600 Days.");
                }
                else
                    throw new MyException("Duration must be a valid number.");
            }
        }
        //validates the description to be betwen 2 and 16 characters including numbers and whitespace
        public string ProjDesc
        {
            get { return projDesc; }
            set
            {
                if (MyValidation.validLength(value, 2,16) && MyValidation.validLetterNumberWhiteSpace(value))
                {
                    projDesc = value;
                }
                else
                    throw new MyException("Project Description must be 2-16 letters.");
            }
        }

        //validates the start days is one day in the future
        public DateTime StartDate
        {
            get { return startDate; }
            set
            {
                if (MyValidation.validDays(Convert.ToString(value),1))
                {
                    startDate = value;
                }
                else
                    throw new MyException("Start days must be greater than 1 day in the future.");
            }
        }
        //validates the capped hours are a valid digit and is greater than 0 and less than 10000
        public string CappedHrs
        {
            get { return cappedHrs; }
            set
            {
                if (MyValidation.validDigit(value))
                {
                    if (Convert.ToDecimal(value) > 0 && Convert.ToDecimal(value) < 10000)
                    {
                        cappedHrs = value;
                    }
                    else
                        throw new MyException("Capped Hours must be greater than 0 and less than 10000.");
                }
                else
                {
                    throw new MyException("Capped Hours must be a valid number.");
                }
            }
        }
        //validates the rate is a valid digit and within the boundaries
        public string B48Rate
        {
            get { return b48Rate; }
            set
            {
                if (MyValidation.validDigit(value))
                {
                    if (Convert.ToDecimal(value) == 1)
                    {
                        b48Rate = value;
                    }
                    else
                        throw new MyException("Basic Hours must be greater than 0 and no greater than 1");
                }
                else
                {
                    throw new MyException("Basic Hours must be a valid number.");
                }
            }
        }
        //validates the rate is a valid digit and within the boundaries
        public string A48Rate
        {
            get { return a48Rate; }
            set
            {
                if (MyValidation.validDigit(value))
                {
                    
                    decimal numb = Decimal.Multiply(Convert.ToDecimal(value),100) ;
                    int comp = Convert.ToInt32(numb);
                    if (Convert.ToDecimal(value) > 1 && comp < 201)
                    {
                        a48Rate = value;
                    }
                    else
                        throw new MyException("Overtime Hours must be between 1.0 and  2.0");
                }
                else
                {
                    throw new MyException("Overtime Hours must be a valid number.");
                }
            }
        }
        //validates the rate is a valid digit and within the boundaries
        public string BHRate
        {
            get { return bHRate; }
            set
            {
                if (MyValidation.validDigit(value))
                {
                    decimal numb = Decimal.Multiply(Convert.ToDecimal(value), 100);
                    int comp = Convert.ToInt32(numb);

                    if (comp > 199 && comp < 401)
                    {
                        bHRate = value;
                    }
                    else
                        throw new MyException("Bank holiday Hours must be between 2.0 and 4.0.");
                }
                else
                {
                    throw new MyException("Bank holiday Hours must be a valid number.");
                }
            }
        }
    }
}
