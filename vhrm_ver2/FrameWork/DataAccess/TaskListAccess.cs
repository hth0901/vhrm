using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class TaskListAccess
    {
        public DataTable LoadDataGrid(string Corporation, string sysEmpid, string FromDate, string ToDate,string Role, string Task)
        {
            OracleParameter[] _sqlParam = new OracleParameter[7];
            _sqlParam[0] = new OracleParameter("pCorporation", Corporation);
            _sqlParam[1] = new OracleParameter("pEmployeeId", sysEmpid);
            _sqlParam[2] = new OracleParameter("pFromDate", FromDate);
            _sqlParam[3] = new OracleParameter("pToDate", ToDate);
            //_sqlParam[4] = new OracleParameter("pRoleGroup", RoleGroup);
            _sqlParam[4] = new OracleParameter("pRole", Role);
            _sqlParam[5] = new OracleParameter("pTask", Task);
            _sqlParam[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_TASKLIST.SP_TASKLIST_QRY", _sqlParam);
        }
    }
}