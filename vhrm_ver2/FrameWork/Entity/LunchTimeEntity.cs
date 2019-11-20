using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vhrm.FrameWork.Entity
{
    public class LunchTimeEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Lunchfrom { get; set; }
        public string Lunchto { get; set; }
        public DateTime Create_dt { get; set; }
        public string Create_uid { get; set; }
        public DateTime Update_dt { get; set; }
        public string Update_uid { get; set; }
    }
}