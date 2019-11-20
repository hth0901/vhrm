using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class AdvanceSalaryEntity
    {
        public string PEMPID { get; set; }
        public string PAdvMonth { get; set; }
        public string PAdvDate { get; set; }
        public float PAdvAmt { get; set; }
        public string PAdvTyp { get; set; }
        public string PConfirmIs { get; set; }
        public string PConfirmUid { get; set; }
        public DateTime PConfirmDate { get; set; }
        public string PUID { get; set; }
      
    }
}