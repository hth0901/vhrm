using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class EmployeeMaster
    {
        public string SYS_EMPID { get; set; }
        [Display(Name = "EMP ID")]
        public string EMPID { get; set; }        
        [Required(ErrorMessage = "Please enter employee name.")]
        [Display(Name = "Name")]
        public string EMPNAME { get; set; }
        public string COMPCODE { get; set; }        
        [Display(Name = "Corporation")]
        public string DISPLAYDEPTCODE { get; set; }
        [Required(ErrorMessage = "Please enter department.")]
        public string DEPTCODE { get; set; }
        public string FUNCDEPT { get; set; }
        public string JOBCODE { get; set; }
        public string JOBFIELD { get; set; }
        public string DUTY { get; set; }
        [Display(Name = "Date of Birth")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "dd-MM-yyyy", ApplyFormatInEditMode = true)]
        public DateTime? BIRTHDATE { get; set; }
        public string BIRTHPLACE { get; set; }
        [Display(Name = "Gender")]
        public string GENDER { get; set; }
        public string STATUS { get; set; }
        public string EMAIL { get; set; }
        public string PHONE { get; set; }
        [Display(Name = "Nationality")]
        public string NATIONALITY { get; set; }
        //[Required(ErrorMessage = "Please enter Joined Date.")]
        [Display(Name = "Joined Date")]    
        [Required]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "dd-MM-yyyy", ApplyFormatInEditMode = true)]
        public DateTime DATEJOIN { get; set; }
        [Display(Name = "EMP ID CARD No.")]
        //[RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string IDENTITYCARD { get; set; }
        public string IDISSUEDPLACE { get; set; }
        public string IDISSUEDDATE { get; set; }
        [Display(Name = "Academic Level")]
        public string ACADEMIC { get; set; }
        public string DATERESIGNED { get; set; }
        public string FINGERPRINT { get; set; }
        public string FINGERINDEX { get; set; }
        public string IMAGE { get; set; }        
        [Display(Name = "Position")]
        public string POSITION { get; set; }
        [Display(Name = "Skill")]
        public string SKILL { get; set; }
        public string SYS_EMPIDOLD { get; set; }
        public string CREATE_UID { get; set; }
        public string CREATE_DT { get; set; }
        public string UPDATE_UID { get; set; }
        public string UPDATE_DT { get; set; }

        public string GEOGRAPHICALORG { get; set; }
        public string GEODIRECTREPORT { get; set; }
        public string FUNCTIONALORG { get; set; }
        public string FUNCDIRECTREPORT { get; set; }

        public string GEOEMPIDREPORT { get; set; }
        
        public string DEPTNAME { get; set; }
        public string FUNCNAME { get; set; }
        public string FUNEMPIDREPORT { get; set; }

        public string DISPLAYGEOGRAPHICALORG { get; set; }
        public string DISPLAYGEODIRECTREPORT { get; set; }
        public string DISPLAYFUNCTIONALORG { get; set; }
        public string DISPLAYFUNCDIRECTREPORT { get; set; }

        public string DISPLAYGEODIRECTREPORTNAME { get; set; }
        public string DISPLAYFUNCDIRECTREPORTNAME { get; set; }

    }
}