using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSClassLibrary.Entities
{
    public  class daycares
    {
        [Required, Key]
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public int province_id { get; set; }
        public string postal_code { get; set; }
        public string owner { get; set; }
        public string primary_email { get; set; }
        public string primary_phone { get; set; }
        public string date_started { get; set; }
        public string logo_filename { get; set; }
        public string business_id { get; set; }
        public bool status { get; set; }
    }
}
