using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SiteTask.Models
{
    public class JobContext: DbContext
    {
        //public JobContext() : base("DefaultConnection")
        //{ }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Time> Times { get; set; }
        
    }
}