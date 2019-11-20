/*
Create by ndhung
Create Date: 02/04/2018
Desc: Code lại trang Evaluation do quá chậm và nặng, kết hợp PK thay đổi công thức đánh giá nên cấu hình lại động không dùng cứng nữa    
*/

using System;
using vhrm.FrameWork.Entity;
using System.Data;
using System.Data.OracleClient;
using System.IO;
using System.Data.OleDb;
namespace vhrm.FrameWork.DataAccess
{
    public static class ConstSessionEvaluation
    {
        //đây là lớp lưu các tên của các Session sử dụng trong page Evaluation_Ver2
        public static string WorkerAttritube = "WRK_ATTTD";
        public static string WorkerContribute = "WRK_CNTRB";

        public static string LeaderAttitude = "LDR_ATTTD";
        public static string LeaderManagementSkill = "LDR_MNGMN";
        public static string LeaderQualityQuantity = "LDR_QLTYQ";

        public static string StaffKnowledge = "STF_KNWLD";
        public static string StaffExperience = "STF_XPRNC";
        public static string StaffCustomization = "STF_CSTMZ";
        public static string StaffCooperation = "STF_CPRTN";
        public static string StaffPlanning = "STF_PLNNN";
        public static string StaffQuality = "STF_QLTYJ";
        public static string StaffTraining = "STF_TRNNG";
        public static string StaffCommunication = "STF_CMMNC";
        public static string StaffAttitude = "STF_ATTTD";
        public static string StaffStrengthWeakness = "STF_STRNG";

        public static string ManagerBusiness = "MNG_BSNSS";
        public static string ManagerInnovation = "MNG_NNVTN";
        public static string ManagerCustomization = "MNG_CSTMZ";
        public static string ManagerCooperation = "MNG_CPRTN";
        public static string ManagerTraining = "MNG_TRNNG";
        public static string ManagerCommunication = "MNG_CMMNC";
        public static string ManagerStrategy = "MNG_STRTG";
        public static string ManagerInformation = "MNG_NFRMT";
        public static string ManagerManagementSkill = "MNG_HRSKL";
        public static string ManagerStrengthWeakness = "MNG_STRNG";
    }

    public class aEvaluationVer2Access
    {
        //============================================================================
        // lấy combobox loại nhân viên
        //============================================================================
        public DataTable GetEvaluationClass(string user, string lang = "en")
        {
            var parameters = new OracleParameter[3];

            parameters[0] = new OracleParameter("P_USER", user);
            parameters[1] = new OracleParameter("P_LANG", lang);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PK_EVALUATION_V2.SP_EVALUATION_VER2_GET_CLASS", parameters);
        }

