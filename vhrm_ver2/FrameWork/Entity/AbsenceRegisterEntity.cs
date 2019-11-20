using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class AbsenceRegisterEntity
    {
        public string Sysempid { get; set; }
        public string Seqno { get; set; }
        public string Fromdate { get; set; }
        public string Todate { get; set; }
        public float Totalday { get; set; }
        public float Annualday { get; set; }
        public string Reason { get; set; }
        public string Remarks { get; set; }
        public string ConfirmIs { get; set; }
        public string ConfirmUid { get; set; }
        public string UserId { get; set; }
    }
}