using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class AnnualLeaveCreateEntity
    {
        public string PayType { get; set; }
        public string Position { get; set; }
        public int Paydate { get; set; }
        public string Year { get; set; }
        public string Sys { get; set; }
        public float PAYABLEDAYS { get; set; }
        public string login { get; set; }
    }
}