using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujitsuPayments
{
    class EmployeeTask
    {
        private int projectId, taskId, employeeId;

        public EmployeeTask()
        {
            projectId = 0; taskId = 0;
            employeeId = 0;
        }

        public EmployeeTask(int projectId, int taskId, int employeeId)
        {
            this.projectId = projectId;
            this.taskId = taskId;
            this.employeeId = employeeId;
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
        public int EmployeeId
        {
            get { return employeeId; }
            set { employeeId = value; }
        }

    }
}
