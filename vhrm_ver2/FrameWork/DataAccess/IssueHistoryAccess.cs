using System.Data;
using System.Data.OracleClient;
using vhrm.FrameWork.Utility;
using vhrm.FrameWork.Entity;

namespace vhrm.FrameWork.DataAccess
{
    public class IssueHistoryAccess
    {
        /// <summary>
        /// Query IssueHistory
        /// </summary>
        /// <param name="WorkingTag">A : Query All by CustomerID | C : Query by Issue History ID </param>
        /// <param name="CustomerId"></param>
        /// <param name="ID">IssueHistory ID</param>
        /// <returns></returns>
        public static DataTable LoadIssueHistory(string WorkingTag, string CustomerId, int ID)
        {
            string spName = "sp_IssueHistory_Qry";
            OracleParameter[] parameters = new OracleParameter[3];
            parameters[0] = new OracleParameter("@pWorkingTag", WorkingTag);
            parameters[1] = new OracleParameter("@pCustomerID", CustomerId);
            parameters[2] = new OracleParameter("@pID", ID);
            return DBHelper.getDataTable_SP(spName, parameters);
        }

        public static DataTable SaveIssueHistory(string workingTag,IssueHistoryEntity entity, string loginId)
        {
            OracleParameter[] parameters = new OracleParameter[8];
            parameters[0] = new OracleParameter("@pWorkingTag", workingTag);
            parameters[1] = new OracleParameter("@pID", entity.ID);
            parameters[2] = new OracleParameter("@pCustomerID", entity.CustomerID);
            parameters[3] = new OracleParameter("@pIssueDate", entity.IssueDate);
            parameters[4] = new OracleParameter("@pIssueType", entity.IssueType);
            parameters[5] = new OracleParameter("@pTitle", entity.Title);
            parameters[6] = new OracleParameter("@pContents", entity.Contents);
            parameters[7] = new OracleParameter("@pLoginID", loginId);
            return DBHelper.getDataTable_SP("sp_IssueHistory_Save", parameters);
        }

    }
}