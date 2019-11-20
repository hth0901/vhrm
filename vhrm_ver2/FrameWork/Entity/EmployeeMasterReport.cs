using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class EmployeeMasterReport
    {
        public string REPORTCD { get; set; }
        public string SYS_EMPID { get; set; }
        public string DEPTCODEGEO { get; set; }
        public string SYS_EMPIDGEO { get; set; }
        public string DEPTCODEFUN { get; set; }
        public string SYS_EMPIDFUN { get; set; }
        public string APPLYDATE { get; set; }
        public string ISACTIVE { get; set; }
        public string POSITION { get; set; }
        public string SKILL { get; set; }
        public string REMARK { get; set; }
        public string LEVELGEO { get; set; }
        public string LEVELFUN { get; set; }
        public string CREATE_UID { get; set; }
        public string CREATE_DT { get; set; }
        public string UPDATE_UID { get; set; }
        public string UPDATE_DT { get; set; }
    }
}