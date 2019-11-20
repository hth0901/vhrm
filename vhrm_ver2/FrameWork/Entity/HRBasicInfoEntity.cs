/*
    2013-03-29 by Phuong
 */

using System;

namespace vhrm.FrameWork.Entity
{
    [Serializable]
    public class HRBasicInfoEntity
    {
        public string EMPID { get; set; }         
	    public string NATIONALITY { get; set; }
	    public string NATIVELAND { get; set; }
	    public string RELIGION { get; set; }
	    public string ETHNIC { get; set; }
	    public string EMAIL { get; set; }
	    public string MOBILE { get; set; }
	    public string PROVINCE { get; set; }
	    public string CITY { get; set; }
	    public string DISTRICT { get; set; }
	    public string RESIDENCE { get; set; }
	    public string PERMADD { get; set; }
	    public string CONTADD { get; set; }
	    public string HOMETEL { get; set; }
	    public string FILECODENO { get; set; }
	    public string ACADEMIC { get; set; }
	    public string LANGUAGE { get; set; }
	    public string BIRTHDAY { get; set; }
	    public string BIRTHPLACE { get; set; }
	    public string SINO { get; set; }
	    public string SIPLACE { get; set; }
	    public string SIDATE { get; set; }
	    public string HINO { get; set; }
	    public string HIPLACE { get; set; }
	    public string HIDATE { get; set; }
	    public string LBNO { get; set; }
	    public string LBPLACE { get; set; }
	    public string LBDATE { get; set; }
	    public string FOREIGNCHECK { get; set; }
	    public string QUALIFICATION { get; set; }
	    public string REGISTERID { get; set; }
	    public DateTime REGISTRYDATE  { get; set; }
	    public string CONFIRMCHECK { get; set; }
	    public string CONFIRMID { get; set; }
	    public DateTime CONFIRMDATE { get; set; }
	    public string HOSPITALPLACE { get; set; }
	    public string HOSPITALNAME { get; set; }
	    public string OLDSICHECK { get; set; }
	    public string PITNO { get; set; }
	    public string PITPLACE { get; set; }
        public string PITDATE { get; set; }
  
    }
}