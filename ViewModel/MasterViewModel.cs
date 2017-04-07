using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
namespace ViewModel
{
    public class MasterViewModel
    {
        public List<DocumentType> DocumentTypes { get; set; }
        public List<EmployeeStatus> EmployeeStatus { get; set; }
        public List<Designation> Designations { get; set; }
        public List<EmployeeStatu> EmployeeStatuses { get; set; }
        public List<int> Years { get; set; }
    }

    public class PagedQueryable
    {
        public int TotalRows { get; set; }
        public IQueryable data { get; set; }


    }
}
