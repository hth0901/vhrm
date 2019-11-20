/*
* Author: Pham Hung Dung
* Create Date:
* Description: 
*/

using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;
using System.Web;

namespace vhrm.FrameWork.DataAccess
{
    public class FormAccess
    {
        public static DataTable GetForm()
        {
            OracleParameter[] _sqlParam = new OracleParameter[1];
            _sqlParam[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("PKOPM_FORMANDMENU.sp_OPM_Form_get_Form", _sqlParam);
            return table;
        }

        public static DataTable GetForm(string dictionaryID)
        {
            OracleParameter[] sqlParam = new OracleParameter[1];
            sqlParam[0] = new OracleParameter("DictionaryID", dictionaryID);
            DataTable table = DBHelper.getDataTable_SP("sp_OPM_Form_get_Form_not_in_DictionaryBook", sqlParam);
            return table;
        }

        public static bool InsertForm(FormEntity formEntity)
        {
      

            OracleParameter[] sqlParam = new OracleParameter[6];
            sqlParam[0] = new OracleParameter("FormID", formEntity.FormID);
            sqlParam[1] = new OracleParameter("FormName", formEntity.FormName);
            sqlParam[2] = new OracleParameter("DictionaryID", formEntity.DictionaryID);
            //sqlParam[3] = new OracleParameter("CREATE_DT", formEntity.CREATE_DT);
            sqlParam[3] = new OracleParameter("CREATE_UID", formEntity.CREATE_UID);
            sqlParam[4] = new OracleParameter("FilePath", formEntity.FilePath);
            sqlParam[5] = new OracleParameter("ModuleID", formEntity.ModuleID);
            return DBHelper.ExecuteNonQuery_SP("PKOPM_FORMANDMENU.sp_OPM_Form_Insert", sqlParam);
        }

        public static bool DeleteForm(string ID)
        {
            OracleParameter[] sqlParam = new OracleParameter[1];
            sqlParam[0] = new OracleParameter("FormID", ID);
            return DBHelper.ExecuteNonQuery_SP("PKOPM_FORMANDMENU.sp_OPM_Form_Delete", sqlParam);
        }

        public static bool UpdateForm(FormEntity formEntity)
        {
            OracleParameter[] sqlParam = new OracleParameter[6];
            sqlParam[0] = new OracleParameter("FormID", formEntity.FormID);
            sqlParam[1] = new OracleParameter("FormName", formEntity.FormName);
            sqlParam[2] = new OracleParameter("DictionaryID", formEntity.DictionaryID);
            //sqlParam[3] = new OracleParameter("UPDATE_DT", formEntity.UPDATE_DT);
            sqlParam[3] = new OracleParameter("UPDATE_UID", formEntity.UPDATE_UID);
            sqlParam[4] = new OracleParameter("FilePath", formEntity.FilePath);
            sqlParam[5] = new OracleParameter("ModuleID", formEntity.ModuleID);
            return DBHelper.ExecuteNonQuery_SP("PKOPM_FORMANDMENU.sp_OPM_Form_Update", sqlParam);
        }
    }
}