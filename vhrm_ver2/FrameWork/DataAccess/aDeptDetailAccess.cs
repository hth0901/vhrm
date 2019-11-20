using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.DataAccess
{
    public class aDeptDetailAccess
    {
        public static DataTable getAllDeptDetail()
        {
            OracleParameter[] _sqlParam = new OracleParameter[1];
            _sqlParam[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("GET_EMP_DEPT", _sqlParam);
            return table;
        }
    }
}