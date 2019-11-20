using System.Data;
using System.Data.OracleClient;
using System.Data.SqlClient;

namespace vhrm.FrameWork.DataAccess
{
    public class OpmGroupAccess
    {
        public DataSet LoadData(string langId, string empId)
        {
            new DataSet();
            OracleParameter[] param = new OracleParameter[3];
            param[0] = new OracleParameter("LangID", langId);
            param[1] = new OracleParameter("EmpID", empId);
            param[2] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataSet_SP("PKOPM_GROUP.sp_ListGroup_Qry", param);
        }

        public DataTable SaveData(string workingTag, string groupCd, string groupNm, bool IsActive, string Dictionary, string LangID, string EmpID)
        {
            OracleParameter[] param = new OracleParameter[8];
            param[0] = new OracleParameter("pWorkingTag",workingTag);
            param[1] = new OracleParameter("pGroupCd",groupCd);
            param[2] = new OracleParameter("pGroupNm",groupNm);
            param[3] = new OracleParameter("pIsActive",IsActive);
            param[4] = new OracleParameter("pDictionaryID",Dictionary);
            param[5] = new OracleParameter("pLangID", LangID);
            param[6] = new OracleParameter("pEmpID", EmpID);
            param[7] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            return DBHelper.getDataTable_SP("PKOPM_GROUP.sp_Group_Save", param);
        }
        public static bool InsertMultiGroupDataToTeam(DataTable dataTable)
        {
            var connectionHelper = new ConnectionHelper();
            using (var connection = connectionHelper.Connect())
            {
                OracleTransaction sqlTransaction = connection.BeginTransaction();
                OracleCommand command = new OracleCommand("PKOPM_GROUP.SP_OPM_GROUP_DATA_INSERT", connection);

                command.CommandType = CommandType.StoredProcedure;
                command.UpdatedRowSource = UpdateRowSource.None;
                command.Transaction = sqlTransaction;

                command.Parameters.Add("pUserID", OracleType.NVarChar, 20, "USER_ID");
                command.Parameters.Add("pGroupID", OracleType.NVarChar, 20, "GROUP_ID");
                command.Parameters.Add("pCreateUID", OracleType.NVarChar, 20, "CREATE_UID");

                OracleDataAdapter dataAdapter = new OracleDataAdapter { InsertCommand = command, UpdateBatchSize = 2 };
                bool message = false;
                try
                {
                    int recordsInserted = dataAdapter.Update(dataTable);
                    message = recordsInserted != 0;
                    sqlTransaction.Commit();
                }
                catch (SqlException exception)
                {
                    sqlTransaction.Rollback();
                    //message = exception.Message;
                }
                finally
                {
                    sqlTransaction.Dispose();
                    connection.Close();
                }
                return message;
            }
        }
    }
}