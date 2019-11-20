using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;

namespace vhrm.FrameWork.DataAccess
{
    public class HRRecruitmentAccess
    {
        public DataSet RecruitmentInfo_QueryAll()
        {
            string spName = "PKHR_RECRUITMENT.sp_Recruitment_Qry";
            //string spName = "HR.sp_HRInfo_Qry";
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataSet dt = DBHelper.getDataSet_SP(spName, param);
            return dt;
        }
    }
}