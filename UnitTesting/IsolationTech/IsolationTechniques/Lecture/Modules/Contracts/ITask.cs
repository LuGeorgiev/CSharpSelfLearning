using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Modules.Contracts
{
    public interface ITask
    {
        int Id { get; set; }

        string Description { get; set; }

        bool IsDone { get; set; }

        DateTime DeadLine { get; set; }
    }
}
