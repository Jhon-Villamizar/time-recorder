using ServiceTimeRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceTimeRecord.Controllers
{
    public class TaskController : ApiController
    {
        [HttpGet]
        public IEnumerable<Task> Get()
        {
            using (var context = new RegistryContext())
            {
                return context.Tasks.ToList();
            }
        }

        [HttpGet]
        public Task Get(int id)
        {
            using (var context = new RegistryContext())
            {
                return context.Tasks.FirstOrDefault(x => x.Id == id);
            }
        }

        [HttpPost]
        public Task Post(Task task)
        {
            using (var context = new RegistryContext())
            {
                context.Tasks.Add(task);
                context.SaveChanges();
                return task;
            }
        }

        [HttpPut]
        public Task Put(Task task)
        {
            using (var context = new RegistryContext())
            {
                var taskAct = context.Tasks.FirstOrDefault(x => x.Id == task.Id);
                taskAct.Name = task.Name;
                taskAct.Description = task.Description;
                taskAct.EmployeeId = task.EmployeeId;
                context.SaveChanges();
                return task;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new RegistryContext())
            {
                var employeeDel = context.Tasks.FirstOrDefault(x => x.Id == id);
                context.Tasks.Remove(employeeDel);
                context.SaveChanges();
                return true;
            }
        }
    }
}
