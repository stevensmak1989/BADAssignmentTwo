using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujitsuPayments
{
    class ProjectTask
    {
        //sets variables for the class
        private int projectId, taskId;
        private string taskDesc;

        //blank constructor
        public ProjectTask()
        {
            projectId = 0; taskId = 0;
            taskDesc = "";
        }
        //constructor to pass in values
        public ProjectTask(int projectId, int taskId , string taskDesc)
        {
            this.projectId = projectId;
            this.taskId = taskId;
            this.taskDesc = taskDesc;
        }

        //sets the project Id
        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }
        //sets the task ID
        public int TaskId
        {
            get { return taskId; }
            set { taskId = value; }
        }
        //validates the task description to be between 2 and 30
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
