using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace HRMS.Controllers
{
    public class TaxComputationController : Controller
    {
        // GET: TaxComputation
        [Authorize(Roles = "Accountant")]
        public ActionResult Index(int EmployeeID)
        {
            ViewBag.EmployeeID = EmployeeID;
            EmployeeService service = new Service.EmployeeService();
            Employee objEmployee = service.GetById(EmployeeID);           
            ViewBag.Name = objEmployee.FullName;
            ViewBag.DOJ = objEmployee.DateOfjoining.ToShortDateString();
            ViewBag.EmployeeCode = objEmployee.EmployeeCode;
            MonthService mService = new MonthService();
            MasterViewModel mvm = new MasterViewModel();
            mvm.Years = mService.Get().Select(s => s.Year).Distinct().ToList();
            return View(mvm);
        }
    }
}