        //============================================================================
        // review data
        //============================================================================
        public DataTable GetDataReview(string evclass, string dept, string month, string user, string lang = "en")
        {
            OracleParameter[] parameters = new OracleParameter[6];
            int i = 0;
            parameters[i++] = new OracleParameter("P_CLASS", evclass);
            parameters[i++] = new OracleParameter("P_DEPT", dept);
            parameters[i++] = new OracleParameter("P_MONTH", month);
            parameters[i++] = new OracleParameter("P_USER", user);
            parameters[i++] = new OracleParameter("P_LANG", lang);
            parameters[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PK_EVALUATION_V2.SP_EVALUATION_VER2_REVIEW", parameters);
        }


        //============================================================================
        // lấy combobox các tiêu chí đánh giá
        //============================================================================
        public DataTable GetEvaluation_FieldCombo(string code, string dept, string month, string lang = "en")
        {
            OracleParameter[] parameters = new OracleParameter[5];
            int i = 0;
            parameters[i++] = new OracleParameter("P_CODE", code);
            parameters[i++] = new OracleParameter("P_DEPT", dept);
            parameters[i++] = new OracleParameter("P_MONTH", month);
            parameters[i++] = new OracleParameter("P_LANG", lang);
            parameters[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PK_EVALUATION_V2.SP_EVALUATION_VER2_GET_COMBO", parameters);
        }

        //============================================================================
        // lấy thông tin biểu đồ
        //============================================================================
        public DataTable GetEvaluation_Chart_GetOtherGrade(string dept, string month)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            int i = 0;
            parameters[i++] = new OracleParameter("P_DEPT", dept);
            parameters[i++] = new OracleParameter("P_MONTH", month);
            parameters[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PK_EVALUATION_V2.SP_EV_VER2_CHART_GET_GRADE", parameters);
        }

        public DataTable GetEvaluation_Chart(string evclass, string dept, string month, string user, string lang = "en")
        {
            OracleParameter[] parameters = new OracleParameter[6];
            int i = 0;
            parameters[i++] = new OracleParameter("P_CLASS", evclass);
            parameters[i++] = new OracleParameter("P_DEPT", dept);
            parameters[i++] = new OracleParameter("P_MONTH", month);
            parameters[i++] = new OracleParameter("P_USER", user);
            parameters[i++] = new OracleParameter("P_LANG", lang);
            parameters[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PK_EVALUATION_V2.SP_EVALUATION_VER2_CHART", parameters);
        }

        //============================================================================
        // lấy thang bảng lương, 2 mức thấp hơn và 3 mức lớn hơn
        //============================================================================
        public DataTable GetEvaluation_SalaryTable(string evlid, string lang = "en")
        {
            OracleParameter[] parameters = new OracleParameter[3];
            int i = 0;
            parameters[i++] = new OracleParameter("P_EVLID", evlid);
            parameters[i++] = new OracleParameter("P_LANG", lang);
            parameters[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PK_EVALUATION_V2.SP_EVALUATION_VER2_GETSALARY", parameters);
        }


        //============================================================================
        // CHỨC NĂNG CALCULATE MỚI
        //============================================================================
        public DataTable ProcessEvaluation_CalculateEach(string empid, string month, string param, string note, string user)
        {
            OracleParameter[] parameters = new OracleParameter[6];
            int i = 0;
            parameters[i++] = new OracleParameter("P_EMPID", empid);
            parameters[i++] = new OracleParameter("P_MONTH", month);
            parameters[i++] = new OracleParameter("P_PARAM", param);
            parameters[i++] = new OracleParameter("P_NOTE", note);
            parameters[i++] = new OracleParameter("P_USER", user);
            parameters[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PK_EVALUATION_V2.SP_EV_VER2_CALCULATE_EACH", parameters);
        }


        //============================================================================
        // chức năng SUBMIT MỚI
        //============================================================================
        public DataTable ProcessEvaluation_Cancel(string evlid, string remark, string user)
        {
            OracleParameter[] parameters = new OracleParameter[4];
            int i = 0;
            parameters[i++] = new OracleParameter("P_EVLID", evlid);
            parameters[i++] = new OracleParameter("P_REMARK", remark); 
            parameters[i++] = new OracleParameter("P_USER", user);
            parameters[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PK_EVALUATION_V2.SP_EVALUATION_VER2_CANCEL", parameters);
        }


        //============================================================================
        // chức năng SUBMIT MỚI
        //============================================================================
        public DataTable ProcessEvaluation_Submit(string evlid, string user)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            int i = 0;
            parameters[i++] = new OracleParameter("P_EVLID", evlid);
            parameters[i++] = new OracleParameter("P_USER", user);
            parameters[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PK_EVALUATION_V2.SP_EVALUATION_VER2_SUBMIT", parameters);
        }


        //============================================================================
        // chức năng CHECK MỚI
        //============================================================================
        public DataTable ProcessEvaluation_Check(string param, string user)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            int i = 0;
            parameters[i++] = new OracleParameter("P_PARAM", param);
            parameters[i++] = new OracleParameter("P_USER", user);
            parameters[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PK_EVALUATION_V2.SP_EVALUATION_VER2_CHECK", parameters);
        }


        //============================================================================
        // chức năng CONFIRM MỚI
        //============================================================================
        public DataTable ProcessEvaluation_Confirm(string param, string user)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            int i = 0;
            parameters[i++] = new OracleParameter("P_PARAM", param);
            parameters[i++] = new OracleParameter("P_USER", user);
            parameters[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PK_EVALUATION_V2.SP_EVALUATION_VER2_CONFIRM", parameters);
        }


        //============================================================================
        // chức năng APPROVE MỚI
        //============================================================================
        public DataTable ProcessEvaluation_Aprrove(string evlid, string user)
        {
            OracleParameter[] parameters = new OracleParameter[3];
            int i = 0;
            parameters[i++] = new OracleParameter("P_EVLID", evlid);
            parameters[i++] = new OracleParameter("P_USER", user);
            parameters[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PK_EVALUATION_V2.SP_EVALUATION_VER2_APPROVE", parameters);
        }

        //============================================================================
        // chức năng APPROVE MỚI
        //============================================================================
        public DataTable ProcessEvaluation_UpdatePercent(string evlid, string percent, string user)
        {
            OracleParameter[] parameters = new OracleParameter[4];
            int i = 0;
            parameters[i++] = new OracleParameter("P_EVLID", evlid);
            parameters[i++] = new OracleParameter("P_PERCENT", percent);
            parameters[i++] = new OracleParameter("P_USER", user);
            parameters[i++] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            return DBHelper.getDataTable_SP("PK_EVALUATION_V2.SP_SAVE_INCREASEPERCENT_MANUAL", parameters);
        }
    }
}