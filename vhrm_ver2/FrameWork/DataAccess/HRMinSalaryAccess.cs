using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class HRMinSalaryAccess
    {
        public static DataTable load_MinSalary()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKINSURANCE.SP_LOAD_MIN_SALARY", param);
        }

        public static DataTable Save(string workingTag, string Sid, string StartDate, string Decreeno, float MinSalary, float MaxSalary, string LoginId)
        {
            string spName = "PKINSURANCE.SP_SAVE_MIN_SALARY";
            OracleParameter[] parameters = new OracleParameter[8];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag);
            parameters[1] = new OracleParameter("pSid", Sid);
            parameters[2] = new OracleParameter("pStrDate", StartDate);
            parameters[3] = new OracleParameter("pDecreeno", Decreeno);
            parameters[4] = new OracleParameter("pMinSalary", MinSalary);
            parameters[5] = new OracleParameter("pMaxSalary", MaxSalary);
            parameters[6] = new OracleParameter("pUSER", LoginId);
            parameters[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);

        }
    }
}