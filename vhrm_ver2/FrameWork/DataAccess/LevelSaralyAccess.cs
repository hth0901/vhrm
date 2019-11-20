using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class LevelSaralyAccess
    {
        #region 
        public static DataTable Load(string versionId ,string jobCode)
        {
            string query = "PKPAYYROLL_LEVELSALARY.sp_LevelSalary_Qry2";
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("pVersionId", versionId ?? "");
            parameters[1] = new OracleParameter("pJobCode", jobCode ?? "");
            parameters[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable LoadComboBoxData()
        {
            string query = "PKPAYYROLL_LEVELSALARY.sp_Version_Qry";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }

        public static DataTable Save(string workingTag, LevelSaralyEntity entity)
        {
            string spName = "PKPAYYROLL_LEVELSALARY.sp_LevelSalary_Save";
            OracleParameter[] parameters = new OracleParameter[8];
            parameters[0] = new OracleParameter("pWorkingTag", workingTag ?? "");
            parameters[1] = new OracleParameter("pVerID", entity.Version ?? "");
            parameters[2] = new OracleParameter("pJobCode", entity.JobCode ?? "");
            parameters[3] = new OracleParameter("pStep", entity.StepNo ?? "");
            parameters[4] = new OracleParameter("pSalary", entity.Salary);
            parameters[5] = new OracleParameter("pCreateUID", entity.CreateUID ?? "");
            parameters[6] = new OracleParameter("pUpdateUID", entity.CreateUID ?? "");
            parameters[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(spName, parameters);
        }
        /// <summary>
        /// load export leval salary
        /// </summary>
        /// <param name="versionId"></param>
        /// <returns></returns>
        public static DataTable Load_Export_levalsalary(string versionId)
        {
            string query = "SP_LEVELSALARY_EXPORT";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pVersion", versionId ?? "");
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        /// <summary>
        /// load combo level
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public static DataTable GetComboBoxData(int categoryId)
        {
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pCATEGORYID", categoryId);
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKPAYYROLL_LEVELSALARY.SP_LOADCOMBOLEVEL", parameters);
        }
        /// <summary>
        /// check data exit
        /// </summary>
        /// <param name="verID"></param>
        /// <param name="step"></param>
        /// <param name="jobcode"></param>
        /// <returns></returns>
        public static DataTable CheckValidatorSalarylevel(string verID, string step, string jobcode)
        {
            string spName = "PKPAYYROLL_LEVELSALARY.SP_SALARY_LEVEL_Validator";
            OracleParameter[] param = new OracleParameter[4];
            param[0] = new OracleParameter("pVER_ID", verID);
            param[1] = new OracleParameter("pStep", step);
            param[2] = new OracleParameter("pjobcode", jobcode);
            param[3] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        public static DataTable LOAD_DATA_TEST(string USER)
        {
            string query = "PK_MENU_PROJECT.sp_OPM_MENU_getMenuByUser";
            OracleParameter[] parameters = new OracleParameter[2];
            parameters[0] = new OracleParameter("pUserID", USER ?? "");
            parameters[1] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        //CALCULATE SALARY LEVEL

        public static DataTable Calculate_salarylevel(string pVerID, string pJobcode, float pMin, float pRate, string User)

        {
            string spName = "PKPAYYROLL_LEVELSALARY.SP_CALCULATE2";
            OracleParameter[] param = new OracleParameter[6];
            param[0] = new OracleParameter("V_VERID", pVerID);
            param[1] = new OracleParameter("V_JOBCODE", pJobcode);
            param[2] = new OracleParameter("v_min", pMin);
            param[3] = new OracleParameter("pRate", pRate);

            param[4] = new OracleParameter("pUser", User);
            param[5] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

            DataTable dt = DBHelper.getDataTable_SP(spName, param);
            return dt;
        }
        #endregion
        #region GridSource
        public static DataTable LoadGridSource()
        {
            string query = "PKPAYYROLL_LEVELSALARY.sp_Category_Qry";
            OracleParameter[] parameters = new OracleParameter[1];
            parameters[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP(query, parameters);
        }
        #endregion

        public bool SaveData(DataTable table)
        {
            bool success = false;
            string errorStr = "Successfull";
            ConnectionHelper cnnHelper = new ConnectionHelper();
            using (OracleConnection connection = cnnHelper.Connect())
            {

                OracleTransaction oracleTran = connection.BeginTransaction();
                OracleCommand command = new OracleCommand("PKPAYYROLL_LEVELSALARY.sp_LevelSalary_InsertDataTable", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.UpdatedRowSource = UpdateRowSource.None;
                command.Transaction = oracleTran;
                command.Parameters.Add("pVerID", OracleType.Char, 5, "Version");
                command.Parameters.Add("pJobCode", OracleType.VarChar, 4, "JobCode");
                command.Parameters.Add("pStepno", OracleType.VarChar, 6, "StepNo");
                command.Parameters.Add("pStepLevel", OracleType.VarChar, 1, "StepLevel");
                command.Parameters.Add("pSalary", OracleType.VarChar, 10, "Salary");
                command.Parameters.Add("pUID", OracleType.VarChar, 10, "UID");

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
    }
}