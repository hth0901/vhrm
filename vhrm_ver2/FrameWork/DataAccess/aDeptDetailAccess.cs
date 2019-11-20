using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.DataAccess
{
    public class aDeptDetailAccess
    {
        public static DataTable getAllDeptDetail()
        {
            OracleParameter[] _sqlParam = new OracleParameter[1];
            _sqlParam[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("GET_EMP_DEPT", _sqlParam);
            return table;
        }
    }
}