using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSClassLibrary.Entities
{
    public class cd_provinces
    {
        [Required, Key]
        public int id { get; set; }
        public string province  { get; set; }
    }
}
