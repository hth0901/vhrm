using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class DrashBoardAccess
    {
        public DataTable GetChart(string pUserId, string pDeptCode, string pDate)
        {
            string query = "PK_HR_DASHBOARD.SP_BASHBOARD_VIEWTOTAL";
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("PUSERID", pUserId ?? "");
            parameters[1] = new OracleParameter("PDEPTCODE", pDeptCode);
            parameters[2] = new OracleParameter("PDATE", pDate);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dtData = new DataTable();
            dtData = DBHelper.getDataTable_SP(query, parameters);
            return dtData;
        }

        public DataTable GetChild(string pDeptCode, string pDate)
        {
            string query = "PK_HR_DASHBOARD.SP_BASHBOARD_VIEWDETAIL";
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("PDEPTCODE", pDeptCode);
            parameters[1] = new OracleParameter("PDATE", pDate);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dtData = new DataTable();
            dtData = DBHelper.getDataTable_SP(query, parameters);
            return dtData;
        }

        //==================================================================================
        //add by ndhung 2016.05.11 -> thêm trang moniroting
        //==================================================================================
        public DataTable Monitoring_GetData(string pDeptCode, string pUserId)
        {
            string query = "PK_HR_DASHBOARD.SP_MONITORING_MASTER";

            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("PUSERID", pUserId);
            parameters[1] = new OracleParameter("PDEPTCODE", pDeptCode);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            
            DataTable dtData = new DataTable();
            dtData = DBHelper.getDataTable_SP(query, parameters);
            return dtData;
        }

        public DataSet Monitoring_GetChart(string pDeptCode, string pUserId)
        {
            string query = "PK_HR_DASHBOARD.SP_MONITORING_CHART";

            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("PUSERID", pUserId);
            parameters[1] = new OracleParameter("PDEPTCODE", pDeptCode);
            parameters[2] = new OracleParameter("T_CHART", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[3] = new OracleParameter("T_COLOR", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[4] = new OracleParameter("T_GRANDTOTAL", OracleType.Cursor) { Direction = ParameterDirection.Output };
            
            return DBHelper.getDataSet_SP(query, parameters);
        }

        //==================================================================================
        //add by ndhung 2016.06.13 -> lấy corporation cho combobox
        //==================================================================================
        public DataTable Monitoring_GetCorporation(string pUserId)
        {
            string query = "PK_HR_DASHBOARD.SP_MONITORING_GET_CORPORATION";

            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("PUSERID", pUserId);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            DataTable dtData = new DataTable();
            dtData = DBHelper.getDataTable_SP(query, parameters);
            return dtData;
        }

        //==================================================================================
        //add by ndhung 2016.06.13 -> thêm CHART MONITORING BY PRODUCTION DEPT
        //==================================================================================
        public DataSet Monitoring_GetDataChart15(string pDeptCode, string pUserId)
        {
            string query = "PK_HR_DASHBOARD.SP_MONITORING_CHART_PRODUCTION";

            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("PUSERID", pUserId);
            parameters[1] = new OracleParameter("PDEPTCODE", pDeptCode);
            parameters[2] = new OracleParameter("T_TOTAL", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[3] = new OracleParameter("T_OFFICE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[4] = new OracleParameter("T_WORKER", OracleType.Cursor) { Direction = ParameterDirection.Output };
            parameters[5] = new OracleParameter("T_COLOR", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataSet_SP(query, parameters); ;
        }
    }
}