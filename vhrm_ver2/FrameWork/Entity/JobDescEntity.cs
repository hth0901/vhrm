using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class JobDescEntity
    {
        public float PTimeyear { get; set; }
        public string PRegisterid { get; set; }
        public float PTimeweek { get; set; }
        public string PDescription { get; set; }
        public string PDocument { get; set; }
        public float PTimemonth { get; set; }
        public float PAverage { get; set; }
        public string PEMPID { get; set; }
        public float PTimeday { get; set; }
        public string PApproval { get; set; }
        public string PJobtitle { get; set; }
        public int PJdid { get; set; }
    }
}