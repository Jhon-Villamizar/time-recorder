﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServiceTimeRecord.Models
{
    public class RegistryContext : DbContext
    {
        public RegistryContext(): base("ConnRegistryDb")
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Time> Times { get; set; }
    }
}