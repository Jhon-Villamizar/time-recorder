using ServiceTimeRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceTimeRecord.Controllers
{
    public class EmployeeController : ApiController
    {
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            using (var context = new RegistryContext())
            {
                return context.Employees.ToList();
            }
        }

        [HttpGet]
        public Employee Get(int id)
        {
            using (var context = new RegistryContext())
            {
                return context.Employees.FirstOrDefault(x=>x.Id==id);
            }
        }

        [HttpPost]
        public Employee Post(Employee employee)
        {
            using (var context = new RegistryContext())
            {
                context.Employees.Add(employee);
                context.SaveChanges();
                return employee;
            }
        }

        [HttpPut]
        public Employee Put(Employee employee)
        {
            using (var context = new RegistryContext())
            {
                var employeeAct = context.Employees.FirstOrDefault(x => x.Id == employee.Id);
                employeeAct.Name = employee.Name;
                employeeAct.Password = employee.Password;
                employeeAct.Tasks = employee.Tasks;
                context.SaveChanges();
                return employee;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new RegistryContext())
            {
                var employeeDel = context.Employees.FirstOrDefault(x => x.Id == id);
                context.Employees.Remove(employeeDel);
                context.SaveChanges();
                return true;
            }
        }

        //funcion que busca un usuario por email
        [HttpGet]
        public bool Login(string name, string password)
        {
            using (var context = new RegistryContext())
            {
                var employee = context.Employees.FirstOrDefault(x => x.Name == name);
                if (name == null)
                {
                    return false;
                }
                else
                {
                    if (employee.Name == name && employee.Password == password)
                    {
                        return true;
                    }
                    return false;
                }
            }
        }
    }
}
