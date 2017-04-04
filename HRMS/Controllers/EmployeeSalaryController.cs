using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS
{
    public class EmployeeSalaryController : Controller
    {
        // GET: EmployeeSalary
        public ActionResult Index(int monthID)
        {            
            Service.MonthService service = new Service.MonthService();
            var month = service.Get().Where(m => m.MonthID == monthID).FirstOrDefault();
            ViewBag.Month = month.Month1 + ", " + month.Year;
            ViewBag.MonthID = monthID;
            ViewBag.Days = DateTime.DaysInMonth(Convert.ToInt32(month.Year), MonthToInt(month.Month1) + 1);
            return View();
        }
        public int MonthToInt(string Input)
        {
            return (int)Enum.Parse(typeof(Helper.Month), Input, true);
        }
    }
}