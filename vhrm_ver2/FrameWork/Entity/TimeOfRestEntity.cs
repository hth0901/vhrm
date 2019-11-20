using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class TimeOfRestEntity
    {
        public string p_REGISTERID { get; set; }
        public string p_CONFIRMID { get; set; }
        public string p_EMPID { get; set; }
        public string p_FullName { get; set; }
        public string p_CORPORATION { get; set; }
        public string p_WORKKIND { get; set; }
        public string p_VALIDITYFROM { get; set; }
        public string p_ENDDATE { get; set; }
        public float p_ALEAVEDEDUCTION { get; set;}
        public string p_Remark { get; set; }
        public DateTime p_CONFIRMDATE { get; set; }
        public string p_CONFIRMCHECK { get; set; }
    }
}