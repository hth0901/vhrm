using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class TimeSheetItemAccess
    {
        public static DataTable load_TimeSheetItem()
        {
            OracleParameter []para = new OracleParameter[1];
            para[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKTIMESHEET_ITEM.SP_LOAD_TIME_SHEET_ITEM_QUERY",para);
        }

        public static DataTable TimeSheetItemSave(string workingTag, string ItemID, string ItemNM, string ItemNMVN,
            string MethodPay, string Symbol, string IsAbsence, string IsLeave, string IsInsurance, int orderindex, string pUID)
        {
            string spName = "PKTIMESHEET_ITEM.sp_INSERT_TIME_SHEET_ITEM";
            OracleParameter[] parameters = new OracleParameter[12];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag);
            parameters[1] = new OracleParameter("pITEMID", ItemID);
            parameters[2] = new OracleParameter("pITEMNM", ItemNM);
            parameters[3] = new OracleParameter("pITEMNMVN", ItemNMVN);
            parameters[4] = new OracleParameter("pMETHODPAY", MethodPay);
            parameters[5] = new OracleParameter("pSYMBOL", Symbol);
            parameters[6] = new OracleParameter("pISABSENCE", IsAbsence);
            parameters[7] = new OracleParameter("pIsLeave", IsLeave);
            parameters[8] = new OracleParameter("pIsInsurance", IsInsurance);
            parameters[9] = new OracleParameter("pORDERINDEX", orderindex);
            parameters[10] = new OracleParameter("pUID", pUID);
            parameters[11] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
    }
}