using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KubixAdmin
{
    public class GlobalSettings
    {
        public static int PreviousPageID { set; get; }
        public static int CurrentPageID { set; get; }
        public static Customer CurrentCustomer { set; get; }
        public static Project CurrentProject { set; get; }
    }
}
