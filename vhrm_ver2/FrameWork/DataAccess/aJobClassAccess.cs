//<%-- 
//    Author: ndhung
//    Date: 2017.06.01
//    Desc: page for management new JobCode Class of PKVN
//--%>

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class aJobClassAccess
    {
        /*===========================================================================
         * JOB CLASS MASTER
        ===========================================================================*/
        #region Job Class

        public static DataTable JobClass_Get()
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOBCLASS_QUERY";

            var p = new OracleParameter[1];
            p[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable JobClass_Insert(eJobClassEntity e, string userid)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOBCLASS_INSERT";

            var p = new OracleParameter[6];
            var i = 0;
            p[i++] = new OracleParameter("PCLASS_NAME", e.Name);
            p[i++] = new OracleParameter("PSUBCODE", e.SubCode);
            p[i++] = new OracleParameter("PDEFINITION", e.Definition);
            p[i++] = new OracleParameter("PIS_ACTIVE", e.IsActive);
            p[i++] = new OracleParameter("PUSERID", userid);
            p[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable JobClass_Update(eJobClassEntity e, string userid)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOBCLASS_UPDATE";

            var p = new OracleParameter[7];
            var i = 0;
            p[i++] = new OracleParameter("PCLASS_ID", e.Id);
            p[i++] = new OracleParameter("PCLASS_NAME", e.Name);
            p[i++] = new OracleParameter("PSUBCODE", e.SubCode);
            p[i++] = new OracleParameter("PDEFINITION", e.Definition);
            p[i++] = new OracleParameter("PIS_ACTIVE", e.IsActive);
            p[i++] = new OracleParameter("PUSERID", userid);
            p[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable JobClass_Delete(string id, string userid)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOBCLASS_DELETE";

            var p = new OracleParameter[3];
            p[0] = new OracleParameter("PCLASS_ID", id);
            p[1] = new OracleParameter("PUSERID", userid);
            p[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        #endregion

        /*===========================================================================
         * JOB SUBCODE
        ===========================================================================*/
        #region Job SubCode

        public static DataTable JobSubCode_Get(string jobclass)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOBSUBCODE_QUERY";

            var p = new OracleParameter[2];
            p[0] = new OracleParameter("PCLASS_ID", jobclass);
            p[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable JobSubCode_Insert(eJobSubCodeEntity e, string userid)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOBSUBCODE_INSERT";

            var p = new OracleParameter[8];
            var i = 0;
            p[i++] = new OracleParameter("PJOB_NAME", e.Name);
            p[i++] = new OracleParameter("PCLASS_ID", e.Class);
            p[i++] = new OracleParameter("PSUBCODE", e.SubCode);
            p[i++] = new OracleParameter("PDEFINITION", e.Definition);
            p[i++] = new OracleParameter("PIS_ACTIVE", e.IsActive);
            p[i++] = new OracleParameter("PREMARK", e.Remark);
            p[i++] = new OracleParameter("PUSERID", userid);
            p[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable JobSubCode_Update(eJobSubCodeEntity e, string userid)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOBSUBCODE_UPDATE";

            var p = new OracleParameter[9];
            var i = 0;
            p[i++] = new OracleParameter("PJOB_ID", e.Id);
            p[i++] = new OracleParameter("PJOB_NAME", e.Name);
            p[i++] = new OracleParameter("PCLASS_ID", e.Class);
            p[i++] = new OracleParameter("PSUBCODE", e.SubCode);
            p[i++] = new OracleParameter("PDEFINITION", e.Definition);
            p[i++] = new OracleParameter("PIS_ACTIVE", e.IsActive);
            p[i++] = new OracleParameter("PREMARK", e.Remark);
            p[i++] = new OracleParameter("PUSERID", userid);
            p[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable JobSubCode_Delete(string id, string userid)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOBSUBCODE_DELETE";

            var p = new OracleParameter[3];
            p[0] = new OracleParameter("PJOB_ID", id);
            p[1] = new OracleParameter("PUSERID", userid);
            p[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        #endregion

        /*===========================================================================
         * JOB CLASS SUB JOB SETTING
        ===========================================================================*/
        #region Job Level Mapping 

        public static DataTable JobMapping_GetSubJobList()
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOB_MAPPING_GET_SUBJOB";

            var p = new OracleParameter[1];
            p[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable JobMapping_GetDataMaster(string id)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOB_MAPPING_GET_MASTER";

            var p = new OracleParameter[2];
            p[0] = new OracleParameter("PJOB_ID", id);
            p[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable JobMapping_GetDataDetail(string id, string userid)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOB_MAPPING_GET_DETAIL";

            var p = new OracleParameter[2];
            p[0] = new OracleParameter("PMAP_ID", id == "" ? (object)DBNull.Value : id);
            p[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable JobMapping_GetColorList()
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOB_MAPPING_GET_COLOR";

            var p = new OracleParameter[1];
            p[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable JobMapping_SaveMappingData(eJobSubCodeMappingEntity e, string userid)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOB_MAPPING_SAVE";
            var i = 0;

            var p = new OracleParameter[8];
            p[i++] = new OracleParameter("PJOB_ID", e.JobId);
            p[i++] = new OracleParameter("PMAP_ID", e.MapId == "" ? (object)DBNull.Value : e.MapId);
            p[i++] = new OracleParameter("PVALIDITYFROM", e.ValidityFrom);
            p[i++] = new OracleParameter("PEXTENDTO", e.Extendto == "" ? (object)DBNull.Value : e.Extendto);
            p[i++] = new OracleParameter("PDESCRIPTION", e.Description);
            p[i++] = new OracleParameter("PLEVELCONTENT", e.LevelMappingContent);
            p[i++] = new OracleParameter("PUSERID", userid);
            p[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable JobMapping_Delete(string id, string userid)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOB_MAPPING_DELETE";

            var p = new OracleParameter[3];
            p[0] = new OracleParameter("PMAP_ID", id);
            p[1] = new OracleParameter("PUSERID", userid);
            p[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        #endregion

        /*===========================================================================
         * JOB CLASS MANAGEMENT
        ===========================================================================*/
        public static DataTable JobMapping_GetJobLevel(string id, string fromdate)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_JOB_MAPPING_GET_LEVEL";

            var p = new OracleParameter[3];
            p[0] = new OracleParameter("PJOB_ID", id == "" ? (object)DBNull.Value : id);
            p[1] = new OracleParameter("PFROMDATE", fromdate == "" ? (object)DBNull.Value : fromdate);
            p[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable EmpJobManagement_GetDataMaster(string sysId)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_EMP_JOB_MANAGEMENT_GET_MT";

            var p = new OracleParameter[2];
            p[0] = new OracleParameter("PSYS_EMPID", sysId);
            p[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable EmpJobManagement_GetDataDetail(string sysId, string masterId)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_EMP_JOB_MANAGEMENT_GET_DT";

            var p = new OracleParameter[3];
            p[0] = new OracleParameter("PSYS_EMPID", sysId == "" ? (object)DBNull.Value : sysId);
            p[1] = new OracleParameter("PIDX", masterId == "" ? (object)DBNull.Value : masterId);
            p[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable EmpJobManagement_Delete(string id, string userid)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_EMP_JOB_MANAGEMENT_DELETE";

            var p = new OracleParameter[3];
            p[0] = new OracleParameter("PIDX", id);
            p[1] = new OracleParameter("PUSERID", userid);
            p[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable EmpJobManagement_SaveData(eJobEmpManagement e, string userid)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_EMP_JOB_MANAGEMENT_SAVE";
            var i = 0;
            var p = new OracleParameter[10];
            p[i++] = new OracleParameter("PIDX", e.Idx == "" ? (object)DBNull.Value : e.Idx);
            p[i++] = new OracleParameter("PSYS_EMPID", e.SysEmpId);
            p[i++] = new OracleParameter("PVALIDITYFROM", e.ValidityFrom);
            p[i++] = new OracleParameter("PEXTENDTO", e.Extendto == "" ? (object)DBNull.Value : e.Extendto);
            p[i++] = new OracleParameter("PREMARK", e.Remark);
            p[i++] = new OracleParameter("PMAIN_JOBCODE", e.MainJob);
            p[i++] = new OracleParameter("PMAIN_LEVEL", e.MainJob_Level == "" ? (object)DBNull.Value : e.MainJob_Level);
            p[i++] = new OracleParameter("PSUBJOB_CONTENT", e.SubJobCode_Content);
            p[i++] = new OracleParameter("PUSERID", userid);
            p[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable EmpJobManagement_Confirm(string id, string userid)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_EMP_JOB_MNGM_CONFIRM";

            var p = new OracleParameter[3];
            p[0] = new OracleParameter("PIDX", id);
            p[1] = new OracleParameter("PUSERID", userid);
            p[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }

        public static DataTable EmpJobManagement_UnConfirm(string id, string userid)
        {
            string sp = "PKHR_JOBCLASS_MANAGEMENT.SP_EMP_JOB_MNGM_UNCONFIRM";

            var p = new OracleParameter[3];
            p[0] = new OracleParameter("PIDX", id);
            p[1] = new OracleParameter("PUSERID", userid);
            p[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, p);
        }
    }
}