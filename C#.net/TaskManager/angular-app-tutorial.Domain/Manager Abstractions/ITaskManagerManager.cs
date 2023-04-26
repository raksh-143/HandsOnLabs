using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace angular_app_tutorial.Domain
{
    public interface ITaskManagerManager
    {
        void AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(Task task);
        IQueryable<Task> GetAllTasks();
        Task GetTaskById(int id);
    }
}
