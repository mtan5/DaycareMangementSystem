using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSClassLibrary.Entities
{
    public class system_accounts
    {
        [Required, Key]
        public int id { get; set; }        
        public string username { get; set; }
        public string password { get; set; }
        public int daycare_id { get; set; }
        public int access_level_id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public DateTime date_created { get; set; }
        public bool status { get; set; }
    }
}
