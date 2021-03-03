using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujitsuPayments
{
    class EmployeeShiftDetails
    {
        private int shiftId, employeeId;


        public EmployeeShiftDetails()
        {
            shiftId = 0;
            employeeId = 0;
        }

        public EmployeeShiftDetails(int shiftId, int employeeId)
        {
            this.shiftId = shiftId;
            this.employeeId = employeeId;
        }

        public int ShiftId
        {
            get { return shiftId; }
            set { shiftId = value; }
        }

        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }
    }
}
