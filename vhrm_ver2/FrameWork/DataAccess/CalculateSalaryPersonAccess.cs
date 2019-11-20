using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class CalculateSalaryPersonAccess
    {
        public DataTable GetEmp(  string pDeptCd,string pWorkingStatus,string planguage,string yM)
        {
            string spName = "PKPAYROLL_CalSalaryPerSon.sp_HREMP_Master_Query";
            //string spName = "HR.sp_HRInfo_Qry";
            OracleParameter[] param = new OracleParameter[5];
           param[0] = new OracleParameter("pDeptCd", pDeptCd);
           param[1] = new OracleParameter("pWorkingStatus", pWorkingStatus);
           param[2] = new OracleParameter("planguage", planguage);
           param[3] = new OracleParameter("YM", yM);
           param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
       
        public  DataSet QueryMaste_Detail_Salary(string pDeptCode, string pSysempid, string pWstatus, string pMonth)
        {
            string query = "PKPAYROLL_CalSalaryPerSon.SP_LOAD_MasterDETAILSalary";
            var parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("PDEPTCODE", pDeptCode);
            parameters[1] = new OracleParameter("PSYSEMPIS", pSysempid);
            parameters[2] = new OracleParameter("PWSTATUS", pWstatus);
            parameters[3] = new OracleParameter("PMONTH", pMonth);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[5] = new OracleParameter("T_TABLE_M", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataSet_SP(query, parameters);
         }
       /* public  DataTable Save(CalculateSalaryPersonEntity entity)
        {
            OracleParameter[] parameters = new OracleParameter[21];
            parameters[0] = new OracleParameter("pSysEmpid", entity.SysEmpid);
            parameters[1] = new OracleParameter("pPbyy", entity.Pbyy);
            parameters[2] = new OracleParameter("pPbmm", entity.Pbmm);
            parameters[3] = new OracleParameter("pAlowhousing", entity.Alowhousing);
            parameters[4] = new OracleParameter("pAllowSeniority", entity.AllowSeniority);
            parameters[5] = new OracleParameter("pAllowPosition", entity.AllowPosition);
            parameters[6] = new OracleParameter("pAllowProductivity", entity.AllowProductivity);
            parameters[7] = new OracleParameter("pAllowMultskill", entity.AllowMultskill);
            parameters[8] = new OracleParameter("pAlowLanguage", entity.AlowLanguage);
            parameters[9] = new OracleParameter("pAllowAttendance", entity.AllowAttendance);
            parameters[10] = new OracleParameter("pAllowH3", entity.AllowH3);
            parameters[11] = new OracleParameter("pALLOWOTHER", entity.ALLOWOTHER);
            parameters[12] = new OracleParameter("pnsurancerefund", entity.Insurancerefund);
            parameters[13] = new OracleParameter("pInsociallb", entity.Insociallb);
            parameters[14] = new OracleParameter("pInhealthlb", entity.Inhealthlb);
            parameters[15] = new OracleParameter("pInunEmploymentlb", entity.InunEmploymentlb);
            parameters[16] = new OracleParameter("pLaborFundlb", entity.LaborFundlb);
            parameters[17] = new OracleParameter("pNoreturnhealthcard", entity.Noreturnhealthcard);
            parameters[18] = new OracleParameter("pLogin", entity.Login);
            parameters[19] = new OracleParameter("pRemarks", entity.Remarks);
            parameters[20] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKPAYROLL_CalSalaryPerSon.SP_T_PR_SLR_ADJUST_Save", parameters);
        }*/
    }
}