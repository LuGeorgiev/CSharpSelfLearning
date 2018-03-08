using Lecture.Core;
using Lecture.Core.Providers;
using Lecture.Modules;
using System;

namespace Lecture
{
    public class Lecture
    {
        static void Main(string[] args)
        {
            var idProvider = new IdProvider();
            var consoleLogger = new ConsooleLogger();
            var manager = new TaskManager(idProvider,consoleLogger);
            var task = new Task("Some task");
            manager.Add(task);            
        }
    }
}
