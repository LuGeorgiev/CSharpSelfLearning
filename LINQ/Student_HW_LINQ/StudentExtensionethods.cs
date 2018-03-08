using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHWLINQ
{
    static class StudentExtensionethods
    {
        public static bool ExactMarksNumber(this ISutudent name, int mark, int times)
        {
            ;
            int count=0;
            for (int i = 0; i < name.Marks.Count; i++)
            {
                if (name.Marks[i]==mark)
                {
                    count++;
                }
            }

            if (count==times)
            {
                return true;
            }

            return false;
        }
    }
}
