﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class SupervisorViewModel
    {
        public string SYS_EMPID { get; set; }
        public string DEPTCODEGEO { get; set; }
        public string EMPID { get; set; }
        public string EMPNAME { get; set; }
        public string EMAIL { get; set; }
        public string POSITION { get; set; }
        public string IMAGE { get; set; }
    }
    public class FunctionerViewModel
    {
        public string SYS_EMPID { get; set; }
        public string DEPTCODEFUN { get; set; }
        public string EMPID { get; set; }
        public string EMPNAME { get; set; }
        public string EMAIL { get; set; }
        public string POSITION { get; set; }
        public string IMAGE { get; set; }
    }
}