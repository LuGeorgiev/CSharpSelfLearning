using Lecture.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Modules
{
    public class Task : ITask
    {
        public Task(string description)
        {
            this.Description = description;
            this.IsDone = false;
        }

        public int Id { get; set; }

        public string Description { get; set; }
            
        public bool IsDone { get; set; }

        public DateTime DeadLine { get; set; }
    }
}
