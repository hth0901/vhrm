using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.DataAccess
{
    public class aGeoReportAccess
    {
        public static DataTable getGeoReportByDept(string deptcode)
        {
            DataTable dtResult = new DataTable();
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("DEPTCODE", deptcode);
            _sqlParam[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("HR_GEO_REPORT.SP_GET_GEO_REPORT_BY_DEPT", _sqlParam);
            return table;
        }
    }
}