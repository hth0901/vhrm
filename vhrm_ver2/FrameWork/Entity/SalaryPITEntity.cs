using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class SalaryPITEntity
    {
       public int Pit_id {get ; set; }
       public string Ver_id {get; set; }
       public double Pit_from { get; set; }
       public double Pit_to { get; set; }
       public float Pit_rate { get; set; }
       public float Amt { get; set; }
       public string Create_UID { get; set; }
       public string Update_UID { get; set; }
    }
}