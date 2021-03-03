using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujitsuPayments
{
    class Timesheet
    {
        private int timesheetId, employeeId, costCentreId;
        private DateTime wkEnding;
        private int approvedBy;

        public Timesheet()
        {
            employeeId = 0; timesheetId = 0; costCentreId =0;
            approvedBy = 0;
            wkEnding = new DateTime(2021, 05, 01);
            
        }

        public Timesheet(int timesheetId, int employeeId, int costCentreId, DateTime wkEnding, int approvedBy)
        {
            this.employeeId = employeeId; this.timesheetId = timesheetId; this.costCentreId = costCentreId; this.approvedBy = approvedBy;
            this.wkEnding = wkEnding;

        }

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }
        public int TimesheetId
        {
            get { return timesheetId; }
            set { timesheetId = value; }
        }
        public int CostCentreId
        {
            get { return costCentreId; }
            set { costCentreId = value; }
        }
        public int ApprovedBy
        {
            get { return approvedBy; }
            set { approvedBy = value; }
        }
        public DateTime WkEnding
        {
            get { return wkEnding; }
            set
            {
              wkEnding = value;
            }
        }
    }
}
