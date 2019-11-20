using System.Data.OracleClient;
using System.Data;
using vhrm.FrameWork.Entity;
namespace vhrm.FrameWork.DataAccess
{
    public class RegisterHealthIsuranceAccess
    {
        public static DataTable Load(string pPlaceCode, string pPlaceName, string pPlaceCity, string pADDRESS)
        {
            string query = "PKINSURANCE_REGHEALTH.sp_INS_HEALTHPLACE_Query";
            OracleParameter[] parameters = new OracleParameter[5];
            parameters[0] = new OracleParameter("p_PLACE_CODE", pPlaceCode);
            parameters[1] = new OracleParameter("p_PLACE_NAME", pPlaceName);
            parameters[2] = new OracleParameter("p_PLACE_CITY", pPlaceCity);
            parameters[3] = new OracleParameter("pADDRESS", OracleType.NVarChar) { Value = pADDRESS };
            parameters[4] = new OracleParameter("T_TABLE", OracleType.Cursor) 
            { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable Save(string workingTag, RegisterHealthIsuranceEntity entity, string loginId)
        {
            string spName = "PKINSURANCE_REGHEALTH.sp_INS_HEALTHPLACE_Save";
            OracleParameter[] parameters = new OracleParameter[9];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag ?? "");
            parameters[1] = new OracleParameter("p_UID", loginId ?? "");
            parameters[2] = new OracleParameter("p_PLACE_NAME", entity.PPlaceName ?? "");
            parameters[3] = new OracleParameter("p_PLACE_CITY", entity.PPlaceCity ?? "");
            parameters[4] = new OracleParameter("p_PLACE_CODE", entity.PPlaceCode?? "");
            parameters[5] = new OracleParameter("p_PLACE_KIND", entity.PPLACEKIND ?? "");
            parameters[6] = new OracleParameter("p_ADDRESS", entity.PAddress ?? "");
            parameters[7] = new OracleParameter("p_REMARK", entity.PRemark ?? "");
            parameters[8] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
        public static int CheckPlaceCode(string PLACE_CODE)
        {
            string spName = "PKINSURANCE_REGHEALTH.sp_INS_HEALTHPLACE_Check";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("p_PLACE_CODE", PLACE_CODE);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP(spName, parameters);
            int numberRow=  int.Parse(table.Rows[0]["numberRow"].ToString());
            return numberRow;
        }
    }
}