﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteTask.Models
{
    public class Time
    {
        public int TimeId { get; set; }
        public int TaskId { get; set; }
        public int WorkerId { get; set; }
        public DateTime Date { get; set; }
        public int Hours { get; set; }
        public int Group { get; set; }
    }
}