using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class SanctionListAccess
    {
        public static DataTable SanctionList_Query(string pCorporation, string pEmployeeId, string pFromDate, string pToDate, string pSanctionKind, string pReasonKind)
        {
            string spName = "PKHR_HRINFO.sp_LEAVE_LIST_Qry";
            OracleParameter[] param = new OracleParameter[7];
            param[0] = new OracleParameter("pCorporation", pCorporation ?? "");
            param[1] = new OracleParameter("pEmployeeId", pEmployeeId);
            param[2] = new OracleParameter("pFromDate", pFromDate);
            param[3] = new OracleParameter("pToDate", pToDate);
            param[4] = new OracleParameter("pSanctionKind", pSanctionKind ?? "");
            param[5] = new OracleParameter("pReasonKind", pReasonKind ?? "");
            param[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

          return DBHelper.getDataTable_SP(spName, param);
        }

        public DataTable SanctionList_Save(string pWorkingTag, SanctionListEntity _entity, string pLoginId)
        {
            DataTable dtData = new DataTable();
            string spName = "PKHR_HRINFO.sp_LEAVE_LIST_Save";
            OracleParameter[] param = new OracleParameter[11];
            param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            param[1] = new OracleParameter("pEmployeeId", _entity.EMPID);
            param[2] = new OracleParameter("pSerialNo", _entity.DSERIAL);
            param[3] = new OracleParameter("pDisciplineKind", _entity.DISCIPLINEKIND ?? "");
            param[4] = new OracleParameter("pReasonKind", _entity.REASONKIND ?? "");
            param[5] = new OracleParameter("pFromDate", _entity.FROMDATE ?? "");
            param[6] = new OracleParameter("pToDate", _entity.UNTILDATE ?? "");
            param[7] = new OracleParameter("pMonthCount", _entity.MONTHSCOUNT);
            param[8] = new OracleParameter("pRemark", OracleType.NVarChar) { Value = _entity.REMARKS ?? "" };
            param[9] = new OracleParameter("pLoginID", pLoginId ?? "");
            param[10] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP(spName, param);
            return dtData;
        }
    }
}