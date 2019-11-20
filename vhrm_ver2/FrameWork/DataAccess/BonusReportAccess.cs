using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.DataAccess
{
    public class BonusReportAccess
    {
        public static DataTable Query(string pDeptCode, string pSysempid, string pMonth,string pKindBonus)
        {
            string query = "PKPAYROLL_BONUSREPORT.SP_LOAD_BONUSREPORT";
            var parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("PDEPTCODE", pDeptCode);
            parameters[1] = new OracleParameter("PSYSEMPIS", pSysempid);
            parameters[2] = new OracleParameter("PMONTH", pMonth);
            parameters[3] = new OracleParameter("PBONUSKIND", pKindBonus);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable Print(string pDeptCode, string pSysempid, string pMonth, string pKindBonus)
        {
            string query = "SP_BONUSREPORT";
            var parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("PDEPTCODE", pDeptCode);
            parameters[1] = new OracleParameter("PSYSEMPIS", pSysempid);
            parameters[2] = new OracleParameter("PMONTH", pMonth);
            parameters[3] = new OracleParameter("PBONUSKIND", pKindBonus);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable Closing( string pSysempid,string pPbym,string pKindBonus)
        {
            string query = "PKPAYROLL_BONUSREPORT.SP_T_PR_SLR_BONUS_CLOSING";
            var parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("PSYSEMPIS", pSysempid);
            parameters[1] = new OracleParameter("PPBYM", pPbym);
            parameters[2] = new OracleParameter("pBONUSKIND", pKindBonus);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable ClosingAll(string pDeptcode,string pSysempid, string pPbym, string pKindBonus)
        {
            string query = "PKPAYROLL_BONUSREPORT.SP_CLOSINGALL";
            var parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("PDEPTCODE", pDeptcode);
            parameters[1] = new OracleParameter("PSYSEMPIS", pSysempid);
            parameters[2] = new OracleParameter("PPBYM", pPbym);
            parameters[3] = new OracleParameter("pBONUSKIND", pKindBonus);
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable Update(Entity.BonusEntity entity, string userId)
        {
            string query = "PKPAYROLL_BONUSREPORT.SP_UPDATE";
            var parameters = new OracleParameter[8];
            parameters[0] = new OracleParameter("PSYSEMPIS", entity.SYS_EMPID);
            parameters[1] = new OracleParameter("PPBMM", entity.PBMM);
            parameters[2] = new OracleParameter("PPBYY", entity.PBYY);
            parameters[3] = new OracleParameter("PBONUSKIND", entity.BONUSKIND);
            parameters[4] = new OracleParameter("PBONUS", entity.BONUS);
            parameters[5] = new OracleParameter("PLOGIN", userId);
            parameters[6] = new OracleParameter("PREMARK", entity.REMARK);
            parameters[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
    }
}