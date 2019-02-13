using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubixAdmin
{
    public class Data
    {
        public string authToken { get; set; }
        public string authStatus { get; set; }
        public object authStatusDescription { get; set; }
    }

    public class ServiceResponse
    {
        public string serviceStatus { get; set; }
        public Data data { get; set; }
    }

}
