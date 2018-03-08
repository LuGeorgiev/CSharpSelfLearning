using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasker.Core.Contracts;
using Tasker.Models.Contracts;

namespace Tasker.Core
{
    public class TaskManager
    {
        private readonly IIdProvider idProvider;
        private readonly ILogger logger;

        protected ICollection<ITask> Tasks { get; private set; }

        public TaskManager(IIdProvider provider,ILogger logger)
        {
            if (provider ==null)
            {
                throw new ArgumentNullException();
            }

            if (logger == null )
            {
                throw new ArgumentNullException();
            }
            this.idProvider = provider;
            this.logger = logger;
            this.Tasks = new List<ITask>();
        }
        public void Add(ITask task)
        {
            if (task==null)
            {
                throw new ArgumentNullException();
            }
            task.Id = this.idProvider.NextId();
            this.Tasks.Add(task);
            this.logger.Log("Task added successfuly!");
        }
    }
}
