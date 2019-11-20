using System;
using System.Data;
using System.Data.OleDb;

namespace vhrm.FrameWork.Utility
{
    public class OleDbHelper
    {
        #region Constructor
        public OleDbHelper(string fileName)
        {
            string ext = System.IO.Path.GetExtension(fileName);
            //dinh dang excel 2007
            if (ext == ".xlsx")
                ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" +
                                   "Data Source=" + fileName + ";" +
                                   "Extended Properties ='Excel 12.0;HDR=YES;'";
            else//dinh dang excel 2003
                ConnectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";" +
                                   "Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";

            
        }
        #endregion

        #region Properties

        public string ConnectionString { get; set; }
        public string FileName { get; set; }
        
        private string errorMessage = "";
        public string ErrorMessage
        {
            get { return errorMessage; }
        }
        private string commandText = "";
        public string CommandText
        {
            get { return commandText; }
            set { commandText = value; }
        }
        
        #endregion

        #region DataTable
        public DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();
            try
            {
                OleDbConnection oleDbConnection;
                using (oleDbConnection = new OleDbConnection(ConnectionString))
                {
                    oleDbConnection.Open();
                    OleDbCommand command = new OleDbCommand
                                {
                                    CommandText = commandText,
                                    Connection = oleDbConnection,
                                    CommandType = CommandType.Text
                                };
                    OleDbDataAdapter oleDbDataAdapter = new OleDbDataAdapter(command);
                    oleDbDataAdapter.Fill(dataTable);
                    oleDbDataAdapter.Dispose();
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Error: " + ex.Message;
            }
            return dataTable;
        }

        public int ExecuteNonQuery()
        {
            errorMessage = "";
            int effectedRecords = 0;
            
            try
            {
                OleDbConnection oleDbConnection;
                using (oleDbConnection = new OleDbConnection(ConnectionString))
                {
                    oleDbConnection.Open();
                    OleDbCommand command = new OleDbCommand
                                {
                                    CommandText = commandText,
                                    Connection = oleDbConnection,
                                    CommandType = CommandType.Text
                                };
                    effectedRecords = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                errorMessage = "Error: " + ex.Message;
            }
            return effectedRecords;
        }

        #endregion

        public string GetExcelSheetName()
        {
            OleDbConnection oleDbConnection;
            try
            {
               using (oleDbConnection = new OleDbConnection(ConnectionString))
                {
                    oleDbConnection.Open();

                    //check table 
                    String tableToDelete = "_xlnm#_FilterDatabase";
                    Boolean tableExists = false;
                    DataTable dataTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    foreach (DataRow dr in dataTable.Rows)
                    {
                        if (dr["TABLE_NAME"].ToString() == tableToDelete)
                        {
                            tableExists = true;
                            break;
                        }
                    }

                    if (tableExists)
                    {
                        using (OleDbCommand cmd = new OleDbCommand(string.Format("DROP TABLE {0}", tableToDelete), oleDbConnection))
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }

                    //get trust table
                    dataTable = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                    if (dataTable == null)
                        return null;

                    return dataTable.Rows[0]["TABLE_NAME"].ToString();
                }
                
            }
            catch (Exception ex)
            {
               return null;
            }
           
        }
    }
}