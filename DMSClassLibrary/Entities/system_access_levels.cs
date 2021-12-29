using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSClassLibrary.Entities
{
    public class system_access_levels
    {
        [Required, Key]
        public int id { get; set; }
        public string access_level { get; set; }
    }
}
