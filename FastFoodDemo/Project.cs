﻿
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
        private float cappedHrs, b48Rate, a48Rate, bHRate;

        public Project()
        {
            projectId = 0; accountID = 0; duration = 0; projDesc = "";
            startDate = new DateTime(); cappedHrs = 0; b48Rate = 0;
            a48Rate = 0; bHRate = 0;
        }

        public Project(int projectId, int accountID, int duration, string projDesc, DateTime startDate,
            float cappedHrs, float b48Rate, float a48Rate, float bHRate)
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
                if (duration < 0 )
                {
                    duration = duration;
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
                if (MyValidation.validLength(value, 2,15) && MyValidation.validLetter(value))
                {
                    projDesc = MyValidation.firstLetterEachWordToUpper(value);
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

        public float CappedHrs
        {
            get { return cappedHrs; }
            set
            {
                if (cappedHrs < 0)
                {
                    cappedHrs = cappedHrs;
                }
                else
                    throw new MyException("Capped Hours must be greater than 0.");
            }
        }

        public float B48Rate
        {
            get { return b48Rate; }
            set
            {
                if (b48Rate < 0)
                {
                    b48Rate = b48Rate;
                }
                else
                    throw new MyException("Before 8 Hours must be greater than 0.");
            }
        }

        public float A48Rate
        {
            get { return a48Rate; }
            set
            {
                if (a48Rate < 0)
                {
                    a48Rate = a48Rate;
                }
                else
                    throw new MyException("After 8 Hours must be greater than 0.");
            }
        }

        public float BHRate
        {
            get { return bHRate; }
            set
            {
                if (bHRate < 0)
                {
                    bHRate = bHRate;
                }
                else
                    throw new MyException("Bank holiday Hours must be greater than 0.");
            }
        }
    }
}
