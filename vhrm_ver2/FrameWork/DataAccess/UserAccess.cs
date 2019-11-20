
using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class UserAccess
    {
        public static DataTable LoadAllUser(string Corporation)
        {
            string spName = "PKOPM_USER.sp_User_Qry";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pCorporation", Corporation);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            foreach (DataRow dr in dt.Rows)
            {
                string strtip, endip;
                try
                {
                    strtip = ToolHelper.INT2IP(Convert.ToInt32(dr["StartIP"]));
                }
                catch
                {
                    strtip = "";
                }
                try
                {
                    endip = ToolHelper.INT2IP(Convert.ToInt32(dr["EndIP"]));
                }
                catch
                {
                    endip = "";
                }
                dr["EndIP"] = endip;
                dr["StartIP"] = strtip;
            }
            return dt;
        }
        public static DataTable getAllUser()
        {
            string spName = "";
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            DataTable dtResult = DBHelper.getDataTable_SP(spName, param);
            return dtResult;
        }
        public DataTable LoadAllUser_Popup(string pWorkingTag)
        {
            string spName = "HUMANRESOURCE.sp_UserList";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("WorkingTag", pWorkingTag);
            param[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public DataTable LoadUserCond_Popup(string QryType, string QryValue)
        {
            string spName = "HUMANRESOURCE.sp_UserList_Cond";
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("QryType", QryType);
            param[1] = new OracleParameter("QryValue", QryValue);
            param[2] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public DataTable Delete(string userId)
        {
            string spName = "PKOPM_USER.sp_User_Delete";
            OracleParameter[] para = new OracleParameter[2];
            para[0] = new OracleParameter("pUserId", userId);
            para[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }

        internal DataTable Save(string workingTag, UserEntity user)
        {
            string spName = "PKOPM_USER.sp_User_Save";
            OracleParameter[] para = new OracleParameter[16];
            para[0] = new OracleParameter("pWorkingTag", workingTag);
            para[1] = new OracleParameter("pUserId", user.UserID);
            para[2] = new OracleParameter("pName", OracleDbType.NVarchar2) { Value = user.Name };
            if (user.Password != "")
                para[3] = new OracleParameter("pPassword", ED5Helper.Encrypt(user.Password));
            else
                para[3] = new OracleParameter("pPassword", "");
            para[4] = new OracleParameter("pStaffId", user.StaffId);
            para[5] = new OracleParameter("pMobile", user.Mobile);
            para[6] = new OracleParameter("pEmail", user.Email);
            para[7] = new OracleParameter("pIPRestriction", user.IPRestriction);
            para[8] = new OracleParameter("pStartID", ToolHelper.IP2INT((user.StartIP == "") ? "0.0.0.0" : user.StartIP));
            para[9] = new OracleParameter("pEndID", ToolHelper.IP2INT((user.EndIP == "") ? "0.0.0.0" : user.EndIP));
            para[10] = new OracleParameter("pIsActive", user.IsActive);
            para[11] = new OracleParameter("pUpdateUID", user.UpdateUID);
            para[12] = new OracleParameter("pGroupId", user.GroupID);
            para[13] = new OracleParameter("pDEPTCODE", user.DEPTCODE);
            para[14] = new OracleParameter("pResetPass", user.ResetPass == true ? "Y" : "N");
            para[15] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }

        public static DataTable LoadAllUserPopup()
        {
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_USER.SP_OPM_USER_GETALL_FOR_POPUP", param);
        }
        public DataTable ChangePasswrod(string userI, string oldpass, string newpass)
        {
            oldpass = ED5Helper.Encrypt(oldpass);
            newpass = ED5Helper.Encrypt(newpass);
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pUserId", userI);
            param[1] = new OracleParameter("pOldpass", oldpass);
            param[2] = new OracleParameter("pNewpass", newpass);
            param[3] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_USER.sp_User_ChangePass", param);
        }
        #region Group
        public DataTable Getgroup(string userId)
        {
            string spName = "PKOPM_USER.sp_GroupDetail_Query";
            OracleParameter[] para = new OracleParameter[2];
            para[0] = new OracleParameter("pUserId", userId);
            para[1] = new OracleParameter("T_TABLE", OracleDbType.RefCursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, para);
        }
        public bool SaveData(DataTable table)
        {
            bool success = false;
            string errorStr = "Successfull";
            ConnectionHelper cnnHelper = new ConnectionHelper();
            using (OracleConnection connection = cnnHelper.Connect())
            {

                OracleTransaction oracleTran = connection.BeginTransaction();
                OracleCommand command = new OracleCommand("PKOPM_USER.sp_Save_OPM_Group_Detail", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.UpdatedRowSource = UpdateRowSource.None;
                command.Transaction = oracleTran;
                command.Parameters.Add("pUserId", OracleDbType.NVarchar2, 20, "pUserId");
                command.Parameters.Add("pUSER_ID", OracleDbType.Varchar2, 20, "pUSER_ID");
                command.Parameters.Add("pGROUP_ID", OracleDbType.Varchar2, 10, "pGROUP_ID");
                OracleDataAdapter adpt = new OracleDataAdapter();
                adpt.InsertCommand = command;
                adpt.UpdateBatchSize = table.Rows.Count;
                try
                {
                    int recordsInserted = adpt.Update(table);
                    success = (recordsInserted == 0 ? false : true);
                    oracleTran.Commit();
                }
                catch (OracleException oex)
                {
                    oracleTran.Rollback();
                    errorStr = oex.Message;
                    //throw oex;
                }
                finally
                {
                    oracleTran.Dispose();
                    connection.Close();
                }
                return success;
            }
        }
        #endregion
    }
}