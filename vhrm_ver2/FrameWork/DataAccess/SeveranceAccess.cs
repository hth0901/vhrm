using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class SeveranceAccess
    {
        //public static DataTable Getdata(string Corporation,string Reasonofstop,string FromDate, string ToDate)
        //{
        //    OracleParameter[] _sqlParam = new OracleParameter[5];
        //    _sqlParam[0] = new OracleParameter("pCorporation",Corporation);
        //    _sqlParam[1] = new OracleParameter("pStopworkReason", Reasonofstop);
        //    _sqlParam[2] = new OracleParameter("pFromDate", FromDate);
        //    _sqlParam[3] = new OracleParameter("pToDate", ToDate);
        //    _sqlParam[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
        //    return DBHelper.getDataTable_SP("PKSEVERANCE_SEVERANCE.SP_SEVERANCE_QRY", _sqlParam);
        //}

        //public  DataTable Savedata(string pWorkingTag, SeveranceEntity enty)
        //{
        //    DataTable dtData = new DataTable();
        //    OracleParameter[] param = new OracleParameter[13];
        //    param[0] = new OracleParameter("pWorkingTag", pWorkingTag);
        //    param[1] = new OracleParameter("P_MONTH", enty.PMonth??"");
        //    param[2] = new OracleParameter("p_empID", enty.PSysempid ?? "");
        //    param[3] = new OracleParameter("pValidityfrom", enty.PValidityfrom ?? "");
        //    param[4] = new OracleParameter("PSTOPWORKREASON", enty.PStopworkreason?? "");
        //    param[5] = new OracleParameter("PPAYTYPE", enty.PPaytype ?? "");
        //    param[6] = new OracleParameter("PNOPAYREASON", enty.PNopayreason ?? "");
        //    param[7] = new OracleParameter("P_RETURNTYPE", enty.PReturnhealthcard ?? "");
        //    param[8] = new OracleParameter("PRETURNIDDATE", enty.PReturniddate ?? "");
        //    param[9] = new OracleParameter("PREMARKS", OracleType.NVarChar) { Value = enty.PRemark??""};
        //    param[10] = new OracleParameter("PCONFIRMCHECK", enty.PConfirmcheck ?? "");
        //    param[11] = new OracleParameter("PUSER", enty.PUser ?? "");
        //    param[12] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
        //    dtData = DBHelper.getDataTable_SP("PKSEVERANCE_SEVERANCE.SP_CALCULATE_SEVERANCE", param);
        //    return dtData;
        //}

        //public static DataTable Caculator( SeveranceEntity enty)
        //{
        //    DataTable dtData = new DataTable();
        //    OracleParameter[] param = new OracleParameter[5];
        //    param[0] = new OracleParameter("p_empID", enty.PSysempid);
        //    param[1] = new OracleParameter("pValidityfrom", enty.PValidityfrom);
        //    param[2] = new OracleParameter("PSTOPWORKREASON", OracleType.NVarChar) { Value = enty.PStopworkreason };
        //    param[3] = new OracleParameter("PPAYTYPE", enty.PPaytype);
        //   param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
        //    dtData = DBHelper.getDataTable_SP("PKSEVERANCE_SEVERANCE.SP_CALCULATE", param);
        //    return dtData;
        //}

        //add by ndhung 2014.07.22
        public static DataTable GetEmpStopWork(string pDept, string pReason, string pDateFrom, string pDateTo, string pIsPay, string status)
        {
            DataTable data = new DataTable();

            OracleParameter[] param = new OracleParameter[7];
            param[0] = new OracleParameter("pDEPT", pDept);
            param[1] = new OracleParameter("pREASON", pReason);
            param[2] = new OracleParameter("pFROMDATE", pDateFrom);
            param[3] = new OracleParameter("pTODATE", pDateTo);
            param[4] = new OracleParameter("pISPAY", pIsPay);
            param[5] = new OracleParameter("pSTATUS", status);
            param[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            data = DBHelper.getDataTable_SP("PKSEVERANCE_SEVERANCE_V2.SP_QRY_STOPWORK_EMP", param);
            return data;
        }

        //add by ndhung 2014.07.23
        public static DataTable CalculateAllowance(string SysEmpID, string IsPay, string HealthCard,
            string monthMaternity, string monthProbation, string monthSickLeave, string returnInsRefund, string otherpayment)
        {
            DataTable data = new DataTable();

            OracleParameter[] param = new OracleParameter[9];
            param[0] = new OracleParameter("pSYS_EMPID", SysEmpID);
            param[1] = new OracleParameter("pISPAY", IsPay);
            param[2] = new OracleParameter("pRETURNHEALTHCARD", HealthCard);
            param[3] = new OracleParameter("pMATERNITYMONTH", monthMaternity == "" ? (object)DBNull.Value : monthMaternity);
            param[4] = new OracleParameter("pPROBATIONMONTH", monthProbation == "" ? (object)DBNull.Value : monthProbation);
            param[5] = new OracleParameter("pSICKMONTH", monthSickLeave == "" ? (object)DBNull.Value : monthSickLeave);
            param[6] = new OracleParameter("pRETURNINSREFUND", returnInsRefund == "" ? (object)DBNull.Value : returnInsRefund);
            param[7] = new OracleParameter("pOTHERPAYMENT", otherpayment == "" ? (object)DBNull.Value : otherpayment);

            param[8] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            data = DBHelper.getDataTable_SP("PKSEVERANCE_SEVERANCE_V2.SP_CALCULATE_ALLOWANCE", param);
            return data;
        }

        //add by ndhung 2014.07.28
        public static DataTable ConfirmSeverance(string SysEmpID, string ValidityFrom, string UserID)
        {
            DataTable data = new DataTable();

            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pSYS_EMPID", SysEmpID);
            param[1] = new OracleParameter("pVALIDITYFROM", ValidityFrom);
            param[2] = new OracleParameter("pUSERID", UserID);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            data = DBHelper.getDataTable_SP("PKSEVERANCE_SEVERANCE_V2.SP_CONFIRM_SEVERANCE", param);
            return data;
        }

        //add by ndhung 2014.07.28
        public static DataTable SaveSeverance(SeveranceEntity _entity, string UserID, string ValidityFrom)
        {
            DataTable data = new DataTable();

            OracleParameter[] param = new OracleParameter[31];
            int i = 0;
            param[i++] = new OracleParameter("P_EMPID", _entity.SYSEMPID);
            param[i++] = new OracleParameter("P_PAYTYP", _entity.PAYTYPE);
            param[i++] = new OracleParameter("P_HEALTHCARD", _entity.RETURNHEALTHCARD);
            param[i++] = new OracleParameter("P_YEAR", _entity.TOTALWORKYEAR);
            param[i++] = new OracleParameter("P_MONTH", _entity.TOTALWORKMONTH);
            param[i++] = new OracleParameter("P_DAY", _entity.TOTALWORKDAY);
            param[i++] = new OracleParameter("P_AVGSAL", _entity.AVGSALARY);
            param[i++] = new OracleParameter("P_AVGALOW", _entity.AVGALLOWANCE);
            param[i++] = new OracleParameter("P_SEVERANCE", _entity.SEVERANCEALLOWANCE);
            param[i++] = new OracleParameter("P_VIODAY", _entity.VIOLATEDDAYS);
            param[i++] = new OracleParameter("P_COMPENDEDUCT", _entity.COMPENSATION);
            param[i++] = new OracleParameter("P_HEALTHCARDDEDUCT", _entity.NORETURNHEALTHCARD);
            param[i++] = new OracleParameter("P_MONTHDEDUCT", _entity.MONTHDEDUCT);
            param[i++] = new OracleParameter("P_ANNPAY", _entity.ANNUALPAY);
            param[i++] = new OracleParameter("P_TOTALSEVERANCE", _entity.TOTALSEVERANCE);
            param[i++] = new OracleParameter("P_USER", UserID);
            param[i++] = new OracleParameter("P_VALIDITYFROM", ValidityFrom);
            param[i++] = new OracleParameter("P_RATE", _entity.PPayrate);
            param[i++] = new OracleParameter("P_ANNAVAIDAY", _entity.AVAILABLE_DAY);
            param[i++] = new OracleParameter("P_ANNPAYDAY", _entity.ANN_PAYDAY);
            param[i++] = new OracleParameter("P_MATER_MON", _entity.TOTAL_MONTH_MATERNITYLEAVE);
            param[i++] = new OracleParameter("P_PROBA_MON", _entity.TOTAL_MONTH_PROBATION);
            param[i++] = new OracleParameter("P_SICK_MON", _entity.TOTAL_MONTH_SICKLEAVE);
            param[i++] = new OracleParameter("P_INSREFUND", _entity.RETURN_INSREFUND);
            //add by ndhung 2017.04.24 -> thêm chức năng nhập other payment
            param[i++] = new OracleParameter("P_OTHERPAY", _entity.OTHER_PAYMENT);
            //add by ndhung 2018.05.18 -> thêm số ngày lẻ thử việc & thai sản và tính lại ngày hưởng tctv
            param[i++] = new OracleParameter("P_MATER_DAY", _entity.DAY_MATERNITYLEAVE);
            param[i++] = new OracleParameter("P_PROBA_DAY", _entity.DAY_PROBATION);
            param[i++] = new OracleParameter("P_YEAR_ACTU", _entity.TOTALWORKYEAR_ACTUAL);
            param[i++] = new OracleParameter("P_MONTH_ACTU", _entity.TOTALWORKMONTH_ACTUAL);
            param[i++] = new OracleParameter("P_DAY_ACTU", _entity.TOTALWORKDAY_ACTUAL);
            param[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            data = DBHelper.getDataTable_SP("PKSEVERANCE_SEVERANCE_V2.SP_SAVE_SEVERANCE", param);
            return data;
        }

        //add by ndhung 2014.10.13
        public static DataTable UnConfirmSeverance(string SysEmpID, string ValidityFrom, string UserID)
        {
            DataTable data = new DataTable();

            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pSYS_EMPID", SysEmpID);
            param[1] = new OracleParameter("pVALIDITYFROM", ValidityFrom);
            param[2] = new OracleParameter("pUSERID", UserID);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            data = DBHelper.getDataTable_SP("PKSEVERANCE_SEVERANCE_V2.SP_UNCONFIRM_SEVERANCE", param);
            return data;
        }

        //add by ndhung 2016.03.14 -> add thông tin status và ngày trả trợ cấp
        public static DataTable SaveSeveranceStatus(string empid, string validityfrom, string userid, string paydate, string paystatus)
        {
            DataTable data = new DataTable();

            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("pSYS_EMPID", empid);
            param[1] = new OracleParameter("pVALIDITYFROM", validityfrom);
            param[2] = new OracleParameter("pUSERID", userid);
            param[3] = new OracleParameter("pPAYDATE", paydate);
            param[4] = new OracleParameter("pPAYSTATUS", paystatus);
            param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            data = DBHelper.getDataTable_SP("PKSEVERANCE_SEVERANCE_V2.SP_SAVE_SEVERANCE_STATUS", param);
            return data;
        }
    }
}