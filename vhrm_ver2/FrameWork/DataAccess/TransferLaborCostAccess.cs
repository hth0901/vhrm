/*
 * Author: Tran Cong Tho
 * Create Date: 2014/03/27
 * Desc: Transfer Labor Cost to Accouting Access
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OracleClient;
using System.Data;

namespace vhrm.FrameWork.DataAccess
{
    public class TransferLaborCostAccess
    {
        //Load Corporation by User
        public DataTable LoadCorporation(string userid)
        {
            string sp_name = "PKPAYROLL_LABORCOST.SP_LOAD_CORPORATION";
            OracleParameter[] _param = new OracleParameter[2];
            _param[0] = new OracleParameter("PUSER", userid);
            _param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp_name, _param);
        }

        //Load Review Salary Information
        public DataTable ReviewSalary(string deptcode, string fromdate, string todate, string feetype, string isstop)
        {
            string sp_name = "PKPAYROLL_LABORCOST.SP_LOAD_REVIEWSALARY";
            OracleParameter[] _param = new OracleParameter[6];
            _param[0] = new OracleParameter("PDEPTCODE", deptcode);
            _param[1] = new OracleParameter("PFROMDATE", fromdate);
            _param[2] = new OracleParameter("PTODATE", todate);
            _param[3] = new OracleParameter("PFEETYPE", feetype);
            _param[4] = new OracleParameter("PISSTOP", isstop);
            _param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp_name,_param);
        }

        // Check Closing Salary
        public DataTable CheckClosing(string deptcode, string fromdate)
        {
            string sp_name = "PKPAYROLL_LABORCOST.SP_CHECK_CLOSING_SAL";
            OracleParameter[] _param = new OracleParameter[3];
            _param[0] = new OracleParameter("PDEPTCODE", deptcode);
            _param[1] = new OracleParameter("PFROMDATE", fromdate);
            _param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp_name, _param);
        }

        //Check Exists of Transfer Fee
        public DataTable CheckExists(string deptcode, string todate, string req_type, string pay_type)
        {
            string sp_name = "PKPAYROLL_LABORCOST.SP_CHECK_EXISTS_TRANS";
            OracleParameter[] _param = new OracleParameter[5];
            _param[0] = new OracleParameter("PDEPTCODE", deptcode);
            _param[1] = new OracleParameter("PTODATE", todate);
            _param[2] = new OracleParameter("PREQ_TYPE", req_type);
            _param[3] = new OracleParameter("PPAY_TYPE", pay_type);
            _param[4] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp_name, _param);
        }

        //Load Master of Transfer Data
        public DataTable LoadMaster(string deptcode, string fromdate, string todate, string feetype, string isstop)
        {
            string sp_name = "PKPAYROLL_LABORCOST.SP_LOAD_MASTER_DATA";
            OracleParameter[] _param = new OracleParameter[6];
            _param[0] = new OracleParameter("PDEPTCODE", deptcode);
            _param[1] = new OracleParameter("PFROMDATE", fromdate);
            _param[2] = new OracleParameter("PTODATE", todate);
            _param[3] = new OracleParameter("PFEETYPE", feetype);
            _param[4] = new OracleParameter("PISSTOP", isstop);
            _param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp_name, _param);
        }

        //Load Generate Transfer Data
        public DataTable GenerateTransferSalary(string deptcode, string fromdate, string todate, string feetype, string isstop)
        {
            string sp_name = "PKPAYROLL_LABORCOST.SP_GENERATE_TRANSFERDATA";
            OracleParameter[] _param = new OracleParameter[6];
            _param[0] = new OracleParameter("PDEPTCODE", deptcode);
            _param[1] = new OracleParameter("PFROMDATE", fromdate);
            _param[2] = new OracleParameter("PTODATE", todate);
            _param[3] = new OracleParameter("PFEETYPE", feetype);
            _param[4] = new OracleParameter("PISSTOP", isstop);
            _param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp_name, _param);
        }

        //Transfer Labor Cost Process
        public bool TransferLaborCost(string deptcode, string fromdate, string todate, string feetype, string isstop, string req_type, string pay_type,string userid,string amount, string outline, string corp, string dept, string team, string section)
        {
            string sp_name = "PKPAYROLL_LABORCOST.SP_TRANSFER_LABORCOST";
            OracleParameter[] _param = new OracleParameter[14];
            _param[0] = new OracleParameter("PUSERID", userid);
            _param[1] = new OracleParameter("PDEPTCODE", deptcode);
            _param[2] = new OracleParameter("PFROMDATE", fromdate);
            _param[3] = new OracleParameter("PTODATE", todate);
            _param[4] = new OracleParameter("PISSTOP", isstop);
            _param[5] = new OracleParameter("PFEETYPE", feetype);
            _param[6] = new OracleParameter("PREQ_TYPE", req_type);
            _param[7] = new OracleParameter("PPAY_TYPE", pay_type);
            _param[8] = new OracleParameter("PAMOUNT", amount);
            _param[9] = new OracleParameter("POUTLINE", outline);
            _param[10] = new OracleParameter("PCORPORATION", corp);
            _param[11] = new OracleParameter("PDEPARTMENT", dept);
            _param[12] = new OracleParameter("PTEAM", team);
            _param[13] = new OracleParameter("PSECTION", section);

            return DBHelper.ExecuteNonQuery_SP(sp_name, _param);
        }
    }
}