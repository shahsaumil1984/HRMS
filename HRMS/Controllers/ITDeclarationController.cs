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
    public class ITDeclarationController : Controller
    {
        // GET: TaxComputation
        [Authorize(Roles = "Accountant")]
        public ActionResult Index(int EmployeeID)
        {
              
            ViewBag.EmployeeID = EmployeeID;
            Service.EmployeeService service = new Service.EmployeeService();
            Employee objEmployee = service.GetById(EmployeeID);
            ViewBag.Name = objEmployee.FullName;
            ViewBag.EmployeeCode = objEmployee.EmployeeCode;
            ViewBag.Pan = objEmployee.PAN;
            
            ViewBag.AddressLine1 = objEmployee.AddressLine1;
            ViewBag.AddressLine2 = objEmployee.AddressLine2;
            ViewBag.AddressLine3 = objEmployee.AddressLine3;
            ViewBag.AddressCity = objEmployee.AddressCity;
            ViewBag.AddressState = objEmployee.AddressState;
            ViewBag.AddressZip = objEmployee.AddressZip;
            ViewBag.AddressCountry = objEmployee.AddressCountry;

            ViewBag.MobileNumber = objEmployee.Phone;

            MonthService mService = new MonthService();
            MasterViewModel mvm = new MasterViewModel();
            mvm.Years = mService.Get().Select(s => s.Year).Distinct().ToList();

            return View(mvm);   
        }
    }
}