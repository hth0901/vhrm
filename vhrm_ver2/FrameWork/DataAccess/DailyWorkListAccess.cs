using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Data;

namespace vhrm.FrameWork.DataAccess
{
    public class DailyWorkListAccess
    {
        public static DataSet loadDailyWorkList(string corporation, string employeeId, string pMonth)
        {
            string query = "PKTIMESHEET_DAILYLOGCONFIRM.SP_DAILY_WORK_LIST_QUERY";
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("pCorporation", corporation);
            parameters[1] = new OracleParameter("pEmployeeId", employeeId);
            parameters[2] = new OracleParameter("pMonth", pMonth);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[4] = new OracleParameter("T_TABLE2", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataSet_SP(query, parameters);
        }
        public static DataTable PrintTotalWorkingTime(string corporation,string sys_empid, string Month)
        {
            string query = "SP_TOTAL_WORKINGTIME";
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("pCorporation", corporation);
            parameters[1] = new OracleParameter("pEmp", sys_empid);
            parameters[2] = new OracleParameter("pMonth", Month);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        
    }
}