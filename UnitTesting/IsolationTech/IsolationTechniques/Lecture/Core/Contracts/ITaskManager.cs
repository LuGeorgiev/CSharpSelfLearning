using Lecture.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lecture.Core.Contracts
{
    public interface ITaskManager
    {
        void Add(ITask task);

        void Remove(int id);
    }
}
