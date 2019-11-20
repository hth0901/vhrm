using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class RewardEntity
    {
        public string pEmpID { get; set; }
        public string RewarDate { get; set; }
        public string pLogin { get; set; }
        public string Remark  { get; set; }     
        public string Rewardkind    { get; set; }
        public float Amount { get; set; }
        public string isConfirm { get; set; }
    }
}