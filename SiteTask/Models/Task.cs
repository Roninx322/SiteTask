using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteTask.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Comment { get; set; }
    }
}