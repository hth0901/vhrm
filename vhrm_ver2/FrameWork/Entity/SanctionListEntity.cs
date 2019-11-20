using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class SanctionListEntity
    {
        public string EMPID { get; set; }
        public double DSERIAL { get; set; }
        public string DISCIPLINEKIND { get; set; }
        public string DISCIPLINEFORM { get; set; }
        public string REASONKIND { get; set; }
        public string FROMDATE { get; set; }
        public string UNTILDATE { get; set; }
        public double MONTHSCOUNT { get; set; }
        public string REASON { get; set; }
        public string REMARKS { get; set; }
        public string CONFIRMCHECK { get; set; }                    
    }
}