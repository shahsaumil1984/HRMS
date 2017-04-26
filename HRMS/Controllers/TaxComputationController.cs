using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS.Controllers
{
    public class TaxComputationController : Controller
    {
        // GET: TaxComputation
        [Authorize(Roles = "Accountant")]
        public ActionResult Index(int EmployeeID)
        {
            ViewBag.EmployeeID = EmployeeID;
            Service.EmployeeService service = new Service.EmployeeService();
            Employee objEmployee = service.GetById(EmployeeID);           
            ViewBag.Name = objEmployee.FullName;
            ViewBag.DOJ = objEmployee.DateOfjoining.ToShortDateString();
            ViewBag.EmployeeCode = objEmployee.EmployeeCode;
            return View();
        }
    }
}