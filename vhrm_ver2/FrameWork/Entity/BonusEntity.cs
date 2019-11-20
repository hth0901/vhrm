using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class BonusEntity
    {
        public string SYS_EMPID { get; set; }
        public string PBYY { get; set; }
        public string PBMM { get; set; }
        public string BONUSKIND { get; set; }
        public string HIREDDATE { get; set; }
        public double? BASICSALARY { get; set; }
        public double? BONUS { get; set; }
        public string CLOSING { get; set; }
        public string PAYDATE { get; set; }
        public int WORKMONTHS { get; set; }
        public int CNTLETTER { get; set; }
        public string CREATE_UID { get; set; }
        public string CREATE_DT { get; set; }
        public string UPDATE_UID { get; set; }
        public string UPDATE_DT { get; set; }
        public string TEMP0 { get; set; }
        public double? PIT_APPEND { get; set; }
        public string REMARK { get; set; }
    }
}