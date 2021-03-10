using FujitsuPayments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujistuPayments
{
    class timesheetDetails
    {
        private int timesheetId, projectId, taskId, claimTypeId;
        private DateTime workedDay;
        private string endTime;
        private string startTime;

        public timesheetDetails()
        {
            timesheetId = 0; projectId = 0; taskId = 0; claimTypeId = 0;
            startTime = ""; endTime = "";
            workedDay = new DateTime(2021, 05, 01);

        }

        public timesheetDetails(int timesheetId, int projectId, int taskId, int claimTypeId, DateTime workedDay, string startTime, string endTime)
        {
            this.timesheetId = timesheetId; this.projectId = projectId; this.taskId = taskId; this.claimTypeId = claimTypeId;
            this.startTime = startTime; this.endTime = endTime;
            this.workedDay = workedDay;

        }
        public int TimesheetId
        {
            get { return timesheetId; }
            set { timesheetId = value; }
        }
        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }
        public int TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }
        public int ClaimTypeId
        {
            get { return claimTypeId; }
            set { claimTypeId = value; }
        }
        public DateTime WorkedDay
        {
            get { return workedDay; }
            set
            {
                workedDay = value;
            }
        }
        public string StartTime
        {
            get { return startTime; }
            set
            {

                if (MyValidation.validTimespan1(value) )
                {
                    startTime = value;
                }
                else
                    throw new MyException("Please enter a valid time formatt HH:MM");
            }
        }
        public string EndTime
        {
            get { return endTime; }
            set
            {
                if (MyValidation.validTimespan1(value) == true)
                {
                    endTime = value;
                }

                else
                    throw new MyException("Please enter a valid time formatt HH:MM");
            }
        }

    }
}

