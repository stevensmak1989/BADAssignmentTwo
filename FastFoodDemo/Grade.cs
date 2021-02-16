using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FujitsuPayments
{
    class Grade
    {
        private String gradeID, gradeDesc;
        private float startSal, endSal;

        public Grade()
        {
            gradeID = ""; gradeDesc = "";
            startSal = 0; endSal = 0;
        }

        public Grade(String gradeID, String gradeDesc, float startSal, float endSal)
        {
            this.gradeID = gradeID; this.gradeDesc = gradeDesc;
            this.startSal = startSal; this.endSal = endSal;
        }

        public string GradeID
        {
            get { return gradeID; }
            set
            {
                if (MyValidation.validLength(value, 1, 5))
                {
                    gradeID = value;
                }
                else
                    throw new MyException("GradeID must be a combination of 5 characters and numbers.");
            }
        }

        public string GradeDesc
        {
            get { return gradeDesc; }
            set
            {
                if (MyValidation.validLength(value, 2, 15) )
                {
                    gradeDesc = MyValidation.firstLetterEachWordToUpper(value);
                }
                else
                    throw new MyException("Grade Description must be 2-15 letters.");
            }
        }

        public float StartSal
        {
            get { return startSal; }
            set
            {
                if (startSal < 0)
                {
                    startSal = startSal;
                }
                else
                    throw new MyException("Start salary muust be greater than £0.");
            }
        }

        public float EndSal
        {
            get { return endSal; }
            set
            {
                if (endSal < 0)
                {
                    endSal = endSal;
                }
                else
                    throw new MyException("End salary muust be greater than £0.");
            }
        }

    }
}
