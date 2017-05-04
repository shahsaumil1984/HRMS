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
            ViewBag.Name = objEmployee.FullName.ToString().Trim();
            ViewBag.EmployeeCode = objEmployee.EmployeeCode.ToString().Trim();
            ViewBag.Pan = objEmployee.PAN.ToString().Trim();
            
            ViewBag.AddressLine1 = objEmployee.AddressLine1.ToString().Trim();
            ViewBag.AddressLine2 = objEmployee.AddressLine2.ToString().Trim();
            ViewBag.AddressLine3 = objEmployee.AddressLine3.ToString().Trim();
            ViewBag.AddressCity = objEmployee.AddressCity.ToString().Trim();
            ViewBag.AddressState = objEmployee.AddressState.ToString().Trim();
            ViewBag.AddressZip = objEmployee.AddressZip.ToString().Trim();
            ViewBag.AddressCountry = objEmployee.AddressCountry.ToString().Trim();

            ViewBag.MobileNumber = objEmployee.Phone.ToString().Trim();

            MonthService mService = new MonthService();
            MasterViewModel mvm = new MasterViewModel();
            mvm.Years = mService.Get().Select(s => s.Year).Distinct().ToList();

            return View(mvm);   
        }
    }
}