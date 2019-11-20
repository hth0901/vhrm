using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Data;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class CalculateSalaryAccess
    {

        public static List<EmpEntity> LoadGridSourceList(string pDeptCd, string planguage, string pmonth, string pStatus)
        {
            List<EmpEntity> arrEmpEntity = new List<EmpEntity>();
            string spName = "PKPayRoll_CalculateSalary.sp_Calculate_Qry";
            OracleDataReader reader;
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("pDeptCd", pDeptCd);
            param[1] = new OracleParameter("planguage", planguage);
            param[2] = new OracleParameter("pMonth", pmonth);
            param[3] = new OracleParameter("pStatus", pStatus);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            reader = DBHelper.getDataReader_SP(spName, param);
            while (reader.Read())
            {
                //Create a new part
                EmpEntity empEntity = new EmpEntity(reader);
                arrEmpEntity.Add(empEntity);
            }
            return arrEmpEntity;
        }
        //Load data for comboxYearMonth from T_PR_MONTHLY by corporation
        public static  DataTable LoadComBoxYearMonth(string corporation)
        {
            string spName = "PKPayRoll_CalculateSalary.sp_T_PR_MONTHLY_Qry";
           OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pCorporation", corporation);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, param); 
        }

        /*Calculate bonus*/
        //sp_Calculate_Bonus(pDeptCd nvarchar2,pMonth nvarchar2,  pEmpId nvarchar2,T_TABLE OUT C_CURSOR)
        public static DataTable Calculate_Bonus(string pDeptCd, string pMonth, string pEmpId, string pLoginId)
        {
            string spName = "PKPAYROLL_CALCULATEBONUS.sp_Calculate_Bonus";
            DataTable dsData = new DataTable();
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("pDeptCd", pDeptCd);
            param[1] = new OracleParameter("pMonth", pMonth);
            param[2] = new OracleParameter("pEmpId", pEmpId);
            param[3] = new OracleParameter("pLoginId", pLoginId);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dsData = DBHelper.getDataTable_SP(spName, param);
            return dsData;
        }

        /*Calculate Salary*/
        //sp_Calculate_Salary(pDeptCd nvarchar2,pMonth nvarchar2,pEmpId nvarchar2, pLoginId nvarchar2
        public static DataTable Calculate_Salary(string pDeptCd, string pMonth, string pEmpId, string pLoginId, string pStatus)
        {
            string spName = "PKPAYROLL_CALCULATESALARY.sp_Calculate_Salary";
            DataTable dsData = new DataTable();
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("pDeptCd", pDeptCd);
            param[1] = new OracleParameter("pMonth", pMonth);
            param[2] = new OracleParameter("pEmpId", pEmpId);
            param[3] = new OracleParameter("pLoginId", pLoginId);
            param[4] = new OracleParameter("pStatus", pStatus);
            param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dsData = DBHelper.getDataTable_SP(spName, param);
            return dsData;
        }

        /*Cancel Salary*/
        //sp_Cancel_Salary(pDeptCd nvarchar2,pMonth nvarchar2,  pEmpId nvarchar2,T_TABLE OUT C_CURSOR)
        public static DataTable Cancel_Salary(string pDeptCd, string pMonth, string pEmpId, string pLoginId)
        {
            string spName = "PKPAYROLL_CALCULATESALARY.sp_Cancel_Salary";
            DataTable dsData = new DataTable();
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("pDeptCd", pDeptCd);
            param[1] = new OracleParameter("pMonth", pMonth);
            param[2] = new OracleParameter("pEmpId", pEmpId);
            param[3] = new OracleParameter("pLoginId", pLoginId);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dsData = DBHelper.getDataTable_SP(spName, param);
            return dsData;
        }

        /*Cancel bonus*/
        //sp_Cancel_Bonus(pDeptCd nvarchar2,pMonth nvarchar2,  pEmpId nvarchar2,T_TABLE OUT C_CURSOR)
        public static DataTable Cancel_Bonus(string pDeptCd, string pMonth, string pEmpId, string pLoginId)
        {
            string spName = "PKPAYROLL_CALCULATEBONUS.sp_Cancel_Bonus";
            DataTable dsData = new DataTable();
            OracleParameter[] param = new OracleParameter[5];
            param[0] = new OracleParameter("pDeptCd", pDeptCd);
            param[1] = new OracleParameter("pMonth", pMonth);
            param[2] = new OracleParameter("pEmpId", pEmpId);
            param[3] = new OracleParameter("pLoginId", pLoginId);
            param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dsData = DBHelper.getDataTable_SP(spName, param);
            return dsData;
        }
    }
}