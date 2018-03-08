

namespace Lecture
{
    interface IDiscipline
    {
        string DisciplineName
        {
            get;
            set;
        }

        int Lectures
        {
            get;
            set;
        }

        int Excercise
        {
            get;
            set;
        }

        string ToString();
    }
}
