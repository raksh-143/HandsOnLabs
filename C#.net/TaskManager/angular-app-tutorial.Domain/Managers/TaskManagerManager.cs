using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angular_app_tutorial.Domain
{
    public class TaskManagerManager:ITaskManagerManager
    {
        private ITaskManagerRepository Repository { get; set; }
        public TaskManagerManager(ITaskManagerRepository TaskManagerRepository) { 
            this.Repository = TaskManagerRepository;
        }

        public void AddTask(Task task)
        {
            Repository.AddTask(task);
        }

        public void UpdateTask(Task task)
        {
            Repository.UpdateTask(task);
        }

        public void DeleteTask(Task task)
        {
            Repository.DeleteTask(task);
        }

        public IQueryable<Task> GetAllTasks()
        {
            return Repository.GetAllTasks();
        }

        public Task GetTaskById(int id)
        {
            return Repository.GetTaskById(id);
        }
    }
}
