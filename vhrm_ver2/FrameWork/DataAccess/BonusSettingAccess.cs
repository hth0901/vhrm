using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class BonusSettingAccess
    {
        public static DataTable loadGridBonusSetting(string versionID)
        {
            string spName = "PKPAYROLL_BONUSSETTING.sp_T_PR_CM_BONUSSETTING_Query";

            DataTable dsData = new DataTable();
            OracleParameter[] param = new OracleParameter[2];
            param[0] = new OracleParameter("pVersionId", versionID);
            param[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dsData = DBHelper.getDataTable_SP(spName,param);
            return dsData;
        }

        public static DataTable loadGridBonusSetting(string versionID, string deptcode)
        {
            string spName = "PKPAYROLL_BONUSSETTING.sp_T_PR_CM_BONUSSET_DEPTQRY";

            DataTable dsData = new DataTable();
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("pVersionId", versionID);
            param[1] = new OracleParameter("pDeptcode", deptcode);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dsData = DBHelper.getDataTable_SP(spName, param);
            return dsData;
        }

        public static DataTable Save(string workingTag, BonusSetingEntity bonusEntity)
        {
            string spName = "PKPAYROLL_BONUSSETTING.sp_T_PR_CM_BONUSSETTING_Save";
            OracleParameter[] parameters = new OracleParameter[21];
            parameters[0] = new OracleParameter("pWorking", workingTag ?? "");
            parameters[1] = new OracleParameter("pVER_ID",bonusEntity.Ver_id);
            parameters[2] = new OracleParameter("pKIND_BONUS", bonusEntity.Kind_Bonus ?? "");
            parameters[3] = new OracleParameter("pJOIN_FROM", bonusEntity.Join_from ?? "");
            parameters[4] = new OracleParameter("pJOIN_TO", bonusEntity.Join_to );
            parameters[5] = new OracleParameter("pRATE", bonusEntity.Rate);
            parameters[6] = new OracleParameter("pAMOUNT", bonusEntity.Amount);
            parameters[7] = new OracleParameter("pDISCIPLINE_FROM", bonusEntity.Discipline_from);
            parameters[8] = new OracleParameter("pDISCIPLINE_TO", bonusEntity.Discipline_to ?? "");
            parameters[9] = new OracleParameter("pDISCIPLINE1", bonusEntity.Discipline1);
            parameters[10] = new OracleParameter("pDISCIPLINE1_RATE", bonusEntity.Discipline1_rate);
            parameters[11] = new OracleParameter("pDISCIPLINE2", bonusEntity.Discipline2);
            parameters[12] = new OracleParameter("pDISCIPLINE2_RATE", bonusEntity.Discipline2_rate);
            parameters[13] = new OracleParameter("pConfirmIs", bonusEntity.ConfirmIs);
            parameters[14] = new OracleParameter("pConfirmUID", bonusEntity.ConfirmUID);
            parameters[15] = new OracleParameter("pUID", bonusEntity.UID);
            parameters[16] = new OracleParameter("pDeptcode", bonusEntity.DEPTCODE);

            //add by ndhung 2017.04.17 -> thêm cấu hình PIT Bonus và PIT Lương
            parameters[17] = new OracleParameter("pIS_BONUS_PIT", bonusEntity.IS_BONUS_PIT);
            parameters[18] = new OracleParameter("pIS_SALARY_PIT", bonusEntity.IS_SALARY_PIT);
            parameters[19] = new OracleParameter("pSALARY_MONTH", bonusEntity.SALARY_MONTH);

            parameters[20] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
    }
}