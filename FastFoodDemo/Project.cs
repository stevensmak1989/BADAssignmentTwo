
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujitsuPayments
{
    class Project
    {
        private int projectId, accountID, duration;
        private string projDesc;
        private DateTime startDate;
        private decimal cappedHrs, b48Rate, a48Rate, bHRate;

        public Project()
        {
            projectId = 0; accountID = 0; duration = 0; projDesc = "";
            startDate = new DateTime(); cappedHrs = 0; b48Rate = 0;
            a48Rate = 0; bHRate = 0;
        }

        public Project(int projectId, int accountID, int duration, string projDesc, DateTime startDate,
            decimal cappedHrs, decimal b48Rate, decimal a48Rate, decimal bHRate)
        {
            this.projectId = projectId; this.accountID = accountID; this.duration = duration; this.projDesc = projDesc;
            this.startDate = startDate; this.cappedHrs = cappedHrs; this.b48Rate = b48Rate;
            this.a48Rate = a48Rate; this.bHRate = bHRate;
        }

        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        public int AccountID
        {
            get { return accountID; }
            set { accountID = value; }
        }

        public int Duration
        {
            get { return duration; }
            set
            {
                if (value > 0 )
                {
                    duration = value;
                }
                else
                    throw new MyException("Duration muust be greater than 0 days.");
            }
        }

        public string ProjDesc
        {
            get { return projDesc; }
            set
            {
                if (MyValidation.validLength(value, 2,15) && MyValidation.validLetterNumberWhiteSpace(value))
                {
                    projDesc = value;
                }
                else
                    throw new MyException("Project Description must be 2-15 letters.");
            }
        }

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
                    throw new MyException("Start days must be greater than 1 day.");
            }
        }

        public decimal CappedHrs
        {
            get { return cappedHrs; }
            set
            {
                if (value > 0)
                {
                    cappedHrs = value;
                }
                else
                    throw new MyException("Capped Hours must be greater than 0.");
            }
        }

        public decimal B48Rate
        {
            get { return b48Rate; }
            set
            {
                if (value > 0)
                {
                    b48Rate = value;
                }
                else
                    throw new MyException("Basic Hours must be greater than 0.");
            }
        }

        public decimal A48Rate
        {
            get { return a48Rate; }
            set
            {
                if (value > 0)
                {
                    a48Rate = value;
                }
                else
                    throw new MyException("Overtime Hours must be greater than 0.");
            }
        }

        public decimal BHRate
        {
            get { return bHRate; }
            set
            {
                if (value > 0)
                {
                    bHRate = value;
                }
                else
                    throw new MyException("Bank holiday Hours must be greater than 0.");
            }
        }
    }
}
