/*
 * Author: Tran Cong Tho
 * Create Date: 10/03/2012
 */

using System.Data.OracleClient;
using System.Data;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class AuthorizationAccess
    {
        //get datatable menuright with menuID
        public static DataTable getMenuRight_withMenuID(string MenuID)
        {
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("p_MENU_ID", MenuID);
            _sqlParam[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            string sp_name = "PKOPM_AUTHORIZATION.sp_OPM_MenuRight_getbyMenuID";
            return DBHelper.getDataTable_SP(sp_name, _sqlParam);
        }

        //get datatable menuright with ownerID
        public static DataTable getMenuRight_withOwnerID(string OwnerID)
        {
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("p_OWNER_ID", OwnerID);
            _sqlParam[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            string sp_name = "PKOPM_AUTHORIZATION.sp_OPM_MenuRight_getbyOwnerID";
            return DBHelper.getDataTable_SP(sp_name, _sqlParam);
        }

        //insert menu right
        public static bool insertMenuRight(AuthorizationEntity entity)
        {
            OracleParameter[] _sqlParam = new OracleParameter[12];
            _sqlParam[0] = new OracleParameter("p_OWNER_ID", entity.OWNER_ID);
            _sqlParam[1] = new OracleParameter("p_MENU_ID", entity.MENU_ID);
            _sqlParam[2] = new OracleParameter("p_IS_VIEW", entity.IS_VIEW);
            _sqlParam[3] = new OracleParameter("p_IS_ADD", entity.IS_ADD);
            _sqlParam[4] = new OracleParameter("p_IS_CONFIRM", entity.IS_CONFIRM);
            _sqlParam[5] = new OracleParameter("p_IS_DELETE", entity.IS_DELETE);
            _sqlParam[6] = new OracleParameter("p_IS_UPDATE", entity.IS_UPDATE);
            _sqlParam[7] = new OracleParameter("p_IS_PRINT", entity.IS_PRINT);
            _sqlParam[8] = new OracleParameter("p_IS_EXPORT", entity.IS_EXPORT);
            _sqlParam[9] = new OracleParameter("p_IS_USER", entity.IS_USER);
            _sqlParam[10] = new OracleParameter("p_CREATE_UID", entity.CREATE_UID);
            _sqlParam[11] = new OracleParameter("p_IS_UNCONFIRM", entity.IS_UNCONFIRM);
            string sp_name = "PKOPM_AUTHORIZATION.sp_OPM_MenuRight_Insert";
            return DBHelper.ExecuteNonQuery_SP(sp_name, _sqlParam);
        }

        //update menu right
        public static bool updateMenuRight(AuthorizationEntity entity)
        {
            OracleParameter[] _sqlParam = new OracleParameter[12];
            _sqlParam[0] = new OracleParameter("p_OWNER_ID", entity.OWNER_ID);
            _sqlParam[1] = new OracleParameter("p_MENU_ID", entity.MENU_ID);
            _sqlParam[2] = new OracleParameter("p_IS_VIEW", entity.IS_VIEW);
            _sqlParam[3] = new OracleParameter("p_IS_ADD", entity.IS_ADD);
            _sqlParam[4] = new OracleParameter("p_IS_CONFIRM", entity.IS_CONFIRM);
            _sqlParam[5] = new OracleParameter("p_IS_DELETE", entity.IS_DELETE);
            _sqlParam[6] = new OracleParameter("p_IS_UPDATE", entity.IS_UPDATE);
            _sqlParam[7] = new OracleParameter("p_IS_PRINT", entity.IS_PRINT);
            _sqlParam[8] = new OracleParameter("p_IS_EXPORT", entity.IS_EXPORT);
            _sqlParam[9] = new OracleParameter("p_IS_USER", entity.IS_USER);
            _sqlParam[10] = new OracleParameter("p_UPDATE_UID", entity.UPDATE_UID);
            _sqlParam[11] = new OracleParameter("p_IS_UNCONFIRM", entity.IS_UNCONFIRM);

            string sp_name = "PKOPM_AUTHORIZATION.sp_OPM_MenuRight_Update";
            return DBHelper.ExecuteNonQuery_SP(sp_name, _sqlParam);
        }

        //Check Exist Menu Right
        public static bool checkExistMenuRight(AuthorizationEntity entity)
        {
            OracleParameter[] _sqlParam = new OracleParameter[3];
            _sqlParam[0] = new OracleParameter("p_MenuID", entity.MENU_ID);
            _sqlParam[1] = new OracleParameter("p_OWNER_ID", entity.OWNER_ID);
            _sqlParam[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            string sp_name = "PKOPM_AUTHORIZATION.sp_OPM_MenuRight_CheckExist";
            //string result = DBHelper.ExcecuteScalar_SP(sp_name, _sqlParam).ToString();
            string result = DBHelper.GetName(sp_name, _sqlParam);
            if (result.Equals("1"))
                return true;
            else
                return false;                
        }

        //delete Menu Right
        public static bool deleteMenuRight(string menuID, string ownerid)
        {
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("p_MENU_ID", menuID);
            _sqlParam[1] = new OracleParameter("p_OWNER_ID", ownerid);

            string sp_name = "PKOPM_AUTHORIZATION.sp_OPM_MenuRight_Delete";
            return DBHelper.ExecuteNonQuery_SP(sp_name, _sqlParam);   
        }

        //get Group Not In Menu Right
        public static DataTable getGroup_notInMenuRight(string MenuID)
        {
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("p_MenuID", MenuID);
            _sqlParam[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            string sp_name = "PKOPM_AUTHORIZATION.sp_OPM_Group_getNotInMenuRight";
            return DBHelper.getDataTable_SP(sp_name, _sqlParam);
        }

        //get User Not In Menu Right
        public static DataTable getUser_notInMenuRight(string MenuID)
        {
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("p_MenuID", MenuID);
            _sqlParam[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            string sp_name = "PKOPM_AUTHORIZATION.sp_OPM_User_getNotInMenuRight";
            return DBHelper.getDataTable_SP(sp_name, _sqlParam);
        }

        //get Group User for tree view
        public static DataTable getGroupUser_Treeview()
        {
            OracleParameter[] _sqlParam = new OracleParameter[1];
            _sqlParam[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            string sp_name = "PKOPM_AUTHORIZATION.sp_OPM_GroupUser_getTreeView";
            return DBHelper.getDataTable_SP(sp_name, _sqlParam);
        }

        //get Menu not in menu right
        public static DataTable getMenu_notInMenuRight(string ownerID)
        {
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("p_OWNER_ID", ownerID);
            _sqlParam[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            string sp_name = "PKOPM_AUTHORIZATION.sp_Menu_getNotInMenuRight";
            return DBHelper.getDataTable_SP(sp_name, _sqlParam);
        }

        //get Permisstion for User and Menu
        public static AuthorizationEntity getPermission_User(string formcode, string userid)
        {
            AuthorizationEntity entity = new AuthorizationEntity();
            OracleParameter[] _sqlParam  = new OracleParameter[3];
            _sqlParam[0] = new OracleParameter("pFORMCODE", formcode);
            _sqlParam[1] = new OracleParameter("pUSERID", userid);
            _sqlParam[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            string sp_name = "PKOPM_AUTHORIZATION.SP_OPM_MENURIGHT_GETPERMISSION";
            DataTable data = DBHelper.getDataTable_SP(sp_name, _sqlParam);
           if(data!=null&&data.Rows.Count>0)
            {
                entity.MENU_ID = data.Rows[0]["MENU_ID"].ToString();
                entity.OWNER_ID = userid;
                foreach (DataRow row in data.Rows)
                {
                    if (row["IS_VIEW"].ToString() == "1")
                        entity.IS_VIEW = true;
                    if (row["IS_CONFIRM"].ToString() == "1")
                        entity.IS_CONFIRM = true;
                    if (row["IS_UNCONFIRM"].ToString() == "1")
                        entity.IS_UNCONFIRM = true;
                    if (row["IS_ADD"].ToString() == "1")
                        entity.IS_ADD = true;
                    if (row["IS_DELETE"].ToString() == "1")
                        entity.IS_DELETE = true;
                    if (row["IS_UPDATE"].ToString() == "1")
                        entity.IS_UPDATE = true;
                    if (row["IS_PRINT"].ToString() == "1")
                        entity.IS_PRINT = true;
                    if (row["IS_EXPORT"].ToString() == "1")
                        entity.IS_EXPORT = true;
                }
            }
            return entity;
        }
        public static DataTable getPermissionForForms_User(string formcode, string userid)
        {
            //AuthorizationEntity entity = new AuthorizationEntity();
            OracleParameter[] _sqlParam = new OracleParameter[3];
            _sqlParam[0] = new OracleParameter("pFORMCODE", formcode);
            _sqlParam[1] = new OracleParameter("pUSERID", userid);
            _sqlParam[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            string sp_name = "PKOPM_AUTHORIZATION.SP_OPM_GETPERMISSIONForms";
            DataTable data = DBHelper.getDataTable_SP(sp_name, _sqlParam);
            return data;
        }
        //get Permisstion for user in page
        public static AuthorizationEntity getPagePermission_User(string formcode, string userid)
        {
            AuthorizationEntity entity = new AuthorizationEntity();
            OracleParameter[] _sqlParam = new OracleParameter[3];
            _sqlParam[0] = new OracleParameter("pFormCode", formcode);
            _sqlParam[1] = new OracleParameter("pUserID", userid);
            _sqlParam[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            string sp_name = "PKOPM_AUTHORIZATION.SP_OPM_MENURIGHT_GETPERMISSION";
            DataTable data = DBHelper.getDataTable_SP(sp_name, _sqlParam);
            if (data != null && data.Rows.Count > 0)
            {
                entity.MENU_ID = data.Rows[0]["MENU_ID"].ToString();
                entity.OWNER_ID = userid;
                foreach (DataRow row in data.Rows)
                {
                    if (row["IS_VIEW"].ToString() == "1")
                        entity.IS_VIEW = true;
                    if (row["IS_CONFIRM"].ToString() == "1")
                        entity.IS_CONFIRM = true;
                    if (row["IS_ADD"].ToString() == "1")
                        entity.IS_ADD = true;
                    if (row["IS_DELETE"].ToString() == "1")
                        entity.IS_DELETE = true;
                    if (row["IS_UPDATE"].ToString() == "1")
                        entity.IS_UPDATE = true;
                    if (row["IS_PRINT"].ToString() == "1")
                        entity.IS_PRINT = true;
                    if (row["IS_EXPORT"].ToString() == "1")
                        entity.IS_EXPORT = true;
                }
            }
            return entity;
        }
        
        

    }
}