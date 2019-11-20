using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.DataAccess
{
    public class LoadFromExcelAccess
    {
        //dinh nghia cau truc bang
        public static DataTable Createtable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("IDSO");
            dt.Columns.Add("CHU");
            dt.Columns.Add("GIA");
            dt.Columns.Add("REMARK");
            return dt;
        }
        public static DataTable Table_T_HR_CM_BIT()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("VER_ID");
            dt.Columns.Add("PIT_FROM");
            dt.Columns.Add("PIT_TO");
            dt.Columns.Add("PIT_RATE");
            dt.Columns.Add("AMT");
            dt.Columns.Add("ISLAST");
            dt.Columns.Add("CREATE_UID");
            dt.Columns.Add("CREATE_DT");
            dt.Columns.Add("UPDATE_UID");
            dt.Columns.Add("UPDATE_DT");
            return dt;
        }
        public static DataTable Table_T_HR_CM_BITExport()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("VER_ID");
            dt.Columns.Add("PIT_FROM");
            dt.Columns.Add("PIT_TO");
            dt.Columns.Add("PIT_RATE");
            dt.Columns.Add("AMT");
            dt.Columns.Add("ISLAST");
            return dt;
        }

        public static DataTable GetTableTemplate()
        {
            string spName = "SP_EXPORT_TEMPLATE";
            OracleParameter[] param = new OracleParameter[1];
            param[0] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };
            DataTable dt = DBHelper.getDataTable_SP(spName, param);

            return dt;
        }
        public static bool SubmitData(DataTable dtcost)
        {
            bool result = false;
            ConnectionHelper cnHelper = new ConnectionHelper();

            using (OracleConnection sqlConnect = cnHelper.Connect())
            {
                OracleTransaction sqlTran = sqlConnect.BeginTransaction();

                OracleCommand command = new OracleCommand("sp_INSERT_HRSALARY_PIT", sqlConnect);
                command.CommandType = CommandType.StoredProcedure;
                command.UpdatedRowSource = UpdateRowSource.None;
                command.Transaction = sqlTran;

                //OracleParameter[] param = new OracleParameter[11];
                //param[0] = new OracleParameter("pWorkingTag", "A");
                //param[1] = new OracleParameter("pPIT_ID", "No.");
                //param[2] = new OracleParameter("pVER_ID", "VER_ID");
                //param[3] = new OracleParameter("pPIT_FROM", "PIT_FROM");
                //param[4] = new OracleParameter("pPIT_TO", "PIT_TO");
                //param[5] = new OracleParameter("pPIT_RATE", "PIT_RATE");
                //param[6] = new OracleParameter("pAMT", "AMT");
                //param[7] = new OracleParameter("pISLAST", "ISLAST");
                //param[8] = new OracleParameter("pCREATE_UID", "CREATE_UID");
                //param[9] = new OracleParameter("pUPDATE_UID", "UPDATE_UID");
                //param[10] = new OracleParameter("T_TABLE", OracleType.Cursor) { Direction = ParameterDirection.Output };

                command.Parameters.Add("pVER_ID", OracleType.VarChar, 20, "VER_ID");
                command.Parameters.Add("pPIT_FROM", OracleType.Number, 20, "PIT_FROM");
                command.Parameters.Add("pPIT_TO", OracleType.Number, 20, "PIT_TO");
                command.Parameters.Add("pPIT_RATE", OracleType.Number, 20, "PIT_RATE");
                command.Parameters.Add("pAMT", OracleType.Number, 20, "AMT");
                command.Parameters.Add("pISLAST", OracleType.Char, 4, "ISLAST");
                command.Parameters.Add("pCREATE_UID", OracleType.NVarChar, 20, "CREATE_UID");
                command.Parameters.Add("pUPDATE_UID", OracleType.NVarChar, 20, "UPDATE_UID");
                //foreach (OracleParameter p in param)
                //{
                //    //check for derived output value with no value assigned
                //    if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
                //    {
                //        p.Value = DBNull.Value;
                //    }
                //    command.Parameters.Add(p);
                //}

                OracleDataAdapter adpt = new OracleDataAdapter();
                adpt.InsertCommand = command;
                // Specify the number of records to be Inserted/Updated in one go. Default is 1.
                adpt.UpdateBatchSize = 2;
                try
                {
                    DataTable Temp = new DataTable();
                    Temp = Table_T_HR_CM_BIT();

                    foreach (DataRow dataRow in dtcost.Rows)
                    {
                        DataRow dr = Temp.NewRow();
                        Temp.Rows.Add(dr);

                        dr["VER_ID"] = dataRow["VER_ID"];
                        dr["PIT_FROM"] = dataRow["PIT_FROM"];
                        dr["PIT_TO"] = dataRow["PIT_TO"];
                        dr["PIT_RATE"] = dataRow["PIT_RATE"];
                        dr["AMT"] = dataRow["AMT"];
                        dr["ISLAST"] = dataRow["ISLAST"];
                        dr["CREATE_UID"] = dataRow["CREATE_UID"];
                        dr["UPDATE_UID"] = dataRow["UPDATE_UID"];
                    }

                    int recordsInserted = adpt.Update(Temp);
                    result = (recordsInserted != 0);
                    sqlTran.Commit();

                }
                catch (Exception ex)
                {
                    sqlTran.Rollback();
                    throw ex;
                }
                finally
                {
                    sqlConnect.Close();
                }


            }
            return result;
        }
    }
}