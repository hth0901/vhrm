using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class HRRecruitmentListAccess
    {
        public static DataTable load_RecruitmentList(string Corporation, string empid, string fromdate, string todate, string IdentityCard, string Position, string RoleGroup, string DateJoinFrom, string DateJoinTo, string isRecruited,string language)
        {
            OracleParameter[] parameters = new OracleParameter[12];
            parameters[0] = new OracleParameter("pDeptCd", Corporation);
            parameters[1] = new OracleParameter("pEmployeeId", empid ?? "");
            parameters[2] = new OracleParameter("pFromDate", fromdate ?? "");
            parameters[3] = new OracleParameter("pToDate", todate ?? "");

            parameters[4] = new OracleParameter("pIdentityCard", IdentityCard);
            parameters[5] = new OracleParameter("pPosition", Position ?? "");
            parameters[6] = new OracleParameter("pRoleGroup", RoleGroup ?? "");
            parameters[7] = new OracleParameter("pDateJoinFrom", DateJoinFrom ?? "");
            parameters[8] = new OracleParameter("pDateJoinTo", DateJoinTo ?? "");
            parameters[9] = new OracleParameter("pisRecruited", isRecruited ?? "");
            parameters[10] = new OracleParameter("planguage", language ?? "");
            parameters[11] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKHR_RECRUITMENTLIST.sp_Recruitment_list_Qry", parameters);
        }

        public static DataTable RecruitmentList_LoadInitInsert(string corp, string userId)
        {
            var sp = "PKHR_RECRUITMENTLIST.SP_LOAD_INIT_INSERT";

            var para = new OracleParameter[3];
            para[0] = new OracleParameter("PCORP", corp);
            para[1] = new OracleParameter("PUSERID", userId ?? "");
            para[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP(sp, para);
        }
    }
}