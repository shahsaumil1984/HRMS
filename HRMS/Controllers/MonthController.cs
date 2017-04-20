using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ViewModel;
using Service;

namespace HRMS
{
    public class MonthController : Controller
    {
        // GET: Month
        [Authorize(Roles = "Accountant")]
        public ActionResult Index()
        {
            MasterViewModel mvm = new MasterViewModel();
            MonthService mService = new MonthService();
            mvm.Years = mService.Get().Select(s => s.Year).Distinct().ToList();
            ViewBag.Month = DateTime.Now.ToString("MMMM");
            ViewBag.Year = DateTime.Now.Year;
            ViewBag.CurrentDay = DateTime.Now.Day;
            DateTime dtPreviousMonthDate = DateTime.Now.AddMonths(-1);
            ViewBag.PreviousMonth = dtPreviousMonthDate.ToString("MMMM");
            ViewBag.PreviousYear = dtPreviousMonthDate.Year;
            return View(mvm);
        }
    }
}