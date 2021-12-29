using DMSClassLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSClassLibrary.Interfaces
{
    public interface IAPIHandler
    {
        dms_api_key GetApi(string api);
    }
}
