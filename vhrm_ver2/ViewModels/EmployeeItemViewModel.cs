using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class EmployeeItemViewModel
    {
        public string EMPID { get; set; }
        public string SYS_EMPID { get; set; }
        public string FULLNAME { get; set; }
        public string EMPNAME { get; set; }
        public string DEPARTMENT { get; set; }
        public string STATUS { get; set; }
        public string IDENTITYCARD { get; set; }
        public string RFID { get; set; }
        public string DATEJOIN { get; set; }
    }
}