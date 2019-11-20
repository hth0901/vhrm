using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Data;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class NewOrganizationAccess
    {
        //load tree view
        public static DataTable LoadTreeView(string loginId)
        {
            /*
            //get from catch by Van
            DataTable dt = new DataTable();
            if (HttpContext.Current.Cache[vhrm.FrameWork.Utility.ToolHelper.CacheOrg] != null)
            {
                dt = (DataTable)HttpContext.Current.Cache[vhrm.FrameWork.Utility.ToolHelper.CacheOrg];

            }
            else
            {   //get from data by Van
                string query = "HR.sp_NewOrgRegistry_TreeView";
                OracleParameter[] parameters = new OracleParameter[2];
                parameters[0] = new OracleParameter("pLoginID", loginId);
                parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
                dt = DBHelper.getDataTable_SP(query, parameters);
                HttpContext.Current.Cache[vhrm.FrameWork.Utility.ToolHelper.CacheOrg] = dt;
            }*/
            DataTable dt = new DataTable();
            string query = "PK_HR_ORGANIZATION_01.sp_NewOrgRegistry_TreeView";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pLoginID", loginId);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            dt = DBHelper.getDataTable_SP(query, parameters);
            return dt;
        }
        public static DataTable LoadPopup(string level, string pParentCode, string pUser)
        {
            string query = "PK_HR_ORGANIZATION_01.sp_OrganazationRegistry_Popup";
            OracleParameter[] parameters = new OracleParameter[4];
            parameters[0] = new OracleParameter("pLevel", level);
            parameters[1] = new OracleParameter("pParentCode",pParentCode??"");
            parameters[2] = new OracleParameter("pUser",pUser);
            parameters[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        public static DataTable Save(string workingTag, NewOrganizationEntyti entity, string loginId)
        {
            string spName = "PK_HR_ORGANIZATION_01.sp_NewOriganaztion_Save";
            OracleParameter[] parameters = new OracleParameter[19];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag ?? "");
            parameters[1] = new OracleParameter("pDepartmentCode", entity.DepartmentCode ?? "");
            parameters[2] = new OracleParameter("pDepartmentLevel", entity.DepartmentLevel ?? "");
            parameters[3] = new OracleParameter("pFullName", entity.FullName ?? "");
            parameters[4] = new OracleParameter("pShortName", entity.ShortName ?? "");
            parameters[5] = new OracleParameter("pDictionary", entity.Dictionary ?? "");
            parameters[6] = new OracleParameter("pDescription", entity.Description ?? "");
            parameters[7] = new OracleParameter("pCorporation", entity.Corporation ?? "");
            parameters[8] = new OracleParameter("pDepartment", entity.Department ?? "");
            parameters[9] = new OracleParameter("pTeam", entity.Team ?? "");
            parameters[10] = new OracleParameter("pSection", entity.Section ?? "");
            parameters[11] = new OracleParameter("pLine", entity.Line ?? "");
            parameters[12] = new OracleParameter("pIsActive", entity.IsActive ?? "");
            parameters[13] = new OracleParameter("pISPRODUCT", entity.IsProduction ?? "");
            parameters[14] = new OracleParameter("pLoginId", loginId);
            parameters[15] = new OracleParameter("pDEPTCODE", entity.DeptCode??"");
            parameters[16] = new OracleParameter("pORDERINDEX",entity.OrderIndex);
            parameters[17] = new OracleParameter("PACCCODE", entity.Acccode);
            parameters[18] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
           return DBHelper.getDataTable_SP(spName, parameters);
        }
        public static DataTable GetDataByDeptcode(string pDEPTCODE)
        {
            string spName = "PK_HR_ORGANIZATION_01.sp_NewOriganaztion_Query";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pDEPTCODE", pDEPTCODE);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }


        //public static DataTable SaveCorporationGroupSalary(string pDEPTCODE)
        //{
        //    string spName = "PK_HR_ORGANIZATION.sp_SaveCorporationGroupSalary";
        //    OracleParameter[] parameters = new OracleParameter[3];
        //    parameters[0] = new OracleParameter("pDEPTCODE", pDEPTCODE);
        //    //parameters[1] = new OracleParameter("pGROUPSALARY", pGROUPSALARY);
        //    parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
        //    return DBHelper.getDataTable_SP(spName, parameters);
        //}

    }
}