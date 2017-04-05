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
        public ActionResult Index()
        {
            MasterViewModel mvm = new MasterViewModel();
            MonthService mService = new MonthService();
            mvm.Years = mService.Get().Select(s => s.Year).Distinct().ToList();
            return View(mvm);
        }
    }
}