using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSClassLibrary.Entities
{
    public class dms_api_key
    {
        [Required, Key]
        public Guid id { get; set; }

        [Required]
        public string consumer { get; set; }
    }
}
