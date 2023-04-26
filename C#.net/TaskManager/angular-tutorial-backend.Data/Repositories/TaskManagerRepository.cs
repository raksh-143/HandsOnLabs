using angular_app_tutorial.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace angular_tutorial_backend.Data
{
    public class TaskManagerRepository:ITaskManagerRepository
    {
        private TaskManagerDbContext Db = new TaskManagerDbContext();
        public void AddTask(Task task)
        {
            Db.Tasks.Add(task);
            Db.SaveChanges();
        }
        public void UpdateTask(Task task)
        {
            Db.Entry(task).State = EntityState.Modified;
            Db.SaveChanges();
        }
        public void DeleteTask(Task task)
        {
            Task taskToDelete = Db.Tasks.Find(task.Id);
            Db.Tasks.Remove(taskToDelete);
            Db.SaveChanges();
        }
        public IQueryable<Task> GetAllTasks()
        {
            return Db.Tasks;
        }
        public Task GetTaskById(int id)
        {
            return Db.Tasks.Find(id);
        }
    }
}
