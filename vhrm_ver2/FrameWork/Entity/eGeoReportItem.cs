using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class eGeoReportItem
    {
        public string GEOREPORTCD { get; set; }
        public string DEPTCODE { get; set; }
        public string SYS_EMPID { get; set; }
        public string EMPNAME { get; set; }
        public string EMPID { get; set; }
        public DateTime APPLYDATE { get; set; }
        public bool ISACTIVE { get; set; }
        public string POSITION { get; set; }
        public string SKILL { get; set; }
        public string REMARK { get; set; }
        public string GEOREPORTLEVEL { get; set; }
        public string CREATE_UID { get; set; }
        public string CREATE_DT { get; set; }
        public string UPDATE_UID { get; set; }
        public string UPDATE_DT { get; set; }
    }
}