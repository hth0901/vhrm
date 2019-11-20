using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class EmployeeDiagramViewModel
    {
        public string SYS_EMPID { get; set; }
        public string EMPID { get; set; }
        public string EMPNAME { get; set; }
        public string Image { get; set; }
        public string ColorScheme { get; set; }
        public string SYS_EMPIDGEO { get; set; }
        public string SYS_EMPIDFUN { get; set; }
        public List<EmployeeDiagramViewModel> Items;
    }
}