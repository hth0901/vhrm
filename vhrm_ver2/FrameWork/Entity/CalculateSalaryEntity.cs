using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class CalculateSalaryEntity
    {
    }
    public class EmpEntity
    {
        public String FULLNAME { get; set; }
        public string EMPID { get; set; }
        public string Department { get; set; }
        public string SYS_EMPID { get; set; }
        public string OldEmpid { get; set; }
        public string type { get; set; }//data :S,D;
        public string Duty { get; set; }
        public string TEAM { get; set; }
        public string SECTION { get; set; }
        public string JobField { get; set; }
        public EmpEntity(OracleDataReader reader)
		{
			LoadFromReader(reader);
		}
        public EmpEntity()
        {
            
        }
        //This method is used to populate the members of this object from a SqlDataReader
        public void LoadFromReader(OracleDataReader reader)
		{
			try
			{

                EMPID =reader.GetOracleString(reader.GetOrdinal("EMPID")).ToString();
                OldEmpid = reader.GetOracleString(reader.GetOrdinal("EMPIDOLD")).ToString();
			    OldEmpid = OldEmpid == "Null" ? "" : OldEmpid;
			    SYS_EMPID =reader.GetOracleString( reader.GetOrdinal("SYS_EMPID")).ToString();
                Department = reader.GetOracleString(reader.GetOrdinal("DEPARTMENT")).ToString();
                TEAM = reader.GetOracleString(reader.GetOrdinal("TEAM")).ToString();
                SECTION = reader.GetOracleString(reader.GetOrdinal("SECTION")).ToString(); 
                FULLNAME = reader.GetOracleString(reader.GetOrdinal("FULLNAME")).ToString();
               
                //EmpEntity.JobField = table.Rows[i]["JobField"].ToString();
                Duty = reader.GetOracleString(reader.GetOrdinal("Duty")).ToString();
			}
			catch(Exception ex)
			{
				throw new Exception("Failed to load part from reader", ex);
			}
		}

    }
}