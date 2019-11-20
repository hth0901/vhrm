/*
 * Author: Tran Cong Tho
 * Create Date: 10/21/2013
 * Desc: Entity fro table T_INS_REG
 * using to registry Social Insurance and Health Insurance
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    [Serializable]
    public class RegisterInsuranceEntity
    {
        public string SYS_EMPID { get; set; }
        public string F_MONTH { get; set; }
        public int F_PHASE { get; set; }
        public string SINO { get; set; }
        public string SIDATE { get; set; }
        public string HINO { get; set; }
        public string HIPLACE { get; set; }
        public string HIDATE { get; set; }
        public string F_REMARK { get; set; }
        public bool IS_CONFIRMED { get; set; }
        public string CONFIRM_UID { get; set; }
        public DateTime? CONFIRM_DT { get; set; }
        public bool IS_COMPLETED { get; set; }
        public string COMPLETE_UID { get; set; }
        public DateTime? COMPLETE_DT { get; set; }
    }
}