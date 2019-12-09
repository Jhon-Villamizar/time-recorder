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
                return context.Employees.FirstOrDefault(x=>x.id==id);
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
                var employeeAct = context.Employees.FirstOrDefault(x => x.id == employee.id);
                employeeAct.name = employee.name;
                employeeAct.password = employee.password;
                employeeAct.tasks = employee.tasks;
                context.SaveChanges();
                return employee;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new RegistryContext())
            {
                var employeeDel = context.Employees.FirstOrDefault(x => x.id == id);
                context.Employees.Remove(employeeDel);
                context.SaveChanges();
                return true;
            }
        }

        //funcion que busca un usuario por email
        [HttpGet]
        public int Login(string name, string password)
        {
            using (var context = new RegistryContext())
            {
                var employee = context.Employees.FirstOrDefault(x => x.name == name);
                if (name == "" || name == null || password == "" || password == null)
                {
                    return 0;
                }
                else
                {
                    if (employee == null)
                    {
                        return 0;
                    }
                    if (employee.name == name && employee.password == password)
                    {
                        return employee.id;
                    }
                    return 0;
                }
            }
        }
    }
}
