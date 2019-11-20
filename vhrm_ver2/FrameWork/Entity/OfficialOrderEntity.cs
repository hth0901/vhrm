using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class OfficialOrderEntity
    {
        public string EmpId { get; set; }
        public string OFFICIAL_NO { get; set; }
        public string OFFICIAL_DATE { get; set; }
        public string OFFICIAL_TYPE { get; set; }
        public string CORPORATION { get; set; }
        public string DEPARTMENT { get; set; }
        public string TEAM { get; set; }
        public string SECTION { get; set; }
        public string PAYMENT_TYPE { get; set; }
        public string POSITION { get; set; }
        public string JOBCODE { get; set; }
        public string JOBFIELD { get; set; }
        public string JOBSTEP { get; set; }
        public string CONTRACTNO { get; set; }
        public string WORK_STATUS { get; set; }
        public string WORK_STATEMENT { get; set; }
        public string CONFIRM_IS { get; set; }
        public string CONFIRM_UID { get; set; }
        public DateTime CONFIRM_DT { get; set; }
        public string CREATE_UID { get; set; }

    }
}