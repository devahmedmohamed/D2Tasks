using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D2Tasks
{
    public interface ITaskCreator
    {
        void CreateSubTask();
    }

    public interface ITaskAssigner
    {
        void AssignTask();
    }

    public interface ITaskWorker
    {
        void WorkOnTask();
    }

    public class Task
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string AssignedTo { get; set; }

        public void AssignTo(Developer developer)
        {
            AssignedTo = developer.Name;
        }
    }

    public class Developer
    {
        public string Name { get; set; }

        public void WorkOnTask(Task task)
        {
            Console.WriteLine($"Developer {Name} is working on: {task.Title}");
        }
    }

    public class TeamLead : ITaskCreator, ITaskAssigner, ITaskWorker
    {
        public string Name { get; set; }

        public void CreateSubTask()
        {
            Console.WriteLine("TeamLead created a subtask.");
        }

        public void AssignTask()
        {
            var task = new Task
            {
                Title = "Merge and Deploy",
                Description = "Task to merge and deploy sharing feature to develop"
            };

            var dev = new Developer { Name = "Developer1" };
            task.AssignTo(dev);
            Console.WriteLine($"Task assigned to {dev.Name}");
        }

        public void WorkOnTask()
        {
            Console.WriteLine("TeamLead is working on a task.");
        }
    }

    public class Manager : ITaskCreator, ITaskAssigner
    {
        private readonly ITaskAssigner _assigner;

        public Manager(ITaskAssigner assigner)
        {
            _assigner = assigner;
        }

        public void CreateSubTask()
        {
            Console.WriteLine("Manager created a high-level subtask.");
        }

        public void AssignTask()
        {
            Console.WriteLine("Manager Assign Task");
            _assigner.AssignTask();
        }
    }
}
