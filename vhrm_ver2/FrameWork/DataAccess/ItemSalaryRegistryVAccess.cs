using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;
using System.Data;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class ItemSalaryRegistryVAccess
    {
        public static DataTable LoadDataForGrid(string version,int ItemType)
        {
            string query = "PKPayroll_SALARYREGISTRYVers.sp_PR_CM_SALARYITEM_VER_Query";

            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("pVER_ID", version);
            parameters[1] = new OracleParameter("pITEMTYPE", ItemType);
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        /*
        public static DataTable Save(string workingTag, ItemSalaryRegistryVEntity entity)
        {
<<<<<<< .mine
            string spName = "SALARY_FORM.sp_Save_T_PR_CM_SALARYITEM_VER";
=======
            string spName = "SALARY_FORM.sp_T_HR_CM_SALARYITEM_VER_Save";
>>>>>>> .r1942
            OracleParameter[] parameters = new OracleParameter[6];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag ?? "");
            parameters[1] = new OracleParameter("p_UID", entity.p_UID ?? "");
            parameters[2] = new OracleParameter("p_ITEMID", entity.p_ITEMID ?? "");
            parameters[3] = new OracleParameter("p_VER_ID", entity.p_VER_ID ?? "");
            parameters[4] = new OracleParameter("p_ISACTIVE", entity.p_ISACTIVE);
            parameters[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }*/
        public static bool SaveData(DataTable table)
         {
             bool success = false;
             string errorStr = "Successfull";
             ConnectionHelper cnnHelper = new ConnectionHelper();
             using (OracleConnection connection = cnnHelper.Connect())
             {

                 OracleTransaction oracleTran = connection.BeginTransaction();
                 OracleCommand command = new OracleCommand("PKPayroll_SALARYREGISTRYVers.sp_Save_T_PR_CM_SALARYITEM_VER", connection);

                 command.CommandType = CommandType.StoredProcedure;
                 command.UpdatedRowSource = UpdateRowSource.None;
                 command.Transaction = oracleTran;
                 command.Parameters.Add("p_UID", OracleType.NVarChar, 20, "p_UID");
                 command.Parameters.Add("p_ITEMID", OracleType.Char, 5, "p_ITEMID");
                 command.Parameters.Add("p_VER_ID", OracleType.Char, 5, "p_VER_ID");
                 command.Parameters.Add("p_ISACTIVE", OracleType.Char, 1, "p_ISACTIVE");
                 OracleDataAdapter adpt = new OracleDataAdapter();
                 adpt.InsertCommand = command;
                 adpt.UpdateBatchSize = table.Rows.Count;
                 try
                 {
                     int recordsInserted = adpt.Update(table);
                     success = (recordsInserted == 0 ? false : true);
                     oracleTran.Commit();
                 }
                 catch (OracleException oex)
                 {
                     oracleTran.Rollback();
                     errorStr = oex.Message;
                     //throw oex;
                 }
                 finally
                 {
                     oracleTran.Dispose();
                     connection.Close();
                 }
                 return success;
             }
        }
        public static DataTable DeleteAllDataByVersion(string p_VER_ID)
        {
            string spName = "PKPayroll_SALARYREGISTRYVers.sp_Dele_T_PR_CM_SALARYITEM_VER";

            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("p_VER_ID", p_VER_ID);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
    }
}