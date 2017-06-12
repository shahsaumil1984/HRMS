using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS
{
    public class EmployeeSalaryController : BaseController
    {
        // GET: EmployeeSalary
        [Authorize(Roles = "Accountant")]
        public ActionResult Index(int monthID)
        {            
            Service.MonthService service = new Service.MonthService();
            var month = service.Get().Where(m => m.MonthID == monthID).FirstOrDefault();
            ViewBag.Month = Enum.GetName(typeof(Helper.Month), month.Month1) + ", " + month.Year;
            ViewBag.MonthID = monthID;
            ViewBag.CurrentMonthID = service.Get().FirstOrDefault(m => m.Month1 == DateTime.Now.Month && m.Year == DateTime.Now.Year).MonthID;

            ViewBag.Days = DateTime.DaysInMonth(Convert.ToInt32(month.Year), month.Month1);
            return View();
        }
    }
}