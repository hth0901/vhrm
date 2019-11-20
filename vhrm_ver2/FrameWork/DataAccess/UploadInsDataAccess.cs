using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.DataAccess
{
    public class UploadInsDataAccess
    {
        /// <summary>
        /// Create tabe for insert data from Excel
        /// </summary>
        /// <returns></returns>
        public static DataTable Table_DATAUPLOAD()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EMPID");
            dt.Columns.Add("FULLNM");
            dt.Columns.Add("PITNO");
            dt.Columns.Add("PITISSUEDPLACE");
            dt.Columns.Add("PITISSUEDDATE");
            dt.Columns.Add("SINO");
            dt.Columns.Add("SINOISSUEDPLACE");
            dt.Columns.Add("SINOISSUEDDATE");
            dt.Columns.Add("HINO");
            dt.Columns.Add("HINOISSUEDPLACE");
            dt.Columns.Add("HINOISSUEDDATE");
            dt.Columns.Add("ACCOUTNO");
            dt.Columns.Add("BANK");
            dt.Columns.Add("BANKDATE");
            dt.Columns.Add("CREATE_UID");
            dt.Columns.Add("CREATE_DT");
            dt.Columns.Add("UPDATE_UID");
            dt.Columns.Add("UPDATE_DT");
            dt.Columns.Add("STATUS");
            dt.Columns.Add("TOOLTIP");
            return dt;
        }
        /// <summary>
        /// Create table for export
        /// </summary>
        /// <returns></returns>
        public static DataTable Table_DATAEXPORT()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("EMPID");
            dt.Columns.Add("FULLNM");
            dt.Columns.Add("PITNO");
            dt.Columns.Add("PITISSUEDPLACE");
            dt.Columns.Add("PITISSUEDDATE");
            dt.Columns.Add("SINO");
            dt.Columns.Add("SINOISSUEDPLACE");
            dt.Columns.Add("SINOISSUEDDATE");
            dt.Columns.Add("HINO");
            dt.Columns.Add("HINOISSUEDPLACE");
            dt.Columns.Add("HINOISSUEDDATE");
            dt.Columns.Add("ACCOUTNO");
            dt.Columns.Add("BANK");
            dt.Columns.Add("BANKDATE");
            dt.Columns.Add("STATUS");
            return dt;
        }
        //public static DataTable QueryData(string pCORPORATION)
        //{
        //    string spName = "PKHR_UPLOADINSDATA.SP_QUERY";
        //    OracleParameter[] param = new OracleParameter[2];
        //    param[0] = new OracleParameter("pCORPORATION", pCORPORATION);
        //    param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
        //    DataTable dt = DBHelper.getDataTable_SP(spName, param);

        //    return dt;
        //}
        public static DataTable Savedata(string pCORPORATION, string pTYPEUPLOAD,
            string pEMPID, string pNO, string pPLACE, string pDATE, string pUSER)
        {
            int num = 0;
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[8];
            param[num++] = new OracleParameter("pCORPORATION",pCORPORATION);
            param[num++] = new OracleParameter("pTYPEUPLOAD", pTYPEUPLOAD);
            param[num++] = new OracleParameter("pEMPID", pEMPID);
            param[num++] = new OracleParameter("pNO", pNO);
            param[num++] = new OracleParameter("pPLACE", OracleType.NVarChar) { Value = pPLACE };
            param[num++] = new OracleParameter("pDATE", pDATE);
            param[num++] = new OracleParameter("pUSER", pUSER);
            param[num++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dtData = DBHelper.getDataTable_SP("PKHR_UPLOADINSDATA.SP_SAVE", param);
            return dtData;
        }
    }
}