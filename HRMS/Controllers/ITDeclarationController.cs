using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;

namespace HRMS
{
    public class ITDeclarationController : BaseController
    {
        // GET: TaxComputation
        [Authorize(Roles = "Accountant")]
        public ActionResult Index(int EmployeeID)
        {

            ViewBag.EmployeeID = EmployeeID;
            Service.EmployeeService service = new Service.EmployeeService();
            Employee objEmployee = service.GetById(EmployeeID);
            ViewBag.Name = objEmployee != null && objEmployee.FullName != null ? objEmployee.FullName.ToString().Trim() : string.Empty;
            ViewBag.EmployeeCode = objEmployee != null && objEmployee.EmployeeCode != null ? objEmployee.EmployeeCode.ToString().Trim() : string.Empty;
            ViewBag.Pan = objEmployee != null && objEmployee.PAN != null ? objEmployee.PAN.ToString().Trim() : string.Empty;

            ViewBag.AddressLine1 = objEmployee != null && objEmployee.AddressLine1 != null ? objEmployee.AddressLine1.ToString().Trim() : string.Empty;
            ViewBag.AddressLine2 = objEmployee != null && objEmployee.AddressLine2 != null ? objEmployee.AddressLine2.ToString().Trim() : string.Empty;
            ViewBag.AddressLine3 = objEmployee != null && objEmployee.AddressLine3 != null ? objEmployee.AddressLine3.ToString().Trim() : string.Empty;
            ViewBag.AddressCity = objEmployee != null && objEmployee.AddressCity != null ? objEmployee.AddressCity.ToString().Trim() : string.Empty;
            ViewBag.AddressState = objEmployee != null && objEmployee.AddressState != null ? objEmployee.AddressState.ToString().Trim() : string.Empty;
            ViewBag.AddressZip = objEmployee != null && objEmployee.AddressZip != null ? objEmployee.AddressZip.ToString().Trim() : string.Empty;
            ViewBag.AddressCountry = objEmployee != null && objEmployee.AddressCountry != null ? objEmployee.AddressCountry.ToString().Trim() : string.Empty;

            ViewBag.MobileNumber = objEmployee.Phone != null ? objEmployee.Phone.ToString().Trim() : string.Empty;

            MonthService mService = new MonthService();
            MasterViewModel mvm = new MasterViewModel();
            mvm.Years = mService.Get().Select(s => s.Year).Distinct().ToList();

            return View(mvm);
        }
    }
}