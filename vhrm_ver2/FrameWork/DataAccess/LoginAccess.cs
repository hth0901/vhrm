using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using vhrm.FrameWork.Utility;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class LoginAccess
    {
        public DataTable changePassword(string UserId, string oldPass, string newPass, string LangID)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("@pUserID", UserId);
            param[1] = new OracleParameter("@pOldPass", oldPass);
            param[2] = new OracleParameter("@pNewPass", newPass);
            param[3] = new OracleParameter("@pLangID", LangID);

            dtData = DBHelper.getDataTable_SP("sp_ChangePassword", param);
            return dtData;
        }
    }
}