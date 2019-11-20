using System.Data;
using Oracle.ManagedDataAccess.Client;
using vhrm.FrameWork.Entity;
using System.Web;

namespace vhrm.FrameWork.DataAccess
{
    public class OrganazationRegistryAccess
    {
        public static DataTable Load()
        {
            string query = "PK_HR_ORGANIZATION.sp_OrganazationRegistry_Qry";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable LoadTreeView(string loginId)
        {
            //get from catch by Van
            DataTable dt = new DataTable();
            if (HttpContext.Current.Cache[vhrm.FrameWork.Utility.ToolHelper.CacheOrg] != null)
            {
                dt = (DataTable)HttpContext.Current.Cache[vhrm.FrameWork.Utility.ToolHelper.CacheOrg];
            }
            else
            {   //get from data by Van
                string query = "PK_HR_ORGANIZATION.sp_OrgRegistry_TreeView";
                OracleParameter[] parameters = new OracleParameter[2];
                parameters[0] = new OracleParameter("pLoginID", loginId);
                parameters[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };

                dt = DBHelper.getDataTable_SP(query, parameters);
                HttpContext.Current.Cache[vhrm.FrameWork.Utility.ToolHelper.CacheOrg] = dt;
            }
            return dt;
        }
        /*Add by Thanh Binh : Load tree view accroding permit  */
        public DataTable LoadTreeViewPermit(string plistDepCode)
        {
            //get from catch by Van
            DataTable dt = new DataTable();
            if (HttpContext.Current.Session["TreeDepartment"] != null)
            {
                dt = (DataTable)HttpContext.Current.Session["TreeDepartment"];
                DataView dv = dt.DefaultView;
                dv.RowFilter = null;
            }
            else
            {   //get from data by Van
                string query = "PK_HR_ORGANIZATION.SP_ORGANAZATION_GETBYPERMIT";
                OracleParameter[] parameters = new OracleParameter[2];
                parameters[0] = new OracleParameter("PLISTDEPARTMENT", plistDepCode);
                parameters[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
                dt = DBHelper.getDataTable_SP(query, parameters);
                HttpContext.Current.Session["TreeDepartment"] = dt;
                //HttpContext.Current.Cache[vhrm.FrameWork.Utility.ToolHelper.CacheOrg] = dt;
            }
            return dt;
        }

        //add by ndhung 2014.10.27 -> add for mrs Van PK1
        public DataTable LoadTreeViewPermitPK1(string plistDepCode)
        {
            //get from catch by Van
            DataTable dt = new DataTable();
            string query = "PK_HR_ORGANIZATION.SP_ORGANAZATION_GETBYPERMIT";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("PLISTDEPARTMENT", plistDepCode);
            parameters[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            dt = DBHelper.getDataTable_SP(query, parameters);
            return dt;
        }

        /*Add Thanh Binh filter by level of department source  */
        public DataTable LoadTreeviewPermitByLevel(DataTable dtsource, string level)
        {
            DataTable tmpdtsource = new DataTable();
            tmpdtsource = dtsource;
            DataView dv = tmpdtsource.DefaultView;
            if (level != "")
                dv.RowFilter = "ItemLevel <= '" + level + "%'";
            tmpdtsource = dv.ToTable();
            DataRow dataRow = tmpdtsource.NewRow();
            dataRow["ITEMCODE"] = "";
            dataRow["SHORTNAME"] = "";
            tmpdtsource.Rows.InsertAt(dataRow, 0);
            return tmpdtsource;
        }
        public static DataTable LoadDeptTreeView()
        {
            DataTable dtData = new DataTable();
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("p_cursor", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            dtData = DBHelper.getDataTable_SP("PKOPM_CATEGORY.sp_LoadCategory", parameters);

            return dtData;
        }

        public static DataTable LoadPopup(string level, string pParentCode)
        {
            string query = "PK_HR_ORGANIZATION.sp_OrganazationRegistry_Popup";
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("pLevel", level);
            parameters[1] = new OracleParameter("pParentCode", pParentCode ?? "");
            parameters[2] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable Save(string level, string corporation, string department, string team, string section)
        {
            string spName = "PK_HR_ORGANIZATION.sp_DepartmentRegistry";
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pLevel", level);
            parameters[1] = new OracleParameter("pCorporation", corporation);
            parameters[2] = new OracleParameter("pDepartment", department);
            parameters[3] = new OracleParameter("pTeam", team);
            parameters[4] = new OracleParameter("pSection", section);
            parameters[5] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }

        public static DataTable LoadDeptCombobox(string pDeptcode)
        {
            string spName = "PKHR_COMPANYINFO.sp_Deparmentload_Qry";

            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pDeptcode", pDeptcode);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, param);
        }

        //ADD BY NDHUNG 2017.07.06 -> KIỂM TRA QUYỀN XUẤT BÁO CÁO LƯƠNG VÀ CÔNG CỦA TẤT CẢ PK
        public static DataTable User_CheckRole8000(string userId)
        {
            string spName = "PKOPM_USER.SP_USER_CHECK_ROLE8000";

            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("PUSER_ID", userId);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, param);
        }
    }
}