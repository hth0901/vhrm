

using System;

namespace vhrm.FrameWork.Entity
{
    [Serializable]
    public class FamilyInfoEntity
    {
        // TABLE :  T_00_FRMT
        public string EMPID { get; set; }
        public double FSERIAL { get; set; }
        public string RELATIONSHIP { get; set; }
        public string FULLNAME { get; set; }
        public string STATUS { get; set; }
        public string IDENTITYCARD { get; set; }
        public string WORKFOR { get; set; }
        public string DEPARTMENT { get; set; }
        public string POSITION { get; set; }
        public string PROVINCE { get; set; }
        public string ADDRESS { get; set; }
        public string HOMETEL { get; set; }
        public string MOBILE { get; set; }
        public string REMARKS { get; set; }
        public string CONFIRMCHECK { get; set; }
        public string CONFIRMID { get; set; }
        public DateTime CONFIRMDATE { get; set; }
        public string VALIDITYFROM { get; set; }
        public string pVALIDITYTO { get; set; }
        public string BIRTHDATE { get; set; }
        public string PITSUBTRACT { get; set; }
        public string IS_CHILDCARE { get; set; }
        public string CHILDCARE_START { get; set; }
        public string CHILDCARE_END { get; set; }

    }
}