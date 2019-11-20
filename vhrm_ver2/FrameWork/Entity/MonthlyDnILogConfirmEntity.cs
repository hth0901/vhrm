using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class MonthlyDnILogConfirmEntity
    {
        public string Sysempid { get; set; }
        public string Pbym { get; set; }
        public string Startdate { get; set; }
        public string Startto { get; set; }
        public float Basicsalary { get; set; }
        public float Wkdays { get; set; }
        public float Deductdays { get; set; }
        public float Ot30 { get; set; }
        public float Ot100 { get; set; }
        public float Ot150 { get; set; }
        public float Ot155 { get; set; }
        public float Ot195 { get; set; }
        public float Ot200 { get; set; }
        public float Ot300 { get; set; }
        public float Ot390 { get; set; }
        public string ConfirmIs { get; set; }
        public string ConfirmUid { get; set; }
        public string User { get; set; }
    }
}