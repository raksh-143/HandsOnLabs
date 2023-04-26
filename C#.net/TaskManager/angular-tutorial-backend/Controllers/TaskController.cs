using angular_app_tutorial.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace angular_tutorial_backend.Controllers
{
    public class TaskController : ApiController
    {
        private ITaskManagerManager Manager = null;
        public TaskController(ITaskManagerManager Manager) {
            this.Manager = Manager;
        }
        [HttpPost]
        public IHttpActionResult AddTask(Task task)
        {
            this.Manager.AddTask(task);
            return Ok();
        }
        [HttpPut]
        public IHttpActionResult UpdateTask(Task task)
        {
            this.Manager.UpdateTask(task);
            return Ok();
        }
        [HttpDelete]
        [Route("api/task/{taskId}")]
        public IHttpActionResult DeleteTask(int taskId)
        {
           var task = Manager.GetTaskById(taskId);
           this.Manager.DeleteTask(task);
           return Ok();
        }
        [HttpGet]
        public IHttpActionResult GetAllTasks()
        {
            return Ok(this.Manager.GetAllTasks());
        }
    }
}