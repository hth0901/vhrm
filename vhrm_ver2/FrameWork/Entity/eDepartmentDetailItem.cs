using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class eDepartmentDetailItem
    {
        public string LEVEL1_CODE { get; set; }
        public string LEVEL1_NAME { get; set; }
        public string LEVEL2_CODE { get; set; }
        public string LEVEL2_NAME { get; set; }
        public string LEVEL3_CODE { get; set; }
        public string LEVEL3_NAME { get; set; }
        public string LEVEL4_CODE { get; set; }
        public string LEVEL4_NAME { get; set; }
        public string LEVEL5_CODE { get; set; }
        public string LEVEL5_NAME { get; set; }
        public string DEPTLEVEL { get; set; }
        public string DEPTCODE { get; set; }
        public string DEPTNAME { get; set; }
    }

    public class eEmployeeDept
    {
        public string SYS_EMPID { get; set; }
        public string EMPID { get; set; }
        public string EMPNAME { get; set; }
        public string DEPTCODE { get; set; }
        public string DEPTNAME { get; set; }
    }
}