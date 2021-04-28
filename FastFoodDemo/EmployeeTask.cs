using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujitsuPayments
{
    class EmployeeTask
    {
        //variables for the class
        private int projectId, taskId, employeeId;
        //blank constructor for the class
        public EmployeeTask()
        {
            projectId = 0; taskId = 0;
            employeeId = 0;
        }
        //constructor to pass values
        public EmployeeTask(int projectId, int taskId, int employeeId)
        {
            this.projectId = projectId;
            this.taskId = taskId;
            this.employeeId = employeeId;
        }
        //sets project
        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }
        //set taskid
        public int TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }
        //sets employee id
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

    }
}
