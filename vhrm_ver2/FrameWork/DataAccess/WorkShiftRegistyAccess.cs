using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class WorkShiftRegistyAccess
    {
        public static DataTable loadComboboxWorkshift()
        {
            string query = "PKTIMESHEET_WORKSHIFT.SP_LOAD_COMBOBOX_WORKSHIFT";
            OracleParameter[] para = new OracleParameter[1];
            para[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, para);
        }
        public static DataTable Load(string corporation, string employeeId, string timeShift, string fromDate, string toDate)
        {
            string query = "PKTIMESHEET_WORKSHIFT.sp_WorkShiftRegisty_Qry";
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pCorporation", corporation ?? "");
            parameters[1] = new OracleParameter("pEmployeeId", employeeId ?? "");
            parameters[2] = new OracleParameter("pTimeShift", timeShift ?? "");
            parameters[3] = new OracleParameter("pFromDate", fromDate ?? "");
            parameters[4] = new OracleParameter("pToDate", toDate ?? "");
            parameters[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable Save(string workingTag, WorkShiftRegistyEntity entity)
        {
            string sp_name = "PKTIMESHEET_WORKSHIFT.sp_WorkShiftRegisty_Save";
            OracleParameter [] OraclePara = new OracleParameter[11];
            OraclePara[0] = new OracleParameter("pWorkingTag",workingTag ?? "");
            OraclePara[1] = new OracleParameter("pRegistryId",entity.UID ?? "");
            OraclePara[2] = new OracleParameter("pEmployeeId",entity.SysEmpid ?? "");
            OraclePara[3] = new OracleParameter("pRemarks", OracleType.NVarChar) { Value = entity.Remarks ?? "" };
            OraclePara[4] = new OracleParameter("pFromdate",entity.FromDate ?? "");
            OraclePara[5] = new OracleParameter("pConfirmId",entity.ConfirmUId ?? "");
            OraclePara[6] = new OracleParameter("pShift_CD",entity.WorkShift ?? "");
            OraclePara[7] = new OracleParameter("pConfirmIs",entity.ConfirmIs ?? "");
            OraclePara[8] = new OracleParameter("pFixedCheck",entity.FixedCheck ?? "");
            OraclePara[9] = new OracleParameter("pEndDate",entity.ToDate ?? "");
            OraclePara[10] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output};
            return DBHelper.getDataTable_SP(sp_name,OraclePara);
        }
        public static DataTable SavebyDept(WorkShiftRegistyEntity entity, string pDeptCode, string pSys_EmpId)
        {
            string sp_name = "PKTIMESHEET_WORKSHIFT.sp_WorkShiftRegisty_SavebyDept";
            OracleParameter[] OraclePara = new OracleParameter[10];
            OraclePara[0] = new OracleParameter("pShift_CD", entity.WorkShift ?? "");
            OraclePara[1] = new OracleParameter("pFromdate", entity.FromDate ?? "");
            OraclePara[2] = new OracleParameter("pFixedCheck", entity.FixedCheck ?? "");
            OraclePara[3] = new OracleParameter("pEndDate", entity.ToDate ?? "");
            OraclePara[4] = new OracleParameter("pRegistryId", entity.UID ?? "");
            OraclePara[5] = new OracleParameter("pRemarks", OracleType.NVarChar) { Value = entity.Remarks ?? "" };
            OraclePara[6] = new OracleParameter("pConfirmIs",entity.ConfirmIs);
            OraclePara[7] = new OracleParameter("pDepcode", pDeptCode);
            OraclePara[8] = new OracleParameter("psys_EmpId", pSys_EmpId);
            OraclePara[9] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(sp_name, OraclePara);
        }

        public static DataTable ConfirmbyDept(string pDepcode, string pShift_CD, string pFromdate, string pEndDate, string pConfirmIs, string pLoginId)
        {
            //(pDepcode varchar2,pShift_CD  varchar2,pFromdate  varchar2,pEndDate varchar2,pConfirmIs char, pLoginId varchar2);
            string sp_name = "PKTIMESHEET_WORKSHIFT.sp_WorkShift_ConfirmbyDept";
            OracleParameter[] OraclePara = new OracleParameter[7];
            OraclePara[0] = new OracleParameter("pDepcode", pDepcode ?? "");
            OraclePara[1] = new OracleParameter("pShift_CD", pShift_CD ?? "");
            OraclePara[2] = new OracleParameter("pFromdate", pFromdate ?? "");
            OraclePara[3] = new OracleParameter("pEndDate", pEndDate ?? "");
            OraclePara[4] = new OracleParameter("pConfirmIs", pConfirmIs);
            OraclePara[5] = new OracleParameter("pLoginId", pLoginId);
            OraclePara[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(sp_name, OraclePara);
        }

        //ADD BY NDHUNG 2014.12.27
        //NEW BATCH CREATE
        public static DataTable WorkShift_BatchRegister(string pDeptCode, string pEmpID, string pShift_CD, string pFromDate, string pToDate, string pUserID)
        {
            string sp_name = "PKTIMESHEET_WORKSHIFT.SP_WORKSHIFT_BATCHREGISTER";
            OracleParameter[] OraclePara = new OracleParameter[7];
            OraclePara[0] = new OracleParameter("PDEPTCODE", pDeptCode);
            OraclePara[1] = new OracleParameter("PEMPID", pEmpID);
            OraclePara[2] = new OracleParameter("PSHIFTCD", pShift_CD);
            OraclePara[3] = new OracleParameter("PFROMDATE", pFromDate);
            OraclePara[4] = new OracleParameter("PTODATE", pToDate);
            OraclePara[5] = new OracleParameter("PUSERID", pUserID);
            OraclePara[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(sp_name, OraclePara);
        }

        //ADD BY NDHUNG 2014.12.30
        //NEW CREATE
        public static DataTable WorkShift_Insert(WorkShiftRegistyEntity entity)
        {
            string sp_name = "PKTIMESHEET_WORKSHIFT.SP_WORKSHIFT_INSERT";
            OracleParameter[] OraclePara = new OracleParameter[8];
            OraclePara[0] = new OracleParameter("PEMPID", entity.SysEmpid);
            OraclePara[1] = new OracleParameter("PFROMDATE", entity.FromDate);
            OraclePara[2] = new OracleParameter("PTODATE", entity.ToDate);
            OraclePara[3] = new OracleParameter("PSHIFTCD", entity.WorkShift);
            OraclePara[4] = new OracleParameter("PREMARKS", entity.Remarks);
            OraclePara[5] = new OracleParameter("PFIXCHECK", entity.FixedCheck);
            OraclePara[6] = new OracleParameter("PUSERID", entity.UID);
            OraclePara[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(sp_name, OraclePara);
        }

        //ADD BY NDHUNG 2014.12.30
        //NEW UPDATE
        public static DataTable WorkShift_Update(WorkShiftRegistyEntity entity)
        {
            string sp_name = "PKTIMESHEET_WORKSHIFT.SP_WORKSHIFT_UPDATE";
            OracleParameter[] OraclePara = new OracleParameter[8];
            OraclePara[0] = new OracleParameter("PEMPID", entity.SysEmpid);
            OraclePara[1] = new OracleParameter("PFROMDATE", entity.FromDate);
            OraclePara[2] = new OracleParameter("PTODATE", entity.ToDate);
            OraclePara[3] = new OracleParameter("PSHIFTCD", entity.WorkShift);
            OraclePara[4] = new OracleParameter("PREMARKS", entity.Remarks);
            OraclePara[5] = new OracleParameter("PFIXCHECK", entity.FixedCheck);
            OraclePara[6] = new OracleParameter("PUSERID", entity.UID);
            OraclePara[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(sp_name, OraclePara);
        }

        //ADD BY NDHUNG 2014.12.30
        //NEW DELETE
        public static DataTable WorkShift_Delete(string empid, string fromdate)
        {
            string sp_name = "PKTIMESHEET_WORKSHIFT.SP_WORKSHIFT_DELETE";
            OracleParameter[] OraclePara = new OracleParameter[3];
            OraclePara[0] = new OracleParameter("PEMPID", empid);
            OraclePara[1] = new OracleParameter("PFROMDATE", fromdate);
            OraclePara[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(sp_name, OraclePara);
        }

        //ADD BY NDHUNG 2014.12.30
        //NEW CONFIRM & BATCH CONFIRM
        public static DataTable WorkShift_Confirm(string EmpInfo, string ConfirmIs, string UserID)
        {
            string sp_name = "PKTIMESHEET_WORKSHIFT.SP_WORKSHIFT_CONFIRM";
            OracleParameter[] OraclePara = new OracleParameter[4];
            OraclePara[0] = new OracleParameter("PEMPINFO", EmpInfo);
            OraclePara[1] = new OracleParameter("PCONFIRMIS", ConfirmIs);
            OraclePara[2] = new OracleParameter("PUSERID", UserID);
            OraclePara[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(sp_name, OraclePara);
        }
    }
}