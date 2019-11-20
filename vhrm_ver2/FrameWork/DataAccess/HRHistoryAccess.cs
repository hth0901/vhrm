using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class HRHistoryAccess
    {
        //pTblNm varchar2,
        public static DataTable loadHistory(string pEmpID, string planguage)
        {
            OracleParameter [] parameters = new OracleParameter[3];
            //parameters[0] = new OracleParameter("pTblNm", pTblName);
            parameters[0] = new OracleParameter("pEmpId", pEmpID);
            parameters[1] = new OracleParameter("planguage", planguage);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor){Direction = ParameterDirection.Output};
            return DBHelper.getDataTable_SP("PKHR_HISTORY.SP_LOAD_HISTORY", parameters);
        }
    }
}