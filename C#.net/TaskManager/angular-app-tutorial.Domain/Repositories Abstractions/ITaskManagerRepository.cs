using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace angular_app_tutorial.Domain
{
    public interface ITaskManagerRepository
    {
        void AddTask(Task task);
        void UpdateTask(Task task);
        void DeleteTask(Task task);
        IQueryable<Task> GetAllTasks();
        Task GetTaskById(int id);   
    }
}
