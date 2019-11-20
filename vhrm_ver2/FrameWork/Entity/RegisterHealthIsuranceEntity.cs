using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class RegisterHealthIsuranceEntity
    {
        public int PAutoID { get; set; }
        public string PPlaceName	{ get; set; }
        public  string PPlaceCode	{ get; set; }	
        public  string PPlaceCity	{ get; set; }
        public  string PAddress	{ get; set; }
        public string  PRemark	{ get; set; }
        public string PCreateUID { get; set; }
        public string PPLACEKIND { get; set; }	
    }
}