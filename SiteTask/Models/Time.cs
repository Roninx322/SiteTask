using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteTask.Models
{
    public class Time
    {
        public int TimeId { get; set; }
        public int TaskId { get; set; }
        public int WorkersId { get; set; }
        public DateTime BeginningDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}