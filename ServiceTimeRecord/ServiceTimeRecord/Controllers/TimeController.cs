﻿using ServiceTimeRecord.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServiceTimeRecord.Controllers
{
    public class TimeController : ApiController
    {
        [HttpGet]
        public IEnumerable<Time> Get()
        {
            using (var context = new RegistryContext())
            {
                return context.Times.ToList();
            }
        }

        [HttpGet]
        public Time Get(int id)
        {
            using (var context = new RegistryContext())
            {
                return context.Times.FirstOrDefault(x => x.id == id);
            }
        }

        [HttpPost]
        public Time Post(Time time)
        {
            using (var context = new RegistryContext())
            {
                context.Times.Add(time);
                context.SaveChanges();
                return time;
            }
        }

        [HttpPut]
        public Time Put(Time time)
        {
            using (var context = new RegistryContext())
            {
                var timeAct = context.Times.FirstOrDefault(x => x.id == time.id);
                timeAct.date = time.date;
                timeAct.hours = time.hours;
                timeAct.taskId = time.taskId;
                context.SaveChanges();
                return time;
            }
        }

        [HttpDelete]
        public bool Delete(int id)
        {
            using (var context = new RegistryContext())
            {
                var timeDel = context.Times.FirstOrDefault(x => x.id == id);
                context.Times.Remove(timeDel);
                context.SaveChanges();
                return true;
            }
        }
    }
}
