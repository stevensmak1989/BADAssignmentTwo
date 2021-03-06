﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujitsuPayments
{
    class EmployeeShift
    {
        private int shiftId, accountId, projectId, taskId;
        private DateTime startDate;
        private TimeSpan startTime, endTime;

        public EmployeeShift()
        {
            shiftId = 0; accountId = 0; projectId = 0; taskId = 0;
            startDate = new DateTime();
            startTime = new TimeSpan();
            endTime = new TimeSpan();
        }

        public EmployeeShift(int shiftId, int accountId, int projectId, int taskId, DateTime startDate, TimeSpan startTime, TimeSpan endTime)
        {
            this.shiftId = shiftId; this.accountId = accountId; this.projectId = projectId; this.taskId = taskId;
            this.startDate = startDate; this.startTime = startTime; this.endTime = endTime;

        }

        public int ShiftId
        {
            get { return shiftId; }
            set { shiftId = value;  }
        }

        public int AccountId
        {
            get { return accountId; }
            set { accountId = value; }
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

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }

        public TimeSpan StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }


        public TimeSpan EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }
    }
}
