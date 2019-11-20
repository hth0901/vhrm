/*
 * Author: ndhung
 * Create Date: 2016-01-26
 * Desc: Access for Part Setting and Part Allocation
*/

using System.Data.OracleClient;
using System.Data;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class PartSettingAllocation
    {
        //add by ndhung 2016.01.26
        #region Part Setting

        //load treeview Organization
        public static DataTable LoadTreeviewPart(string pUserId)
        {
            DataTable dt = new DataTable();
            string query = "PK_HR_ORGANIZATION_PART.SP_PARTSETTING_GETTREEVIEW";

            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("PUSERID", pUserId);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dt = DBHelper.getDataTable_SP(query, parameters);
            return dt;
        }

        //save Part Info
        public static DataTable SavePart(string tag, string dept, string partname, string isactive, string seq, string pUserId)
        {
            DataTable dt = new DataTable();
            string query = "PK_HR_ORGANIZATION_PART.SP_SAVE_PART";

            OracleParameter[] parameters = new OracleParameter[7];
            parameters[0] = new OracleParameter("PWORKINGTAG", tag);
            parameters[1] = new OracleParameter("PDEPTCODE", dept);
            parameters[2] = new OracleParameter("PPARTNAME", partname);
            parameters[3] = new OracleParameter("PISACTIVE", isactive);
            parameters[4] = new OracleParameter("PSEQ", seq);
            parameters[5] = new OracleParameter("PUSERID", pUserId);
            parameters[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dt = DBHelper.getDataTable_SP(query, parameters);
            return dt;
        }

        #endregion


        //add by ndhung 2016.01.26
        #region Part Allocation


        public static DataTable LoadTreeviewAllocation(string pUserId)
        {
            DataTable dt = new DataTable();
            string query = "PK_HR_ORGANIZATION_PART.SP_PARTALLOCATION_GETTREEVIEW";

            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("PUSERID", pUserId);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dt = DBHelper.getDataTable_SP(query, parameters);
            return dt;
        }

        public static DataTable LoadListEmpAllocation(string pDept, string pStatus)
        {
            DataTable dt = new DataTable();
            string query = "PK_HR_ORGANIZATION_PART.SP_GETEMPLOYEE";

            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("PDEPTCODE", pDept);
            parameters[1] = new OracleParameter("PSTATUS", pStatus);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dt = DBHelper.getDataTable_SP(query, parameters);
            return dt;
        }

        public static DataTable LoadListPart(string pDept)
        {
            DataTable dt = new DataTable();
            string query = "PK_HR_ORGANIZATION_PART.SP_GETPARTLIST";

            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("PDEPTCODE", pDept);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dt = DBHelper.getDataTable_SP(query, parameters);
            return dt;
        }

        public static DataTable InsertAllocation(string sysId, string partCd, string fromdate, string todate, string remark, string userid)
        {
            DataTable dt = new DataTable();
            string query = "PK_HR_ORGANIZATION_PART.SP_INSERT_ALLOCATION";

            OracleParameter[] parameters = new OracleParameter[7];
            parameters[0] = new OracleParameter("PEMPID", sysId);
            parameters[1] = new OracleParameter("PPART", partCd);
            parameters[2] = new OracleParameter("PFROMDATE", fromdate);
            parameters[3] = new OracleParameter("PTODATE", todate);
            parameters[4] = new OracleParameter("PREMARK", remark);
            parameters[5] = new OracleParameter("PUSERID", userid);
            parameters[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dt = DBHelper.getDataTable_SP(query, parameters);
            return dt;
        }

        public static DataTable UpdateAllocation(string ID, string partCd, string fromdate, string todate, string remark, string userid)
        {
            DataTable dt = new DataTable();
            string query = "PK_HR_ORGANIZATION_PART.SP_UPDATE_ALLOCATION";

            OracleParameter[] parameters = new OracleParameter[7];
            parameters[0] = new OracleParameter("PID", ID);
            parameters[1] = new OracleParameter("PPART", partCd);
            parameters[2] = new OracleParameter("PFROMDATE", fromdate);
            parameters[3] = new OracleParameter("PTODATE", todate);
            parameters[4] = new OracleParameter("PREMARK", remark);
            parameters[5] = new OracleParameter("PUSERID", userid);
            parameters[6] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            dt = DBHelper.getDataTable_SP(query, parameters);
            return dt;
        }

        #endregion
    }
}