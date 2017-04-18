using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
   public class EmployeeStatusHistoryExtend : EmployeeStatusHistory
    {
        public Nullable<System.DateTime> EndDate_New { get; set; }
        public Nullable<System.DateTime> StartDate_New { get; set; }
        public Nullable<int> Status_New { get; set; }
        public string StatusNote_New { get; set; }
        public string CurrentStatus { get; set; }
    }
}
