using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class StaffEntity
    {
        public int Staff_ID { get; set; }
        public int TeamId { get; set; }
        public string Employee_ID { get; set; }
        public DateTime Joined_Date { get; set; }
        public string StaffName { get; set; }
        public string StaffEngName { get; set; }
        public string Staff_Mobile { get; set; }
        public int JobTitle { get; set; }
        public int IsActive { get; set; }
        public string UserCd { get; set; }
    }
}