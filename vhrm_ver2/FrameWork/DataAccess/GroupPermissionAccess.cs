/*      Author: Dat.vdt
 *      Description: To access Group's functions
 */

using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;

namespace vhrm.FrameWork.DataAccess
{
    public class GroupPermissionAccess
    {
        //this area is used for GROUP
        public DataTable GetAll(string pLangId, string pEmpId)
        {
            string sqlQuery = "sp_GroupPermission_Qry";
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("@pLangID", pLangId);
            param[1] = new OracleParameter("@pUserID", pEmpId);
            DataTable dt = DBHelper.getDataTable_SP(sqlQuery, param);
            return dt;
        }

        public DataTable Group_Save(string WorkingTag, string GrpId, string GrpNm, bool pIsActive, string pDictionary, string pLangID, string EmpID)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[7];
            param[0] = new OracleParameter("@pWorkingTag", WorkingTag);
            param[1] = new OracleParameter("@pGrpId", GrpId);
            param[2] = new OracleParameter("@pGrpNm", GrpNm);
            param[3] = new OracleParameter("@pIsActive", pIsActive);
            param[4] = new OracleParameter("@pDictionaryId", pDictionary);
            param[5] = new OracleParameter("@pLangID", pLangID);
            param[6] = new OracleParameter("@pUserID", EmpID);

            dtData = DBHelper.getDataTable_SP("sp_GroupPermission_Save", param);

            return dtData;
        }

        /////This area is used for Group's permission
        public DataTable GetGroupPermission(string UserCdOrGrpId)
        {
            string sqlQuery = "sp_PgmSecu_Qry";
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("@pUserCdOrGrpId", UserCdOrGrpId);
            DataTable dt = DBHelper.getDataTable_SP(sqlQuery, param);
            return dt;
        }

        public DataTable GroupPermission_Save(string WorkingTag, string PgmID, string UserCdOrGrpId, bool IsUser, bool SInsert,
                                                                    bool SUpdate, bool SDelete, bool SRead, bool SReport, string pLangID, string EmpID)
        {
            DataTable dtData = new DataTable();
            OracleParameter[] param = new OracleParameter[11];
            param[0] = new OracleParameter("@pWorkingTag", WorkingTag);
            param[1] = new OracleParameter("@pPgmID", PgmID);
            param[2] = new OracleParameter("@pUserCdOrGrpId", UserCdOrGrpId);
            param[3] = new OracleParameter("@pIsUser", IsUser);
            param[4] = new OracleParameter("@pSInsert", SInsert);
            param[5] = new OracleParameter("@pSUpdate", SUpdate);
            param[6] = new OracleParameter("@pSDelete", SDelete);
            param[7] = new OracleParameter("@pSRead", SRead);
            param[8] = new OracleParameter("@pSReport", SReport);
            param[9] = new OracleParameter("@pLangID", pLangID);
            param[10] = new OracleParameter("@pUserID", EmpID);

            dtData = DBHelper.getDataTable_SP("sp_PgmSecu_Save", param);

            return dtData;
        }
        public DataSet LoadQueryData(DataTable dtParam, string PgmID)
        {
            DataSet dsData = new DataSet();
            OracleParameter[] param = new OracleParameter[dtParam.Rows.Count];
            for (int i = 0; i < dtParam.Rows.Count; i++)
                param[i] = new OracleParameter(dtParam.Rows[i]["Name"].ToString(), dtParam.Rows[i]["Value"]);                

            dsData = DBHelper.getDataSet_SP("S" + PgmID, param);

            return dsData;
        }
    }
}