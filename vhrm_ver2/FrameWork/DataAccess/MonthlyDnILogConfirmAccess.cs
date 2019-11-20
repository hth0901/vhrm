using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class MonthlyDnILogConfirmAccess
    {

        public static DataTable Monthly_loaddata(string Corpodation, string Monthly, string Empid)
        {
            string query = "PKTIMESHEET_WKMONTHLY.SP_WKMONTHLY_QUERY";
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("pCorporation", Corpodation);
            parameters[1] = new OracleParameter("pMONTHLY", Monthly);
            parameters[2] = new OracleParameter("pEMPID", Empid ?? "");
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        
        public static DataTable CONFIRM(string Corporaion,string Month,String sys_empid,string Confirmis, string ConfirmUID,string User)
        {
            string spName = "PKTIMESHEET_WKMONTHLY.SP_WKMONTHLY_CONFIRM";
            OracleParameter[] parameters = new OracleParameter[7];
            parameters[0] = new OracleParameter("pCorporation", Corporaion);
            parameters[1] = new OracleParameter("pMONTHLY", Month);
            parameters[2] = new OracleParameter("pEMPID", sys_empid);
            parameters[3] = new OracleParameter("pCONFIRMIS", Confirmis);
            parameters[4] = new OracleParameter("pCONFIRMUID", ConfirmUID);
            parameters[5] = new OracleParameter("pUSER", User);
            parameters[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }

        public static DataTable CALCULATE(string Corpodation, string Monthly, string Empid, string LoginId)
        {
            string query = "PKTIMESHEET_WKMONTHLY.SP_WKMONTHLY_CALCULATE";
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("pCorporation", Corpodation);
            parameters[1] = new OracleParameter("pMONTHLY", Monthly);
            parameters[2] = new OracleParameter("pEMPID", Empid ?? "");
            parameters[3] = new OracleParameter("pUSER", LoginId ?? "");
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable Confirm_ById(string pPBYM, string pSYS_EMPID, string pFROMDATE, string pTODATE, string pCONTRACTKIND,
            float pBASICSALARY, float pDAY_WK, float pDEDUCTDAYS, float pMINU_LATE,
            float pMINU_SOON, float pOT150, float pOT215, float pOT195, float pOT200, float pOT300, float pSHIFT300,
            float pNORMALHOUR150, float pBREAKHOUR, float pCNTLEAVE, float pCNTLEAVE3MIN, string pConfirmIs, string pUserId)
        {
            /*pPBYM varchar2, psys_empid varchar2, pFROMDATE varchar2, pTODATE varchar2, pCONTRACTKIND varchar2,
                pBASICSALARY number, pDAY_WK number, pDEDUCTDAYS number, pMINU_LATE number, pMINU_SOON number, 
                pOT150 number, pOT215 number, pOT195 number, pOT200 number, pOT300 number, pSHIFT300 number, 
                pNORMALHOUR150 number, pBREAKHOUR number, pCNTLEAVE number, pCNTLEAVE3MIN number,
                pConfirmIs varchar2, pUserId varchar2, T_TABLE OUT C_CURSOR*/
            string spName = "PKTIMESHEET_WKMONTHLY.SP_CONFIRM_BYID";
            OracleParameter[] parameters = new OracleParameter[24];
            parameters[0] = new OracleParameter("pPBYM", pPBYM);
            parameters[1] = new OracleParameter("pSYS_EMPID", pSYS_EMPID);
            parameters[2] = new OracleParameter("pFROMDATE", pFROMDATE);
            parameters[3] = new OracleParameter("pFROMDATE", pFROMDATE);
            parameters[4] = new OracleParameter("pTODATE", pTODATE);
            parameters[5] = new OracleParameter("pCONTRACTKIND", pCONTRACTKIND);
            parameters[6] = new OracleParameter("pBASICSALARY", pBASICSALARY);
            parameters[7] = new OracleParameter("pDAY_WK", pDAY_WK);
            parameters[8] = new OracleParameter("pDEDUCTDAYS", pDEDUCTDAYS);
            parameters[9] = new OracleParameter("pMINU_LATE", pMINU_LATE);
            parameters[10] = new OracleParameter("pMINU_SOON", pMINU_SOON);
            parameters[11] = new OracleParameter("pOT150", pOT150);
            parameters[12] = new OracleParameter("pOT215", pOT215);
            parameters[13] = new OracleParameter("pOT195", pOT195);
            parameters[14] = new OracleParameter("pOT200", pOT200);
            parameters[15] = new OracleParameter("pOT300", pOT300);
            parameters[16] = new OracleParameter("pSHIFT300", pSHIFT300);
            parameters[17] = new OracleParameter("pNORMALHOUR150", pNORMALHOUR150);
            parameters[18] = new OracleParameter("pBREAKHOUR", pBREAKHOUR);
            parameters[19] = new OracleParameter("pCNTLEAVE", pCNTLEAVE);
            parameters[20] = new OracleParameter("pCNTLEAVE3MIN", pCNTLEAVE3MIN);
            parameters[21] = new OracleParameter("pConfirmIs", pConfirmIs);
            parameters[22] = new OracleParameter("pUserId", pUserId);
            parameters[23] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }

        public static DataTable SP_CONFIRM_BYEMPID(string pPBYM, string pSYS_EMPID, string pConfirmIs, string pUserId)
        {
            string spName = "PKTIMESHEET_WKMONTHLY.SP_CONFIRM_BYEMPID";
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("pPBYM", pPBYM);
            parameters[1] = new OracleParameter("pSYS_EMPID", pSYS_EMPID);
            parameters[2] = new OracleParameter("pConfirmIs", pConfirmIs);
            parameters[3] = new OracleParameter("pUserId", pUserId);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(spName, parameters);
        }
    }
}