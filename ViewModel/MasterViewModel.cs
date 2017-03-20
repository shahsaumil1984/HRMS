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
        
    }

    public class PagedQueryable
    {
        public int TotalRows { get; set; }
        public IQueryable data { get; set; }


    }
}
