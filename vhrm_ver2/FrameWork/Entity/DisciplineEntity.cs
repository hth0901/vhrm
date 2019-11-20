

using System;

namespace vhrm.FrameWork.Entity
{
    [Serializable]
    public class DisciplineEntity
    {
        // TABLE :  T_HT_DCPT
        public string EMPID { get; set; }
        public double DSERIAL { get; set; }
        public string DISCIPLINEKIND { get; set; }
        public string DISCIPLINECLSS { get; set; }
        public string DISCIPLINEFORM { get; set; }
        public string REASONKIND { get; set; }
        public string FROMDATE { get; set; }
        public string UNTILDATE { get; set; }
        public double MONTHSCOUNT { get; set; }
        public string REASON { get; set; }
        public string REMARKS { get; set; }
        public string CONFIRMCHECK { get; set; }                       
    }
}