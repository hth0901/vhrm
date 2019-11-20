using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class PaymentAMTEntity
    {
        public string SysEMPID { get; set; }
        public string Fromdate { get; set; }
        public string ToDate { get; set; }
        public float JobAllow { get; set; }
        public float MultiSkill { get; set; }
        public float LanguageSkill { get; set; }
        public float Housing { get; set; }
        public float Position { get; set; }
        public float H3 { get; set; }
        public float LaborFun { get; set; }
        public float BasicSalaryUp { get; set; }
        public float Others { get; set; }
        public string LoginUi { get; set; }
        public string Remarks { get; set; }

        public string Itemid { get; set; }
        public float Amt { get; set; }
        
    }
}