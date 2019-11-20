using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Data;

namespace vhrm.FrameWork.DataAccess
{
    public class PrintInsuranceReportAccess
    {
        public DataTable QueryPrintReport(string pCategory, string pMotherId)
        {
            string spName = "PKINSURANCE_PrintReport.SP_PrintReport_QUERY";
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("pCategory", pCategory);
            param[1] = new OracleParameter("pMOTHER_ID", pMotherId);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
    }
}