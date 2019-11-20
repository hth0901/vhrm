using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.DataAccess
{
    public class EmpID_InitAccess
    {
        public static DataTable load_Group(string group)
        {
            OracleParameter[] _sqlParam = new OracleParameter[2];
            _sqlParam[0] = new OracleParameter("pGroup", group);
            _sqlParam[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("PKCONFIG_EMPID_INIT.sp_LoadiInitGroup", _sqlParam);
            return table;
        }
        public static DataTable load_GroupValue()
        {
            OracleParameter[] _sqlParam = new OracleParameter[1];
            _sqlParam[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("PKCONFIG_EMPID_INIT.sp_LoadiInitGroupValue", _sqlParam);
            return table;
        }
        public static DataTable INITVALUES_SAVE(string workingtag, string deptcode, string deptlevel, string staffinit, string workerinit)
        {
            OracleParameter[] _sqlParam = new OracleParameter[6];
            _sqlParam[0] = new OracleParameter("pWorkingTag", workingtag);
            _sqlParam[1] = new OracleParameter("pDeptcode", deptcode);
            _sqlParam[2] = new OracleParameter("pDeptlevel", deptlevel);
            _sqlParam[3] = new OracleParameter("pStaffInit", staffinit);
            _sqlParam[4] = new OracleParameter("pWorkerInit", workerinit);
            _sqlParam[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable table = DBHelper.getDataTable_SP("PKCONFIG_EMPID_INIT.sp_InitValue_Save", _sqlParam);
            return table;
        }
       
    }
}