using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class AbsenceDetailEntity
    {
        public string FromDate { get; set; }
        public string SeqNo { get; set; }
        public string Clsid { get; set; }
        public string ItemNm { get; set; }
        public string ParentId { get; set; }
        public string ToDate { get; set; }
        public string Pbym { get; set; }
        public string Condition { get; set; }
        public string Remark { get; set; }
        public string ConfirmIs { get; set; }
        public string ConfirmUid { get; set; }
        public string SysEmpId { get; set; }
        public float TotalDate { get; set; }
        public int Version { get; set; }
        public string IsConfirm { get; set; }
        public string Condition_Time { get; set; }
        public string IS_FOCUS { get; set; }
    }
}