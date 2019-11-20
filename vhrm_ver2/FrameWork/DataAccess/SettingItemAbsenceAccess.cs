using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class SettingItemAbsenceAccess
    {
        public static DataTable Getdata(string pParentID)
        {
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("pParentID", pParentID);
            _sqlParam[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_SETTING_ITEM_ABSENCE.SP_SETTING_ITEM_ABSENCE_QUERY", _sqlParam);
        }

        public static DataTable Save(string pWorkingTag ,string pCLSID ,string pITEMNM, string pITEMNMVN ,string pPARENTID, int pORDERINDEX,string pUID)
        {
            OracleParameter[] _sqlParam = new OracleParameter[8];
            _sqlParam[0] = new OracleParameter("pWorkingTag", pWorkingTag);
            _sqlParam[1] = new OracleParameter("pCLSID", pCLSID);
            _sqlParam[2] = new OracleParameter("pITEMNM", pITEMNM);
            _sqlParam[3] = new OracleParameter("pITEMNMVN", pITEMNMVN);
            _sqlParam[4] = new OracleParameter("pPARENTID", pPARENTID);
            _sqlParam[5] = new OracleParameter("pORDERINDEX", pORDERINDEX);
            _sqlParam[6] = new OracleParameter("pUID", pUID);
            _sqlParam[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PK_SETTING_ITEM_ABSENCE.sp_SAVE_SETTING_ITEM_ABSENCE", _sqlParam);
        }
    }
}