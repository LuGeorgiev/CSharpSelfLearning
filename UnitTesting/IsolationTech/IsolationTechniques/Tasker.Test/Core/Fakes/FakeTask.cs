using Lecture.Modules;
using Lecture.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tasker.Test.Core.Fakes
{
    internal class FakeTask : ITask
    {
        private string v;

        public FakeTask(string v)
        {
            this.v = v;
        }

        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public bool IsDone { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime DeadLine { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
