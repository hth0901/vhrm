/*
 * author: Nguyen Duy Hung
 * Date: 2017.04.19
 * Desc: Page for batch transfer position (department) of employee
*/
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class aTransferDepartmentAccess
    {
        public static DataTable Get_SourceData(string deptcode, string UserId)
        {
            string sp = "PK_HR_TRANSFER_POSITION.SP_GET_EMPLOYEE_SOURCE";

            var p = new OracleParameter[3];
            p[0] = new OracleParameter("PDEPTCODE", deptcode);
            p[1] = new OracleParameter("PUSERID", UserId);
            p[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        //Submit string to database
        public static DataTable Submit_StringData(string ValidityDate, string Key, string UserId)
        {
            string sp = "PK_HR_TRANSFER_POSITION.SP_TRANSFER_POSITION_LIST";

            var p = new OracleParameter[4];
            p[0] = new OracleParameter("PVALIDITYDATE", ValidityDate);
            p[1] = new OracleParameter("PKEY", Key);
            p[2] = new OracleParameter("PUSERID", UserId);
            p[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }
    }
}