using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HRMS
{
    public class HomeController : BaseController
    {
        // GET: Home
        [Authorize(Roles= "Admin,Accountant,Employee")]
        public ActionResult Index()
        {
            return View();
        }
    }
}