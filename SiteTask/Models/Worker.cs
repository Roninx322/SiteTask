using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteTask.Models
{
    public class Worker
    {
        public int WorkerId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}