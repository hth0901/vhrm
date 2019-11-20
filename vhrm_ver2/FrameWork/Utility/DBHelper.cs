using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Runtime.Serialization;
using System.Data.OracleClient;
/// <summary>
/// Summary description for DBHelper
/// </summary>
public class DBHelper : IDeserializationCallback
{
    #region------ error sql property----
    //ErrorMessage SQL Property
    public static string errorMessageSql = "";

    //ErrorCode SQL Property
    public static int errorCodeSql = 0;
    #endregion

    [NonSerialized]
    private static OracleConnection connect = null;
    private static OracleTransaction trans = null;
    private static OracleCommand cmd = null;


    void IDeserializationCallback.OnDeserialization(object sender)
    {
        ConnectionHelper connHelper = new ConnectionHelper();
        connect = connHelper.Connect();
    }


    //set value para = DB.Null if para=null
    private static void AttachParameters(OracleCommand command, OracleParameter[] commandParameters)
    {
        foreach (OracleParameter p in commandParameters)
        {
            //check for derived output value with no value assigned
            if ((p.Direction == ParameterDirection.InputOutput) && (p.Value == null))
            {
                p.Value = DBNull.Value;
            }
            command.Parameters.Add(p);
        }
    }

    //Update,Insert,Delete with Store Procedure or Text
    public static bool ExecuteNonQuery_SP(string spName, params OracleParameter[] parameters)
    {
        return ExecuteNonQuery(spName, CommandType.StoredProcedure, parameters);
    }
    public static bool ExecuteNonQuery_Text(string strSQLQuery, params OracleParameter[] parameters)
    {
        return ExecuteNonQuery(strSQLQuery, CommandType.Text, parameters);
    }
    public static bool ExecuteNonQuery(string strSQL, CommandType type, params OracleParameter[] parameters)
    {
        bool success = false;
        ConnectionHelper cnnHelper = new ConnectionHelper();
        using (OracleConnection cnn = cnnHelper.Connect())
        {
            trans = cnn.BeginTransaction();
            cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = type;
            cmd.Connection = cnn;
            cmd.Transaction = trans;
            //cmd.CommandTimeout = 0;

            //Add parameters
            if (parameters != null)
            {
                AttachParameters(cmd, parameters);
            }
            try
            {
                int rowEffected = cmd.ExecuteNonQuery();
                trans.Commit();
                success = (rowEffected == 0 ? false : true);
            }
            catch (OracleException sex)
            {
                trans.Rollback();
                throw sex;
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
        return success;
    }

    //Get DataSet with SP or Text
    public static DataSet getDataSet_SP(string spName, params OracleParameter[] parameters)
    {
        return getDataSet(spName, CommandType.StoredProcedure, parameters);
    }
    public static DataSet getDataSet_Text(string strSQLQuery, params OracleParameter[] parameters)
    {
        return getDataSet(strSQLQuery, CommandType.Text, parameters);
    }
    public static DataSet getDataSet(string strSQL, CommandType type, params OracleParameter[] parameters)
    {
        DataSet ds = new DataSet();
        ConnectionHelper cnnHelper = new ConnectionHelper();
        using (OracleConnection cnn = cnnHelper.Connect())
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = type;
            OracleDataAdapter adt = new OracleDataAdapter(cmd);
            cmd.Connection = cnn;
            //cmd.CommandTimeout = 0;
            if (parameters != null)
            {
                AttachParameters(cmd, parameters);
            }
            try
            {
                adt.Fill(ds);
            }
            catch (OracleException sex)
            {
                throw sex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
        return ds;
    }

    //Get DataTable with SP or Text
    public static DataTable getDataTable_SP(string spName, OracleParameter[] parameters)
    {
        return getDataTable(spName, CommandType.StoredProcedure, parameters);
    }
    public static DataTable getDataTable_Text(string strSQLQuery, OracleParameter[] parameters)
    {
        return getDataTable(strSQLQuery, CommandType.Text, parameters);
    }
    public static DataTable getDataTable(string strSQL, CommandType type, OracleParameter[] parameters)
    {
        DataTable table = new DataTable();
        ConnectionHelper cnnHelper = new ConnectionHelper();
        using (OracleConnection cnn = cnnHelper.Connect())
        {
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.CommandText = strSQL;
                cmd.CommandType = type;
                OracleDataAdapter adt = new OracleDataAdapter(cmd);
                cmd.Connection = cnn;
                //cmd.CommandTimeout = 0;

                if (parameters != null)
                {
                    AttachParameters(cmd, parameters);
                }
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adt.Fill(table);
            }
                catch (OracleException sex)
            {
                throw sex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
        return table;
    }

    //Get value of a cell in query result with SP or Text
    public static object ExcecuteScalar_SP(string spName, params OracleParameter[] parameters)
    {
        return ExcecuteScalar(spName, CommandType.StoredProcedure, parameters);
    }
    public static object ExcecuteScalar_Text(string strSQLQuery, params OracleParameter[] parameters)
    {
        return ExcecuteScalar(strSQLQuery, CommandType.Text, parameters);
    }
    public static object ExcecuteScalar(string strSQL, CommandType type, params OracleParameter[] parameters)
    {
        object value;
        ConnectionHelper cnnHelper = new ConnectionHelper();
        using (OracleConnection cnn = cnnHelper.Connect())
        {
            OracleCommand cmd = new OracleCommand();
            cmd.CommandText = strSQL;
            cmd.CommandType = type;
            cmd.Connection = cnn;

            //Add parameters
            if (parameters != null)
            {
                AttachParameters(cmd, parameters);
            }
            try
            {
                value = cmd.ExecuteScalar();
            }
            catch (OracleException sex)
            {
                throw sex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cnn.Close();
            }
        }
        return value;
    }

    /*get DataReader in query result with SP or Text.
        Remember:When using SqlDataReader's object.We should call SqlDataReader.Close() when we does not use it more. 
     */
    public static OracleDataReader getDataReader_SP(string spName, params OracleParameter[] parameters)
    {
        return getDataReader(spName, CommandType.StoredProcedure, parameters);
    }
    public static OracleDataReader getDataReader_Text(string strSQLQuery, params OracleParameter[] parameters)
    {
        return getDataReader(strSQLQuery, CommandType.Text, parameters);
    }
    public static OracleDataReader getDataReader(string strSQL, CommandType type, params OracleParameter[] parameters)
    {

        OracleDataReader reader = null;
        ConnectionHelper cnnHelper = new ConnectionHelper();

        OracleConnection cnn = cnnHelper.Connect();

        OracleCommand cmd = new OracleCommand();
        cmd.CommandText = strSQL;
        cmd.CommandType = type;
        cmd.Connection = cnn;

        //Add parameters
        if (parameters != null)
        {
            AttachParameters(cmd, parameters);
        }
        try
        {
            reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
        }
        catch (OracleException sex)
        {
            throw sex;
        }
        catch (Exception ex)
        {
            throw ex;
        }

        return reader;

    }

    public static String GetName(String sql, params OracleParameter[] parameters)
    {
        String result = null;

        ConnectionHelper cnnHelper = new ConnectionHelper();

        OracleConnection cnn = cnnHelper.Connect();
        OracleCommand cmd = new OracleCommand();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = cnn;

        //Add parameters
        if (parameters != null)
        {
            AttachParameters(cmd, parameters);
        }
        try
        {
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    result = dr[0].ToString();
                }
            }
        }
        catch (OracleException sex)
        {
            throw sex;
        }
        return result;
    }
    public static String Get_SQLTEXT(String sql, params OracleParameter[] parameters)
    {
        String result = null;

        ConnectionHelper cnnHelper = new ConnectionHelper();

        OracleConnection cnn = cnnHelper.Connect();
        OracleCommand cmd = new OracleCommand();
        cmd.CommandText = sql;
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Connection = cnn;

        //Add parameters
        if (parameters != null)
        {
            AttachParameters(cmd, parameters);
        }
        try
        {
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    result = dr[2].ToString();
                }
            }
        }
        catch (OracleException sex)
        {
            throw sex;
        }
        return result;
    }

}


public class ConnectionHelper
{
    public OracleConnection Connect()
    {
        OracleConnection _SqlConnection = new OracleConnection();
        String _MainConnectionString = ConfigurationManager.ConnectionStrings["PKConn"].ToString();
        try
        {

            _SqlConnection = new OracleConnection(_MainConnectionString);
            if (_SqlConnection.State != ConnectionState.Open)
            {
                _SqlConnection.Open();
            }
        }
        catch (OracleException sex)
        {
            //Log here
             throw sex;
        }
        return _SqlConnection;
    }
}