using System;
using System.Data;
using System.Data.SqlClient;
using vhrm.Framework.Utility;

namespace vhrm.Framework.DataAccess
{
    public class ProductCostAccess
    {
        public static DataTable CreateProductCost()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductCode");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("MonthApp");
            dt.Columns.Add("Cost");
            dt.Columns.Add("CreateDT");
            dt.Columns.Add("CreateUID");
            dt.Columns.Add("UpdateDT");
            dt.Columns.Add("UpdateUID");
            return dt;
        }
        //create product cost template
        public static DataTable CreateProductCostTemplate()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ProductCode");
            dt.Columns.Add("ProductName");
            dt.Columns.Add("Cost");
            dt.Columns.Add("MonthApp");
            
            return dt;
        }
      
        public static bool Insert_Productcost(string pProductcode, string monthapp, int cost, string createUID, string updateUID )
        {
            SqlParameter[] _sqlParam = new SqlParameter[5];
            _sqlParam[0] = new SqlParameter("@pProductcode", pProductcode);
            _sqlParam[1] = new SqlParameter("@pMonthapp", monthapp);
            _sqlParam[2] = new SqlParameter("@pCost", cost);
            _sqlParam[3] = new SqlParameter("@pCreateUID", createUID);
            _sqlParam[4] = new SqlParameter("@pUpdateUID", updateUID);
            return DBHelper.ExecuteNonQuery_SP("ProductCost_Insert", _sqlParam);
        }
        
        //load product cost input template
        public static DataTable GetProductCostTemplate()
        {
            string sp_name = "sp_LoadProductCost_Template";
           
            return DBHelper.getDataTable_SP(sp_name,null);
        }
        //load product cost in DB
        public static DataTable LoadProductCost(string month)
        {
            string sp_name = "sp_loadProductcost_Month";
            SqlParameter[] _sqlParam = new SqlParameter[1];
            _sqlParam[0] = new SqlParameter("@pmonth", month);
            return DBHelper.getDataTable_SP(sp_name, _sqlParam);
        }
        public static bool SubmitProductCost(DataTable dtcost)
        {
            bool result = false;
            ConnectionHelper cnHelper = new ConnectionHelper();
           
                using (SqlConnection sqlConnect = cnHelper.Connect())
                {
                    SqlTransaction sqlTran = sqlConnect.BeginTransaction();

                    SqlCommand command = new SqlCommand("ProductCost_Insert", sqlConnect);
                    command.CommandType = CommandType.StoredProcedure;
                    command.UpdatedRowSource = UpdateRowSource.None;
                    command.Transaction = sqlTran;

                    command.Parameters.Add("@pProductcode", SqlDbType.VarChar, 30, "ProductCode");
                    command.Parameters.Add("@pMonthapp", SqlDbType.Char, 6, "MonthApp");
                    command.Parameters.Add("@pCost", SqlDbType.Int, 32, "Cost");
                    command.Parameters.Add("@pCreateUID", SqlDbType.VarChar, 30, "CreateUID");
                    command.Parameters.Add("@pUpdateUID", SqlDbType.VarChar, 30, "UpdateUID");

                    SqlDataAdapter adpt = new SqlDataAdapter();
                    adpt.InsertCommand = command;
                    // Specify the number of records to be Inserted/Updated in one go. Default is 1.
                    adpt.UpdateBatchSize = 2;
                    try
                    {
                        DataTable Temp = new DataTable();
                        Temp = CreateProductCost();

                        foreach (DataRow dataRow in dtcost.Rows)
                        {
                            DataRow dr = Temp.NewRow();
                            Temp.Rows.Add(dr);

                            dr["ProductCode"] = dataRow["ProductCode"];
                            dr["ProductName"] = dataRow["ProductName"];
                            dr["MonthApp"] = dataRow["MonthApp"];
                            dr["Cost"] = dataRow["Cost"];
                            dr["CreateUID"] = dataRow["CreateUID"];
                            dr["UpdateUID"] = dataRow["UpdateUID"];
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