using Lecture.Core.Contracts;
using Lecture.Core.Providers.Contract;
using Lecture.Modules.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Lecture.Core
{
    public class TaskManager :ITaskManager
    {
        private ICollection<ITask> tasks;

        
        private readonly IIdProvider idProvider;
        private readonly ILogger logger;

        public TaskManager(IIdProvider idProvide, ILogger logger)
        {
            this.tasks = new List<ITask>();

            this.idProvider = idProvide;
            this.logger = logger;
        }

        public IList<ITask> Members()
        {
            return new List<ITask>(this.tasks);
        }

        public void Add(ITask task)
        {
            if (task==null)
            {
                throw new ArgumentNullException();
            }
            task.Id = this.idProvider.NextId();
            this.tasks.Add(task);
            this.logger.Log("New task was adedd");
        }

        public void Remove(int id)
        {
            var task = this.tasks.SingleOrDefault(x => x.Id == id);
            if (task==null)
            {
                this.logger.Log($"Task with {id} was not found");
            }
            else
            {
                this.tasks.Remove(task);
                this.logger.Log($"task {id} was removed");
            }
        }
    }
}
