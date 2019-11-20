/*
 * Author: Tran Cong Tho
 * Modify Date: 2014/05/20
 * Desc: Closing Salary Log Access
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class SalaryClosingLogAccess
    {

        // lay danh sach lich su da closing salary
        public DataTable ClosingLog_Query(string deptcode)
        {
            OracleParameter[] _param = new OracleParameter[2];
            _param [0] = new OracleParameter("PDEPTCODE", deptcode);
            _param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            string sp_name = "PKPAYROLL_CLOSINGLOG.SP_SLR_CLOSING_LOG_QUERY";
            return DBHelper.getDataTable_SP(sp_name,_param);
        }

        // kiem tra ton tai salary truoc khi chay process
        public DataTable ClosingLog_Check(string deptcode, string month)
        {
            OracleParameter[] _param = new OracleParameter[3];
            _param[0] = new OracleParameter("PDEPTCODE", deptcode);
            _param[1] = new OracleParameter("PMONTH",month);
            _param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            string sp_name = "PKPAYROLL_CLOSINGLOG.SP_SLR_CLOSING_CHECK";
            return DBHelper.getDataTable_SP(sp_name, _param);
        }
        
        // thực hien closing salary
        public bool ClosingSalary_Process(string deptcode, string month, string userid)
        {
            OracleParameter[] _param = new OracleParameter[3];
            _param[0] = new OracleParameter("PDEPTCODE", deptcode);
            _param[1] = new OracleParameter("PMONTH", month);
            _param[2] = new OracleParameter("PUSERID", userid);

            string sp_name = "PKPAYROLL_CLOSINGLOG.SP_SLR_CLOSING_SALARY";
            return DBHelper.ExecuteNonQuery_SP(sp_name, _param);
        }

    }
}