using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class Official_Order_Entity
    {
        public string EmpId { get; set; }
        public string OFFICIAL_CD { get; set; }
        public string OFFICIAL_DATE { get; set; }
        public string OFFICIAL_NM { get; set; }
        public string OFFICIAL_FROM { get; set; }
        public string OFFICIAL_TO { get; set; }
        public string STATUS { get; set; }
        public string DEPT_CODE { get; set; }
        public string LINE_CD { get; set; }
        public string DISPATCH_CODE { get; set; }
        public string DUTY { get; set; }
        public string JOB_CODE { get; set; }
        public string JOB_FIELD { get; set; }
        //public string JOB_DESC { get; set; }
        public string CONFIRM_IS { get; set; }
        public string TASK { get; set; }
        public string Role { get; set; }
        public string WorkHours { get; set; }
        public string ROAbsence { get; set; }
        public int ID { get; set; }
        public string Remark { get; set; }
        public string OFFICIAL_REASON { get; set; }
        public string DECIDE_NO { get; set; }
    }
}