using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class PaymentAnnualLeave
    {
        
        public string SysEmpid { get; set; }
        public string Startdate { get; set; }
        public string Enddate { get; set; }
        public int Payday { get; set; }
        public int Adjustpayday { get; set; }
        public int LeaveDays { get; set; }
        public int UsedDays { get; set; }
        public int RemainDays { get; set; }
        public float BasicSalary { get; set; }
        public float Allowance { get; set; }
        public string ISCONFIRM { get; set; }
        public string LoginId { get; set; }
        public string PBYY { get; set; }
    }
}