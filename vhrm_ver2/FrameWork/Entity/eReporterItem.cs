using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class eReporterItem
    {
        public string EMPNAME { get; set; }
        public string SYS_EMPID { get; set; }
        public string EMPID { get; set; }
        public string DEPTNODE_CODE { get; set; }
        public string DEPTCODE { get; set; }
        public string FUNCNODE_CODE { get; set; }
        public string FUNCDEPT { get; set; }
        public string LEVEL0 { get; set; }
        public string LEVEL1 { get; set; }
        public string GEO_RP_CODE { get; set; }
        public string GEO_RP_EMPID { get; set; }
        public string GEO_RP_EMPNAME { get; set; }
        public string FUNC_RP_CODE { get; set; }
        public string FUNC_RP_EMPID { get; set; }
        public string FUNC_RP_EMPNAME { get; set; }
    }
}