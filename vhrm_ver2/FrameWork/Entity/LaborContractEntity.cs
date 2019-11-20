/*
 * Author:     NguuNguyen
 * Create Date: 2012-03-07
 * Description: 
 * ---------------------------------
 * Deveoper:    Phuong
 * Date:        2013-03-20
 */

using System;
using System.Data;

namespace vhrm.FrameWork.Entity
{
    [Serializable]
    public class LaborContractEntity
    {
        public  const string LABOURCONTRACT_APPENDIX = "1";
        public  const string LABOURCONTRACT_CONTRACT = "0";
        public const string OFFICIAL_DEFINITE = "DF";
        public const string OFFICIAL_REDEFINITE = "RF";
        public const string OFFICIAL_INDEFINITE = "ID";
        public const string TEMPERARY = "T";
        public const string SEASON = "S";

        public LaborContractEntity()
        { }

        public LaborContractEntity(DataRow dr)
        {
            ContractNo = dr["CONTRACTNO"].ToString();
            ValidityFrom = dr["VALIDITYFROM"].ToString();
            try {
                RealValidityFrom = DateTime.ParseExact(ValidityFrom, "dd-MM-yyyy", null);
            }
            catch(Exception){}
            Appendix = dr["APPENDIX"].ToString();
            ContractKind = dr["CONTRACTKIND"].ToString();
            Empid = dr["EMPID"].ToString();
            
        }

        public string FixedContractNo { get; set; }
        public DateTime RealValidityFrom { get; set; }
        public string Empid { get; set; }
        public string Sys_EmpID { get; set; }
        public string ContractNo { get; set; }
        public string ContractKind { get; set; }
        public string ContractCD { get; set; }
        public string Appendix { get; set; }
        public string ValidityFrom { get; set; }
        public string ExtendTo { get; set; }
        public string JobCode { get; set; }
        public string JobDescription{ get; set; }
        public string StepNo { get; set; }
        public string StepLevel { get; set; }
        public double BasicSalary { get; set; }
        //public double ContractSalary { get; set; }
        public string SignedDate { get; set; }
        public string ConfirmCheck { get; set; }
        public string ConfirmID { get; set; }
        public string ConfirmDate { get; set; }
        public string ResponsibilityCD{ get; set;}
        public string Responsibility { get; set; }
        public string ResponsibilityOther { get; set; }

        public string ContractId { get; set; } //add by ndhung 2017.12.05 -> dùng để update, confirm, print chứ ko dùng contractno nữa. contractno bị trùng
    }
}