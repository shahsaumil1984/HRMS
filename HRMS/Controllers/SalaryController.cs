using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS
{
    public class SalaryController : Controller
    {
        // GET: Salary
        public ActionResult Index()
        {
            //ViewBag.EmployeeID = employeeID;
            //ViewBag.MonthID = monthID;

            //Service.EmployeeService empService = new Service.EmployeeService();
            //ViewBag.EmployeeName = empService.Get().Where(m => m.EmployeeID == employeeID).FirstOrDefault().FullName;

            //Service.MonthService monthService = new Service.MonthService();
            //var month = monthService.Get().Where(m => m.MonthID == monthID).FirstOrDefault();
            //ViewBag.Month = month.Month1 + ", " + month.Year;
            //ViewBag.Days = DateTime.DaysInMonth(Convert.ToInt32(month.Year), MonthToInt(month.Month1) + 1);
            return View();
        }

        //public enum Month
        //{
        //    January,
        //    February,
        //    March,
        //    April,
        //    May,
        //    June,
        //    July,
        //    August,
        //    September,
        //    November,
        //    December,
        //}

        //public int MonthToInt(string Input)
        //{
        //    return (int)Enum.Parse(typeof(Month), Input, true);
        //}
    }
}