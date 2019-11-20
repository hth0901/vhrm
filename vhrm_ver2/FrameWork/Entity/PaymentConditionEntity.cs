using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class PaymentConditionEntity
    {
        public string DeptCode { get; set; }
        public string ItemCD { get; set; }
        //public string Corporation { get; set; }
        public string ConditionCD { get; set; }
        public float From { get; set; }
        public float To { get; set; }
        public string ClssContition { get; set; }
        public float Amt { get; set; }
        public float Rate { get; set; }
        public string Remark { get; set; }
        public string UserID { get; set; }
        public string ValidFromdate { get; set; }
        public string ValidTodate { get; set; }
        public string IdNo { get; set; }
        
    }
}