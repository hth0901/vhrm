using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.ViewModels
{
    public class DeptViewModel
    {
        public string DEPTCODE { get; set; }
        public string DEPTNAME { get; set; }
        public string DEPTPARENT { get; set; }
        public string DEPTLEVEL { get; set; }
        public string ORDERINDEX { get; set; }
        public string ISACTIVE { get; set; }
        public string REMARK { get; set; }
        public string DEPTCODEOLD { get; set; }
        public string COMPCODE { get; set; }
        public string CREATE_UID { get; set; }
        public string CREATE_DT { get; set; }
        public string UPDATE_UID { get; set; }
        public string UPDATE_DT { get; set; }
        public List<DeptViewModel> DeptViewModels { get; set; }
    }
}