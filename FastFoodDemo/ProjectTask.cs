using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujitsuPayments
{
    class ProjectTask
    {
        private int projectId, taskId;
        private string taskDesc;

        public ProjectTask()
        {
            projectId = 0; taskId = 0;
            taskDesc = "";
        }

        public ProjectTask(int projectId, int taskId , string taskDesc)
        {
            this.projectId = projectId;
            this.taskId = taskId;
            this.taskDesc = taskDesc;
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

        public string TaskDesc
        {
            get { return taskDesc; }
            set
            {
                if (MyValidation.validLength(value, 2, 30) && MyValidation.validLetterNumberWhiteSpace(value))
                {
                    taskDesc = value;
                }
                else
                    throw new MyException("Task Desc must be 2-30 letters.");
            }
        }


    }
}
