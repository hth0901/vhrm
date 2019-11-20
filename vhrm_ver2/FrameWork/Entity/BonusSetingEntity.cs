using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class BonusSetingEntity
    {
        public string Ver_id { get; set; }
        public string Kind_Bonus { get; set; }
        public string Join_from { get; set; }
        public string Join_to { get; set; }
        public float Rate { get; set; }
        public float Amount { get; set; }
        public string Discipline_from { get; set; }
        public string Discipline_to { get; set; }
        public string Discipline1{ get; set; }
        public float Discipline1_rate { get; set; }
        public string Discipline2 { get; set; }
        public float Discipline2_rate { get; set; }
        public string UID { get; set; }
        public string DEPTCODE { get; set; }
        public string ConfirmIs { get; set; }
        public string ConfirmUID { get; set; }

        //add by ndhung 2017.04.17 -> thêm chức năng tính PIT cho bonus, và tính pit theo pit lương
        public string IS_BONUS_PIT { get; set; }
        public string IS_SALARY_PIT { get; set; }
        public string SALARY_MONTH { get; set; }
    }
}