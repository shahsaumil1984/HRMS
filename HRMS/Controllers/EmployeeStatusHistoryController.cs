using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model;
using Service;
using ViewModel;

namespace HRMS.Controllers
{
    public class EmployeeStatusHistoryController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }



        // GET: ManageStatus
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            EmployeeStatusService de = new EmployeeStatusService();

            MasterViewModel obj = new MasterViewModel();
            obj.EmployeeStatus = de.Get().ToList();
            return View(obj);
        }
    }
    public class ManageEmployeeStatus: Controller
    {
        public List<EmployeeStatusHistory> EmployeeStatusHistory { get; set; }
        public List<EmployeeStatu> EmployeeStatuses { get; set; }
        public Employee Employee { get; set; }

    }
}

