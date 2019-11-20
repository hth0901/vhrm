using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class DocumentCenterAccess
    {
        public static DataTable GetAllDocument()
        { 
            string sp_name = "PKHR_DOCUMENTCENTER.SP_GETALLREPORT";
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(sp_name, param);
        }
    }
}