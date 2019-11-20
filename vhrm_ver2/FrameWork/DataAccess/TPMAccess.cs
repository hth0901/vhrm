using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class TPMAccess
    {
        //==================================================================================
        //add by ndhung 2016.08.18 -> get list user TPM
        //==================================================================================
        public DataTable TPM_GetListEmp(string dept, string status)
        {
            string query = "PK_TPM.SP_GET_TPM_USER";

            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("PDEPT", dept);
            parameters[1] = new OracleParameter("PSTATUS", status);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            DataTable dtData = new DataTable();
            dtData = DBHelper.getDataTable_SP(query, parameters);
            return dtData;
        }
    }
}