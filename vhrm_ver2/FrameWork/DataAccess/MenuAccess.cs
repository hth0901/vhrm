/*      Author: Dat.vdt
 *      Description: To access Menu's functions
 */

using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;

namespace vhrm.FrameWork.DataAccess
{
    public class MenuAccess
    {

        public DataTable Get_Modules_forMenu(string pLangId, string pEmpId)
        {
            string sqlQuery = "sp_Menu_GetModule";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("@pLangID", pLangId);
            param[1] = new OracleParameter("@pEmpID", pEmpId);
            DataTable dt = DBHelper.getDataTable_SP(sqlQuery, param);
            return dt;
        }

        public DataTable Menu_Save(string WorkingTag, string PgmId, string PgmNm, string PgmNmEn, string PgmNmKr, string PgmFile, string Url, string ModuleId, string pLangID, string EmpID)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[10];
            param[0] = new OracleParameter("@pWorkingTag", WorkingTag);
            param[1] = new OracleParameter("@pPgmId", PgmId);
            param[2] = new OracleParameter("@pPgmNm", PgmNm);
            param[3] = new OracleParameter("@pPgmNmEn", PgmNmEn);
            param[4] = new OracleParameter("@pPgmNmKr", PgmNmKr);
            param[5] = new OracleParameter("@pPgmFile", PgmFile);
            param[6] = new OracleParameter("@pUrl", Url);
            param[7] = new OracleParameter("@pModuleId", ModuleId);
            param[8] = new OracleParameter("@pLangID", pLangID);
            param[9] = new OracleParameter("@pEmpID", EmpID);

            dtData = DBHelper.getDataTable_SP("sp_Menu_Save", param);

            return dtData;
        }
    }
}