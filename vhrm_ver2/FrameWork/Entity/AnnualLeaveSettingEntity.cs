using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class AnnualLeaveSettingEntity
    {
        public string JobCD { get; set; }
        public int Aldays { get; set; }
        public int Alyears { get; set; }
        public string Create_UID { get; set; }
        public string Create_DT { get; set; }
        public string UID { get; set; }
    }
}