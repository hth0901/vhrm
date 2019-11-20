using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class PgmPermissionAccess
    {
        public PageInfo GetPgmPermission(string PgmId, PageInfo _page)
        {
           
            DataTable dsData = new DataTable();
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("@pPgmID", PgmId);
            param[1] = new OracleParameter("@pLangID", _page.LangId);
            param[2] = new OracleParameter("@pEmpID", _page.UserCd);
            dsData = DBHelper.getDataTable_SP("sp_PgmPermission_Get", param);
            if (dsData != null && dsData.Rows.Count>0)
            {
                _page.IsInsert = (dsData.Rows[0]["SInsert"].ToString()=="1"?true:false);
                _page.IsUpdate = (dsData.Rows[0]["SUpdate"].ToString() == "1" ? true : false);
                _page.IsDelete = (dsData.Rows[0]["SDelete"].ToString() == "1" ? true : false);
                _page.IsRead = (dsData.Rows[0]["SRead"].ToString() == "1" ? true : false);
                _page.IsReport = (dsData.Rows[0]["SReport"].ToString() == "1" ? true : false);
                _page.IsExcel = (dsData.Rows[0]["SExcel"].ToString() == "1" ? true : false);
            }
            return _page;
        }
    }
}